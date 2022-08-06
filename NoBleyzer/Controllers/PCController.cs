using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoBleyzer.Models;
using NoBleyzer.Request.PCController;

namespace NoBleyzer.Controllers
{
    [Route("[controller]/[action]")]
    public class PCController: Controller
    {
        private StoreContext db;
        public readonly IMapper _mapper;

        public PCController(StoreContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await db.PCs.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostPC postPC)
        {
            var _mappedPC = _mapper.Map<PC>(postPC);
            db.PCs.Add(_mappedPC);
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await db.PCs.FirstOrDefaultAsync(x => x.Id == id);
            if (res != null)
            {
                db.PCs.Remove(res);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
