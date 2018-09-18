using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AngularDemo.Models
{
    public partial class DepartmentMaster
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
