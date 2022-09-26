using System;
using System.Collections.Generic;

namespace BADC_Backend.Models
{
    public partial class EmployeeDetail
    {
        public int OfficeId { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeePhone { get; set; }
    }
}
