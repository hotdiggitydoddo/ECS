using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Test.Components
{
    class HealthComponent : Component
    {
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public override void FireEvent(Event e)
        {
            switch (e.Type)
            {
                case EventType.TakeDamage:
                    CurrentHealth -= (int)e.Parameters["amount"];
                    Entity.FireEvent(new Event(EventType.Render,
                        new Dictionary<string, object>
                        {
                            {
                                "text",
                                string.Format("Entity #{0} has been damaged for {1} damage.", Entity.Id,
                                    (int) e.Parameters["amount"])
                            }
                        }));
                        break;

                case EventType.Regenerate:
                    if (CurrentHealth < MaxHealth)
                    {
                        CurrentHealth += (int)e.Parameters["amount"];
                        Entity.FireEvent(new Event(EventType.Render,
                       new Dictionary<string, object>
                       {
                            {
                                "text",
                                string.Format("Entity #{0} has been healed for {1} HP.", Entity.Id,
                                    (int) e.Parameters["amount"])
                            }
                       }));
                    }
                    if (CurrentHealth >= MaxHealth)
                        CurrentHealth = MaxHealth;
                    break;
            }
        }

        public override void Init(Entity e)
        {
            MaxHealth = 100;
            CurrentHealth = 100;
            Priority = 100;
            base.Init(e);
        }
    }
}
