using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealKonyvtar.Server.Data;
using RealKonyvtar.Shared;

namespace RealKonyvtar.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KolcsonzesController : ControllerBase
    {
        private readonly DataContext _dataConext;

        public KolcsonzesController(DataContext dataConext)
        {
            _dataConext = dataConext;
        }

        public async Task<List<Kolcsonzes>> GetAllKolcs()
        {
            //var list = await _dataConext.Konyvek.ToArrayAsync();
            var list = await _dataConext.Kolcsonzes.ToListAsync();
            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kolcsonzes>> GetKolcs(int id)
        {
            var dbkonyv = await _dataConext.Kolcsonzes.FindAsync(id);
            if (dbkonyv == null)
            {
                return NotFound("Ilyen kölcsönzés nem létezik");
            }

            return Ok(dbkonyv);
        }


        [HttpPost]
        public async Task<ActionResult<List<Kolcsonzes>>> AddKolcs(Kolcsonzes k)
        {
            var kolcsonzesek = await GetAllKolcs();
            foreach (var kolcs in kolcsonzesek)
            {
                if(kolcs.KonyvId == k.KonyvId)
                    return BadRequest("Ezt a könyvet már kikölcsönözték.");
            }
            if (k.BringOut.Date < DateTime.Now.Date)
                return BadRequest("Rossz kiviteli idő!");
            else if (k.BringOut > k.BringBack)
                return BadRequest("Rossz visszahozatali idő!");
            else
            {
                _dataConext.Kolcsonzes.Add(k);
                await _dataConext.SaveChangesAsync();


                return await GetAllKolcs();
            }
            
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Kolcsonzes>>> UpdateKolcs(int id, Kolcsonzes k)
        {
            var dbkonyv = await _dataConext.Kolcsonzes.FindAsync(id);
            if (dbkonyv == null)
            {
                return NotFound("Ilyen kölcsönzés nem létezik");
            }

            if (k.BringOut.Date < DateTime.Now.Date)
                return BadRequest("Rossz kiviteli idő!");
            else if (k.BringOut > k.BringBack)
                return BadRequest("Rossz visszahozatali idő!");

            dbkonyv.OlvId = k.OlvId;
            dbkonyv.KonyvId = k.KonyvId;
            dbkonyv.BringOut = k.BringOut;
            dbkonyv.BringBack = k.BringBack;

            await _dataConext.SaveChangesAsync();


            return await GetAllKolcs();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Kolcsonzes>> DeleteKolcs(int id)
        {
            var dbkonyv = await _dataConext.Kolcsonzes.FindAsync(id);
            if (dbkonyv == null)
            {
                return NotFound("Ilyen kölcsönzés nem létezik");
            }

            _dataConext.Kolcsonzes.Remove(dbkonyv);
            await _dataConext.SaveChangesAsync();

            return Ok(dbkonyv);
        }
    }
}
