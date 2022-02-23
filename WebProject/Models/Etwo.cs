using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class Etwo
    {

        [Key]
        public int EnrolName_Id { get; set; }



        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }


        [Display(Name = "Course")]
        public string Course_Name { get; set; }

        [Display(Name = "Class Location")]
        public string class_Location { get; set; }



        [ForeignKey("Student_Id")]
        public Student Student { get; set; }

        [ForeignKey("Course_Id")]
        public Courses Course { get; set; }


    }
}
