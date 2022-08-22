using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SellerAndBuyer.Data;
using SellerAndBuyer.Models;

namespace SellerAndBuyer.Controllers
{
    public class SellerController : Controller
    {

        private readonly ApplicationDbContext _db;

        public SellerController(ApplicationDbContext db)
        {
            _db = db;
        }

        /*public IActionResult Index()
        {
            IEnumerable<Seller> objSellerList = _db.Seller;
            return View(objSellerList);
        } */


        public IActionResult Index()
        {          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Seller obj)
        {
            if(ModelState.IsValid)
            {
                _db.Seller.Add(obj);
                _db.SaveChanges();
                return View("Index");
            }
            else
            {
                return View(obj);
            }
        }
    }
}
