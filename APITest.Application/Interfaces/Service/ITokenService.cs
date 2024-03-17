using APITest.Application.DTO;
using APITest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Application.Interfaces.Service
{
    public interface ITokenService
    {
        Task<string> GenerateToken(UserMaster user);
    }
}
