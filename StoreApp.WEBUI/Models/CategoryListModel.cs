using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.Models
{
    public class CategoryListModel
    {
        public List<Category> Categories { get; set; }
        public List<CategorySub> CategorySubs { get; set; }
    }
}
