using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningMVCWithCF.Models
{
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }
        public string DeptName { get; set; }
    }
}