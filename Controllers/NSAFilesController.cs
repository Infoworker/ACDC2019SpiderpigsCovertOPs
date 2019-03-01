using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACDC2019SpiderpigsCovertOPs.Database;
using ACDC2019SpiderpigsCovertOPs.Models.DbModels;
using ACDC2019SpiderpigsCovertOPs.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ACDC2019SpiderpigsCovertOPs.Controllers
{
    /// Controller - Persons
    [Route("api/[controller]")]
    [ApiController]
    public class NSAFilesController : ControllerBase
    {
        private readonly CovertOPsContext _context;

        ///
        public NSAFilesController(CovertOPsContext context)
        {
            _context = context;

            // if(_context.Persons.Count() == 0)
            // {
            //     _context.Persons.Add(new Person{ FirstName="Bart", LastName="Simpsons"});
            //     _context.Persons.Add(new Person{ FirstName="Lisa", LastName="Simpsons"});
            //     //_context.Persons.Add(new Person{ FirstName="Maggie", LastName="Simpsons"});
            //     _context.SaveChanges();
            // }
        }

        /// <summary>
        /// - Gets all persondata for the Flow Challange
        /// </summary>
        [HttpGet("Persons")]
        public ActionResult<IEnumerable<string>> GetPersons()
        {
            var persons = new List<FlowChallangePersonsDto> {
                new FlowChallangePersonsDto{ Id=1, FirstName="Bart", LastName="Simpson", Email="sd@infoworker.no", Birthday=new DateTime(2005, 05, 15), Relation="Tier1", Role="Punk"},
                new FlowChallangePersonsDto{ Id=2, FirstName="Marge", LastName="Simpson", Email="rb@infoworker.no", Birthday=new DateTime(1978, 02, 28), Relation="Tier1", Role="CEO"},
                new FlowChallangePersonsDto{ Id=3, FirstName="Maggie", LastName="Simpson", Email="ak@infoworker.no", Birthday=new DateTime(2017, 10, 21), Relation="Tier1", Role="Cute"},
                new FlowChallangePersonsDto{ Id=4, FirstName="Lisa", LastName="Simpson", Email="ml@infoworker.no", Birthday=new DateTime(2008, 11, 05), Relation="Tier1", Role="Genius"},
                new FlowChallangePersonsDto{ Id=5, FirstName="Homer", LastName="Simpson", Email="bo@infoworker.no", Birthday=new DateTime(1975, 12, 12), Relation="Tier1", Role="Drunk"},
                new FlowChallangePersonsDto{ Id=6, FirstName="Hussain", LastName="Flanders", Email="ha@infoworker.no", Birthday=new DateTime(1994, 02, 28), Relation="Tier2", Role="Someone"},
                new FlowChallangePersonsDto{ Id=7, FirstName="Kokulan", LastName="Burns", Email="kr@infoworker.no", Birthday=new DateTime(1968, 01, 11), Relation="Tier2", Role="Someone"},
                new FlowChallangePersonsDto{ Id=8, FirstName="Ronny", LastName="Syzlak", Email="rs@infoworker.no", Birthday=new DateTime(1957, 08, 15), Relation="Tier2", Role="CEO"},
            };

            return Ok(persons);
        }

        
        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}