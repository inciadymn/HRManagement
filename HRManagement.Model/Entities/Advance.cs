using HRManagement.Core.Entity;
using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Model.Entities
{
    public class Advance : BaseEntity
    {
        public DateTime RequestDate { get; set; }
        public AdvanceType AdvanceType { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public PermitStatus PermitStatus { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
