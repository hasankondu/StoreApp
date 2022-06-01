using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.WEBUI.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        [StringLength(30, ErrorMessage = "En fazla 30 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Ürün adı alanı gereklidir.")]
        public string ProductName { get; set; }
        [StringLength(10000, ErrorMessage = "En fazla 10000 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Ürün açıklaması alanı gereklidir.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Ürün fiyatı boş bırakılamaz.")]
        [Range(0,999999, ErrorMessage = "Ürün fiyatı 0'dan az olamaz.")]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal? UnitPrice { get; set; }
        public DateTime DisplayDate { get; set; }
        public string ImageUrl { get; set; }
        public int? UnitsInStock { get; set; }
        public int? UnitsInOrder { get; set; }
        public int CategoryID { get; set; }

        public List<Category> Categories { get; set; }
        public List<CategorySub> SelectedCategorySubs { get; set; }
        public List<CategorySub> SelectedCategoryWithCategorySubs { get; set; }
    }
}
