using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class EnrolName
    {

        [Key]
        public int EnrolName_Id { get; set; }

        [Display(Name = "Student")]
        public string First_Name { get; set; }

        [ForeignKey("Student_Id")]
        public virtual Student Students { get; set; }

        [Display(Name = "Course")]
        public string Course_Name { get; set; }

        [ForeignKey("Course_Id")]
        public virtual Courses Courses { get; set; }


    }
}
