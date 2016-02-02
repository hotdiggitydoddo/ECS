using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ECS.Test.Components;

namespace ECS.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var entity = new Entity();
            var timer = new GameTimer();
            entity.AttachComponent(new HealthComponent());
            entity.AttachComponent(new ArmorComponent());
            entity.AttachComponent(new FlammableComponent());
            entity.AttachComponent(new RegenerateComponent());
            entity.AttachComponent(new ConsoleRendererComponent());
            entity.Init();
            entity.FireEvent(new Event(EventType.TakeDamage, new Dictionary<string, object> { {"amount", 10} }));

            while (true)
            {
                timer.Reset();
                //Console.WriteLine("tick");
                entity.Update(166);
                while (timer.GetTicks() < 166);
            }
        }
    }
}
