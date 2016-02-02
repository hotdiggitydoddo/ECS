namespace ECS.AnotherTest.Subsystems
{
    public abstract class Subsystem
    {
        protected World World { get; private set; }
        protected BitSet ComponentMask { get; private set; }
        protected Subsystem(World theWorld)
        {
            World = theWorld;
            ComponentMask = new BitSet();
        }
       
        public abstract void Update(float dt);
    }
}
