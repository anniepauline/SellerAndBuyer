using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

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

      //public string AppUserId { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public int AppUser_Id { get; set; }
        public AppUser AppUser { get; set; }

        //        [ForeignKey("AppUserId")]
        //public string AppUserRefId { get; set; }
        //public AppUser AppUserId { get; set; }

    }
}
