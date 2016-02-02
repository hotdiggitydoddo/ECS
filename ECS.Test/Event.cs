using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Test
{
    public class Event
    {
        public Guid Id { get; private set; }
        public Dictionary<string, object> Parameters { get; private set; }
        public int Type { get; private set; }
        public bool Valid { get; set; }
        public Event(int type, Dictionary<string, object> parameters)
        {
            Id = Guid.NewGuid();
            Type = type;
            Parameters = parameters;
            Valid = true;
        }
    }
}
