using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACDC2019SpiderpigsCovertOPs.Database;
using ACDC2019SpiderpigsCovertOPs.Models.DbModels;
using ACDC2019SpiderpigsCovertOPs.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace ACDC2019SpiderpigsCovertOPs.Controllers
{
    /// Controller - Persons
    [Route("api/[controller]")]
    [ApiController]
    public class IoTHackingController : ControllerBase
    {

        private CovertOPsContext _context;

        ///
        public IoTHackingController(CovertOPsContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAllTemperatures")]
        public ActionResult GetAllTemperatures()
        {
            var allTemperatures = _context.Sensordatas.ToList();

            return Ok(allTemperatures);          
        }

        [HttpGet("{id}", Name = "GetTemperature")]
        //[Route("{id:int}", Name = nameof(GetSingleFood))]
        public ActionResult<SensordataDto> GetTemperature(int id)
        {
            var result = _context.Sensordatas.FirstOrDefault(sd => sd.Id == id); // data access call

            if (result == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<SensordataDto>(result));
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public ActionResult<SensordataInsertDto> PostTemperatures([FromBody] SensordataInsertDto sensordataInsertDto)
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
            _context.SaveChanges();

            Sensordata newTemperature = _context.Sensordatas.FirstOrDefault(sd => sd.Id == addSensordata.Id);

            return CreatedAtRoute(
                routeName: "GetTemperature",
                routeValues: new { id = newTemperature.Id },
                value: Mapper.Map<SensordataDto>(newTemperature));
        }


    }
}
