using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsManagementApp.Models;

namespace CarsManagementApp.Services.Interfaces
{
    public interface IUserService
    {
        Task <User> GetUser(int id);
        Task <IList<User>> GetUserList();
        Task <User> PostUser(User user);
        Task <bool> PutUser(User user);
        Task <bool> DeleteUser(int id);

    }
}
