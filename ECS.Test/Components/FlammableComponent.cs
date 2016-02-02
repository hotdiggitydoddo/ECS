using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Test.Components
{
    public class FlammableComponent : Component
    {
        private float _frequency;
        private float _elapsed;
        private float _duration;
        private float _totalTime;
        private bool _onFire;
        public override void Init(Entity e)
        {
            _frequency = 5000f;
            _elapsed = 0f;
            _duration = 12000f;
            _totalTime = 0f;
            Priority = 105;
            _onFire = false;
            base.Init(e);
        }

        public override void FireEvent(Event e)
        {
            if (e.Type == EventType.TakeDamage && !_onFire)
                _onFire = true;
        }

        public override void Update(float dt)
        {
            if (!_onFire) return;

            if (_elapsed >= _frequency)
            {
                if (_totalTime >= _duration)
                {
                    _onFire = false;
                    return;
                }

                Entity.FireEvent(new Event(EventType.TakeDamage, new Dictionary<string, object> { { "amount", 5 } }));
                Entity.FireEvent(new Event(EventType.Render,
                        new Dictionary<string, object>
                        {
                            {
                                "text",
                                string.Format("Entity #{0} is on fire, and received {1} fire damage.", Entity.Id,
                                    5)
                            }
                        }));
                _totalTime += _elapsed;
                _elapsed = 0f;
                return;
            }
            _elapsed += dt;
        }
    }
}
