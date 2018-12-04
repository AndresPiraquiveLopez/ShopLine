using System.Collections.Generic;
using CartBusinessLogic.Models;

namespace CartBusinessLogic.UnitOfWork
{
    public interface ICartUoW
    {
        string AddCart(CartModel newCart);

        int AddItem(CartItemModel newItem);

        List<CartItemModel> GetCartItems();

        int UpdateQtyItem(int productId, int qty);

        // ToDo today

        int RemoveItem(CartItemModel item);

        int GetNbrItems();
        decimal GetTotal();
        
        void EmptyCart();


       












        
    }
}
