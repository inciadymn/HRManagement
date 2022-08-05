﻿using HRManagement.Core.Entity;
using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Model.Entities
{
    public class Employee : BaseEntity
    {
        public Employee()
        {
            Permissions = new HashSet<Permission>();
            Advances = new HashSet<Advance>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime StartDate { get; set; }
        public string Photo { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public double Salary { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public UserRole UserRole { get; set; }

        //public bool IsActive { get; set; }  // Şifre değişikliği için ekleyebiliriz?

        public ICollection<Permission> Permissions { get; set; }
        public ICollection<Advance> Advances { get; set; }
    }
}
