using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Data;
using WarehouseManagement.Models;

namespace WarehouseManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMovementsController : ControllerBase
    {
        private readonly WarehouseManagementContext _context;

        public StockMovementsController(WarehouseManagementContext context)
        {
            _context = context;
        }

        // GET: api/StockMovements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockMovements>>> GetStockMovements()
        {
            return await _context.StockMovements.ToListAsync();
        }

        // GET: api/StockMovements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockMovements>> GetStockMovements(int id)
        {
            var stockMovements = await _context.StockMovements.FindAsync(id);

            if (stockMovements == null)
            {
                return NotFound();
            }

            return stockMovements;
        }

        // PUT: api/StockMovements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockMovements(int id, StockMovements stockMovements)
        {
            if (id != stockMovements.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockMovements).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockMovementsExists(id))
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

        // POST: api/StockMovements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockMovements>> PostStockMovements(StockMovements stockMovements)
        {
            _context.StockMovements.Add(stockMovements);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockMovements", new { id = stockMovements.Id }, stockMovements);
        }

        // DELETE: api/StockMovements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockMovements(int id)
        {
            var stockMovements = await _context.StockMovements.FindAsync(id);
            if (stockMovements == null)
            {
                return NotFound();
            }

            _context.StockMovements.Remove(stockMovements);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockMovementsExists(int id)
        {
            return _context.StockMovements.Any(e => e.Id == id);
        }
    }
}
