using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellerAndBuyer.Data;
using SellerAndBuyer.Models;
namespace SellerAndBuyer.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize(Roles = "Admin")]

        public IActionResult Buyer()
        {
            IEnumerable<Buyer> objBuyerList = _db.Buyer;
            return View(objBuyerList);
        }
        //get
        public IActionResult EditBuyers(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Buyer.FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult EditBuyers(Buyer obj)
        {
         
                _db.Buyer.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Buyer updated Successfully!";
                return RedirectToAction("Buyer");
            
                      
        }

        //get
        public IActionResult DeleteBuyers(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Buyer.FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //post
        [HttpPost,ActionName("DeleteBuyers")]
        [ValidateAntiForgeryToken]       
        public IActionResult DeleteBuyersPost(int? id)
        {
            var obj = _db.Buyer.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
           // var studentCourseIds =
             //    from s in _db.Buyer 
               //  select s.AppUser.Id;
            _db.Buyer.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Buyer deleted Successfully!";
            return RedirectToAction("Buyer");
        }

        //Seller
        public IActionResult Seller()
        {
            IEnumerable<Seller> objSellerList = _db.Seller;
            return View(objSellerList);
        }
        //Edit get
        public IActionResult EditSellers(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Seller.FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Edit post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult EditSellers(Seller obj)
        {
            _db.Seller.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Seller updated Successfully!";
            return RedirectToAction("Seller");
        }

        //get Delete
        public IActionResult DeleteSellers(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Seller.FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //post Delete
        [HttpPost, ActionName("DeleteSellers")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSellerPost(int? id)
        {
            var obj = _db.Seller.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Seller.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Seller deleted Successfully!";
            return RedirectToAction("Seller");
        }


    }
}
