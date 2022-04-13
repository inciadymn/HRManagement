using HRManagement.Core.Entity;
using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Model.Entities
{
    public class Admin : BaseEntity
    {
        public Admin()
        {
            Companies = new HashSet<Company>();
            IsActive = false;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? ImageUrl { get; set; }
        public UserRole UserRole { get; set; }  
        public bool IsActive { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
