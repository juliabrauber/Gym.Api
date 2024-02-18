using Entities.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class UserEntity : IAggregateRoot
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public  long PhoneNumber { get; set; }
        public bool Status { get; set; }
        public DateTime DateRegister { get; set; }
        public int Role { get; set; }

        public void SetStatusTrue()
        {
            Status = true;
        }
        public void SetStatusFalse()
        {
            Status = false;
        }
        public void SetNewDateRegister() 
        {
            DateRegister = DateTime.Now;
        }

        public void SetEntityUpdate(UserEntity userEntityMapping)
        {
            Name = !string.IsNullOrEmpty(userEntityMapping.Name) ? userEntityMapping.Name : Name;
            Email = !string.IsNullOrEmpty(userEntityMapping.Email) ? userEntityMapping.Email : Email;
            Password = !string.IsNullOrEmpty(userEntityMapping.Password) ? userEntityMapping.Password : Password;
            PhoneNumber = userEntityMapping.PhoneNumber > 0 ? userEntityMapping.PhoneNumber : PhoneNumber;
            Role = userEntityMapping.Role > 0 ? userEntityMapping.Role : Role;
        }

    }
}
