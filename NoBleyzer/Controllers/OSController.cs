using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoBleyzer.Models;
using NoBleyzer.Request.OSController;

namespace NoBleyzer.Controllers
{
    [Route("[controller]/[action]")]
    public class OSController: Controller
    {
        private StoreContext db;
        public readonly IMapper _mapper;

        public OSController(StoreContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await db.OSs.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Create(PostOS postOS)
        {
            var _mappedOS = _mapper.Map<OS>(postOS);
            db.OSs.Add(_mappedOS);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await db.OSs.FirstOrDefaultAsync(x => x.Id == id);
            if (res != null)
            {
                db.OSs.Remove(res);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
