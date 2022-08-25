using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellerAndBuyer.Data;
using SellerAndBuyer.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Drawing;
using Microsoft.EntityFrameworkCore;


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
        public IActionResult Create(Seller obj)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var CurrentUser = _db.Users
                .Where(users => users.Id == userId)
                    .FirstOrDefault();

            obj.AppUser = CurrentUser;
            
            _db.Seller.Add(obj);
            _db.SaveChanges();
           
            return RedirectToAction("Index");
        }



        //EDIT GET
        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }

            var obj = _db.Seller.FirstOrDefault(u => u.Id == id);
            if (obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Seller obj)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var CurrentUser = _db.Users
               .Where(users => users.Id == userId)
               .FirstOrDefault();

            obj.AppUser = CurrentUser;
            _db.Seller.Update(obj);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
