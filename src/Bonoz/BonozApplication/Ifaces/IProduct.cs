namespace BonozApplication.Ifaces
{
    public interface IProduct
    {
        Task<IList<Product>> GetProducts();
        Task<IList<ProductCategory>> GetCategories();
        Task<Product> GetProduct(int id);
        Task<ProductCategory> GetCategory(int id);

        Task<IList<Product>> GetItemsByCategory(int id);

    }
}
