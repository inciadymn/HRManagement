﻿using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.Model.Entities;
using HRManagement.ViewModel.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Abstract
{
    public interface IPackageBLL:IBaseBLL<Package>
    {
        List<PackageVM> GetAllPackages();
        ResultService<bool> AddPackage(PackageVM package);

        ResultService<List<string>> GetPackagesNames();
    }
}
