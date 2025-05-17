using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransfareObjects.IdentityDTO_s;

namespace Shared.DataTransfareObjects.OrderDTOs
{
    public class OrderToReturnDTo
    {
        public Guid Id { get; set; }
        public string buyerEmail { get; set; } = default!;
        public DateTimeOffset OrderDate { get; set; }
        public ICollection<OrderItemDTo> Items { get; set; } = [];

        public AddressDTo shipToAddress { get; set; } = default!;
        public string DeliveryMethod { get; set; } = default!;
        public decimal deliveryCost { get; set; }
        public string status { get; set; } = default!;
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
