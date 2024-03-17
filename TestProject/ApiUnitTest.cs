using APITest.API.Controllers;
using APITest.Application.DTO;
using APITest.Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestProject
{
    public class ApiUnitTest
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly ILogger<UserController> _logger;
        string token = string.Empty;
        [Fact]
        public void TestLogin()
        {
            AuthRequestDTO userDTO = new AuthRequestDTO()
            {
                UserName = "test",
                Password = "12345678"
            };
            var controller = new UserController(userService,tokenService,_logger);
            var result=controller.Authenticate(userDTO);
            Assert.IsType<Task<IActionResult>>(result);
        }


       
        [Theory]
        [InlineData("test", "12345678")]
        public void TestLoginParameter(string username,string password)
        {
            AuthRequestDTO userDTO = new AuthRequestDTO()
            {
                UserName = username,
                Password = password
            };
            var controller = new UserController(userService, tokenService, _logger);
            var result = controller.Authenticate(userDTO);
            var okResult=Assert.IsType<Task<IActionResult>>(result);
           
        }

    }
}