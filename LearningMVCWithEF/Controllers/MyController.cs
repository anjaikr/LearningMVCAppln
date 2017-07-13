using LearningMVCWithEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningMVCWithEFWithEF.Controllers
{
    public class MyController : Controller
    {
        #region Display...
        /// <summary>
        /// Get Action for index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            using (var dbContext = new MVCEntities())
            {
                var userList = from user in dbContext.Users select user;
                var users = new List<LearningMVCWithEF.Models.UserList>();
                if (userList.Any())
                {
                    foreach (var user in userList)
                    {
                        users.Add(new LearningMVCWithEF.Models.UserList() { UserId = user.UserId, Address = user.Address, Company = user.Company, FirstName = user.FirstName, LastName = user.LastName, Designation = user.Designation, EMail = user.EMail, PhoneNo = user.PhoneNo });
                    }
                }
                ViewBag.FirstName = "My First Name";
                ViewData["FirstName"] = "My First Name";
                if (TempData.Any())
                {
                    var tempData = TempData["TempData Name"];
                }
                return View(users);
            }
        }

        /// <summary>
        /// Get Action for Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            using (var dbContext = new MVCEntities())
            {
                var userDetails = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
                var user = new LearningMVCWithEF.Models.UserList();
                if (userDetails != null)
                {
                    user.UserId = userDetails.UserId;
                    user.FirstName = userDetails.FirstName;
                    user.LastName = userDetails.LastName;
                    user.Address = userDetails.Address;
                    user.PhoneNo = userDetails.PhoneNo;
                    user.EMail = userDetails.EMail;
                    user.Company = userDetails.Company;
                    user.Designation = userDetails.Designation;
                }
                return View(user);
            }
        }
        #endregion

        #region Create...
        /// <summary>
        /// Get Action for Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Action for Create
        /// </summary>
        /// <param name="userDetails"> </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(LearningMVCWithEF.Models.UserList userDetails)
        {
            try
            {
                using (var dbContext = new MVCEntities())
                {
                    var user = new User();
                    if (userDetails != null)
                    {
                        user.UserId = userDetails.UserId;
                        user.FirstName = userDetails.FirstName;
                        user.LastName = userDetails.LastName;
                        user.Address = userDetails.Address;
                        user.PhoneNo = userDetails.PhoneNo;
                        user.EMail = userDetails.EMail;
                        user.Company = userDetails.Company;
                        user.Designation = userDetails.Designation;
                    }
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        #endregion

        #region Edit...
        /// <summary>
        /// Get Action for Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            using (var dbContext = new MVCEntities())
            {
                var userDetails = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
                var user = new LearningMVCWithEF.Models.UserList();
                if (userDetails != null)
                {
                    user.UserId = userDetails.UserId;
                    user.FirstName = userDetails.FirstName;
                    user.LastName = userDetails.LastName;
                    user.Address = userDetails.Address;
                    user.PhoneNo = userDetails.PhoneNo;
                    user.EMail = userDetails.EMail;
                    user.Company = userDetails.Company;
                    user.Designation = userDetails.Designation;
                }
                return View(user);
            }
        }

        /// <summary>
        /// Post Action for Edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <param name="userDetails">todo: describe userDetails parameter on Edit</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int? id, User userDetails)
        {
            TempData["TempData Name"] = "Akhil";

            try
            {
                using (var dbContext = new MVCEntities())
                {
                    var user = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
                    if (user != null)
                    {
                        user.FirstName = userDetails.FirstName;
                        user.LastName = userDetails.LastName;
                        user.Address = userDetails.Address;
                        user.PhoneNo = userDetails.PhoneNo;
                        user.EMail = userDetails.EMail;
                        user.Company = userDetails.Company;
                        user.Designation = userDetails.Designation;
                        dbContext.SaveChanges();
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        #endregion

        #region Delete...
        /// <summary>
        /// Get Action for Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            using (var dbContext = new MVCEntities())
            {
                var user = new LearningMVCWithEF.Models.UserList();
                var userDetails = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
                if (userDetails != null)
                {
                    user.FirstName = userDetails.FirstName;
                    user.LastName = userDetails.LastName;
                    user.Address = userDetails.Address;
                    user.PhoneNo = userDetails.PhoneNo;
                    user.EMail = userDetails.EMail;
                    user.Company = userDetails.Company;
                    user.Designation = userDetails.Designation;
                }
                return View(user);
            }
        }

        /// <summary>
        /// Post Action for Delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDetails"> </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int? id, LearningMVCWithEF.Models.UserList userDetails)
        {
            try
            {
                using (var dbContext = new MVCEntities())
                {
                    var user = dbContext.Users.FirstOrDefault(userId => userId.UserId == id);
                    if (user != null)
                    {
                        dbContext.Users.Add(user);
                        dbContext.SaveChanges();
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        #endregion
    }
}
