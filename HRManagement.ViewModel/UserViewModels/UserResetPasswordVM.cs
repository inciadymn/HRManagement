using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModel.UserViewModels
{
    public class UserResetPasswordVM
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", Prompt = "NewPassword")]
        [Required(ErrorMessage = "Yeni şifre girilmesi zorunlu...")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "OldPassword", Prompt = "OldPassword")]
        [Required(ErrorMessage = "Şifre girilmesi zorunlu...")]
        public string OldPassword { get; set; }
    }
}
