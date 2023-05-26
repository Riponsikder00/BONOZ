using BonozApplication.Common.Enum;

namespace BonozApplication.Managers;
public class UsersManager : BaseDataManager, IUser
{
    public UsersManager(BanazDbContext dbContext) : base(dbContext) { }
    public async Task<(ExecutionState executionState, User user, string message)> GetUser(int id)
    {
        (ExecutionState executionState, User user, string message) returnResponse;
        try
        {
            if (id == 0)
                return (executionState: ExecutionState.Failure, user: null, message: "Id can not null");

            var userObj = FindEntity<User>(id);
            if (userObj != null)
            {
                return (executionState: ExecutionState.Retrieved, user: userObj, message: "User retrive successfully")
            }
            else return (executionState: ExecutionState.Failure, userObj: null, message: "User do not found");

        }
        catch (Exception ex)
        {
            returnResponse = (executionState: ExecutionState.Failure, userObj: null, message: ex.Message);
        }
        return returnResponse;
    }

    public bool UpdateUser(User user)
    {
        return AddUpdateEntity(user);
    }
}