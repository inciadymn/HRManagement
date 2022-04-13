using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.BLL.Concrete.SendMailServiceBLL;
using HRManagement.ViewModel.AdminViewModels;
using HRManagement.ViewModel.EmployeeViewModels;
using HRManagement.ViewModel.UserViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HRManagement.UI.Controllers
{
    public class UserController : Controller
    {
        IEmployeeBLL employeeBLL;
        IAdminBLL adminBLL;
        public UserController(IEmployeeBLL employeeBLL, IAdminBLL adminBLL)
        {
            this.employeeBLL = employeeBLL;
            this.adminBLL = adminBLL;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginVM user)
        {
            if (ModelState.IsValid)
            {
                ResultService<SingleEmployeeVM> employee = employeeBLL.GetEmployee(user.Email, user.Password);
                if (employee.HasError)
                {
                    ResultService<AdminInfoVM> admin = adminBLL.GetAdmin(user.Email, user.Password);
                    if (admin.HasError)
                    {
                        ViewBag.Message = employee.Errors[0].ErrorMessage;

                        //manager geldiğinde altaki satırlar dahil edilecek
                        //ResultService<CompanyManagerVM> companyManager = companyManagerBLL.GetCompanyManager(user.Email, user.Password);
                        //if (companyManager.HasError)
                        //{
                        //    ViewBag.Message = employee.Errors[0].ErrorMessage;
                        //}
                        //else
                        //{
                        //    return RedirectToAction(nameof(Index), "CompanyManager", new { id = companyManager.Data.Id });
                        //    //CompanyManager için session ları yaz
                        //}
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("ID", admin.Data.ID);
                        HttpContext.Session.SetString("Name", admin.Data.Name);
                        HttpContext.Session.SetString("UserRole", admin.Data.UserRole.ToString());

                        return RedirectToAction(nameof(Index), "Admin", new { id = admin.Data.ID });
                    }
                }
                else
                {
                    HttpContext.Session.SetInt32("ID", employee.Data.Id);
                    HttpContext.Session.SetString("FirstName", employee.Data.FirstName);
                    HttpContext.Session.SetString("LastName", employee.Data.LastName);
                    HttpContext.Session.SetString("Title", employee.Data.Title);
                    HttpContext.Session.SetString("Department", employee.Data.Department);
                    HttpContext.Session.SetString("UserRole", employee.Data.UserRole.ToString());

                    return RedirectToAction(nameof(Index), "Employee", new { id = employee.Data.Id });
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(string email)
        {
            if (ModelState.IsValid)
            {
                ResultService<bool> result = employeeBLL.CheckUserEmail(email);
                if (result.HasError)
                {
                    ViewBag.Message = result.Errors[0].ErrorMessage;
                }
                else
                {
                    //Guid id = Guid.NewGuid();
                    //string password = id.ToString().Substring(0, 8);
                    //employeeBLL.ChangePassword(userLoginVM, password);
                    SendMailService.SendMail(email);

                    return RedirectToAction(nameof(UpdatePassword), "User", new { email });
                }
            }
            return View();
        }


        [HttpGet]
        public IActionResult UpdatePassword(string email)
        {
            UserResetPasswordVM model = new UserResetPasswordVM();
            model.Email = email;
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdatePassword(string email, string newPassword, string oldPassword)
        {
            //email ve oldPassword un doğruluğunu kontrol et
            //newPassword u db'ye kaydet, artık yeni şifren bu
            return RedirectToAction(nameof(Login), "User");
        }
    }
}
