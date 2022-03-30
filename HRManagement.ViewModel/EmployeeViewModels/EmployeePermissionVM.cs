using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModel.EmployeeViewModels
{
    public class EmployeePermissionVM
    {
        public int PermissionID { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime FinishDate { get; set; }
        public int NumberOfDaysOff { get; set; }
        public PermitStatus PermitStatus { get; set; }
        public PermissionType PermissionType { get; set; }

    }
}
