using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Test.Components
{
    public class RegenerateComponent : Component
    {
        private float _frequency;
        private float _elapsed;
        public override void FireEvent(Event e)
        {
            
        }

        public override void Init(Entity e)
        {
            _frequency = 5000f;
            _elapsed = 0f;
            Priority = 85;
            base.Init(e);
        }

        public override void Update(float dt)
        {
            _elapsed += dt;

            if (_elapsed >= _frequency)
            {
                Entity.FireEvent(new Event(EventType.Regenerate, new Dictionary<string, object> {{"amount", 3}}));
                _elapsed = 0;
            }
        }
    }
}
