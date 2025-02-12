﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            string userName = form["txtEmail"];
            string email = form["txtEmail"];
            string pwd = form["txtPassword"];

            var user = new ApplicationUser();
            user.UserName = userName;
            user.Email = email;

            var newUser = userManager.Create(user, pwd);

            return View();
        }
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRole(FormCollection form)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string roleName = form["roleName"];

            if (!roleManager.RoleExists(roleName))
            {
                var role = new IdentityRole(roleName);             //create admin role
                roleManager.Create(role);
            }

            return View("Index");
        }
        public ActionResult AssignRole()
        {
            ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AssignRole(FormCollection form)
        {
            string userName = form["txtUserName"];
            string roleName = form["RoleName"];

            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var query = context.Users.Where(u => u.UserName == userName);
            int count = query.Count();
            if (count != 0)
            {
                TempData["創建訊息"] = "儲存成功";
                userManager.AddToRole(user.Id, roleName);
            }
            else
            {
                TempData["創建訊息"] = "儲存失敗，沒有此UserName";
            }


            return View("Index");
        }
        public ActionResult AddMoney()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMoney(FormCollection form)
        {
            string userName = form["txtUserName"];
            string money = form["txtMoney"];

            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var query = context.Users.Where(u => u.UserName == userName);
            int count = query.Count();

            if (count != 0)
            {
                TempData["創建訊息"] = "儲存成功";

                int addMoney = Convert.ToInt32(money);
                int userOrignalWallet= Convert.ToInt32(user.Wallet);

                int userTotalMoney = addMoney + userOrignalWallet;

                user.Wallet = Convert.ToString(userTotalMoney);

                context.SaveChanges();
            }
            else
            {
                TempData["創建訊息"] = "儲存失敗，沒有此UserName";
            }

            return RedirectToAction("Index");
        }

       
    }
}