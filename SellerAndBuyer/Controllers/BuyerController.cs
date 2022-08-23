using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<Buyer> objSellerList = _db.Buyer;
            return View(objSellerList);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Buyer obj)
        {
            _db.Buyer.Add(obj);
            _db.SaveChanges();
            

            return RedirectToAction("Index");
        }
    }
}
