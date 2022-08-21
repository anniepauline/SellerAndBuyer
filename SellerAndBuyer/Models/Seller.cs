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
        public string? Type { get; set; }

        public int User_Id { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public AppUser AppUser { get; set; }

    }
}
