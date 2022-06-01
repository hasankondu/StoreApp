using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreApp.Entities
{
    public class CategorySub
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategorySubID { get; set; }

        [StringLength(30, ErrorMessage = "En fazla 30 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Alt kategori adı alanı gereklidir.")]
        public string CategorySubName { get; set; }

        [StringLength(50, ErrorMessage = "En fazla 50 karakter uzunluğunda olmalıdır.")]
        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }

        public virtual List<ProductCategorySub> ProductCategorySubs { get; set; }
    }
}
