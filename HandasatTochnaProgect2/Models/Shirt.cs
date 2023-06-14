using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Models
{
    public class Shirt
    {

        private static Shirt instance = null;
        public static Shirt Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Shirt(-1);
                }
                return instance;
            }
        }
        private Shirt(int shirtId)
        {
            this.shirtId = shirtId;
        }

        public int id { get; set; }

        public int shirtId { get; set; }
    }
}
