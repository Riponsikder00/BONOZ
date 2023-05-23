namespace BonozApplication.Ifaces
{
    public interface ISales
    {
        #region Category

        Category GetCategory(int id);

        //IList<Petition> GetAllPetitions(int CaseId);

        int CreateCategory(Category category);

        bool UpdateCategory(Category category);

       IList<Category> GetAllCategories();

        bool DeleteCategory(int id);

        #endregion Category
    }
}
