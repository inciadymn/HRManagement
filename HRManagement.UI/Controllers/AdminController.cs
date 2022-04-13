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

        public AdminController(ICompanyBLL companyBLL)
        {
            this.companyBLL = companyBLL;
        }

        public IActionResult Index() //admin ana sayfası
        {
            return View();
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
            return View();
        }

        [HttpPost]
        public IActionResult CreateCompany(CompanyVM companyVM)  //eklenen şirketi db'ye kaydet
        {
            return View();
        }


        public IActionResult PackageList() //tüm Paketler listelenecek
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreatePackage() //Paket ekleme sayfası
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePackage(CompanyVM companyVM)  //eklenen Paketi db'ye kaydet
        {
            return View();
        }
    }
}
