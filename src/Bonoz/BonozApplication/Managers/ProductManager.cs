namespace BonozApplication.Managers
{
    public class ProductManager : BaseDataManager, IProduct
    {

        public ProductManager(BanazDbContext context) : base(context)
        {
        }

        public async Task<IList<ProductCategory>> GetCategories()
        {
            return GetEntityListData<ProductCategory>();
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            return FindEntity<ProductCategory>(id);
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _dbContext.Products
                                .Include(p => p.ProductCategory)
                                .SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IList<Product>> GetProducts()
        {
            var products = await _dbContext.Products
                                     .Include(p => p.ProductCategory).ToListAsync();

            return products;

        }

        public async Task<IList<Product>> GetItemsByCategory(int id)
        {
            var products = await _dbContext.Products
                                     .Include(p => p.ProductCategory)
                                     .Where(p => p.ProductCategoryId == id).ToListAsync();
            return products;
        }
    }
}
