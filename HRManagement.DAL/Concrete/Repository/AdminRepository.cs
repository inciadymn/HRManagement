using HRManagement.Core.DataAccess.EntityFramework;
using HRManagement.DAL.Abstract;
using HRManagement.DAL.Concrete.Context;
using HRManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.DAL.Concrete.Repository
{
    class AdminRepository : EFRepositoryBase<Admin, HRManagementDbContext>, IAdminDAL
    {
        public AdminRepository(HRManagementDbContext context) : base(context)
        {

        }
    }
}
