using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Application.DTO
{
    public class ResponseDTO
    {
        public int status {  get; set; }
        public string message { get; set; }
        public object Data { get; set; }
    }
}
