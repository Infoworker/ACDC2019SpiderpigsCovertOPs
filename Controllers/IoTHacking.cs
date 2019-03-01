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

        [HttpGet(Name = "GetAllTempratures")]
        public ActionResult GetAllTempratures()
        {
            var allTempratures = _context.Sensordatas.ToList();

            return Ok(allTempratures);          
        }

        [HttpGet("{id}", Name = "GetTemprature")]
        //[Route("{id:int}", Name = nameof(GetSingleFood))]
        public ActionResult<SensordataDto> GetTemprature(int id)
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
        public ActionResult<SensordataInsertDto> PostTempratures([FromBody] SensordataInsertDto sensordataInsertDto)
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

            Sensordata newTemprature = _context.Sensordatas.FirstOrDefault(sd => sd.Id == addSensordata.Id);

            return CreatedAtRoute(
                routeName: "GetTemprature",
                routeValues: new { id = newTemprature.Id },
                value: Mapper.Map<SensordataDto>(newTemprature));
        }


    }
}
