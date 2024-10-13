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
                sizeName = s.size.sizeName,
                quantity = s.Quantity,
            };
        }
    }
}
