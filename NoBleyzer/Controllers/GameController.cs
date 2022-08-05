using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoBleyzer.Models;

namespace NoBleyzer.Controllers
{
    [Route("[controller]/[action]")]
    public class GameController: Controller
    {
        private StoreContext db;
        public GameController(StoreContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await db.Games.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Create(Game game)
        {
            db.Games.Add(game);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public async Task<ActionResult> Remove(Game game)
        {
            db.Games.Remove(game);
            await db.AddRangeAsync(db.Games);
            return View(game);
        }

    }
}
