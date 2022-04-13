using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.Model.Entities;
using HRManagement.ViewModel.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Abstract
{
    public interface ICompanyBLL : IBaseBLL<Company>
    {
        ResultService<List<CompanyVM>> GetAllCompanies();
        ResultService<bool> AddCompany(CompanyVM company);
    }
}
