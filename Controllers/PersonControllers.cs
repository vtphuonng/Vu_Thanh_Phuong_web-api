using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personinfor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly personContex _context;

    public PersonController(personContex context)
    {
        _context = context;
    }

    // GET: api/Person
    [HttpGet]
    public async Task<ActionResult<IEnumerable<socialPlatformsModels>>> GetPeople()
    {
        return await _context.socailPl.ToListAsync();
    }

    // GET: api/Person/5
    [HttpGet("{id}")]
    public async Task<ActionResult<socialPlatformsModels>> GetPerson(int id)
    {
        var person = await _context.socailPl.FindAsync(id);

        if (person == null)
        {
            return NotFound();
        }

        return person;
    }

    // POST: api/Person
    [HttpPost]
    public async Task<ActionResult<socialPlatformsModels>> PostPerson(socialPlatformsModels person)
    {
        _context.socailPl.Add(person);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPerson), new { id = person.platformid }, person);
    }

    // PUT: api/Person/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPerson(int id, socialPlatformsModels person)
    {
        if (id != person.platformid)
        {
            return BadRequest();
        }

        _context.Entry(person).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonExists(id))
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

    // DELETE: api/Person/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(int id)
    {
        var person = await _context.socailPl.FindAsync(id);
        if (person == null)
        {
            return NotFound();
        }

        _context.socailPl.Remove(person);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("platfom")]
    public async Task<ActionResult<IEnumerable<socialPlatformsModels>>> SearchPlatfom(string platfom)
    {
        var tg = await _context.socailPl.Where(s => s.platfoms == platfom).ToListAsync();

        if (tg == null)
        {
            return NotFound();
        }
        return tg;
    }

    [HttpGet("getLenghtOf")]
    public async Task<ActionResult<IEnumerable<string>>> getByLenght(int getLenghtOf)
    {
        var tgp = await _context.socailPl.Where(s => s.platfoms.Length >= getLenghtOf).Select(s => s.platfoms).ToListAsync();

        if (tgp == null || !tgp.Any())
        {
            return NotFound();
        }

        return tgp;
    }

    private bool PersonExists(int id)
    {
        return _context.socailPl.Any(e => e.platformid == id);
    }
}
