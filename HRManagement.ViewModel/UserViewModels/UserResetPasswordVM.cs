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
        public int ID { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "CurrentPassword", Prompt = "CurrentPassword")]
        [Required(ErrorMessage = "Şifre girilmesi zorunlu...")]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", Prompt = "NewPassword")]
        [Required(ErrorMessage = "Yeni şifre girilmesi zorunlu...")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirPassword", Prompt = "ConfirPassword")]
        [Compare("NewPassword", ErrorMessage =
        "Yeni Şifrenizi tekrar giriniz.")]
        public string ConfirmPassword { get; set; }

    }
}
