using HRManagement.Model.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModel.EmployeeViewModels
{
    public class CreateEmployeePermissionVM
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage ="Zorunlu Alan")]
        [DataType(DataType.Date,ErrorMessage ="Lütfen tarih giriniz.")]
        [Display(Name = "Başlangıç Tarihi")]
        [PermissionDateControl(ErrorMessage ="Geçerli bir tarih giriniz.")]
        public DateTime StartDate { get; set; } //izin başlangıcı

        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.Date, ErrorMessage = "Lütfen tarih giriniz.")]
        [Display(Name = "Bitiş Tarihi")]
        [PermissionDateControl(ErrorMessage = "Geçerli bir tarih giriniz.")]
        public DateTime FinishDate { get; set; } //izin bitişi

        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.Text)]
        [StringLength(250, ErrorMessage = "min bir kelime giriniz.", MinimumLength = 2)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "İzin Tipi")]
        public PermissionType PermissionType { get; set; }

        public DateTime RequestDate { get; set; }

        public IFormFile Report { get; set; }


    }

    public class PermissionDateControl : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime permissionDate = Convert.ToDateTime(value);
            return permissionDate > DateTime.Now;
        }
    }
}
