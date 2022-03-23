using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.ViewModel.EmployeeViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.UI.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeBLL employeeBLL;
        public EmployeeController(IEmployeeBLL employeeBLL)
        {
            this.employeeBLL = employeeBLL;
        }

        // GET: EmployeeController
        public ActionResult Index(int id)
        {
            ResultService<SingleEmployeeVM> employee = employeeBLL.GetEmployee(id);

            //Login olmus gibi davran ama bunu normalde Login actionda yazman lazım, yani employee başarılı giriş yaptığında bu session lardaki bilgileri sayfalar arası taşıyoruz
            HttpContext.Session.SetInt32("ID", employee.Data.Id);
            HttpContext.Session.SetString("FirstName", employee.Data.FirstName);
            HttpContext.Session.SetString("LastName", employee.Data.LastName);

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
            
            return View(createEmployeePermissionVM);
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
