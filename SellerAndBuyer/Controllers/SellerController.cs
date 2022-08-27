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
           IEnumerable<Seller> objSellerList = _db.Seller;
            //var BuyerType = _db.Buyer.Select(s => new Buyer { Type = s.Type });
            //BuyerType.ToString();
            //var obj = _db.Seller.Where(Seller => Seller.Type == BuyerType).FirstOrDefault();


            //            foreach(var obj1 in obj)
            //{
            //               var Name = obj1.AppUser.UserName;

            //}
            //var posts = _db.Buyer
            //                    .Where(p => p.Type == )
            //                    .Select(p => new { p.Type });
               var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var CurrentUser = _db.Users
                  .Where(users => users.Id == userId)
                  .FirstOrDefault();
            var matches = objSellerList.Where(p => p.AppUser == CurrentUser);
            if (matches != null )
            {
                var sellerId = matches.Select(p => p.Id).FirstOrDefault();
                Seller sellerDb = _db.Seller.Find(sellerId);
                ViewData["SellDb"] = sellerDb;
                return View();
            }
            else
            {   
                return View("Create");
            }
            return View("Index");
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

        public IActionResult Map()
        {
            return View();
        }


    }
}
