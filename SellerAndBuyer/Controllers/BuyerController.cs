using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellerAndBuyer.Data;
using SellerAndBuyer.Models;
using System.Security.Claims;

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

            // var objBuyer = _db.Buyer.ToList();
            //IEnumerable<Buyer> objSellerList = _db.Buyer;
            //return View(objSellerList);
            IEnumerable<Buyer> objBuyerList = _db.Buyer;
            //get current userId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //get userId from buyer table if they match the current userId
            var CurrentUser = _db.Users
                  .Where(users => users.Id == userId)
                  .FirstOrDefault();
           
            // check if current user id == buyer user id(foreign key)
            var matches = objBuyerList.Where(p => p.AppUser == CurrentUser);
            if (matches != null)
            {
                var buyerId = matches.Select(p => p.Id).FirstOrDefault();
                Buyer buyerDb = _db.Buyer.Find(buyerId);
                ViewData["buyDb"] = buyerDb;
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
        public IActionResult Create(Buyer obj)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var CurrentUser = _db.Users
               .Where(users => users.Id == userId)
               .FirstOrDefault();

            obj.AppUser = CurrentUser;
            _db.Buyer.Add(obj);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        //EDIT GET
        public IActionResult Edit(int? id)
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

        //EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Buyer obj)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var CurrentUser = _db.Users
               .Where(users => users.Id == userId)
               .FirstOrDefault();

            obj.AppUser = CurrentUser;
            _db.Buyer.Update(obj);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
       
    }
}
