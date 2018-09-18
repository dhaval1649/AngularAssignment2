using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDemo.Models
{
    public partial class EmployeeMaster
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public string ContactNumber { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public DepartmentMaster DepartmentMaster { get; set; }
        [NotMapped]
        public string DepartmentName { get; set; }
    }
}
