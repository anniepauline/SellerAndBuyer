using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SellerAndBuyer.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Role { get; set; }

        [Required]
        public int Phone { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        //public string AppUserId1 { get; set; }

        //Seller Realationship
        public List<Seller> Sellers { get; set; }

        //Buyer Realationship
        public List<Buyer> Buyers { get; set; }
    }

  

}
