using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.AnotherTest.Components
{
    public class RegenerationComponent
    {
        public int AmountToHeal { get; set; }
        public float Frequency { get; set; }
        public float ElapsedTime { get; set; }
    }
}
