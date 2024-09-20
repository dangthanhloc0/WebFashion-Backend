using BACKENDEMO.Dtos.Sessions;

namespace BACKENDEMO.interfaces
{
    public interface ISessions
    {
        string AddItem(ItemProduct itemProduct, List<ItemProduct> _listItem);

        bool RemoveItem(ItemProduct itemProduct, List<ItemProduct> _listItem);


    }
}
