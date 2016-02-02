using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Test.Components
{
    public class ConsoleRendererComponent : Component
    {
        public override void FireEvent(Event e)
        {
            if (e.Type == EventType.Render)
            {
                Console.WriteLine(e.Parameters["text"]);
            }
        }

        public override void Init(Entity e)
        {
            Priority = 999;
            base.Init(e);
        }
    }
}
