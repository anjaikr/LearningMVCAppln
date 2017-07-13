using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LearningMVCAppln.Models
{
    #region User Model...
    /// <summary>
    /// User Model Class, purposely used for populating views and carry data from database.
    /// </summary>
    public class User
    {
        #region Automated Properties
        public int UserId { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "EMail is required")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "PhoneNo is required")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Company is required")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }
        #endregion
    }
    #endregion
}