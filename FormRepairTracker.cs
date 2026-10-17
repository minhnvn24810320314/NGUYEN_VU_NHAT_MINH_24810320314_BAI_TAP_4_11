using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NGUYEN_VU_NHAT_MINH_24810320314_BAI_TAP_4_11
{
    public partial class FormRepairTracker : Form
    {
        private BindingList<RepairOrder> masterList = new BindingList<RepairOrder>();
        private BindingSource bsOrders = new BindingSource();
        private string selectedImagePath = string.Empty;

        public FormRepairTracker()
        {
            InitializeComponent();
        }

        private void FormRepairTracker_Load(object sender, EventArgs e)
        {
            errorProviderApp.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            InitDropdownData();
            LoadSampleData();

            bsOrders.DataSource = masterList;
            dgvOrders.DataSource = bsOrders;

            UpdateStatusAndTotalCost();
            ClearInputForm();
        }

        private void InitDropdownData()
        {
            // Nạp loại thiết bị
            cboDeviceType.Items.AddRange(new string[] {
                "Laptop", "Điện thoại", "Máy tính bảng", "PC / Desktop", "Màn hình", "Thiết bị âm thanh"
            });
            if (cboDeviceType.Items.Count > 0) cboDeviceType.SelectedIndex = 0;

            // Nạp trạng thái
            string[] statuses = new string[] {
                "Mới tiếp nhận", "Đang sửa", "Chờ linh kiện", "Hoàn tất", "Đã hủy"
            };
            cboStatus.Items.AddRange(statuses);
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;

            // Nạp bộ lọc trạng thái
            cboFilterStatus.Items.Add("Tất cả");
            cboFilterStatus.Items.AddRange(statuses);
            cboFilterStatus.SelectedIndex = 0;
        }

        private void LoadSampleData()
        {
            masterList.Add(new RepairOrder("SC001", "Trần Văn Nam", "0912345678", "Laptop",
                "Hỏng màn hình, bật không lên nguồn", DateTime.Now.AddDays(-2), 1500000m, "Mới tiếp nhận", ""));

            masterList.Add(new RepairOrder("SC002", "Nguyễn Thị Mai", "0987654321", "Điện thoại",
                "Vỡ kính cảm ứng, pin vồng", DateTime.Now.AddDays(-1), 850000m, "Đang sửa", ""));

            masterList.Add(new RepairOrder("SC003", "Phạm Hoàng Long", "0905112233", "PC / Desktop",
                "Lỗi RAM, màn hình xanh BSOD", DateTime.Now.AddDays(-5), 350000m, "Hoàn tất", ""));
        }

        private void UpdateStatusAndTotalCost()
        {
            int count = bsOrders.Count;
            // Tính tổng chi phí dự kiến của các đơn CHƯA HOÀN TẤT (và chưa bị hủy)
            decimal pendingTotalCost = masterList
                .Where(x => x.Status != "Hoàn tất" && x.Status != "Đã hủy")
                .Sum(x => x.EstimatedCost);

            lblStatusCount.Text = $"Hiển thị: {count} đơn | Tổng hệ thống: {masterList.Count} đơn";
            lblPendingCost.Text = $"Tổng chi phí đơn chưa hoàn tất: {pendingTotalCost:N0} VNĐ";
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null && dgvOrders.CurrentRow.DataBoundItem is RepairOrder order)
            {
                txtOrderId.Text = order.OrderId;
                txtOrderId.ReadOnly = true;

                txtCustomerName.Text = order.CustomerName;
                txtPhoneNumber.Text = order.PhoneNumber;
                cboDeviceType.SelectedItem = order.DeviceType;
                txtIssueDescription.Text = order.IssueDescription;
                dtpReceiveDate.Value = order.ReceiveDate;
                txtEstimatedCost.Text = order.EstimatedCost.ToString("G0");
                cboStatus.SelectedItem = order.Status;

                selectedImagePath = order.ImagePath;
                DisplayDeviceImage(selectedImagePath);

                errorProviderApp.Clear();
            }
        }

        private void DisplayDeviceImage(string path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    picDevice.Image = Image.FromFile(path);
                }
                catch
                {
                    picDevice.Image = null;
                }
            }
            else
            {
                picDevice.Image = null;
            }
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Chọn ảnh thiết bị"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                DisplayDeviceImage(selectedImagePath);
            }
        }

        private bool ValidateForm(bool isNew)
        {
            bool isValid = true;
            errorProviderApp.Clear();

            errorProviderApp.SetIconAlignment(txtEstimatedCost, ErrorIconAlignment.MiddleLeft);
            errorProviderApp.SetIconPadding(txtEstimatedCost, 4);

            errorProviderApp.SetIconAlignment(txtIssueDescription, ErrorIconAlignment.MiddleLeft);
            errorProviderApp.SetIconPadding(txtIssueDescription, 4);

            // 1. Kiểm tra Mã đơn
            if (string.IsNullOrWhiteSpace(txtOrderId.Text))
            {
                errorProviderApp.SetError(txtOrderId, "Mã đơn không được để trống!");
                isValid = false;
            }
            else if (isNew && masterList.Any(x => x.OrderId.Equals(txtOrderId.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                errorProviderApp.SetError(txtOrderId, "Mã đơn đã tồn tại!");
                isValid = false;
            }

            // 2. Tên khách hàng
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                errorProviderApp.SetError(txtCustomerName, "Tên khách hàng không được để trống!");
                isValid = false;
            }

            // 3. Số điện thoại
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                errorProviderApp.SetError(txtPhoneNumber, "Số điện thoại không được để trống!");
                isValid = false;
            }

            // 4. Chi phí dự kiến phải là số không âm
            if (!decimal.TryParse(txtEstimatedCost.Text.Trim(), out decimal cost) || cost < 0)
            {
                errorProviderApp.SetError(txtEstimatedCost, "Chi phí dự kiến phải là số không âm!");
                isValid = false;
            }

            // 5. Mô tả lỗi bắt buộc
            if (string.IsNullOrWhiteSpace(txtIssueDescription.Text))
            {
                errorProviderApp.SetError(txtIssueDescription, "Mô tả lỗi bắt buộc phải nhập!");
                isValid = false;
            }

            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm(isNew: true)) return;

            decimal.TryParse(txtEstimatedCost.Text.Trim(), out decimal cost);

            string deviceType = cboDeviceType.SelectedItem != null ? cboDeviceType.SelectedItem.ToString()! : cboDeviceType.Text;
            string status = cboStatus.SelectedItem != null ? cboStatus.SelectedItem.ToString()! : cboStatus.Text;

            RepairOrder order = new RepairOrder(
                txtOrderId.Text.Trim(),
                txtCustomerName.Text.Trim(),
                txtPhoneNumber.Text.Trim(),
                deviceType,
                txtIssueDescription.Text.Trim(),
                dtpReceiveDate.Value,
                cost,
                status,
                selectedImagePath
            );

            masterList.Add(order);
            FilterOrders(null, null);
            MessageBox.Show("Thêm đơn sửa chữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm(isNew: false)) return;

            string id = txtOrderId.Text.Trim();
            RepairOrder order = masterList.FirstOrDefault(x => x.OrderId == id);
            if (order != null)
            {
                decimal.TryParse(txtEstimatedCost.Text.Trim(), out decimal cost);

                string deviceType = cboDeviceType.SelectedItem != null ? cboDeviceType.SelectedItem.ToString()! : cboDeviceType.Text;
                string status = cboStatus.SelectedItem != null ? cboStatus.SelectedItem.ToString()! : cboStatus.Text;

                order.CustomerName = txtCustomerName.Text.Trim();
                order.PhoneNumber = txtPhoneNumber.Text.Trim();
                order.DeviceType = deviceType;
                order.IssueDescription = txtIssueDescription.Text.Trim();
                order.ReceiveDate = dtpReceiveDate.Value;
                order.EstimatedCost = cost;
                order.Status = status;
                order.ImagePath = selectedImagePath;

                bsOrders.ResetBindings(false);
                UpdateStatusAndTotalCost();
                MessageBox.Show("Cập nhật đơn sửa chữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null || !(dgvOrders.CurrentRow.DataBoundItem is RepairOrder order))
            {
                MessageBox.Show("Vui lòng chọn đơn cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa đơn sửa chữa [{order.OrderId}] của [{order.CustomerName}]?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                masterList.Remove(order);
                FilterOrders(null, null);
                MessageBox.Show("Đã xóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputForm();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputForm();
        }

        private void ClearInputForm()
        {
            txtOrderId.ReadOnly = false;
            txtOrderId.Clear();
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            if (cboDeviceType.Items.Count > 0) cboDeviceType.SelectedIndex = 0;
            txtIssueDescription.Clear();
            dtpReceiveDate.Value = DateTime.Now;
            txtEstimatedCost.Text = "0";
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;

            selectedImagePath = string.Empty;
            picDevice.Image = null;

            dgvOrders.ClearSelection();
            errorProviderApp.Clear();
        }

        private void FilterOrders(object? sender, EventArgs? e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string status = cboFilterStatus.SelectedItem != null ? cboFilterStatus.SelectedItem.ToString()! : "Tất cả";

            var filtered = masterList.Where(x =>
                (string.IsNullOrEmpty(keyword) ||
                 x.OrderId.ToLower().Contains(keyword) ||
                 x.CustomerName.ToLower().Contains(keyword) ||
                 x.PhoneNumber.Contains(keyword)) &&
                (status == "Tất cả" || x.Status == status)
            ).ToList();

            bsOrders.DataSource = new BindingList<RepairOrder>(filtered);
            UpdateStatusAndTotalCost();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterStatus.SelectedIndex = 0;
            bsOrders.DataSource = masterList;
            UpdateStatusAndTotalCost();
        }

        private void mnuExportCsv_Click(object sender, EventArgs e)
        {
            if (bsOrders.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV File (*.csv)|*.csv",
                FileName = $"DonSuaChua_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        sw.WriteLine("Mã Đơn,Tên Khách Hàng,Số Điện Thoại,Loại Thiết Bị,Mô Tả Lỗi,Ngày Tiếp Nhận,Chi Phí Dự Kiến,Trạng Thái");

                        foreach (RepairOrder item in bsOrders)
                        {
                            string line = $"\"{item.OrderId}\",\"{item.CustomerName}\",\"{item.PhoneNumber}\",\"{item.DeviceType}\",\"{item.IssueDescription}\",\"{item.ReceiveDate:dd/MM/yyyy}\",\"{item.EstimatedCost:N0}\",\"{item.Status}\"";
                            sw.WriteLine(line);
                        }
                    }

                    MessageBox.Show("Xuất dữ liệu đơn sửa chữa ra CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất file CSV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}