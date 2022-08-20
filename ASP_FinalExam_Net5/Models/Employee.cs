using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_FinalExam_Net5.Models
{
    public class Employee
    {
        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public bool IsManager { get; set; }

    }
}
