using System.Net.Http.Json;

namespace BonozApplication.Managers
{
    public class SalesManager : BaseDataManager, ISales
    {
        public SalesManager(BanazDbContext model) : base(model)
        {
        }


        #region Category

        public int CreateCategory(Category category)
        {
            AddUpdateEntity(category);
            return category.Id;
        }

        public bool UpdateCategory(Category category)
        {
            return AddUpdateEntity(category);
        }

        public Category GetCategory(int id)
        {
            return FindEntity<Category>(id);
        }

        //public IList<PetitionListDTO> GetAllPetitionsList(int caseId)
        //{
        //    return GetListData<PetitionListDTO>($"EXEC GetAllPetitions_ByCaseId @caseId={caseId}");
        //}

        public bool DeleteCategory(int id)
        {
            return RemoveEntity<Category>(id);
        }

        public IList<Category> GetAllCategories()
        {
            return GetEntityListData<Category>();
        }

        //private async Task SetUsers(HttpResponseMessage result)
        //{
        //    var respons = await result.Content.ReadFromJsonAsync<List<AppUser>>();
        //    AppUsers = respons;
        //    _navigationManager.NavigateTo("AppUsers");

        //}

        #endregion Category
    }
}
