using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.Models
{
    public class CategoryListViewModel
    {
        public string SelectedCategorySub { get; set; }
        public List<Category> Categories { get; set; }
        public List<CategorySub> CategorySubs { get; set; }
    }
}
