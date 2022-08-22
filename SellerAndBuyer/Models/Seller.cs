using System.ComponentModel.DataAnnotations;

namespace SellerAndBuyer.Models
{
    public class Seller
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Item Type { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public AppUser AppUser { get; set; }

    }

    public enum Item
    {
        Fruits,
        Vegeteables,
        Carpets,
        Mats,
        Utensils
    }
}
