using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TlouAPI.Data;
using TlouAPI.DTOs;
using TlouAPI.Models;

namespace TlouAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TlouController : ControllerBase
    {
        private readonly DataContext _context;

        public TlouController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("id")]
        public async Task<ActionResult<Character>> GetCharacterById(int id)
        {
            var charater = await _context.Characters
                .Include(c => c.Backpack)
                .Include(c => c.Weapons)
                .Include(c => c.Factions)
                .FirstOrDefaultAsync(c => c.Id == id);

            return Ok(charater);
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDTO request)
        {
            var newCharacter = new Character
            {
                Name = request.Name,
            };

            var backpack = new Backpack { Description = request.Backpack.Description, Character = new Character() };
            var weapons = request.Weapons.Select(w => new Weapon { Name = w.Name, Character = new Character() }).ToList();
            var factions = request.Factions.Select(f => new Faction { Name = f.Name, Characters = new List<Character> { newCharacter } }).ToList();

            newCharacter.Backpack = backpack;
            newCharacter.Weapons = weapons;
            newCharacter.Factions = factions;

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return Ok(await _context.Characters.Include(c => c.Backpack).Include(c => c.Weapons).ToListAsync());
        }
    }
}
