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
                        whenSignIn(user);
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

        private void whenSignIn(User user)
        {
            String userName = user.userName;
            using (var db = new dbContext())
            {
                Avatar avatar = new Avatar();
                db.Avatars.Add(avatar);
                db.SaveChanges();
                user.avatarId = avatar.id;

                user.director = userName.Equals(Constant.DIRECTOR_USER_NAME);
  
                ViewBag.registerMassage = user.userName + " has been successfully registered";
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public IActionResult DeleteUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteUser(User user)
        {
            if (ModelState.IsValid)
            {
                Object userName = TempData["userName"];
                using (var db = new dbContext())
                {
                    if (userName.Equals(user.userName))
                    {
                        User userToDelete = db.Users.Where(n => n.userName.Equals(user.userName)).ToList()[0];
                        if (userToDelete.password.Equals(user.password))
                        {
                            deleteUser(user.userName);
                            return Logout();
                        }
                        ViewBag.isDeleted = "password is incorrect";

                    }
                    else if (Constant.DIRECTOR_USER_NAME.Equals(userName))
                    {
                        TempData["userName"] = userName;
                        List<User> userToDelete = db.Users.Where(n => n.userName.Equals(user.userName) && n.password.Equals(user.password)).ToList();
                        if (userToDelete.Count == 1)
                        {
                            deleteUser(user.userName);
                        }
                        else
                        {
                            ViewBag.isDeleted = "userName or password are incorrect";
                        }
                        
                    }
                    else
                    {
                        ViewBag.isDeleted = "You can't delete this user";
                    }
                }
            }
            else
            {
                ViewBag.isDeleted = "illigal input";
            } 
            return View();
        }

        private void deleteUser(String userName)
        {
            using (var db = new dbContext())
            {

                var user_ToRemove = db.Users.Where(n => n.userName.Equals(userName)).ToList()[0];
                var avatar_ToRemove = db.Avatars.Where(n => n.id.Equals(user_ToRemove.avatarId)).ToList()[0];
                var ItemsToSell_ToRemove = db.Shop.Where(n => n.sellerUserName.Equals(userName)).ToList();
                var UsersToItems_ToRemove = db.Users2Items.Where(n => n.userName.Equals(userName)).ToList();

                db.Users.Remove(user_ToRemove);
                db.Avatars.Remove(avatar_ToRemove);
                foreach (var item in ItemsToSell_ToRemove)
                {
                    db.Shop.Remove(item);
                }
                foreach (var item in UsersToItems_ToRemove)
                {
                    db.Users2Items.Remove(item);
                }

                db.SaveChanges();
            }
            ViewBag.isDeleted = userName + " is deleted";
        }


        public IActionResult Logout()
        {
            TempData["userName"] = null;
            return Redirect("/Home/Index");
        }


    }
}
