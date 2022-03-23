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
    class PermissionRepository : EFRepositoryBase<Permission, HRManagementDbContext>, IPermissionDAL
    {
        public PermissionRepository(HRManagementDbContext context) : base(context)
        {

        }
    }
}
