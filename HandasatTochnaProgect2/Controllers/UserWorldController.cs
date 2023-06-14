using HandasatTochnaProgect2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Controllers
{
    public class UserWorldController : Controller
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

                Item body;
                if (avatar.bodyId.Equals(Constant.DEFULT_ITEM)) { body = db.ItemsList.Where(n => n.id.Equals(db.DefultBody.bodyId)).ToList()[0]; }
                else { body = db.ItemsList.Where(n => n.id.Equals(avatar.bodyId)).ToList()[0]; }
                string bodyBase64Data = Convert.ToBase64String(body.ImageData);

                Item pants;
                if (avatar.pantsId.Equals(Constant.DEFULT_ITEM)) { pants = db.ItemsList.Where(n => n.id.Equals(db.DefultPants.pantsId)).ToList()[0]; }
                else { pants = db.ItemsList.Where(n => n.id.Equals(avatar.pantsId)).ToList()[0]; }
                string pantsBase64Data = Convert.ToBase64String(pants.ImageData);

                Item shirt;
                if (avatar.shirtId.Equals(Constant.DEFULT_ITEM)) { shirt = db.ItemsList.Where(n => n.id.Equals(db.DefultShirt.shirtId)).ToList()[0]; }
                else { shirt = db.ItemsList.Where(n => n.id.Equals(avatar.shirtId)).ToList()[0]; }
                string shirtBase64Data = Convert.ToBase64String(shirt.ImageData);

                items.Add(string.Format("data:image/jpg;base64,{0}", bodyBase64Data));
                items.Add(string.Format("data:image/jpg;base64,{0}", shirtBase64Data));
                items.Add(string.Format("data:image/jpg;base64,{0}", pantsBase64Data));

            }
            ViewBag.avatarImage = items;
            return View();
        }

        [HttpPost]
        public IActionResult Uplodeitem()
        {
            Object userName = TempData["userName"];
            TempData["userName"] = userName;

            foreach (var file in Request.Form.Files)
            {
                Item item = new Item();
                String file_name = file.FileName;
                String item_type = "";

                bool doneName = false;
                for(int i = 0; !doneName && i < file_name.Length; i++)
                {
                    if (file_name[i] == ' ') doneName = true;
                    if (doneName)
                    {
                        item.name = file_name.Substring(0, i);

                        bool doneType = false;
                        for(int j = i + 1; !doneType && j < file_name.Length; j++)
                        {
                            if (file_name[j] == '.') doneType = true;
                            if(doneType)
                            {
                                item_type = file_name.Substring(i + 1, j - (i + 1));
                                switch (item_type)
                                {
                                    case "body":
                                        item.type = Item._type.body;
                                        break;
                                    case "pants":
                                        item.type = Item._type.pants;
                                        break;
                                    case "shirt":
                                        item.type = Item._type.shirt;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                item.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();

                using (var db = new dbContext())
                {
                    db.ItemsList.Add(item);
                    item.universal = true;

                    db.SaveChanges();
                    if (item.universal)
                    {
                        switch ((int)item.type)
                        {
                            case 0:
                                db.DefultBody.bodyId = item.id;
                                break;
                            case 1:
                                db.DefultShirt.shirtId = item.id;
                                break;
                            case 2:
                                db.DefultPants.pantsId = item.id;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        User2Item user2Item = new User2Item((String)userName, item.id);
                        db.Users2Items.Add(user2Item);
                    }
                    
                    db.SaveChanges();
                }
            }
            ViewBag.UploadItemMessage = "Item stored in database!";
            return View("UplodeItem");
        }
    }
}
