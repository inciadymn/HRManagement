using HRManagement.Core.DataAccess.EntityFramework;
using HRManagement.DAL.Abstract;
using HRManagement.DAL.Concrete.Context;
using HRManagement.Model.Entities;

namespace HRManagement.DAL.Concrete.Repository
{
    class CompanyRepository : EFRepositoryBase<Company, HRManagementDbContext>, ICompanyDAL
    {
        public CompanyRepository(HRManagementDbContext context) : base(context)
        {

        }
    }
}
