using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModel.AdminViewModels
{
    public class CompanyVM
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        [MaxLength(100), MinLength(2, ErrorMessage = "Paket adı min 2 max 100 karakter olabilir")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        [MaxLength(500), MinLength(2, ErrorMessage = "Paket adı min 2 max 500 karakter olabilir")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen ornek@ornek.com şeklinde bir mail adresi giriniz")]
        public string MailExtension { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Tarihi gun/ay/yıl olarak giriniz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]

        public DateTime RegisterDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Tarihi gun/ay/yıl olarak giriniz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        public DateTime DatePurchased { get; set; }
        public string PhoneNumber { get; set; }

        [MaxLength(10, ErrorMessage = "Max 10 haneli olmalıdır"), MinLength(10, ErrorMessage = "Min 10 haneli olmalıdır")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        public string TaxId { get; set; }
        public CompanyType CompanyType { get; set; }
        public int AdminId { get; set; }
        public string PackageId { get; set; }
        public string ImageURL { get; set; }
    }
}
