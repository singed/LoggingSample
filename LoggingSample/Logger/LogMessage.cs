using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoggingSample.Logger
{
    public class LogMessage
    {
        public int StatusCode { get; set; }
        public string RequestMethod { get; set; }
        public string RequestUri { get; set; }
        public string ElapsedMls { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}",
                       StatusCode,
                       RequestMethod,
                       RequestUri,
                       ElapsedMls,
                       Message);
        }
    }
}