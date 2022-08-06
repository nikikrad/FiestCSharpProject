﻿using AutoMapper;
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
        public readonly IMapper _mapper;
        public GameController(StoreContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await db.Games.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Create(PostGame game)
        {
            var _mappedGame = _mapper.Map<Game>(game);
            db.Games.Add(_mappedGame);
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
