using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public List<CategorySub> CategorySubs { get; set; }
        public List<Product> Products { get; set; }
    }
}
