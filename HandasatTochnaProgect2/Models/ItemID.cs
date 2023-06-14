using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Models
{
    public class ItemID
    {
        public ItemID(int itemId)
        {
            this.itemId = itemId;
        }

        public int id { get; set; }

        public int itemId { get; set; }

    }
}
