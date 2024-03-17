using APITest.Application.DTO;
using APITest.Application.Enum;
using APITest.Application.Interfaces.Service;
using APITest.Application.Services;
using APITest.Domain;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APITest.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;        
        private readonly ITokenService _tokenService;
        ILogger<UserController> _logger;
        public UserController(IUserService userService,  ITokenService tokenService, ILogger<UserController> logger)
        {
            _userService = userService;          
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost]        
        public async Task<IActionResult> Register(RegistrationRequestDTO request)
        {

            try
            {
                var result = await _userService.GetUserByUserName(request.Username);

                if (result == null)
                {
                    UserMaster user = new UserMaster()
                    {
                        Password = request.Password,
                        Email = request.Email,
                        Role = request.Role.ToString(),
                        UserName = request.Username
                    };
                    var response = await _userService.SaveUser(user);
                    if (response)
                    {
                        return CustomResult("Success", HttpStatusCode.OK);
                    }
                }

                return CustomResult(HttpStatusCode.Conflict.ToString(), HttpStatusCode.Conflict);
            }
            catch (Exception ex)
            {

                _logger.LogError("Register:" + ex.StackTrace);
                return CustomResult("Exception:"+ex.Message, HttpStatusCode.BadRequest);
            }
            
        }


        [HttpPost]        
        public async Task<IActionResult> Authenticate(AuthRequestDTO request)
        {
            try
            {
                var managedUser = await _userService.GetUserByUserName(request.UserName!);
                if (managedUser == null)
                {
                    return CustomResult("UserName Not Found",HttpStatusCode.NotFound);
                }

                var isPasswordValid = await _userService.CheckPassword(managedUser, request.Password!);
                if (!isPasswordValid)
                {
                    
                    return CustomResult("Password Not Match",HttpStatusCode.NotFound);
                }

                var accessToken = await _tokenService.GenerateToken(managedUser);
                var response = new AuthResponseDTO
                {
                    UserName = managedUser.UserName,
                    Token = accessToken
                };
                return CustomResult(response, HttpStatusCode.OK);
                
            }
            catch (Exception ex)
            {

                _logger.LogError("Authenticate:" + ex.StackTrace);
                return CustomResult("Exception:" + ex.Message, HttpStatusCode.BadRequest);
            }
            
        }
    }
}
