using HRManagement.BLL.Abstract;
using HRManagement.BLL.Concrete.ResultServiceBLL;
using HRManagement.DAL.Abstract;
using HRManagement.Model.Entities;
using HRManagement.ViewModel.EmployeeViewModels;
using HRManagement.ViewModel.UserViewModels;
using System;

namespace HRManagement.BLL.Concrete
{
    public class EmployeeService : IEmployeeBLL
    {
        IEmployeeDAL employeeDAL;

        public EmployeeService(IEmployeeDAL employeeDAL)
        {
            this.employeeDAL = employeeDAL;
        }

        public bool ChangePassword(UserResetPasswordVM userResetPassword )
        {

            Employee employee = employeeDAL.Get(a => a.Email == userResetPassword.Email);
            if (employee != null)
            {
                if (employee.Password == userResetPassword.CurrentPassword)
                {
                    if (userResetPassword.NewPassword == userResetPassword.ConfirmPassword)
                    {
                        employee.Password = userResetPassword.NewPassword;
                        employeeDAL.Update(employee);
                        return true;
                    }
                    else
                    {
                        throw new Exception("Girdiğiniz şifreler uyuşmamaktadır.");
                    }

                }
                else
                {
                    throw new Exception("Girilen şifre yanlıştır.Lütfen tekrar deneyiniz");
                }
            }
            else
            {
                throw new Exception("Bir hata oluştu");
            }
        }

        public bool MailChangePassword(SingleEmployeeVM singleEmployee, string password)  //User Genelinde olmalı --> Employe, Admin, Manager --> 3'ü içinde --> UserService
        {
            if (employeeDAL != null || password != null)
            {

                Employee passChangeUser = employeeDAL.Get(a => a.Email == singleEmployee.Email);
                passChangeUser.Password = password;
                //passChangeUser.IsActive = false;
                passChangeUser = employeeDAL.Update(passChangeUser);

                return true;

            }
            return false;
        }

        public ResultService<bool> CheckUserEmail(string email)
        {
            ResultService<bool> result = new ResultService<bool>();
            Employee emp = employeeDAL.Get(a => a.Email == email);
            if (emp == null)
            {
                result.AddError("Login Hatası", "***Böyle bir kullanıcı bulunamadı");
                result.Data = false;
                return result;
            }

            result.Data = true;
            return result;
        }

        public ResultService<SingleEmployeeVM> GetEmployee(string email, string password)
        {
            ResultService<SingleEmployeeVM> result = new ResultService<SingleEmployeeVM>();
            Employee emp = employeeDAL.Get(a => a.Email == email && a.Password == password);
            if (emp == null)
            {
                result.AddError("Login Hatası", "***Böyle bir kullanıcı bulunamadı");
                return result;
            }
            result.Data = new SingleEmployeeVM()
            {
                Address = emp.Address,
                BirthDay = emp.BirthDay,
                Email = emp.Email,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                PhoneNumber = emp.PhoneNumber,
                Photo = emp.Photo,
                StartDate = emp.StartDate,
                Id = emp.ID,
                Title = emp.Title,
                Department = emp.Department,
                UserRole = emp.UserRole
            };
            return result;
        }

        public ResultService<SingleEmployeeVM> GetEmployee(int id)
        {
            ResultService<SingleEmployeeVM> result = new ResultService<SingleEmployeeVM>();
            Employee emp = employeeDAL.Get(a => a.ID == id);
            if (emp == null)
            {
                result.AddError("Null hatası", "id ile uyumlu employee yok");
                return result;
            }
            result.Data = new SingleEmployeeVM()
            {
                Address = emp.Address,
                BirthDay = emp.BirthDay,
                Email = emp.Email,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                PhoneNumber = emp.PhoneNumber,
                Photo = emp.Photo,
                StartDate = emp.StartDate,
                Id = emp.ID,
                Title = emp.Title,
                Department = emp.Department,
                UserRole=emp.UserRole
            };
            return result;
        }

        public double GetEmployeeSalary(int id)
        {
            Employee emp = employeeDAL.Get(a => a.ID == id);
            if (emp == null)
            {
                throw new Exception("Boş geçilemez");
            }

            return emp.Salary;
        }

        //public bool CheckPassword(string password)
        //{
        //    bool isCharUpper = false;
        //    bool isCharLower = false;
        //    bool isNumber = false;
        //    bool isPasswordLength = false;
        //    if (password.Length > 6)
        //    {
        //        isPasswordLength = true;
        //    }
        //    foreach (char item in password)
        //    {
        //        if (char.IsUpper(item))
        //        {
        //            isCharUpper = true;
        //        }
        //        else if (char.IsLower(item))
        //        {
        //            isCharLower = true;
        //        }
        //        else if (char.IsDigit(item))
        //        {
        //            isNumber = true;
        //        }

        //    }

        //    if (!isCharUpper || !isCharLower || !isNumber || !isPasswordLength)
        //    {
        //        return false;
        //    }

        //    return true;
        //}
    }
}
