using Libs.Entity;
using WebApi.Model.MessageDetail;

namespace WebApi.Mappers
{
    public static class MessageDetailMapper
    {
        public static MessageDetailDto toMessageDetail(this MessageOfCustomer s)
        {
            return new MessageDetailDto
            {
                UserName = s.AppUser.UserName,
                Time = s.Time,
                Image = s.Image,
                Message = s.Message,
            };
        }
    }
}
