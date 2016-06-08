using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoggingSample.Logger;
using LoggingSample.Filters;

namespace LoggingSample.Controllers
{
    //  [Authorize]
    [LogFilter]
    public class ValuesController : ApiController
    {
        private readonly ICoreLogger _coreLogger;

        public ValuesController(ICoreLogger coreLogger)
        {
            _coreLogger = coreLogger;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
            return new string[] { "value1", "value2" };
        }
    }
}
