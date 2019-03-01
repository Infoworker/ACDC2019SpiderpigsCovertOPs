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
    public class ShitHappensController : ControllerBase
    {

        private CovertOPsContext _context;

        ///
        public ShitHappensController(CovertOPsContext context)
        {
            _context = context;
        }

        ///
        [HttpGet(Name = "GetAllIncidents")]
        public ActionResult GetAllIncidents()
        {
            var allIncidents = _context.Incidents.ToList();

            return Ok(allIncidents);          
        }

        ///
        [HttpGet("{id}", Name = "GetIncident")]        
        public ActionResult<IncidentDto> GetIncident(int id)
        {
            var result = _context.Incidents.FirstOrDefault(sd => sd.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<IncidentDto>(result));
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<Incident>> PutIncident(int id, [FromBody] Incident incident)
        {
            var result = _context.Incidents.FirstOrDefault(sd => sd.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            _context.Entry(incident).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public ActionResult<IncidentInsertDto> PostIncident([FromBody] IncidentInsertDto incidentInsertDto)
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
            _context.SaveChanges();

            Incident newIncident = _context.Incidents.FirstOrDefault(sd => sd.Id == addIncident.Id);

            return CreatedAtRoute(
                routeName: "GetIncident",
                routeValues: new { id = newIncident.Id },
                value: Mapper.Map<IncidentDto>(newIncident));
        }
    }
}
