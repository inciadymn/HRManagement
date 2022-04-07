using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
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
        public UserController(IEmployeeBLL employeeBLL)
        {
            this.employeeBLL = employeeBLL;
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
                    ViewBag.Message = employee.Errors[0].ErrorMessage;
                }
                else
                {
                    HttpContext.Session.SetInt32("ID", employee.Data.Id);
                    HttpContext.Session.SetString("FirstName", employee.Data.FirstName);
                    HttpContext.Session.SetString("LastName", employee.Data.LastName);
                    HttpContext.Session.SetString("Title", employee.Data.Title);
                    HttpContext.Session.SetString("Department", employee.Data.Department);

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
                    //random password üret ve mail olarak gönder 
                    //bu kullanıcı için bu passwordu kaydet db'ye
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
            return View();
        }
    }
}
