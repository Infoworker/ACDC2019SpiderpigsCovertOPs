using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ACDC2019SpiderpigsCovertOPs.Models.ViewModels;

namespace ACDC2019SpiderpigsCovertOPs.Controllers
{
    /// Controller for the Flow Challange:
    [Route("api/[controller]")]
    [ApiController]
    public class FlowChallangesController : ControllerBase
    {
        /// <summary>
        /// - Gets all persondata for the Flow Challange
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var persons = new List<FlowChallangePersonsDto> {
                new FlowChallangePersonsDto{ Id=1, FirstName="Bart", LastName="Simpson", Email="sd@infoworker.no", Birthday=new DateTime(2005, 05, 15), Relation="Tier1", Role="Punk"},
                new FlowChallangePersonsDto{ Id=1, FirstName="Marge", LastName="Simpson", Email="rb@infoworker.no", Birthday=new DateTime(1978, 02, 28), Relation="Tier1", Role="CEO"},
                new FlowChallangePersonsDto{ Id=1, FirstName="Maggie", LastName="Simpson", Email="ak@infoworker.no", Birthday=new DateTime(2017, 10, 21), Relation="Tier1", Role="Cute"},
                new FlowChallangePersonsDto{ Id=1, FirstName="Lisa", LastName="Simpson", Email="ml@infoworker.no", Birthday=new DateTime(2008, 11, 05), Relation="Tier1", Role="Genius"},
                new FlowChallangePersonsDto{ Id=1, FirstName="Homer", LastName="Simpson", Email="bo@infoworker.no", Birthday=new DateTime(1975, 12, 12), Relation="Tier1", Role="Drunk"},
                new FlowChallangePersonsDto{ Id=1, FirstName="Hussain", LastName="Flanders", Email="ha@infoworker.no", Birthday=new DateTime(1994, 02, 28), Relation="Tier2", Role="Someone"},
                new FlowChallangePersonsDto{ Id=1, FirstName="Kokulan", LastName="Burns", Email="kr@infoworker.no", Birthday=new DateTime(1968, 01, 11), Relation="Tier2", Role="Someone"},
                new FlowChallangePersonsDto{ Id=1, FirstName="Ronny", LastName="Syzlak", Email="rs@infoworker.no", Birthday=new DateTime(1957, 08, 15), Relation="Tier2", Role="CEO"},
            };

            return Ok(persons);
        }
    }
}