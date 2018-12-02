using System.Collections.Generic;
using CartBusinessLogic.Models;

namespace CartBusinessLogic.UnitOfWork
{
    public interface ICartUoW
    {
        string AddCart(CartModel newCart);

        int AddItem(CartItemModel newItem);



        List<CartItemModel> GetCartItems();

        void RemoveItem(int itemId);

        void UpdateQtyItem(string cartId, int productId, int qty);
    

        decimal GetTotal();
        int GetNbrItems();
        void EmptyCart();


        void AddItem(ProductModel newProduct);












        
    }
}
