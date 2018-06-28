using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetup.GraphQLNet.App;

namespace GraphQLNet.Demo20.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class GraphQLController: Controller
    {
        private readonly SeriesGraphQueryExecuter _executer;

        public GraphQLController(SeriesGraphQueryExecuter exec)
        {
            _executer = exec;
        }

        [HttpGet]
        public string Get()
        {
            return "Ping Ok";
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var result = await _executer.ExecuteQuery(query);

            var hasAnySuccess = result.Errors == null || result.Errors?.Count == 0;

            if (!hasAnySuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
