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
    /// Controller - Shit happens all the time
    [Route("api/[controller]")]
    [ApiController]
    public class ShitHappensController : ControllerBase
    {
        private CovertOPsContext _context;

        /// Shit happens controller
        public ShitHappensController(CovertOPsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// - Get all the shits that happens around the globe (Open)
        /// </summary>
        [HttpGet(Name = "GetAllShitHappens")]
        public async Task<ActionResult<IncidentDto>> GetAllShitHappens()
        {
            var allShitHappens = await _context.Incidents
                .ToListAsync();

            return Ok(Mapper.Map<List<IncidentDto>>(allShitHappens));          
        }

        /// <summary>
        /// - Get some shit by id (Open)
        /// </summary>
        [HttpGet("{id}", Name = "GetShitHappen")]        
        public async Task<ActionResult<IncidentDto>> GetShitHappen(int id)
        {
            var aShitHappen = await _context.Incidents
                .FirstOrDefaultAsync(sd => sd.Id == id);

            if (aShitHappen == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<IncidentDto>(aShitHappen));
        }

        /// <summary>
        /// - Change a shite that happened (need accesskey)
        /// </summary>
        [HttpPut("{id}", Name = "PutShitHappen")]
        public async Task<ActionResult<IncidentDto>> PutShitHappen(int id, [FromBody] IncidentDto incident)
        {
            var updateShitHappen = await _context.Incidents
                .FirstOrDefaultAsync(sd => sd.Id == id);

            if (updateShitHappen == null)
            {
                return NotFound();
            }

            updateShitHappen.Temperature = incident.Temperature;
            updateShitHappen.Responsible = incident.Responsible;
            updateShitHappen.Location = incident.Location;
            updateShitHappen.Status = incident.Status;
            updateShitHappen.Date = incident.Date;
            
            _context.Entry(updateShitHappen).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// - Add a new shit happen (need accesskey)
        /// </summary>
        [HttpPost(Name = "PostShitHappen")]
        public async Task<ActionResult<IncidentInsertDto>> PostShitHappen([FromBody] IncidentInsertDto incidentInsertDto)
        {
            if (incidentInsertDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Incident addIncident = Mapper.Map<Incident>(incidentInsertDto);

            _context.Incidents.Add(addIncident);
            await _context.SaveChangesAsync();

            Incident newIncident = await _context.Incidents
                .FirstOrDefaultAsync(sd => sd.Id == addIncident.Id);

            return CreatedAtRoute(
                routeName: "GetShitHappen",
                routeValues: new { id = newIncident.Id },
                value: Mapper.Map<IncidentDto>(newIncident));
        }
    }
}