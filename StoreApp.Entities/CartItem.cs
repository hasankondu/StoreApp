using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreApp.Entities
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartItemID { get; set; }

        public virtual Product Product { get; set; }
        public int ProductID { get; set; }

        public virtual Cart Cart { get; set; }
        public int CartID { get; set; }

        public int Quantity { get; set; }
    }
}
