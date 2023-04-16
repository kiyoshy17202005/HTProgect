using HandasatTochnaProgect2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new dbContext())
                {
                    List<User> users = db.Users.Where(n => n.userName.Equals(user.userName) && n.password.Equals(user.password)).ToList();
                    if (users.Count() == 1)
                    {
                        ViewBag.loginError = user.userName + " has been successfully login";
                        TempData["userName"] = user.userName;
                        return Redirect("/UserWorld/HomePage");
                    }
                    else
                    {
                        ViewBag.loginError = "The user name or password is incorrect";
                        return View();
                    }
                }
            }


            ViewBag.loginError = "illigal input";
            return View();

        }

        [HttpPost]
        public IActionResult Signin(User user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new dbContext())
                {
                    List<User> users = db.Users.Where(n => n.userName.Equals(user.userName)).ToList();
                    if (users.Count() == 0)
                    {
                        int id = db.Avatars.Count() + 1;
                        Avatar avatar = new Avatar(id);
                        user.avatarId = id;
                        db.Avatars.Add(avatar);
                        if (user.userName == "asafgu")
                        {
                            user.director = true;
                        }
                        ViewBag.registerMassage = user.userName + " has been successfully registered";
                        db.Users.Add(user);
                        db.SaveChanges();
                        return View();
                    }
                    else
                    {
                        ViewBag.registerMassage = user.userName + " is catched, try another one";
                        return View();
                    }
                }

            }
            else
            {
                ViewBag.registerMassage = "illigal input";
                return View();
            }
        }

        public IActionResult Logout()
        {
            TempData["userName"] = null;
            return Redirect("/Home/Index");
        }


    }
}
