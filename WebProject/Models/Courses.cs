using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class Courses
    {
        [Key]
        public int Course_Id { get; set; }
        public String Course_Name { get; set; }
        public String Tutor_Name { get; set; }
        public String class_Location { get; set; }
        public DateTime Start_Date { get; set; }
    }
}
