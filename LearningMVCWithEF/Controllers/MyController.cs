﻿using LearningMVCWithEF;
using LearningMVCWithEF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningMVCWithEF.Controllers
{
    public class MyController : Controller
    {
        #region Private member variables...
        private IUserRepository userRepository;
        #endregion

        #region Public Constructor...
        /// <summary>
        /// Public Controller to initialize User Repository
        /// </summary>
        public MyController()
        {
            this.userRepository = new UserRepository(new MVCEntities());
        }
        #endregion

        #region Display...
        /// <summary>
        /// Get Action for index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var userList = from user in userRepository.GetUsers() select user;
            var users = new List<Models.UserList>();
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

        /// <summary>
        /// Get Action for Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var userDetails = userRepository.GetUserByID(id);
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
                userRepository.InsertUser(user);
                userRepository.Save();
                return RedirectToAction(nameof(Index));
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
        public ActionResult Edit(int id)
        {
            var userDetails = userRepository.GetUserByID(id);
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

        /// <summary>
        /// Post Action for Edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <param name="userDetails">todo: describe userDetails parameter on Edit</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, User userDetails)
        {
            TempData["TempData Name"] = "Akhil";

            try
            {
                var user = userRepository.GetUserByID(id);
                user.FirstName = userDetails.FirstName;
                user.LastName = userDetails.LastName;
                user.Address = userDetails.Address;
                user.PhoneNo = userDetails.PhoneNo;
                user.EMail = userDetails.EMail;
                user.Company = userDetails.Company;
                user.Designation = userDetails.Designation;
                userRepository.UpdateUser(user);
                userRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
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
        public ActionResult Delete(int id)
        {
            var user = new Models.UserList();
            var userDetails = userRepository.GetUserByID(id);

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

        /// <summary>
        /// Post Action for Delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDetails"> </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id, Models.UserList userDetails)
        {
            try
            {
                var user = userRepository.GetUserByID(id);

                if (user != null)
                {
                    userRepository.DeleteUser(id);
                    userRepository.Save();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
        #endregion
    }
}
