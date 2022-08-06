using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoBleyzer.Models;
using NoBleyzer.Request.PlayerController;

namespace NoBleyzer.Controllers
{
    [Route("[controller]/[action]")]
    public class PlayerController:Controller
    {
        private StoreContext db;
        public readonly IMapper _mapper;

        public PlayerController(StoreContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await db.Players.ToListAsync());
        }
         
        [HttpPost]
        public async Task<ActionResult> Create(PostPlayer postPlayer)
        {
            var _mappedPlayer = _mapper.Map<Player>(postPlayer);
            db.Players.Add(_mappedPlayer);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await db.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (res != null)
            {
                db.Games.Remove(res);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
