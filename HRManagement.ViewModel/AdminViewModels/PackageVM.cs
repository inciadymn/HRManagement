using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModel.AdminViewModels
{
    public class PackageVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        [MaxLength(100), MinLength(2, ErrorMessage = "Paket adı min 2 max 100 karakter olabilir")]
        public string Name { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Tarihi gun/ay/yıl olarak giriniz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} exception")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Tarihi gun/ay/yıl olarak giriniz")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        public DateTime EndDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }


        public bool IsActive { get; set; } = true;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        public int Duration { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        public int UserNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bu alan boş bırakılamaz")]
        public string ImageURL { get; set; }
    }
}
