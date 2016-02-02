using System;

namespace ECS.AnotherTest.Subsystems
{
    public class ConsoleDisplaySubsystem : Subsystem
    {

        public ConsoleDisplaySubsystem(World world) : base(world)
        {
            ComponentMask.SetBit(ComponentType.ConsoleRendererComponent);
        }

        public override void Update(float dt)
        {
            uint entity;

            for (entity = 0; entity < World.MaxEntities; entity++)
            {
                if (!ComponentMask.IsSubsetOf(World.EntityMasks[entity])) continue;

                var renderer = World.ConsoleRendererComponents[entity];

                foreach (var message in renderer.Messages)
                    Console.WriteLine("Entity #{0}: {1}", entity, message);

                renderer.Messages.Clear();
            }
        }
    }
}
