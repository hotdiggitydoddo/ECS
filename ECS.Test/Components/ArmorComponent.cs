using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Test.Components
{
    class ArmorComponent : Component
    {
        public decimal DamageAbsoption { get; set; }
        public override void FireEvent(Event e)
        {
            if (e.Type == EventType.TakeDamage)
            {
                var amount = (int) e.Parameters["amount"];
                amount -= (int)(amount * (1 / DamageAbsoption));
                e.Parameters["amount"] = amount;
            }
        }

        public override void Init(Entity e)
        {
            DamageAbsoption = 10;
            Priority = 99;
            base.Init(e);
        }
    }
}
