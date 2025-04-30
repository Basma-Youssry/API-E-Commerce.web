using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransfareObjects.BasketModuleDTos
{
    public class BasketDTo
    {
        public string Id { get; set; }
        public ICollection<BasketItemDto> Items { get; set; } = [];
    }

 
}
