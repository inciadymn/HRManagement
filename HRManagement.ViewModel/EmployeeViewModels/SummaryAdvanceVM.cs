using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModel.EmployeeViewModels
{
    public class SummaryAdvanceVM
    {
        public int AdvanceID { get; set; }
        public DateTime RequestDate { get; set; }
        public double Price { get; set; }
        public PermitStatus PermitStatus { get; set; }
        public AdvanceType AdvanceType { get; set; }
    }
}
