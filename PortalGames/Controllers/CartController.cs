using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PortalGames.Controllers
{
    public class CartController : Controller
    {
        private readonly Context db;
        public CartController(Context db)
        {
            this.db = db;
        }

        public IActionResult List()
        {
            return View(Repository.Cart);
        }

        public IActionResult Add(int? id)
        {
            Repository.Cart.Add(db.Games.Find(id));
            return RedirectToAction("Index","Games");
        }
        public IActionResult Remove(int? id)
        {
            Repository.Cart.Remove(Repository.Cart.First(g => g.Id == id));
            return RedirectToAction(nameof(List));
        }

        public IActionResult Buy(int? id)
        {
            var sum = Repository.Cart.Sum(z => z.Price);
            if (Repository.Sum < sum)
            {
                ViewBag.Message = "Недостаточно стредств";
                return View(nameof(List), Repository.Cart);
            }
            else if (Repository.Cart.Count == 0)
            {
                ViewBag.Message = "Должен быть хоть 1 товар в корзине";
                return View(nameof(List), Repository.Cart);
            }
            Repository.Sum -= sum;
            Repository.MyGames.AddRange(Repository.Cart);
            Repository.Cart.Clear();
            return RedirectToAction("Index", "Games");
        }

        public IActionResult TopUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TopUp(string name, string cvv, int yy, int mm, string number, decimal sum)
        {
            var card = db.Cards.FirstOrDefault(z => z.Name.Contains(name) && z.CVV == cvv && z.Number == number);
            if (card != null)
            {
                Repository.Sum += sum;
                card.Sum -= sum;
                db.Cards.Update(card);
                ViewBag.Mess = "";
                db.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            ViewBag.Mess = "Карта не найдена";
            return View();
        }
    }
}
