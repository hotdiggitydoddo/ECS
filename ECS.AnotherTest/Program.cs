using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.AnotherTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var _world = new World();
            var entity = _world.CreateEntity();
            var timer = new GameTimer();

            _world.EntityMasks[entity].ClearAll();
            _world.EntityMasks[entity].SetBit(ComponentType.ConsoleRendererComponent);
            _world.EntityMasks[entity].SetBit(ComponentType.HealthComponent);
            _world.EntityMasks[entity].SetBit(ComponentType.RegenerationComponent);
            _world.EntityMasks[entity].SetBit(ComponentType.FlammableComponent);

            _world.HealthComponents[entity].MaxHealth = 100;
            _world.HealthComponents[entity].CurrentHealth = 100;
            _world.HealthComponents[entity].Damage = 15;

            _world.RegenerationComponents[entity].Frequency = 2000f;
            _world.RegenerationComponents[entity].AmountToHeal = 2;

            _world.FlammableComponents[entity].Duration = 10000;
            _world.FlammableComponents[entity].Frequency = 1500;
            _world.FlammableComponents[entity].Damage = 6;

            while (true)
            {
                timer.Reset();
                _world.Update(166);
                while (timer.GetTicks() < 166);
            }
        }
    }
}
