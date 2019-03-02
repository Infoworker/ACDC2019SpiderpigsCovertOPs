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
    /// Controller - Secret lairs
    [Route("api/[controller]")]
    [ApiController]
    public class SpiderpigsController : ControllerBase
    {
        private CovertOPsContext _context;

        /// Secret lair controller
        public SpiderpigsController(CovertOPsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// - Get all spiderpigs observations (Open)
        /// </summary>
        [HttpGet(Name = "GetAllSpiderpigsObservations")]
        public async Task<ActionResult<SpiderpigDto>> GetAllSpiderpigsObservations()
        {
            var allSpiderpigsObservations = await _context.Spiderpigs
                .ToListAsync();

            return Ok(Mapper.Map<List<SpiderpigDto>>(allSpiderpigsObservations));          
        }

        /// <summary>
        /// - Get a spiderpig observation by id (Open)
        /// </summary>
        [HttpGet("{id}", Name = "GetSpiderpigObservation")]        
        public async Task<ActionResult<SpiderpigDto>> GetSpiderpigObservation(int id)
        {
            var oneSpiderpigObservation = await _context.Spiderpigs               
                .FirstOrDefaultAsync(sd => sd.Id == id);

            if (oneSpiderpigObservation == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<SpiderpigDto>(oneSpiderpigObservation));
        }

        /// <summary>
        /// - Change a spiderpig observation (need accesskey)
        /// </summary>
        [HttpPut("{id}", Name = "PutSpiderpigObservation")]
        public async Task<ActionResult<SpiderpigDto>> PutSpiderpigObservation(int id, [FromBody] SpiderpigDto spiderpigObservation)
        {
            var updateSpiderpigObservation = await _context.Spiderpigs         
                .FirstOrDefaultAsync(sd => sd.Id == id);

            if (updateSpiderpigObservation == null)
            {
                return NotFound();
            }
            
            updateSpiderpigObservation.BuildingId = spiderpigObservation.BuildingId;
            updateSpiderpigObservation.Glasses = spiderpigObservation.Glasses;
            updateSpiderpigObservation.Friendly = spiderpigObservation.Friendly;           

            _context.Entry(updateSpiderpigObservation).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// - Add a new spiderpig observation (need accesskey)
        /// </summary>
        [HttpPost(Name = "PostSpiderpigObservation")]
        public async Task<ActionResult<SpiderpigInsertDto>> PostSecretLair([FromBody] SpiderpigInsertDto spiderpigObservation)
        {
            if (spiderpigObservation == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Spiderpig addSpiderpigObservation = Mapper.Map<Spiderpig>(spiderpigObservation);

            _context.Spiderpigs.Add(addSpiderpigObservation);
            await _context.SaveChangesAsync();

            Spiderpig newSpiderpigObservation = await _context.Spiderpigs               
                .FirstOrDefaultAsync(sd => sd.Id == addSpiderpigObservation.Id);

            return CreatedAtRoute(
                routeName: "GetSpiderpigObservation",
                routeValues: new { id = newSpiderpigObservation.Id },
                value: Mapper.Map<SpiderpigDto>(newSpiderpigObservation));
        }
    }
}