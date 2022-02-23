using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class Enrol
    {
        [Key]
        public int Enrol_Id { get; set; }
        
        [Display(Name ="Student")]
        public int Student_Id { get; set; }

        [ForeignKey("Student_Id")]
        public virtual Student Students { get; set; }
        
        [Display(Name ="Course")]
        public int Course_Id { get; set; }

        [ForeignKey("Course_Id")]
        public virtual Courses Courses { get; set; }


    }
}
