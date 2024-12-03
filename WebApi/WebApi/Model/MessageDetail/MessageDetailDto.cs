namespace WebApi.Model.MessageDetail
{
    public class MessageDetailDto
    {
        public string UserName { get; set; } // Tên người dùng (nếu có)
        public DateTime Time { get; set; } // Thời gian tạo
        public string ? Image  { get; set; } // Đường dẫn hình ảnh (nếu có)
        public string  Message { get; set; } // Nội dung tin nhắn


    }
}
