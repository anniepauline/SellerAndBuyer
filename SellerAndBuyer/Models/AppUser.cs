using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        //Seller Realationship
        public List<Seller> SellerId { get; set; }

        //Buyer Realationship
        public List<Buyer> BuyerId { get; set; }




    }
}
