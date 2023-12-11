using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealKonyvtar.Server.Data;
using RealKonyvtar.Shared;

namespace RealKonyvtar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly DataContext _dataConext;

        public ReaderController(DataContext dataConext)
        {
            _dataConext = dataConext;
        }

        public async Task<ActionResult<List<Reader>>> GetAllOlv()
        {
            //var list = await _dataConext.Konyvek.ToArrayAsync();
            var list = await _dataConext.Olvasok.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reader>> GetOlv(int id)
        {
            var dbolv = await _dataConext.Olvasok.FindAsync(id);
            if (dbolv == null)
            {
                return NotFound("Ilyen olvasó nem létezik");
            }

            return Ok(dbolv);
        }


        [HttpPost]
        public async Task<ActionResult<List<Reader>>> AddOlv(Reader r)
        {
            _dataConext.Olvasok.Add(r);
            await _dataConext.SaveChangesAsync();


            return await GetAllOlv();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Reader>>> UpdateOlv(int id, Reader r)
        {
            var dbolv = await _dataConext.Olvasok.FindAsync(id);
            if (dbolv == null)
            {
                return NotFound("Ilyen az olvasó nem létezik");
            }

            dbolv.Name = r.Name;
            dbolv.Address = r.Address;
            dbolv.BirthDate = r.BirthDate;
            await _dataConext.SaveChangesAsync();


            return await GetAllOlv();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Reader>> DeleteOlv(int id)
        {
            var dbolv = await _dataConext.Olvasok.FindAsync(id);
            if (dbolv == null)
            {
                return NotFound("Ilyen olvasó nem létezik");
            }

            _dataConext.Olvasok.Remove(dbolv);
            await _dataConext.SaveChangesAsync();

            return Ok(dbolv);
        }
    }
}
