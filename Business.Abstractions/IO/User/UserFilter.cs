using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions.IO.User
{
    public class UserFilter
    {
        public List<int>? ListIdStore { get; set; }
        public int? IdUser { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }
        public long? PhoneNumber { get; set; }
        public bool? Status { get; set; }
        public DateTime? DateRegister { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? SortOrder { get; set; }
        public string? SortField { get; set; }
    }
}
