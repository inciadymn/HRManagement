using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.DAL.Abstract;
using HRManagement.Model.Entities;
using HRManagement.Model.Enums;
using HRManagement.ViewModel.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Concrete
{
    public class AdminService : IAdminBLL
    {
        IAdminDAL adminDAL;
        public AdminService(IAdminDAL adminDAL)
        {
            this.adminDAL = adminDAL;
        }

        public ResultService<bool> ActivedAdmin(Guid guid)
        {
            throw new NotImplementedException();
        }

        public ResultService<UserRole> CheckAdminForLogin(string email, string password)
        {
            ResultService<UserRole> userRole = new ResultService<UserRole>();
            Admin admin = adminDAL.Get(a => a.Email == email && a.Password == password);
            if (admin == null)
            {
                userRole.AddError("Login Hatası", "Login Başarısız");
                return userRole;
            }
            userRole.Data = admin.UserRole;
            return userRole;
        }
        public ResultService<bool> CheckAdminLogin(string email, string password)
        {
            ResultService<bool> result = new ResultService<bool>();
            Admin admin = adminDAL.Get(a => a.Email == email && a.Password == password);
            if (admin == null)
            {
                result.AddError("Login Hatası", "Login Başarısız");
                return result;
            }
            result.Data = true;
            return result;
        }

        public AdminInfoVM GetAdminInfo(string email)
        {
            Admin admin = adminDAL.Get(a => a.Email == email);
            if (admin != null)
            {
                AdminInfoVM adminInfo = new AdminInfoVM()
                {
                    ID=admin.ID,
                    ImageUrl = admin.ImageUrl,
                    Name = admin.FirstName + " " + admin.LastName,
                    UserRole = admin.UserRole
                };
                return adminInfo;
            }
            return null;
        }

        public ResultService<AdminInfoVM> GetAdmin(string email, string password)
        {
            ResultService<AdminInfoVM> result = new ResultService<AdminInfoVM>();
            Admin admin = adminDAL.Get(a => a.Email == email && a.Password == password);
            if (admin == null)
            {
                result.AddError("Login Hatası", "***Böyle bir kullanıcı bulunamadı");
                return result;
            }
            result.Data = new AdminInfoVM()
            {
                ID = admin.ID,
                Name= admin.FirstName + " " + admin.LastName,
                ImageUrl=admin.ImageUrl,
                UserRole = admin.UserRole
            };
            return result;
        }

        //public bool ChangePassword(UserLoginVM userloginvm, string password)
        //{
        //    if (userloginvm != null || password != null)
        //    {

        //        User passChangeUser = adminDAL.Get(a => a.Email == userloginvm.Email);
        //        passChangeUser.Password = password;
        //        passChangeUser.IsActive = false;
        //        passChangeUser = adminDAL.Update(passChangeUser);

        //        return true;

        //    }
        //    return false;
        //}
    }
}
