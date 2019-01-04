using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Model_DAL.Models
{
    public class LoginViewModel
    {
        [Display(Name ="Login ID")]
        [Required(ErrorMessage ="*")]
        public int LoginID { get; set; }
        [Display(Name ="Password")]
        [Required(ErrorMessage =("*"))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}