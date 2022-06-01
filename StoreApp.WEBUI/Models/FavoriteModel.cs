using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.Models
{
    public class FavoriteModel
    {
        public int FavoriteId { get; set; }
        public List<FavoriteItemModel> FavoriteItems { get; set; }
    }

    public class FavoriteItemModel
    {
        public int FavoriteItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}
