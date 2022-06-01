using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreApp.Entities
{
    public class Advertised
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdvertisedID { get; set; }

        [Required(ErrorMessage = "Öne çıkan ürünün haftalıkmı günlük mü olacağı alanı gereklidir.")]
        public bool WeeklyOrDaily { get; set; }

        public virtual Product Product { get; set; }
        public int ProductID { get; set; }
    }
}
