using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.DAL.Abstract;
using HRManagement.Model.Entities;
using HRManagement.ViewModel.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Concrete
{
    public class CompanyService : ICompanyBLL
    {
        ICompanyDAL companyDAL;
        public CompanyService(ICompanyDAL companyDAL)
        {
            this.companyDAL = companyDAL;
        }

        public ResultService<bool> AddCompany(CompanyVM company)
        {
            ResultService<bool> result = new ResultService<bool>();
            try
            {
                if (company.Name != null && company.Address != null && company.TaxId != null)
                {
                    Company addeedPackage = companyDAL.Add(
                        new Company
                        {
                            CompanyName = company.Name,
                            CompanyType = company.CompanyType,
                            Address = company.Address,
                            ImageUrl = company.ImageURL,
                            MailExtension = company.MailExtension,
                            TaxId = company.TaxId,
                            PhoneNumber = company.PhoneNumber,
                            RegisterDate = company.RegisterDate,
                            DatePurchased = company.DatePurchased
                        });
                    result.Data = true;
                    return result;
                }
            }
            catch (Exception)
            {
                result.AddError("Boş Alan", "Bu alan boş bırakılamaz");
            }
            return result;
        }

        public ResultService<List<CompanyVM>> GetAllCompanies()
        {
            ResultService<List<CompanyVM>> resultService = new ResultService<List<CompanyVM>>();
            try
            {
                List<CompanyVM> companies = companyDAL.GetAll(a => a.CompanyName != null)
                .OrderByDescending(a => a.ID)
                .Select(company => new CompanyVM
                {
                    Id = company.ID,
                    Name = company.CompanyName,
                    Address = company.Address,
                    CompanyType = company.CompanyType,
                    MailExtension = company.MailExtension,
                    PhoneNumber = company.PhoneNumber,
                    RegisterDate = company.RegisterDate,
                    DatePurchased = company.DatePurchased,
                    TaxId = company.TaxId,
                    ImageURL = company.ImageUrl == null ? "değer yok" : company.ImageUrl.ToString(),
                    PackageId = company.PackageId == null ? "Paket yok!" : company.PackageId.ToString()
                }).ToList();
                resultService.Data = companies;
            }
            catch (Exception ex)
            {
                resultService.AddError("exception", ex.Message);
            }

            return resultService;
        }
    }
}
