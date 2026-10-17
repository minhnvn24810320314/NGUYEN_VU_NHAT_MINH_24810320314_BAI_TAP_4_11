using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NGUYEN_VU_NHAT_MINH_24810320314_BAI_TAP_4_11
{
    partial class FormRepairTracker
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new Container();
            this.errorProviderApp = new ErrorProvider(this.components);

            this.menuStripApp = new MenuStrip();
            this.mnuFile = new ToolStripMenuItem();
            this.mnuExportCsv = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.mnuExit = new ToolStripMenuItem();

            this.grpInput = new GroupBox();
            this.tblInput = new TableLayoutPanel();
            this.lblOrderId = new Label();
            this.txtOrderId = new TextBox();
            this.lblCustomerName = new Label();
            this.txtCustomerName = new TextBox();
            this.lblPhoneNumber = new Label();
            this.txtPhoneNumber = new TextBox();

            this.lblDeviceType = new Label();
            this.cboDeviceType = new ComboBox();
            this.lblReceiveDate = new Label();
            this.dtpReceiveDate = new DateTimePicker();
            this.lblEstimatedCost = new Label();
            this.txtEstimatedCost = new TextBox();

            this.lblStatus = new Label();
            this.cboStatus = new ComboBox();
            this.lblIssueDescription = new Label();
            this.txtIssueDescription = new TextBox();

            this.pnlImage = new Panel();
            this.picDevice = new PictureBox();
            this.btnChooseImage = new Button();

            this.pnlButtons = new FlowLayoutPanel();
            this.btnAdd = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.btnClear = new Button();

            this.grpFilter = new GroupBox();
            this.pnlFilterFlow = new FlowLayoutPanel();
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.lblFilterStatus = new Label();
            this.cboFilterStatus = new ComboBox();
            this.btnResetFilter = new Button();

            this.dgvOrders = new DataGridView();
            this.colOrderId = new DataGridViewTextBoxColumn();
            this.colCustomerName = new DataGridViewTextBoxColumn();
            this.colPhoneNumber = new DataGridViewTextBoxColumn();
            this.colDeviceType = new DataGridViewTextBoxColumn();
            this.colIssueDescription = new DataGridViewTextBoxColumn();
            this.colReceiveDate = new DataGridViewTextBoxColumn();
            this.colEstimatedCost = new DataGridViewTextBoxColumn();
            this.colStatus = new DataGridViewTextBoxColumn();

            this.statusStripApp = new StatusStrip();
            this.lblStatusCount = new ToolStripStatusLabel();
            this.lblPendingCost = new ToolStripStatusLabel();
            this.lblStudentInfo = new ToolStripStatusLabel();

            this.menuStripApp.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.tblInput.SuspendLayout();
            this.pnlImage.SuspendLayout();
            ((ISupportInitialize)(this.picDevice)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlFilterFlow.SuspendLayout();
            ((ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.statusStripApp.SuspendLayout();
            ((ISupportInitialize)(this.errorProviderApp)).BeginInit();
            this.SuspendLayout();

            // MenuStrip
            this.menuStripApp.Items.AddRange(new ToolStripItem[] { this.mnuFile });
            this.menuStripApp.Location = new Point(0, 0);
            this.menuStripApp.Name = "menuStripApp";
            this.menuStripApp.Size = new Size(1200, 24);

            this.mnuFile.DropDownItems.AddRange(new ToolStripItem[] { this.mnuExportCsv, this.toolStripSeparator1, this.mnuExit });
            this.mnuFile.Text = "Hệ thống";

            this.mnuExportCsv.Text = "Xuất danh sách ra CSV";
            this.mnuExportCsv.Click += new EventHandler(this.mnuExportCsv_Click);

            this.mnuExit.Text = "Thoát";
            this.mnuExit.Click += new EventHandler(this.mnuExit_Click);

            // GroupInput
            this.grpInput.Controls.Add(this.tblInput);
            this.grpInput.Controls.Add(this.pnlImage);
            this.grpInput.Controls.Add(this.pnlButtons);
            this.grpInput.Dock = DockStyle.Top;
            this.grpInput.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.grpInput.Location = new Point(10, 34);
            this.grpInput.Name = "grpInput";
            this.grpInput.Padding = new Padding(5);
            this.grpInput.Size = new Size(1180, 235);
            this.grpInput.Text = "Thông Tin Đơn Sửa Chữa";

            // Panel chứa PictureBox
            this.pnlImage.Dock = DockStyle.Right;
            this.pnlImage.Size = new Size(160, 175);
            this.pnlImage.Padding = new Padding(5, 5, 5, 0);
            this.pnlImage.Controls.Add(this.picDevice);
            this.pnlImage.Controls.Add(this.btnChooseImage);

            this.picDevice.Dock = DockStyle.Fill;
            this.picDevice.SizeMode = PictureBoxSizeMode.Zoom;
            this.picDevice.BorderStyle = BorderStyle.FixedSingle;

            this.btnChooseImage.Dock = DockStyle.Bottom;
            this.btnChooseImage.Text = "Chọn ảnh...";
            this.btnChooseImage.Size = new Size(150, 28);
            this.btnChooseImage.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.btnChooseImage.Click += new EventHandler(this.btnChooseImage_Click);

            // TableLayout nhập liệu
            this.tblInput.ColumnCount = 6;
            this.tblInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            this.tblInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.tblInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            this.tblInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.tblInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            this.tblInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));

            this.tblInput.Controls.Add(this.lblOrderId, 0, 0);
            this.tblInput.Controls.Add(this.txtOrderId, 1, 0);
            this.tblInput.Controls.Add(this.lblCustomerName, 2, 0);
            this.tblInput.Controls.Add(this.txtCustomerName, 3, 0);
            this.tblInput.Controls.Add(this.lblPhoneNumber, 4, 0);
            this.tblInput.Controls.Add(this.txtPhoneNumber, 5, 0);

            this.tblInput.Controls.Add(this.lblDeviceType, 0, 1);
            this.tblInput.Controls.Add(this.cboDeviceType, 1, 1);
            this.tblInput.Controls.Add(this.lblReceiveDate, 2, 1);
            this.tblInput.Controls.Add(this.dtpReceiveDate, 3, 1);
            this.tblInput.Controls.Add(this.lblEstimatedCost, 4, 1);
            this.tblInput.Controls.Add(this.txtEstimatedCost, 5, 1);

            this.tblInput.Controls.Add(this.lblStatus, 0, 2);
            this.tblInput.Controls.Add(this.cboStatus, 1, 2);
            this.tblInput.Controls.Add(this.lblIssueDescription, 2, 2);
            this.tblInput.Controls.Add(this.txtIssueDescription, 3, 2);
            this.tblInput.SetColumnSpan(this.txtIssueDescription, 3);

            this.tblInput.Dock = DockStyle.Fill;
            this.tblInput.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.tblInput.RowCount = 3;
            this.tblInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            this.tblInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            this.tblInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));

            this.lblOrderId.Text = "Mã đơn (*):"; this.lblOrderId.AutoSize = true; this.lblOrderId.Anchor = AnchorStyles.Left;
            this.txtOrderId.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.lblCustomerName.Text = "Tên khách (*):"; this.lblCustomerName.AutoSize = true; this.lblCustomerName.Anchor = AnchorStyles.Left;
            this.txtCustomerName.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.lblPhoneNumber.Text = "Số ĐT (*):"; this.lblPhoneNumber.AutoSize = true; this.lblPhoneNumber.Anchor = AnchorStyles.Left;
            this.txtPhoneNumber.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.lblDeviceType.Text = "Thiết bị:"; this.lblDeviceType.AutoSize = true; this.lblDeviceType.Anchor = AnchorStyles.Left;
            this.cboDeviceType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboDeviceType.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.lblReceiveDate.Text = "Ngày nhận:"; this.lblReceiveDate.AutoSize = true; this.lblReceiveDate.Anchor = AnchorStyles.Left;
            this.dtpReceiveDate.Format = DateTimePickerFormat.Short;
            this.dtpReceiveDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.lblEstimatedCost.Text = "Chi phí (*):"; this.lblEstimatedCost.AutoSize = true; this.lblEstimatedCost.Anchor = AnchorStyles.Left;
            this.txtEstimatedCost.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.lblStatus.Text = "Trạng thái:"; this.lblStatus.AutoSize = true; this.lblStatus.Anchor = AnchorStyles.Left;
            this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            this.lblIssueDescription.Text = "Mô tả lỗi (*):"; this.lblIssueDescription.AutoSize = true; this.lblIssueDescription.Anchor = AnchorStyles.Left;
            this.txtIssueDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // Panel chứa nút bấm
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Dock = DockStyle.Bottom;
            this.pnlButtons.FlowDirection = FlowDirection.RightToLeft;
            this.pnlButtons.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.pnlButtons.Size = new Size(1170, 45);

            this.btnAdd.Text = "Thêm đơn"; this.btnAdd.Size = new Size(95, 32);
            this.btnAdd.BackColor = Color.MediumSeaGreen; this.btnAdd.ForeColor = Color.White;
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            this.btnUpdate.Text = "Cập nhật"; this.btnUpdate.Size = new Size(95, 32);
            this.btnUpdate.BackColor = Color.DodgerBlue; this.btnUpdate.ForeColor = Color.White;
            this.btnUpdate.FlatStyle = FlatStyle.Flat;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);

            this.btnDelete.Text = "Xóa đơn"; this.btnDelete.Size = new Size(95, 32);
            this.btnDelete.BackColor = Color.Crimson; this.btnDelete.ForeColor = Color.White;
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            this.btnClear.Text = "Làm mới"; this.btnClear.Size = new Size(95, 32);
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            // GroupFilter (Sử dụng FlowLayoutPanel để dàn hàng tự động)
            this.grpFilter.Controls.Add(this.pnlFilterFlow);
            this.grpFilter.Dock = DockStyle.Top;
            this.grpFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.grpFilter.Location = new Point(10, 269);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new Size(1180, 60);
            this.grpFilter.Text = "Tìm Kiếm Tức Thời && Bộ Lọc";

            this.pnlFilterFlow.Controls.Add(this.lblSearch);
            this.pnlFilterFlow.Controls.Add(this.txtSearch);
            this.pnlFilterFlow.Controls.Add(this.lblFilterStatus);
            this.pnlFilterFlow.Controls.Add(this.cboFilterStatus);
            this.pnlFilterFlow.Controls.Add(this.btnResetFilter);
            this.pnlFilterFlow.Dock = DockStyle.Fill;
            this.pnlFilterFlow.FlowDirection = FlowDirection.LeftToRight;
            this.pnlFilterFlow.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.pnlFilterFlow.Padding = new Padding(5, 5, 0, 0);

            this.lblSearch.Text = "Từ khóa (Mã đơn/Tên/SĐT):";
            this.lblSearch.AutoSize = true;
            this.lblSearch.Margin = new Padding(3, 6, 3, 0);

            this.txtSearch.Size = new Size(220, 23);
            this.txtSearch.Margin = new Padding(3, 3, 25, 0);
            this.txtSearch.TextChanged += new EventHandler(this.FilterOrders);

            this.lblFilterStatus.Text = "Trạng thái:";
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Margin = new Padding(3, 6, 3, 0);

            this.cboFilterStatus.Size = new Size(160, 23);
            this.cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboFilterStatus.Margin = new Padding(3, 3, 25, 0);
            this.cboFilterStatus.SelectedIndexChanged += new EventHandler(this.FilterOrders);

            this.btnResetFilter.Text = "Xóa lọc";
            this.btnResetFilter.Size = new Size(85, 25);
            this.btnResetFilter.Margin = new Padding(3, 1, 3, 0);
            this.btnResetFilter.Click += new EventHandler(this.btnResetFilter_Click);

            // DataGridView
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoGenerateColumns = false;
            this.dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new DataGridViewColumn[] {
                this.colOrderId,
                this.colCustomerName,
                this.colPhoneNumber,
                this.colDeviceType,
                this.colIssueDescription,
                this.colReceiveDate,
                this.colEstimatedCost,
                this.colStatus
            });
            this.dgvOrders.Dock = DockStyle.Fill;
            this.dgvOrders.Location = new Point(10, 329);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new Size(1180, 310);
            this.dgvOrders.SelectionChanged += new EventHandler(this.dgvOrders_SelectionChanged);

            // DataGridView Columns
            this.colOrderId.DataPropertyName = "OrderId"; this.colOrderId.HeaderText = "Mã Đơn";
            this.colCustomerName.DataPropertyName = "CustomerName"; this.colCustomerName.HeaderText = "Tên Khách Hàng";
            this.colPhoneNumber.DataPropertyName = "PhoneNumber"; this.colPhoneNumber.HeaderText = "Số Điện Thoại";
            this.colDeviceType.DataPropertyName = "DeviceType"; this.colDeviceType.HeaderText = "Loại Thiết Bị";
            this.colIssueDescription.DataPropertyName = "IssueDescription"; this.colIssueDescription.HeaderText = "Mô Tả Lỗi";
            this.colReceiveDate.DataPropertyName = "ReceiveDate"; this.colReceiveDate.DefaultCellStyle.Format = "dd/MM/yyyy"; this.colReceiveDate.HeaderText = "Ngày Tiếp Nhận";
            this.colEstimatedCost.DataPropertyName = "EstimatedCost"; this.colEstimatedCost.DefaultCellStyle.Format = "N0"; this.colEstimatedCost.HeaderText = "Chi Phí Dự Kiến";
            this.colStatus.DataPropertyName = "Status"; this.colStatus.HeaderText = "Trạng Thái";

            // StatusStrip
            this.statusStripApp.Items.AddRange(new ToolStripItem[] {
                this.lblStatusCount,
                this.lblPendingCost,
                this.lblStudentInfo
            });
            this.statusStripApp.Location = new Point(10, 639);
            this.statusStripApp.Name = "statusStripApp";
            this.statusStripApp.Size = new Size(1180, 22);

            this.lblStatusCount.Name = "lblStatusCount"; this.lblStatusCount.Size = new Size(260, 17);
            this.lblPendingCost.Name = "lblPendingCost"; this.lblPendingCost.Size = new Size(500, 17);
            this.lblPendingCost.Spring = true; this.lblPendingCost.TextAlign = ContentAlignment.MiddleLeft;
            this.lblStudentInfo.Name = "lblStudentInfo"; this.lblStudentInfo.Size = new Size(350, 17);
            this.lblStudentInfo.Text = "Sinh viên: Nguyễn Vũ Nhật Minh - 24810320314"; this.lblStudentInfo.TextAlign = ContentAlignment.MiddleRight;

            // Form
            this.ClientSize = new Size(1200, 671);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.menuStripApp);
            this.Controls.Add(this.statusStripApp);
            this.MainMenuStrip = this.menuStripApp;
            this.Padding = new Padding(10);
            this.MinimumSize = new Size(1000, 600);
            this.Name = "FormRepairTracker";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Repair Service Tracker - NGUYỄN VŨ NHẬT MINH - D19QTANM1";
            this.Load += new EventHandler(this.FormRepairTracker_Load);

            this.menuStripApp.ResumeLayout(false);
            this.menuStripApp.PerformLayout();
            this.grpInput.ResumeLayout(false);
            this.tblInput.ResumeLayout(false);
            this.tblInput.PerformLayout();
            this.pnlImage.ResumeLayout(false);
            ((ISupportInitialize)(this.picDevice)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.pnlFilterFlow.ResumeLayout(false);
            this.pnlFilterFlow.PerformLayout();
            ((ISupportInitialize)(this.dgvOrders)).EndInit();
            this.statusStripApp.ResumeLayout(false);
            this.statusStripApp.PerformLayout();
            ((ISupportInitialize)(this.errorProviderApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MenuStrip menuStripApp;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuExportCsv;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuExit;

        private GroupBox grpInput;
        private TableLayoutPanel tblInput;
        private Label lblOrderId;
        private TextBox txtOrderId;
        private Label lblCustomerName;
        private TextBox txtCustomerName;
        private Label lblPhoneNumber;
        private TextBox txtPhoneNumber;
        private Label lblDeviceType;
        private ComboBox cboDeviceType;
        private Label lblReceiveDate;
        private DateTimePicker dtpReceiveDate;
        private Label lblEstimatedCost;
        private TextBox txtEstimatedCost;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Label lblIssueDescription;
        private TextBox txtIssueDescription;

        private Panel pnlImage;
        private PictureBox picDevice;
        private Button btnChooseImage;

        private FlowLayoutPanel pnlButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;

        private GroupBox grpFilter;
        private FlowLayoutPanel pnlFilterFlow;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblFilterStatus;
        private ComboBox cboFilterStatus;
        private Button btnResetFilter;

        private DataGridView dgvOrders;
        private DataGridViewTextBoxColumn colOrderId;
        private DataGridViewTextBoxColumn colCustomerName;
        private DataGridViewTextBoxColumn colPhoneNumber;
        private DataGridViewTextBoxColumn colDeviceType;
        private DataGridViewTextBoxColumn colIssueDescription;
        private DataGridViewTextBoxColumn colReceiveDate;
        private DataGridViewTextBoxColumn colEstimatedCost;
        private DataGridViewTextBoxColumn colStatus;

        private StatusStrip statusStripApp;
        private ToolStripStatusLabel lblStatusCount;
        private ToolStripStatusLabel lblPendingCost;
        private ToolStripStatusLabel lblStudentInfo;
        private ErrorProvider errorProviderApp;
    }
}