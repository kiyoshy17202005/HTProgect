using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Models
{
    public class Avatar
    {

        public int id { get; set; }

        public String name { get; set; }

        public ItemID shirtId { get; set; } = Constant.DEFULT_SHIRT;

        public ItemID pantsId { get; set; } = Constant.DEFULT_PANTS;

        public ItemID bodyId { get; set; } = Constant.DEFULT_BODY;
    }
}
