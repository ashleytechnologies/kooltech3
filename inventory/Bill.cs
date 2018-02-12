using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inventory
{
  public  class Bill
    {

        public int id { get; set; }
        public float netAmount { get; set; }
        public float grossAmount { get; set; }
        public float itemDiscount { get; set; }
        public float discount { get; set; }
    }
}
