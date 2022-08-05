using HRManagement.Core.Entity;
using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Model.Entities
{
    public class Company : BaseEntity
    {
        public Company()
        {
            
        }

        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string MailExtension { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime DatePurchased { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxId { get; set; }
        public string? ImageUrl { get; set; }
        public CompanyType CompanyType { get; set; }
      

        public int AdminID { get; set; }
        public Admin Admin { get; set; }

        public int? PackageId { get; set; }
        public Package Package { get; set; }  //paketler gelince kaldır yorumu



    }
}
