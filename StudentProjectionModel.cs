using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Model_DAL.Models
{
    public class StudentProjectionModel
    {
        [Display(Name ="Student ID")]
        public int StudentID { get; set; }
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }
        [Display(Name = "Student Gender")]
        public string StudentGender { get; set; }
        [Display(Name = "Student Image")]
        public string StudentImageAddress { get; set; }
    }
}