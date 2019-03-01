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
    /// Controller - NSA files
    [Route("api/[controller]")]
    [ApiController]
    public class NSAFilesController : ControllerBase
    {
        private readonly CovertOPsContext _context;

        /// Secret NSA files
        public NSAFilesController(CovertOPsContext context)
        {
            _context = context;           
        }

        /// <summary>
        /// - Gets all secret personel files
        /// </summary>
        [HttpGet(Name = "GetAllNSAFiles")]
        public async Task<ActionResult<PersonDto>> GetAllNSAFiles()
        {
            var allNSAFiles = await _context.Persons
                .ToListAsync();

            return Ok(Mapper.Map<List<PersonDto>>(allNSAFiles));
        }

        /// <summary>
        /// - Get a secret personel file by id (Open)
        /// </summary>
        [HttpGet("{id}", Name = "GetNSAFile")]        
        public async Task<ActionResult<PersonDto>> GetNSAFile(int id)
        {
            var oneNSAFile = await _context.Persons                
                .FirstOrDefaultAsync(sd => sd.Id == id);

            if (oneNSAFile == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PersonDto>(oneNSAFile));
        }

        /// <summary>
        /// - Change a secret personel file (need accesskey)
        /// </summary>
        [HttpPut("{id}", Name = "PutNSAFile")]
        public async Task<ActionResult<PersonDto>> PutSecretLair(int id, [FromBody] PersonDto secretNSAFile)
        {
            var updateNSAFile = await _context.Persons
                .Include(l => l.Location)               
                .FirstOrDefaultAsync(sd => sd.Id == id);

            if (updateNSAFile == null)
            {
                return NotFound();
            }
            
            updateNSAFile.FirstName = secretNSAFile.FirstName;
            updateNSAFile.LastName = secretNSAFile.LastName;
            updateNSAFile.Email = secretNSAFile.Email;
            //updateNSAFile.Location. = secretLair.Position.Lat;
            //updateNSAFile.Position.Lng = secretLair.Position.Lng;

            _context.Entry(updateNSAFile).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        /// <summary>
        /// - Add a new secret personel file (need accesskey)
        /// </summary>
        [HttpPost(Name = "PostNSAFile")]
        public async Task<ActionResult<PersonInsertDto>> PostNSAFile([FromBody] PersonInsertDto secretNSAFile)
        {
            if (secretNSAFile == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Person addNSAFile = Mapper.Map<Person>(secretNSAFile);

            _context.Persons.Add(addNSAFile);
            await _context.SaveChangesAsync();

            Person newNSAFile = await _context.Persons
                .Include(l => l.Location)
                .FirstOrDefaultAsync(p => p.Id == addNSAFile.Id);
            
            return CreatedAtRoute(
                routeName: "GetNSAFile",
                routeValues: new { id = newNSAFile.Id },
                value: Mapper.Map<PersonDto>(newNSAFile));
        }        
    }
}