using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModel.EmployeeViewModels
{
    public class SummaryPermissionVM
    {
        public int PermissionID { get; set; }
        public DateTime RequestDate { get; set; }
        public PermitStatus PermitStatus { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
