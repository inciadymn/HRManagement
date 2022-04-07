using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModel.UserViewModels
{
    public class UserLoginVM
    {
        [Display(Name = "Email Address", Prompt = "e-mail address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email girilmelidir...")]
        [StringLength(100, ErrorMessage = "Email min 10, max 100 karakter girilebilir...", MinimumLength = 10)]
        [Required(ErrorMessage = "Email zorunlu...")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "password")]
        [StringLength(20, ErrorMessage = "Şifre min 3, max 20 karakter girilebilir...", MinimumLength = 3)]
        [Required(ErrorMessage = "Şifre zorunlu...")]
        public string Password { get; set; }

      
    }
}
