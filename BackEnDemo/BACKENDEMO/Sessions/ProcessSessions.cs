using BACKENDEMO.Data;
using BACKENDEMO.Dtos.Sessions;
using BACKENDEMO.Entity;
using BACKENDEMO.interfaces;
using Microsoft.AspNetCore.Identity;

namespace BACKENDEMO.Sessions
{
    public class ProcessSessions : ISessions
    {
        public string AddItem(ItemProduct itemProduct,List<ItemProduct> _listItem) {
            var result = _listItem.SingleOrDefault(p => p.ProductId == itemProduct.ProductId);
            if (result != null)
            {
                result.Quantity += itemProduct.Quantity;
                return "Update item Successfully";
            } else
            {
                _listItem.Add(itemProduct);
                return "Add item Successfully";
            }
           
        }

        public bool RemoveItem (ItemProduct itemProduct, List<ItemProduct> _listItem) {
            var result =  _listItem.SingleOrDefault(p => p.ProductId == itemProduct.ProductId);
            if(result != null) {
                _listItem.Remove(result);
                return true;
            }    
            return false;   
        }
    }
}
