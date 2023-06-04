﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Models
{
    public class User2Item
    {
        public User2Item(string userName, ItemID itemId)
        {
            this.userName = userName;
            this.itemId = itemId;
        }

        [Key]
        public String userName { get; set; }

        public ItemID itemId { get; set; }
    }
}
