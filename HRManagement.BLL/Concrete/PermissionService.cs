using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.DAL.Abstract;
using HRManagement.Model.Entities;
using HRManagement.ViewModel.EmployeeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Concrete
{
    public class PermissionService : IPermissionBLL
    {
        IPermissionDAL permissionRepository;
        public PermissionService(IPermissionDAL permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }
        public ResultService<CreateEmployeePermissionVM> Insert(CreateEmployeePermissionVM createEmployeePermissionVM, string fileName)
        {
            ResultService<CreateEmployeePermissionVM> permissionResult = new ResultService<CreateEmployeePermissionVM>();
            try
            {
                Permission permission = permissionRepository.Add(new Permission
                {
                    EmployeeID = createEmployeePermissionVM.EmployeeID,
                    Description = createEmployeePermissionVM.Description,
                    FinishDate = createEmployeePermissionVM.FinishDate,
                    StartDate = createEmployeePermissionVM.StartDate,
                    PermissionType = createEmployeePermissionVM.PermissionType,
                    ReportUrl = fileName,
                    RequestDate = createEmployeePermissionVM.RequestDate,
                    PermitStatus = Model.Enums.PermitStatus.Onaylanmamis

                });


                if (permission == null)
                {
                    //throw new Exception("ekleme başarılı değil");
                    permissionResult.AddError("Ekleme Hatasi", "ekleme başarılı değil");
                    return permissionResult;
                }
            }
            catch (Exception ex)
            {

                permissionResult.AddError("Exception", ex.Message);
            }
            return permissionResult;
        }

        public ResultService<List<EmployeePermissionVM>> GetAllPermission(int id)
        {
            ResultService<List<EmployeePermissionVM>> resultService = new ResultService<List<EmployeePermissionVM>>();

            try
            {
                List<EmployeePermissionVM> employeePermissions = permissionRepository.GetAll(a => a.EmployeeID == id).OrderByDescending(a => a.RequestDate)
                                                                .Select(permission => new EmployeePermissionVM
                                                                {
                                                                    PermissionID = permission.ID,
                                                                    Description = permission.Description,
                                                                    RequestDate = permission.RequestDate,
                                                                    StartDate = permission.StartDate,
                                                                    FinishDate = permission.FinishDate,
                                                                    PermitStatus = permission.PermitStatus,
                                                                    PermissionType = permission.PermissionType
                                                                }).ToList();

                resultService.Data = employeePermissions;
            }
            catch (Exception ex)
            {
                resultService.AddError("exception", ex.Message);
            }

            return resultService;
        }

        public ResultService<List<SummaryPermissionVM>> GetSumPermission(int id)
        {
            ResultService<List<SummaryPermissionVM>> resultService = new ResultService<List<SummaryPermissionVM>>();

            try
            {
                List<SummaryPermissionVM> sumPermissions = permissionRepository.GetAll(a => a.EmployeeID == id).OrderByDescending(a => a.RequestDate).Take(3)
                                                                .Select(sum => new SummaryPermissionVM
                                                                {
                                                                    PermissionID = sum.ID,
                                                                    RequestDate = sum.RequestDate,
                                                                    PermitStatus = sum.PermitStatus,
                                                                    PermissionType = sum.PermissionType
                                                                }).ToList();

                resultService.Data = sumPermissions;
            }
            catch (Exception ex)
            {
                resultService.AddError("exception", ex.Message);
            }

            return resultService;
        }

    }
}
