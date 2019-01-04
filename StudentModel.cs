using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Model_DAL.Models
{
    public class StudentModel
    {
        [Display(Name ="Student ID")]//Label Text
        public int StudentID { get; set; }
        [Display(Name =("Student Name"))]
        [Required(ErrorMessage ="*")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Too Short Name")]
        public string StudentName { get; set; }
        [Display(Name =("Stdent Email ID"))]
        [Required(ErrorMessage ="*")]
        [EmailAddress(ErrorMessage ="Invalid Format")]
        public string StudentEmailID { get; set; }
        [Display(Name =("Student Password"))]
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password)]
        public string StudentPassword { get; set; }
        [Display(Name =("Student Mobile No"))]
        [Required(ErrorMessage ="*")]
        [RegularExpression("^[7-9][0-9]{9}$",ErrorMessage ="Invalid Number")]
        public string StudentMobileNo { get; set; }
        [Display(Name =("Student City"))]
        [Required(ErrorMessage ="*")]
        public string StudentCity { get; set; }
        [Display(Name =("Student Gender"))]
        [Required(ErrorMessage ="*")]
        public string StudentGender { get; set; }
        public string StudentImageAddress { get; set; }
        [Display(Name ="Student Image")]
        [Required(ErrorMessage ="*")]
        //[Range(10,int.MaxValue,ErrorMessage ="")]
        public HttpPostedFileBase StudentImageFile { get; set; }
    }
}