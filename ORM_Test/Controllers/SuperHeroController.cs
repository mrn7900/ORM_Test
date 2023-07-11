using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM_Test.Data;
using ORM_Test.Models;

namespace ORM_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _Context;
        public SuperHeroController(DataContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _Context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> Post(SuperHero Hero)
        {
            _Context.SuperHeroes.Add(Hero);
            await _Context.SaveChangesAsync();
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> Update(SuperHero Req)
        {
            var dbHero = await _Context.SuperHeroes.FindAsync(Req.Id);
            if (dbHero == null)
                return NotFound();
            dbHero.Name=Req.Name;
            dbHero.FirstName=Req.FirstName;
            dbHero.LastName=Req.LastName;
            dbHero.Place = Req.Place;

            await _Context.SaveChangesAsync();

            return Ok(await _Context.SuperHeroes.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var dbHero = await _Context.SuperHeroes.FindAsync(id);
            if (dbHero == null)
                return NotFound();
            _Context.SuperHeroes.Remove(dbHero);
            await _Context.SaveChangesAsync();
            return Ok(await _Context.SuperHeroes.ToListAsync());
        }
    }
}
