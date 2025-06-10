using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransfareObjects.IdentityDTO_s;

namespace Shared.DataTransfareObjects.OrderDTOs
{
    public class OrderDTo
    {
        public string BasketId { get; set; } = default!;
        public int DeliveryMethodId { get; set; }
        public AddressDTo shipToAddress { get; set; } = default!;

    }
}
