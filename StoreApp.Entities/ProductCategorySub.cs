using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Entities
{
    public class ProductCategorySub
    {
        public int CategorySubID { get; set; }
        public virtual CategorySub CategorySub { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
