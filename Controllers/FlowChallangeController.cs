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
        /// - Gets all issues for the Flow Challange
        /// </summary>
        [HttpGet("Issues")]
        public ActionResult<IEnumerable<string>> GetIssues()
        {
            var issues = new List<FlowChallangeIssuesDto> {
                new FlowChallangeIssuesDto{ Id=1, Sender="Bart Simpson", Email="sd@infoworker.no", Issue="Why the hell did you let Sideshow Bob loose?!?!!!" },
                new FlowChallangeIssuesDto{ Id=2, Sender="Mr. Burns", Email="rb@infoworker.no", Issue="I like to have a meeting raising the taxation of solar power, cannot have it competing with my nuclear power plant. If not, I will raise hell!" },
                new FlowChallangeIssuesDto{ Id=3, Sender="Ned Flanders", Email="ak@infoworker.no", Issue="I demand that Homer needs to get dressed, can’t have him running around naked all the time." },
                new FlowChallangeIssuesDto{ Id=4, Sender="Moe Szyslak", Email="ml@infoworker.no", Issue="Please send all the Arctic Challenge participants to Moe’s…. PLEASE!" },
                new FlowChallangeIssuesDto{ Id=5, Sender="Krusty the Clown", Email="bo@infoworker.no", Issue="Budget is way to low - need it increased if my new TV-Show is going to be as expensive as I hope!" }
            };

            return Ok(issues);
        }
    }
}