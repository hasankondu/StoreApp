using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreApp.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [StringLength(30, ErrorMessage = "En fazla 30 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Kategori adı alanı gereklidir.")]
        public string CategoryName { get; set; }

        [StringLength(50, ErrorMessage = "En fazla 50 karakter uzunluğunda olmalıdır.")]
        public string ImageUrl { get; set; }
        public virtual List<CategorySub> CategorySubs { get; set; }

    }
}
