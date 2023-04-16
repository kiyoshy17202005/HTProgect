using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Models
{
    public class User
    {

        public string name { get; set; }

        [Required(ErrorMessage = "Please enter a username")]
        [Key]
        public string userName { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public String password { get; set; }

        public String email { get; set; }

        public String phonNumber { get; set; }

        public int money { get; set; }

        public int avatarId { get; set; }

        public bool director { get; set; } = false;

    }
}
