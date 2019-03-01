using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACDC2019SpiderpigsCovertOPs.Database;
using ACDC2019SpiderpigsCovertOPs.Models.DbModels;
using ACDC2019SpiderpigsCovertOPs.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACDC2019SpiderpigsCovertOPs.Controllers
{
    /// Controller - Persons
    [Route("api/[controller]")]
    [ApiController]
    public class SecretLairsController : ControllerBase
    {

        private CovertOPsContext _context;

        /// Secret lair controller
        public SecretLairsController(CovertOPsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// - Get all secret lairs around the world (Open)
        /// </summary>
        [HttpGet(Name = "GetAllSecretLairs")]
        public async Task<ActionResult<BuildingDto>> GetAllSecretLairs()
        {
            var allSecretLairs = await _context.Buildings
                .Include(l => l.Position)
                .ToListAsync();

            return Ok(Mapper.Map<List<BuildingDto>>(allSecretLairs));          
        }

        /// <summary>
        /// - Get a secret lair by id (Open)
        /// </summary>
        [HttpGet("{id}", Name = "GetSecretLair")]        
        public async Task<ActionResult<BuildingDto>> GetSecretLair(int id)
        {
            var oneSecretLair = await _context.Buildings
                .Include(l => l.Position)
                .FirstOrDefaultAsync(sd => sd.Id == id);

            if (oneSecretLair == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<BuildingDto>(oneSecretLair));
        }

        /// <summary>
        /// - Change a secret lair (need accesskey)
        /// </summary>
        [HttpPut("{id}", Name = "PutSecretLair")]
        public async Task<ActionResult<BuildingDto>> PutSecretLair(int id, [FromBody] BuildingDto secretLair)
        {
            var updateSecretLair = await _context.Buildings
                .Include(p => p.Position)               
                .FirstOrDefaultAsync(sd => sd.Id == id);

            if (updateSecretLair == null)
            {
                return NotFound();
            }
            
            updateSecretLair.Title = secretLair.Title;
            updateSecretLair.Icon = secretLair.Icon;
            updateSecretLair.Feed = secretLair.Feed;
            updateSecretLair.Position.Lat = secretLair.Position.Lat;
            updateSecretLair.Position.Lng = secretLair.Position.Lng;

            _context.Entry(updateSecretLair).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// - Add a new secret lair (need accesskey)
        /// </summary>
        [HttpPost(Name = "PostSecretLair")]
        public async Task<ActionResult<BuildingInsertDto>> PostSecretLair([FromBody] BuildingInsertDto secretLair)
        {
            if (secretLair == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Building addSecretLair = Mapper.Map<Building>(secretLair);

            _context.Buildings.Add(addSecretLair);
            await _context.SaveChangesAsync();

            Building newSecretLair = await _context.Buildings
                .Include(l => l.Position)
                .FirstOrDefaultAsync(sd => sd.Id == addSecretLair.Id);

            return CreatedAtRoute(
                routeName: "GetSecretLair",
                routeValues: new { id = newSecretLair.Id },
                value: Mapper.Map<BuildingDto>(newSecretLair));
        }
    }
}