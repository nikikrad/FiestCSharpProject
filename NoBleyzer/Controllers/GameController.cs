using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoBleyzer.Models;
using NoBleyzer.Repositories;
using NoBleyzer.Request.GameController;

namespace NoBleyzer.Controllers
{
    [Route("[controller]/[action]")]
    public class GameController: Controller
    {
        private StoreContext db;
        private EFUnitOfWork unitOfWork;
        private GameRepository gameRepository;
        public readonly IMapper _mapper;
        public GameController(StoreContext context, IMapper mapper)
        {
            unitOfWork = new EFUnitOfWork(context);
            gameRepository = (GameRepository?)unitOfWork.Games;
            db = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = gameRepository.GetAsync;
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult> Create(PostGame game)
        {
            //_mapper.Map<Player>(game.Players);
            var _mappedGame = _mapper.Map<Game>(game);
            //var PlayersInGame = _mapper.Map<Player>(game.Players);
            //_mappedGame.Players = _mapper.Map<Player>(game.Players);
            db.Games.Add(_mappedGame);
            await db.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
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
