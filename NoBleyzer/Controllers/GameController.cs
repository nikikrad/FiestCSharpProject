using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoBleyzer.Models;
using NoBleyzer.Request.GameController;

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
            return Ok(await db.Games.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Create(PostGame game)
        {
            var geyGame = new Game();
            geyGame.Title = game.Title;
            geyGame.Price = game.Price;
            db.Games.Add(geyGame);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Remove(int id)
        {
            var res = await db.Games.FirstOrDefaultAsync(x => x.Id == id);
            if(res != null)
            {
                db.Games.Remove(res);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

    }
}
