using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.DAL.Abstract;
using HRManagement.DAL.Migrations;
using HRManagement.ViewModel.EmployeeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Concrete
{
    public class AdvanceService : IAdvanceBLL
    {
        IAdvanceDAL advanceRepository;
        public AdvanceService(IAdvanceDAL advanceRepository)
        {
            this.advanceRepository = advanceRepository;
        }

        public ResultService<CreateEmployeeAdvanceVM> Insert(CreateEmployeeAdvanceVM createEmployeeAdvanceVM)
        {
            ResultService<CreateEmployeeAdvanceVM> advanceResult = new ResultService<CreateEmployeeAdvanceVM>();
            try
            {
                //Salary kontrolü yap !!!
                //if (createEmployeeAdvanceVM.StartDate.Date >= createEmployeeAdvanceVM.FinishDate.Date)
                //{
                //    //throw new Exception("İzin başlangıç ve bitiş tarihi aynı olmamalıdır.");
                //    advanceResult.AddError("Tarih uyumsuzluğu", "İzin başlangıç ve bitiş tarihi aynı olmamalıdır.");
                //    return advanceResult;
                //}

                Advance advance = advanceRepository.Add(new Advance
                {
                    EmployeeID = createEmployeeAdvanceVM.EmployeeID,
                    Description = createEmployeeAdvanceVM.Description,
                    Price = createEmployeeAdvanceVM.Price,
                    AdvanceType = createEmployeeAdvanceVM.AdvanceType,
                    RequestDate = DateTime.Now,
                    PermitStatus = Model.Enums.PermitStatus.Onaylanmamis

                });


                if (advance == null)
                {
                    //throw new Exception("ekleme başarılı değil");
                    advanceResult.AddError("Ekleme Hatasi", "ekleme başarılı değil");
                    return advanceResult;
                }
            }
            catch (Exception ex)
            {

                advanceResult.AddError("Exception", ex.Message);
            }
            return advanceResult;
        }

        public ResultService<List<EmployeeAdvanceVM>> GetAllAdvance(int id)
        {
            ResultService<List<EmployeeAdvanceVM>> resultService = new ResultService<List<EmployeeAdvanceVM>>();

            try
            {
                List<EmployeeAdvanceVM> employeeAdvances = advanceRepository.GetAll(a => a.EmployeeID == id).OrderByDescending(a => a.RequestDate)
                                                                .Select(advance => new EmployeeAdvanceVM
                                                                {
                                                                    AdvanceID = advance.ID,
                                                                    Description = advance.Description,
                                                                    RequestDate = advance.RequestDate,
                                                                    Price = advance.Price,
                                                                    PermitStatus = advance.PermitStatus,
                                                                    AdvanceType = advance.AdvanceType
                                                                }).ToList();

                resultService.Data = employeeAdvances;
            }
            catch (Exception ex)
            {
                resultService.AddError("exception", ex.Message);
            }

            return resultService;
        }

        public ResultService<List<SummaryAdvanceVM>> GetSumAdvance(int id)
        {
            ResultService<List<SummaryAdvanceVM>> resultService = new ResultService<List<SummaryAdvanceVM>>();

            try
            {
                List<SummaryAdvanceVM> sumAdvances = advanceRepository.GetAll(a => a.EmployeeID == id).OrderByDescending(a => a.RequestDate).Take(5)
                                                                .Select(sum => new SummaryAdvanceVM
                                                                {
                                                                    AdvanceID = sum.ID,
                                                                    RequestDate = sum.RequestDate,
                                                                    Price=sum.Price,
                                                                    PermitStatus = sum.PermitStatus,
                                                                    AdvanceType = sum.AdvanceType
                                                                }).ToList();

                resultService.Data = sumAdvances;
            }
            catch (Exception ex)
            {
                resultService.AddError("exception", ex.Message);
            }

            return resultService;
        }
    }
}
