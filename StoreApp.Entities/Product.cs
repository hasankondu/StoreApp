using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreApp.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [StringLength(30, ErrorMessage = "En fazla 30 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Ürün adı alanı gereklidir.")]
        public string ProductName { get; set; }
        [StringLength(10000, ErrorMessage = "En fazla 10000 karakter uzunluğunda olmalıdır.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Ürün fiyatı boş bırakılamaz.")]
        public decimal? UnitPrice { get; set; }
        public string UserId { get; set; }
        public DateTime DisplayDate { get; set; }
        public string ImageUrl { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsInOrder { get; set; }
        public virtual List<ProductCategorySub> ProductCategorySubs { get; set; }
    }
}
