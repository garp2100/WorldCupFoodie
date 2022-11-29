﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldCupFoodie.Models;

namespace WorldCupFoodie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryListsController : ControllerBase
    {
        private readonly WorldCupFoodieContext _context;

        public GroceryListsController(WorldCupFoodieContext context)
        {
            _context = context;
        }

        // GET: api/GroceryLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroceryList>>> GetGroceryLists()
        {
            return await _context.GroceryLists.ToListAsync();
        }

        // GET: api/GroceryLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryList>> GetGroceryList(int id)
        {
            var groceryList = await _context.GroceryLists.FindAsync(id);

            if (groceryList == null)
            {
                return NotFound();
            }

            return groceryList;
        }

        // PUT: api/GroceryLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroceryList(int id, GroceryList groceryList)
        {
            if (id != groceryList.Id)
            {
                return BadRequest();
            }

            _context.Entry(groceryList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryListExists(id))
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

        // POST: api/GroceryLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroceryListPost>> PostGroceryList(GroceryListPost groceryList)
        {
            var gl = new GroceryList { Id = groceryList.Id, Ingredients = groceryList.Ingredients, MatchId = groceryList.MatchId};
            _context.GroceryLists.Add(gl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroceryList", new { id = gl.Id }, gl);
        }

        // DELETE: api/GroceryLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroceryList(int id)
        {
            var groceryList = await _context.GroceryLists.FindAsync(id);
            if (groceryList == null)
            {
                return NotFound();
            }

            _context.GroceryLists.Remove(groceryList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroceryListExists(int id)
        {
            return _context.GroceryLists.Any(e => e.Id == id);
        }
    }
}
