using APITest.Application.DTO;
using APITest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Application.Interfaces.Service
{
    public interface IUserService
    {
        Task<bool> SaveUser(UserMaster user);
        Task<UserMaster> GetUserByUserName(string userName);
        Task<ApplicationUserDTO> GetUserById(int id);
        Task<bool> CheckPassword(UserMaster applicationUser, string requestPassword);

    }
}
