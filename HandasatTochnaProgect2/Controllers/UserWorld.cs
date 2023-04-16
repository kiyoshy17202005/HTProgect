using HandasatTochnaProgect2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Controllers
{
    public class UserWorld : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult UplodeItem()
        {
            return View();
        }

        public IActionResult Avatar()
        {
            List<String> items = new List<String>();
            using (var db = new dbContext())
            {
                User user = db.Users.Where(n => n.userName.Equals(TempData["userName"])).ToList()[0];
                Avatar avatar = db.Avatars.Where(n => n.id.Equals(user.avatarId)).ToList()[0];
                string bodyBase64Data = Convert.ToBase64String(db.ItemsList.Where(n => n.id.Equals(avatar.bodyId)).ToList()[0].ImageData);
                items.Add(string.Format("data:image/jpg;base64,{0}", bodyBase64Data));
                string shirtBase64Data = Convert.ToBase64String(db.ItemsList.Where(n => n.id.Equals(avatar.shirtId)).ToList()[0].ImageData);
                items.Add(string.Format("data:image/jpg;base64,{0}", shirtBase64Data));
                string pantsBase64Data = Convert.ToBase64String(db.ItemsList.Where(n => n.id.Equals(avatar.pantsId)).ToList()[0].ImageData);
                items.Add(string.Format("data:image/jpg;base64,{0}", pantsBase64Data));

            }
            ViewBag.avatarImage = items;
            return View();
        }

        [HttpPost]
        public IActionResult Uplodeitem()
        {
            foreach (var file in Request.Form.Files)
            {
                Item item = new Item();
                item.name = file.FileName;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                item.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();
                using (var db = new dbContext())
                {
                    db.ItemsList.Add(item);
                    db.SaveChanges();
                }
            }
            ViewBag.UploadItemMessage = "Item stored in database!";
            return View("UplodeItem");
        }
    }
}
