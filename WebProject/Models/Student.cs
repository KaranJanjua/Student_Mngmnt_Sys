using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
    }
}
