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
        Task <User> PutUser(/*int id,*/ User user);
        Task<User> DeleteUser(int id);

    }
}
