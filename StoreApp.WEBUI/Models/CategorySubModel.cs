using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.Models
{
    public class CategorySubModel
    {
        public int CategorySubID { get; set; }

        [StringLength(30, ErrorMessage = "En fazla 30 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Alt kategori adı alanı gereklidir.")]
        public string CategorySubName { get; set; }

        [StringLength(50, ErrorMessage = "En fazla 50 karakter uzunluğunda olmalıdır.")]
        public string ImageUrl { get; set; }
        public int CategoryID { get; set; }

        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
