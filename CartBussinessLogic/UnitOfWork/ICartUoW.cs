using System.Collections.Generic;
using CartBusinessLogic.Models;

namespace CartBusinessLogic.UnitOfWork
{
    public interface ICartUoW
    {
        void AddItem(ProductModel newProduct);
        int GetCartId();
        List<CartItemModel> GetCartItems();
        decimal GetTotal();
        void RemoveItem(string cartId, int productId);
        void UpdateQtyItem(string cartId, int productId, int qty);
        int GetNbrItems();
        void EmptyCart();
    }
}
