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
    /// Controller - IoT is taking over the world!
    [Route("api/[controller]")]
    [ApiController]
    public class IoTHackingsController : ControllerBase
    {
        private CovertOPsContext _context;

        /// IoT controller
        public IoTHackingsController(CovertOPsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// - Get all IoT temperature readings around the world (Open)
        /// </summary>
        [HttpGet(Name = "GetAllIoTTemperatures")]
        public async Task<ActionResult<SensordataDto>> GetAllIoTTemperatures()
        {
            var allIoTTemperatures = await _context.Sensordatas
                .ToListAsync();

            return Ok(Mapper.Map<List<SensordataDto>>(allIoTTemperatures));          
        }

        /// <summary>
        /// - Get a IoT temperature by id (Open)
        /// </summary>
        [HttpGet("{id}", Name = "GetIoTTemperature")]        
        public async Task<ActionResult<SensordataDto>> GetIoTTemperature(int id)
        {
            var oneTemprature = await _context.Sensordatas
                .FirstOrDefaultAsync(sd => sd.Id == id);

            if (oneTemprature == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<SensordataDto>(oneTemprature));
        }

        /// <summary>
        /// - Add a new IOT temperature (need accesskey)
        /// </summary>
        [HttpPost(Name = "PostIoTTemperatures")]
        public async Task<ActionResult<SensordataInsertDto>> PostIoTTemperatures([FromBody] SensordataInsertDto sensordataInsertDto)
        {
            if (sensordataInsertDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sensordata addSensordata = Mapper.Map<Sensordata>(sensordataInsertDto);

            _context.Sensordatas.Add(addSensordata);
            await _context.SaveChangesAsync();

            Sensordata newTemperature = await _context.Sensordatas
                .FirstOrDefaultAsync(sd => sd.Id == addSensordata.Id);

            return CreatedAtRoute(
                routeName: "GetIoTTemperature",
                routeValues: new { id = newTemperature.Id },
                value: Mapper.Map<SensordataDto>(newTemperature));
        }
    }
}