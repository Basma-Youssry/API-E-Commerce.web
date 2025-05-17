using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.OrderModule
{
    public class Order :BaseEntity<Guid>
    {

        public Order(string userEmail, OrderAddress address, DeliveryMethod deliveryMethod, ICollection<OrderItem> items, decimal subTotal, string paymentIntentId = "")
        {
            BuyerEmail = userEmail;
            shipToAddres = address;
            DeliveryMethod = deliveryMethod;
            Items = items;
            SubTotal = subTotal;
            PaymentIntentId = paymentIntentId;
        }

        public string BuyerEmail { get; set; } = default!;
        public OrderAddress shipToAddres { get; set; } = default!;
        public DeliveryMethod DeliveryMethod { get; set; } = default!;
        public ICollection<OrderItem> Items { get; set; } = [];
        public decimal SubTotal { get; set; }


        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public int DeliveryMethodId { get; set; } //FK
        public OrderStatus Status { get; set; }
        public decimal GetTotal() => SubTotal + DeliveryMethod.cost;
        public string PaymentIntentId { get; set; }

        
    }
}
