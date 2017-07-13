using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningMVCWithCF.Models
{
    #region User Model...
    /// <summary>
    /// User Model Class, purposely used for populating views and carry data from database.
    /// </summary>
    public class User
    {
        #region Automated Properties
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
        public string Salary { get; set; }

        #endregion
    }
    #endregion
}