using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModel.AdminViewModels
{
    public class AdminInfoVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public UserRole UserRole { get; set; }
        public string ImageUrl { get; set; }
    }
}
