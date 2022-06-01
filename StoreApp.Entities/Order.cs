using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreApp.Entities
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime RequiredDate  { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OrderNote { get; set; }
        public EnumPaymentTypes PaymentTypes  { get; set; }
        public EnumOrderStatus OrderStatus { get; set; }
        public string PaymentID { get; set; }
        public string PaymentToken { get; set; }
        public string ConversationID { get; set; }


        public virtual List<OrderItem> OrderItems { get; set; }
    }

    public enum EnumOrderStatus
    {
        Waiting=0,
        Unpaid=1,
        Completed=2

    }
    public enum EnumPaymentTypes
    {
        CreditCart = 0,
        Eft,
        Balance = 1

    }
}
