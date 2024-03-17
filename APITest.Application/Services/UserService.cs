using APITest.Application.DTO;
using APITest.Application.Helper;
using APITest.Application.Interfaces.Repository;
using APITest.Application.Interfaces.Service;

using APITest.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> SaveUser(UserMaster user)
        {
            try
            {
                user.Password = PasswordEncryptHelper.encryptPassword(user.Password);
                return await _userRepository.SaveUser(user);
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
                return await _userRepository.GetUserByUserName(userName);
              

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ApplicationUserDTO> GetUserById(int id)
        {
            try
            {
                var result = await _userRepository.GetUserById(id);
                return _mapper.Map<ApplicationUserDTO>(result);

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> CheckPassword(UserMaster applicationUser, string requestPassword)
        {
            try
            {
                if (applicationUser.Password == PasswordEncryptHelper.encryptPassword(requestPassword))
                    return true;
                else return false;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
