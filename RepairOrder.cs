using System;

namespace NGUYEN_VU_NHAT_MINH_24810320314_BAI_TAP_4_11
{
    public class RepairOrder
    {
        public string OrderId { get; set; }           // Mã đơn
        public string CustomerName { get; set; }      // Tên khách hàng
        public string PhoneNumber { get; set; }       // Số điện thoại
        public string DeviceType { get; set; }        // Loại thiết bị
        public string IssueDescription { get; set; }  // Mô tả lỗi
        public DateTime ReceiveDate { get; set; }      // Ngày tiếp nhận
        public decimal EstimatedCost { get; set; }     // Chi phí dự kiến
        public string Status { get; set; }            // Mới tiếp nhận, Đang sửa, Chờ linh kiện, Hoàn tất, Đã hủy
        public string ImagePath { get; set; }         // Đường dẫn ảnh thiết bị

        public RepairOrder() { }

        public RepairOrder(string orderId, string customerName, string phoneNumber,
                           string deviceType, string issueDescription, DateTime receiveDate,
                           decimal estimatedCost, string status, string imagePath)
        {
            OrderId = orderId;
            CustomerName = customerName;
            PhoneNumber = phoneNumber;
            DeviceType = deviceType;
            IssueDescription = issueDescription;
            ReceiveDate = receiveDate;
            EstimatedCost = estimatedCost;
            Status = status;
            ImagePath = imagePath;
        }
    }
}