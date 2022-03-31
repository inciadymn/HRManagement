using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModel.EmployeeViewModels
{
    public class CreateEmployeeAdvanceVM
    {
        public int EmployeeID { get; set; }

        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Avans Miktarı")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Avans Tipi")]
        public AdvanceType AdvanceType { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [DataType(DataType.Text)]
        [StringLength(250, ErrorMessage = "min bir kelime giriniz.", MinimumLength = 2)]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}

