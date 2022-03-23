using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModel.EmployeeViewModels
{
    public class CreateEmployeePermissionVM
    {
        public int EmployeeID { get; set; }
        public DateTime StartDate { get; set; } //izin başlangıcı
        public DateTime FinishDate { get; set; } //izin bitişi
        public string Description { get; set; }
        public PermissionType PermissionType { get; set; }

        
    }
}
