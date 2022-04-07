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
    }
}
