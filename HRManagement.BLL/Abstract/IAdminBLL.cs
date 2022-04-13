using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.Model.Entities;
using HRManagement.Model.Enums;
using HRManagement.ViewModel.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Abstract
{
    public interface IAdminBLL : IBaseBLL<Admin>
    {
        ResultService<bool> ActivedAdmin(Guid guid);
        ResultService<UserRole> CheckAdminForLogin(string email, string password);
        ResultService<bool> CheckAdminLogin(string email, string password);
        AdminInfoVM GetAdminInfo(string email);
        ResultService<AdminInfoVM> GetAdmin(string email, string password);
        //bool ChangePassword(UserLoginVM userloginvm, string password);
    }
}
