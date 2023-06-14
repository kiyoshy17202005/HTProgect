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

        public int shirtId { get; set; } = Constant.DEFULT_ITEM;

        public int pantsId { get; set; } = Constant.DEFULT_ITEM;

        public int bodyId { get; set; } = Constant.DEFULT_ITEM;
    }
}
