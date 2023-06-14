using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandasatTochnaProgect2.Models
{
    public class Body
    {

        private static Body instance = null;
        public static Body Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Body(-1);
                }
                return instance;
            }
        }
        private Body(int bodyId)
        {
            this.bodyId = bodyId;
        }

        public int id { get; set; }

        public int bodyId { get; set; }
    }
}
