using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellerAndBuyer.Data;
using SellerAndBuyer.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SellerAndBuyer.Controllers
{
    public class SellerController : Controller
    {

        private readonly ApplicationDbContext _db;

        public SellerController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize]
        public IActionResult Index()
        {
           IEnumerable<Seller> objSellerList = _db.Seller;
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
        public IActionResult Create(Seller obj)
        {
           // obj.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _db.Seller.Add(obj);
            
            //_db.Seller.Add(id);
            _db.SaveChanges();
            //var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return RedirectToAction("Index");
        }
    }
}
