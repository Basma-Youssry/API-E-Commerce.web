using System.ComponentModel.DataAnnotations;

namespace E_Commerce.web.Moduels
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
