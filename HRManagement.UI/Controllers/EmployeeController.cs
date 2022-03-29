using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.ViewModel.EmployeeViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace HRManagement.UI.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeBLL employeeBLL;
        IPermissionBLL permissionBLL;
        IWebHostEnvironment env;
        public EmployeeController(IEmployeeBLL employeeBLL, IPermissionBLL permissionBLL, IWebHostEnvironment env)
        {
            this.employeeBLL = employeeBLL;
            this.permissionBLL = permissionBLL;
            this.env = env;
        }

        // GET: EmployeeController
        public ActionResult Index(int id)
        {
            ResultService<SingleEmployeeVM> employee = employeeBLL.GetEmployee(id);

            //Login olmus gibi davran ama bunu normalde Login actionda yazman lazım, yani employee başarılı giriş yaptığında bu session lardaki bilgileri sayfalar arası taşıyoruz
            HttpContext.Session.SetInt32("ID", employee.Data.Id);
            HttpContext.Session.SetString("FirstName", employee.Data.FirstName);
            HttpContext.Session.SetString("LastName", employee.Data.LastName);


            ResultService<List<SummaryPermissionVM>> summaryPermission = permissionBLL.GetSumPermission(id);

            if (!summaryPermission.HasError)
            {
                ViewBag.sumPermision = summaryPermission.Data;
            }
            else
            {
                ViewBag.Message = summaryPermission.Errors[0].ErrorMessage;
            }

            return View(employee.Data);
        }

        [HttpGet]
        public ActionResult CreatePermission(int id)
        {
            ViewBag.Data = id;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePermission(CreateEmployeePermissionVM createEmployeePermissionVM)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;

                if (createEmployeePermissionVM.Report != null)
                {
                    fileName = Path.GetFileName($"{createEmployeePermissionVM.EmployeeID}_" +
                                                $"{createEmployeePermissionVM.StartDate.Day}" +
                                                $"{createEmployeePermissionVM.StartDate.Month}" +
                                                $"{createEmployeePermissionVM.StartDate.Year}" +
                                                $"{Path.GetExtension(createEmployeePermissionVM.Report.FileName)}");

                    string filePath = Path.Combine(env.ContentRootPath, "UploadedFiles/Reports", fileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        createEmployeePermissionVM.Report.CopyTo(fileStream);
                    }
                }
             

                ResultService<CreateEmployeePermissionVM> resultService = permissionBLL.Insert(createEmployeePermissionVM, fileName);
                if (resultService.HasError)
                {
                    ViewBag.Message = "***Bitiş tarihi başlangıç tarihinden sonra olmalıdır.";
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            
            return View(createEmployeePermissionVM);
        }

        //İzinler sayfası
        [HttpGet]
        public ActionResult Permission(int id)
        {
            ResultService<List<EmployeePermissionVM>> permission = permissionBLL.GetAllPermission(id);
            if (!permission.HasError)
            {
                return View(permission.Data);
            }
            else
            {
                ViewBag.Message = permission.Errors[0].ErrorMessage;
                return View();
            }
        }


        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
