using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.User
{
    public class UserOutput
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public bool Status { get; set; }
        public long PhoneNumber { get; set; }
    }
}
