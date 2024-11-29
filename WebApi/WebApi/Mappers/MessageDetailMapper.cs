using Libs.Entity;
using WebApi.Model.MessageDetail;

namespace WebApi.Mappers
{
    public static class MessageDetailMapper
    {
        public static MessageDetailDto toMessageDetail(this MessageDetail s)
        {
            return new MessageDetailDto
            {
                UserName = s.messageOfCustomer.UserId,
                Time = s.Time,
                Image = s.messageOfCustomer.Image,
                Message = s.messageOfCustomer.Message,
            };
        }
    }
}
