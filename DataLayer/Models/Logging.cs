using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Logging : EntityBase
    {
        public string Message { get; set; }
        public Guid SeverityId { get; set; }
        public Severity Severity { get; set; }
    }
}
