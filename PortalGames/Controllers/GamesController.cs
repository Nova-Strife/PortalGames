using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalGames;
using PortalGames.Models;
using PortalGames.ViewModels;

namespace PortalGames.Controllers
{
    public class GamesController : Controller
    {
        readonly Context db;

        public GamesController(Context context)
        {
            db = context;
            if (!Process.GetProcessesByName("GameBot").Any())
                Process.Start(@"D:\Доки\Desktop\C#\PortalGames\GameBot\bin\Debug\netcoreapp3.1\GameBot.exe");
              
        }

        const int PageSize = 4;
        public async Task<IActionResult> Index(decimal? startPrice,
                                               decimal? endPrice,
                                               string name,
                                               int page = 1,
                                               SortState sortOrder = SortState.NameAsc)
        {
            var source = db.Games.AsQueryable();

            if (startPrice != null)
                source = source.Where(z => z.Price >= startPrice);
            if (endPrice != null)
                source = source.Where(z => z.Price <= endPrice);

            if (!string.IsNullOrEmpty(name))
                source = source.Where(z => z.Name.Contains(name));

            source = sortOrder switch
            {
                SortState.NameDesc => source.OrderByDescending(s => s.Name),
                SortState.PriceAsc => source.OrderBy(s => s.Price),
                SortState.PriceDesc => source.OrderByDescending(s => s.Price),
                SortState.DateAsc => source.OrderBy(s => s.Release),
                SortState.DateDesc => source.OrderByDescending(s => s.Release),
                _ => source.OrderBy(s => s.Name),
            };

            return View(new IndexViewModel
            {
                PageViewModel = new PageViewModel(await source.CountAsync(), page, PageSize),
                FilterViewModel = new FilterViewModel(name, startPrice, endPrice),
                SortViewModel = new SortViewModel(sortOrder),
                Games = await source.Skip((page - 1) * PageSize).Take(PageSize).ToListAsync(),
            });
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var game = await db.Games.FindAsync(id);
            if (game == null)
                return NotFound();

            return PartialView(game);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Genre,Mode,Release,Age,Price,Description")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var game = await db.Games.FindAsync(id);
            if (game == null)
                return NotFound();
            return View(game);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Genre,Mode,Release,Age,Price,Description")] Game game)
        {
            if (id != game.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(game);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var game = await db.Games.FindAsync(id);
            if (game == null)
                return NotFound();
            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await db.Games.FindAsync(id);
            db.Games.Remove(game);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool GameExists(int id) => db.Games.Any(e => e.Id == id);
    }
}