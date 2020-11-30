using Microsoft.AspNetCore.Mvc;
using PortalGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGames.Controllers
{
    public class AuthController : Controller
    {
        readonly Context db;

        public AuthController(Context db)
        {
            this.db = db;
        }

        public IActionResult Login(string email,string password)
        {
            var user = db.Accounts.FirstOrDefault(z => z.Email == email && z.Password == password);
            if(user != null)
            {
                Repository.Account = user;
                return RedirectToAction("Index", "Games");
            }
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
                return View();
            return View("Login","Такого пользователя нет! Вы можете зарегистрировать новый аккаунт");
        }

        public IActionResult Register(string nickname, string email, string password)
        {
            if (db.Accounts.FirstOrDefault(z => z.Email == email) != null)
                return View("Login", "Аккаунт с такой почтой уже есть");
            var acc = new Account { Nickname = nickname, Email = email, Password = password };
            Repository.Account = acc;
            db.Accounts.Add(acc);
            db.SaveChanges();
            return RedirectToAction("Index", "Games");
        }
    }
}
