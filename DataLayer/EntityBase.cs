using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
    }
}
