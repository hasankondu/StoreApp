using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.Models
{
    public class ProductDetailsModel
    {
        public Product Product { get; set; }
        public List<CategorySub> CategorySubs { get; set; }
    }
}
