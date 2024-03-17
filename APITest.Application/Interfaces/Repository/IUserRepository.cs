using APITest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<bool> SaveUser(UserMaster user);
        Task<UserMaster> GetUserByUserName(string userName);
        Task<UserMaster> GetUserById(int id);
    }
}
