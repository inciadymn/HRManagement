using HRManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Model.Entities
{
    public class Package: BaseEntity
    {
        public Package()
        {
            Companies = new HashSet<Company>();
            
        }
        public string Name { get; set; }
        public DateTime StartDate { get; set; } //paketin satışa açılacağı süre
        public DateTime EndDate { get; set; } //paketin satış biteceği süre
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
        public int Duration { get; set; } // satın alan şirketin paketi kullanabilecek süresi
        public int UserNumber { get; set; }
        public string ImageUrl { get; set; }


        public ICollection<Company> Companies { get; set; }
    }
}
