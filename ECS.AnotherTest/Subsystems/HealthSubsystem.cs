namespace ECS.AnotherTest.Subsystems
{
    public class HealthSubsystem : Subsystem
    {
        public HealthSubsystem(World world) : base(world)
        {
            ComponentMask.SetBit(ComponentType.HealthComponent);
            ComponentMask.SetBit(ComponentType.RegenerationComponent);
            ComponentMask.SetBit(ComponentType.ConsoleRendererComponent);
        }


        public override void Update(float dt)
        {
            uint entity;

            for (entity = 0; entity < World.MaxEntities; entity++)
            {
                if (!ComponentMask.IsSubsetOf(World.EntityMasks[entity])) continue;

                var health = World.HealthComponents[entity];
                var regen = World.RegenerationComponents[entity];
                var renderer = World.ConsoleRendererComponents[entity];

                if (regen.Frequency > 0)
                {
                    if (regen.ElapsedTime >= regen.Frequency && health.CurrentHealth != health.MaxHealth)
                    {
                        health.CurrentHealth += regen.AmountToHeal;
                        regen.ElapsedTime = 0;
                        renderer.Messages.Add(string.Format("healed for {0} points.  Health: {1}/{2} ({3})",
                            regen.AmountToHeal, health.CurrentHealth, health.MaxHealth, health.IsAlive ? "ALIVE" : "DEAD"));
                    }
                    else
                        regen.ElapsedTime += dt;
                }

                if (health.Damage == 0) continue;

                health.CurrentHealth -= health.Damage;
                renderer.Messages.Add(string.Format("damaged for {0} points.  Health: {1}/{2} ({3})",
                            health.Damage, health.CurrentHealth, health.MaxHealth, health.IsAlive ? "ALIVE": "DEAD"));
                health.Damage = 0;
                
            }

        }
    }
}
