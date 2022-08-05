using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.Model.Entities;
using HRManagement.ViewModel.EmployeeViewModels;
using HRManagement.ViewModel.UserViewModels;

namespace HRManagement.BLL.Abstract
{
    public interface IEmployeeBLL : IBaseBLL<Employee>
    {
        ResultService<SingleEmployeeVM> GetEmployee(int id);
        double GetEmployeeSalary(int id);
        ResultService<SingleEmployeeVM> GetEmployee(string email, string password);
        ResultService<bool> CheckUserEmail(string email);
        bool MailChangePassword(SingleEmployeeVM singleEmployeeVM, string password);    //User gibi bir yer de tüm kullanıcılar toplanmalı? Admin, Employee, Manager
        bool ChangePassword(UserResetPasswordVM userResetPassword);
    }
}
