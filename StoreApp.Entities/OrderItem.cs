using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreApp.Entities
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemID { get; set; }

        public virtual Order Order { get; set; }
        public int OrderID { get; set; }

        public virtual Product Product { get; set; }
        public int ProductID { get; set; }


        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
