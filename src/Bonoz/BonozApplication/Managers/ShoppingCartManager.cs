using BonozDomain.DTO.SalesDTO;

namespace BonozApplication.Managers
{
    public class ShoppingCartManager : BaseDataManager, IShoppingCart
    {
        public ShoppingCartManager(BanazDbContext context) : base(context)
        {
        }

        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await _dbContext.CartItems.AnyAsync(c => c.CartId == cartId &&
                                                                     c.ProductId == productId);

        }
        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {
                var item = await (from product in _dbContext.Products
                                  where product.Id == cartItemToAddDto.ProductId
                                  select new CartItem
                                  {
                                      CartId = cartItemToAddDto.CartId,
                                      ProductId = product.Id,
                                      Quantity = cartItemToAddDto.Quantity
                                  }).SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await _dbContext.CartItems.AddAsync(item);
                    await _dbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }

            return null;

        }

        public async Task<CartItem> DeleteItem(int id)
        {
            var item = FindEntity<CartItem>(id);

            if (item != null)
            {
                _dbContext.CartItems.Remove(item);
                await _dbContext.SaveChangesAsync();
            }

            return item;

        }

        public async Task<CartItem> GetItem(int id)
        {
            return await (from cart in _dbContext.Carts
                          join cartItem in _dbContext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cartItem.Id == id
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Quantity = cartItem.Quantity,
                              CartId = cartItem.CartId
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            return await (from cart in _dbContext.Carts
                          join cartItem in _dbContext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Quantity = cartItem.Quantity,
                              CartId = cartItem.CartId
                          }).ToListAsync();
        }

        public async Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            var item = FindEntity<CartItem>(id);

            if (item != null)
            {
                item.Quantity = cartItemQtyUpdateDto.Quantity;
                await _dbContext.SaveChangesAsync();
                return item;
            }

            return null;
        }
    }
}
