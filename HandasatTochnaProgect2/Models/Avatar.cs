using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Models
{
    public class Avatar
    {
        public Avatar(int id)
        {
            this.id = id;
        }

        public int id { get; set; }

        public String name { get; set; }

        public int shirtId { get; set; } = 3;

        public int pantsId { get; set; } = 2;

        public int bodyId { get; set; } = 1;
    }
}
