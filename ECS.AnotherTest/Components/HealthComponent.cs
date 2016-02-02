using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.AnotherTest.Components
{
    public class HealthComponent
    {
        private int _currentHealth;
        public int Damage { get; set; }
        public int MaxHealth { get; set; }

        public int CurrentHealth
        {
            get { return _currentHealth; }
            set
            {
                _currentHealth = value;
                if (_currentHealth > MaxHealth) _currentHealth = MaxHealth;
            }
        }

        public bool IsAlive { get { return CurrentHealth > 0; } }
    }
}
