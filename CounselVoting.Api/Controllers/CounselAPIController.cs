using Counsel.DAL.Models;
using Counsel.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace CounselVoting.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CounselAPIController : ControllerBase
    {
        private readonly ILogger<CounselAPIController> logger;
        private readonly IService service;

        public CounselAPIController(
            ILogger<CounselAPIController> logger,
            IService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpPost]
        public Measure PostMeasure([FromBody] Measure modelMeasure)
        {
            return service.InsertMeasure(modelMeasure);
        }


        [HttpDelete("{id}")]
        public Measure DeleteMeasure(long id)
        {
            return service.DeleteMeasure(id);
        }

        [HttpGet("{id}")]
        public Measure GetMeasureById(int id)
        {
            return service.GetMeasureById(id);
        }

        [HttpGet]
        public IEnumerable<Measure> GetMeasure()
        {
            return service.GetMeasure();
        }

        [HttpPost("vote")]
        public Vote PostVote([FromBody] Vote modelMeasure)
        {
            return service.InsertVote(modelMeasure);
        }

        [HttpGet("voterNames")]
        public IEnumerable<string> GetVoterName()
        {
            return service.GetVoterName();
        }
    }
}
