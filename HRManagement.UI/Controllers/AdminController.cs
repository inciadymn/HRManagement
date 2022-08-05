using Microsoft.AspNetCore.Mvc;
using HRManagement.ViewModel.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.BLL.Abstract;

namespace HRManagement.UI.Controllers
{
    public class AdminController : Controller
    {
        ICompanyBLL companyBLL;
        IPackageBLL packageBLL;

        public AdminController(ICompanyBLL companyBLL,IPackageBLL packageBLL)
        {
            this.companyBLL = companyBLL;
            this.packageBLL = packageBLL;
        }

        public IActionResult Index() //admin ana sayfası
        {
            List<PackageVM> packageList = packageBLL.GetAllPackages();
            return View(packageList);
        }

        public IActionResult CompanyList() //tüm şirketler listelenecek
        {
            ResultService<List<CompanyVM>> resultService = companyBLL.GetAllCompanies();
            if (!resultService.HasError)
            {
                return View(resultService.Data);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult CreateCompany() //şirket ekleme sayfası
        {
            ResultService<List<string>> result = packageBLL.GetPackagesNames();
            ViewBag.Packages = result.Data;
            return View();
        }

        [HttpPost]
        public IActionResult CreateCompany(CompanyVM companyVM)  //eklenen şirketi db'ye kaydet
        {
            ResultService<bool> result = companyBLL.AddCompany(companyVM);

            if (result.HasError)
            {
                ViewBag.Message = "Şirket eklenirken hata oluştu";
                return View(companyVM);
            }

            return RedirectToAction(nameof(CompanyList));
        }

        //static List<PackageVM> packageList = new List<PackageVM>(); BU NE LA?
        public IActionResult PackageList() //tüm Paketler listelenecek
        {
            List<PackageVM> packageList = packageBLL.GetAllPackages();
            return View(packageList);
        }

        [HttpGet]
        public IActionResult CreatePackage() //Paket ekleme sayfası
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePackage(PackageVM packageVM)  //eklenen Paketi db'ye kaydet
        {
            if (packageVM != null)
            {

                ResultService<bool> success = packageBLL.AddPackage(packageVM);
                return View(packageVM);
            }
            else
            {
                ResultService<bool> result = new ResultService<bool>();
                result.AddError("Boş Alan", "Bu alan boş bırakılamaz");
                return RedirectToAction(nameof(PackageList));
            }
        }
    }
}
