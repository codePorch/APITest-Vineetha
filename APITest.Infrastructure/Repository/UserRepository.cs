using APITest.Application.Interfaces.Repository;
using APITest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Infrastructure.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly TestDBContext _context;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(TestDBContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> SaveUser(UserMaster user)
        {
            try
            {
                user.IsActive = true;
                user.CreatedDate = DateTime.Now;
                await _context.UserMasters.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserMaster> GetUserByUserName(string userName)
        {
            try
            {
                
                return await _context.UserMasters.FirstOrDefaultAsync(x=>x.UserName== userName);
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserMaster> GetUserById(int id)
        {
            try
            {

                return await _context.UserMasters.FirstOrDefaultAsync(x => x.Id == id);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
