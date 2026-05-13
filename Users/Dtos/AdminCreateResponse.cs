using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Users.Dtos
{
    public class AdminCreateResponse : UserCreateResponse
    {
        public int Salary {  get; set; }
        public string Password { get; set; }
    }
}
