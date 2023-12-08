using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealKonyvtar.Server.Data;
using RealKonyvtar.Shared;

namespace RealKonyvtar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KonyvController : ControllerBase
    {
        private readonly DataContext _dataConext;

        public KonyvController(DataContext dataConext)
        {
            _dataConext = dataConext;
        }

        public async Task<ActionResult<List<Konyv>>> GetAllKonyv()
        {
            //var list = await _dataConext.Konyvek.ToArrayAsync();
            var list = await _dataConext.Konyvek.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Konyv>> GetKonyv(int id)
        {
            var dbkonyv = await _dataConext.Konyvek.FindAsync(id);
            if (dbkonyv == null)
            {
                return NotFound("Ez a könyv nem létezik");
            }

            return Ok(dbkonyv);
        }


        [HttpPost]
        public async Task<ActionResult<List<Konyv>>> AddKonyv(Konyv k)
        {
            _dataConext.Konyvek.Add(k);
            await _dataConext.SaveChangesAsync();


            return await GetAllKonyv();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Konyv>>> UpdateKonyv(int id, Konyv k)
        {
            var dbkonyv = await _dataConext.Konyvek.FindAsync(id);
            if (dbkonyv == null)
            {
                return NotFound("Ez a könyv nem létezik");
            }
            
            dbkonyv.Title = k.Title;
            dbkonyv.Author = k.Author;
            dbkonyv.Publisher = k.Publisher;
            dbkonyv.ReleaseYear = k.ReleaseYear;

            await _dataConext.SaveChangesAsync();


            return await GetAllKonyv();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Konyv>> DeleteKonyv(int id)
        {
            var dbkonyv = await _dataConext.Konyvek.FindAsync(id);
            if (dbkonyv == null)
            {
                return NotFound("Ez a könyv nem létezik");
            }

            _dataConext.Konyvek.Remove(dbkonyv);
            await _dataConext.SaveChangesAsync();

            return Ok(dbkonyv);
        }
    }
}
