using BonozApplication.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonozApplication.Ifaces
{
    public interface IUser
    {
        Task<(ExecutionState executionState, User user, string message)> GetUser(int id);
        bool UpdateUser(User user);
    }
}
