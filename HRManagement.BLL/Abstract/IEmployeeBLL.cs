using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.Model.Entities;
using HRManagement.ViewModel.EmployeeViewModels;

namespace HRManagement.BLL.Abstract
{
    public interface IEmployeeBLL : IBaseBLL<Employee>
    {
        ResultService<SingleEmployeeVM> GetEmployee(int id);
        double GetEmployeeSalary(int id);
        ResultService<SingleEmployeeVM> GetEmployee(string email, string password);
    }
}
