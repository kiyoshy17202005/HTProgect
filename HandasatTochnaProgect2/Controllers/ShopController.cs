using HandasatTochnaProgect2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult MyItems()
        {
            Object userName = TempData["userName"];
            TempData["userName"] = userName;

            List<String>[] itemsNames = new List<String>[Constant.ITEM_TYPES_NUMBER]; 
            List<String>[] itemsImages = new List<String>[Constant.ITEM_TYPES_NUMBER];


            for (int i = 0; i < Constant.ITEM_TYPES_NUMBER; i++)
            {
                itemsNames[i] = new List<String>();
                itemsImages[i] = new List<String>();
            }
            using (var db = new dbContext())
            {
                List<ItemID> universalItems = db.UniversalItems.ToList();
                for (int i = 0; i < universalItems.Count; i++)
                {
                    Item item = db.ItemsList.Where(n => n.id.Equals(universalItems[i].id)).ToList()[0];
                    Item._type type = item.type;

                    int type_num = ((int)type);
                    itemsNames[type_num].Add(item.name);
                    String bodyBase64Data = Convert.ToBase64String(item.ImageData);
                    itemsImages[type_num].Add(String.Format("data:image/jpg;base64,{0}", bodyBase64Data));
                }


                List<User2Item> items = db.Users2Items.Where(n => n.userName.Equals(userName)).ToList();
                for (int i = 0; i < items.Count; i++)
                {

                    Item item = db.ItemsList.Where(n => n.id.Equals(items[i].itemId.id)).ToList()[0];
                    Item._type type = item.type;

                    int type_num = ((int)type);
                    
                    itemsNames[type_num].Add(item.name);
                    String bodyBase64Data = Convert.ToBase64String(item.ImageData);
                    itemsImages[type_num].Add(String.Format("data:image/jpg;base64,{0}", bodyBase64Data));
                }
            }
            ViewBag.myItemsNames = itemsNames;
            ViewBag.myItemsImages = itemsImages;
            return View();
        }

        public IActionResult Shop()
        {

            List<String>[] itemsNames = new List<String>[Constant.ITEM_TYPES_NUMBER];
            List<String>[] itemsSellers = new List<String>[Constant.ITEM_TYPES_NUMBER];
            List<int>[] itemsCosts = new List<int>[Constant.ITEM_TYPES_NUMBER];
            List<String>[] itemsImages = new List<String>[Constant.ITEM_TYPES_NUMBER];

            for (int i = 0; i < Constant.ITEM_TYPES_NUMBER; i++)
            {
                itemsNames[i] = new List<String>();
                itemsSellers[i] = new List<String>();
                itemsCosts[i] = new List<int>();
                itemsImages[i] = new List<String>();
            }
            using (var db = new dbContext())
            {
                List<ItemToSell> items = db.Shop.ToList();
                for (int i = 0; i < items.Count; i++)
                {

                    Item item = db.ItemsList.Where(n => n.id.Equals(items[i].itemId.id)).ToList()[0];
                    int type_num = ((int)item.type);

                    itemsNames[type_num].Add(item.name);
                    itemsSellers[type_num].Add(items[i].sellerUserName);
                    itemsCosts[type_num].Add(items[i].cost);
                    string bodyBase64Data = Convert.ToBase64String(item.ImageData);
                    itemsImages[type_num].Add(String.Format("data:image/jpg;base64,{0}", bodyBase64Data));
                }
            }
            ViewBag.shopItemsNames = itemsNames;
            ViewBag.shopItemsSellers = itemsSellers;
            ViewBag.shopItemsCosts = itemsCosts;
            ViewBag.shopItemsImages = itemsImages;
            return View();
        }


        public IActionResult BuyItem()
        {




            return View();
        }


        [HttpPost]
        public IActionResult BuyItem(int shopItemID)
        {

            String userName = (String)TempData["userName"];
            TempData["userName"] = userName;

            using (var db = new dbContext())
            {

                User user = db.Users.Where(n => n.userName.Equals(userName)).ToList()[0];
                ItemToSell itemToSell = db.Shop.Where(n => n.id == shopItemID).ToList()[0];

                user.money = user.money - itemToSell.cost;

                User2Item user2Item = new User2Item(userName, itemToSell.itemId);
                db.Users2Items.Add(user2Item);

                db.SaveChanges();
            }
            return View("Shop");
        }


    }
}
