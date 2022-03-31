using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.DAL.Migrations;
using HRManagement.ViewModel.EmployeeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Abstract
{
    public interface IAdvanceBLL:IBaseBLL<Advance>
    {
         ResultService<CreateEmployeeAdvanceVM> Insert(CreateEmployeeAdvanceVM createEmployeeAdvanceVM, double employeeSalary);
        ResultService<List<EmployeeAdvanceVM>> GetAllAdvance(int id);
        ResultService<List<SummaryAdvanceVM>> GetSumAdvance(int id);
    }
}
