using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentwebAPI.DataDB;

namespace studentwebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblstudentInfoesController : ControllerBase
    {
        private readonly CRUDContext _context;

        public TblstudentInfoesController(CRUDContext context)
        {
            _context = context;
        }

        // GET: api/TblstudentInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblstudentInfo>>> GetTblstudentInfos()
        {
          if (_context.TblstudentInfos == null)
          {
              return NotFound();
          }
            return await _context.TblstudentInfos.ToListAsync();
        }

        // GET: api/TblstudentInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblstudentInfo>> GetTblstudentInfo(int id)
        {
          if (_context.TblstudentInfos == null)
          {
              return NotFound();
          }
            var tblstudentInfo = await _context.TblstudentInfos.FindAsync(id);

            if (tblstudentInfo == null)
            {
                return NotFound();
            }

            return tblstudentInfo;
        }

        // PUT: api/TblstudentInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblstudentInfo(int id, TblstudentInfo tblstudentInfo)
        {
            if (id != tblstudentInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblstudentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblstudentInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblstudentInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblstudentInfo>> PostTblstudentInfo(TblstudentInfo tblstudentInfo)
        {
          if (_context.TblstudentInfos == null)
          {
              return Problem("Entity set 'CRUDContext.TblstudentInfos'  is null.");
          }
            _context.TblstudentInfos.Add(tblstudentInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblstudentInfo", new { id = tblstudentInfo.Id }, tblstudentInfo);
        }

        // DELETE: api/TblstudentInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblstudentInfo(int id)
        {
            if (_context.TblstudentInfos == null)
            {
                return NotFound();
            }
            var tblstudentInfo = await _context.TblstudentInfos.FindAsync(id);
            if (tblstudentInfo == null)
            {
                return NotFound();
            }

            _context.TblstudentInfos.Remove(tblstudentInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblstudentInfoExists(int id)
        {
            return (_context.TblstudentInfos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
