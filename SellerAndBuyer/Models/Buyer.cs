using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SellerAndBuyer.Models
{
    public class Buyer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }


        //public string AppUserId1 { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;

       
        public AppUser AppUser { get; set; }


        //[ForeignKey("AppUserId")]
        //public string AppUserRefId { get; set; }
        //public AppUser AppUserId { get; set; }
    }
   
}
