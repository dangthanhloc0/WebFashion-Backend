using Libs.Entity;
using WebApi.Model.SizeDetail;

namespace WebApi.Mappers
{
    public static class SizeMapper
    {
        public static SizeDetailUi toSizeDetailUi(this SizeDetail s)
        {
            return new SizeDetailUi
            {
                sizeId = s.size.Id,
                sizeName = s.size.sizeName,
                quantity = s.Quantity,
            };
        }

        public static SizeDetail toSizeDetail(this SizeDetailUpdate s)
        {
            return new SizeDetail
            {
                sizeId = s.sizeId,
                Quantity = s.quantity,
            };
        }
    }
}
