using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Models
{
    public class Item
    {
        public int id { get; set; }

        public String name { get; set; }

        public byte[] ImageData { get; set; }
    }
    public class ItemToSell
    {

        public int id { get; set; }
        public int itemId { get; set; }
        public int sellerId { get; set; }
        public int cost { get; set; }
    }
}
