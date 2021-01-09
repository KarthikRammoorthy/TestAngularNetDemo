using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testapi.Models;
using testapi.Service;

namespace testapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueryController : ControllerBase
    {
        private readonly ILogger<QueryController> _logger;
        private readonly IQueryProcessor _queryProcessor;

        public QueryController(ILogger<QueryController> logger, IQueryProcessor queryProcessor)
        {
            _logger = logger;
            _queryProcessor = queryProcessor;
        }

        [HttpPost]
        public ActionResult<Response> PostQuery(QueryRequest queryItem)
        {
            return _queryProcessor.QueryProcessing(queryItem);
        }
    }
}
