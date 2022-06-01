using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Entities
{
    public class FavoriteItem
    {
        public int FavoriteItemID { get; set; }

        public virtual Product Product { get; set; }
        public int ProductID { get; set; }

        public virtual Favorite Favorite { get; set; }
        public int FavoriteID { get; set; }
    }
}
