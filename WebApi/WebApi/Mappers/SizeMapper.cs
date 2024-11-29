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
    }
}
