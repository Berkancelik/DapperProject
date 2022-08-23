using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DapperProject
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
    }
}
