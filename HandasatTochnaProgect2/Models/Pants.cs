using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Models
{
    public class Pants
    {

        private static Pants instance = null;
        public static Pants Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Pants(-1);
                }
                return instance;
            }
        }

        private Pants(int pantsId)
        {
            this.pantsId = pantsId;
        }
        public int pantsId { get; set; }
    }
}
