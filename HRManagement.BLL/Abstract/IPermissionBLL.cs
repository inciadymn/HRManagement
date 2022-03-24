using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.Model.Entities;
using HRManagement.ViewModel.EmployeeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Abstract
{
    public  interface IPermissionBLL: IBaseBLL<Permission>
    {
        ResultService<CreateEmployeePermissionVM> Insert(CreateEmployeePermissionVM createEmployeePermissionVM, string fileName);
        ResultService<List<EmployeePermissionVM>> GetAllPermission(int id);
        ResultService<List<SummaryPermissionVM>> GetSumPermission(int id);
    }
}
