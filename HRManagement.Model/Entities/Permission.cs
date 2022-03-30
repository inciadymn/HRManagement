﻿using HRManagement.Core.Entity;
using HRManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Model.Entities
{
    public class Permission : BaseEntity
    {

        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime StartDate { get; set; } //izin başlangıcı
        public DateTime FinishDate { get; set; } //izin bitişi
        public int NumberOfDaysOff { get; set; }
        public string ReportUrl { get; set; }
        public PermitStatus PermitStatus { get; set; }
        public PermissionType PermissionType { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
