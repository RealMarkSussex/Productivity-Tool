using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Logging
    {
        public int LoggingId { get; set; }
        public string Message { get; set; }
        public int SeverityId { get; set; }
    }
}
