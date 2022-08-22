using Microsoft.AspNetCore.Mvc;
using SellerAndBuyer.Data;
using SellerAndBuyer.Models;

namespace SellerAndBuyer.Controllers
{
    public class BuyerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BuyerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Buyer> objSellerList = _db.Buyer;
            return View(objSellerList);
        }
    }
}
