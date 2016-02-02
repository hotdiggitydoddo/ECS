using ECS.AnotherTest.Components;
using ECS.AnotherTest.Subsystems;

namespace ECS.AnotherTest
{
    public class World
    {
        private HealthSubsystem _healthSubsystem;
        private ConsoleDisplaySubsystem _consoleDisplaySubsystem;
        private StatusEffectsSubsystem _statusEffectsSubsystem;


        public HealthComponent[] HealthComponents { get; }
        public RegenerationComponent[] RegenerationComponents { get; }
        public SpatialComponent[] SpatialComponents { get; }
        public FlammableComponent[] FlammableComponents { get; }
        public ConsoleRendererComponent[] ConsoleRendererComponents { get; }

        public const uint MaxEntities = 1000;
        public BitSet[] EntityMasks { get; } 

        public World()
        {
            EntityMasks = new BitSet[MaxEntities];

            HealthComponents = new HealthComponent[MaxEntities];
            RegenerationComponents = new RegenerationComponent[MaxEntities];
            SpatialComponents = new SpatialComponent[MaxEntities];
            FlammableComponents = new FlammableComponent[MaxEntities];
            ConsoleRendererComponents = new ConsoleRendererComponent[MaxEntities];

            _healthSubsystem = new HealthSubsystem(this);
            _consoleDisplaySubsystem = new ConsoleDisplaySubsystem(this);
            _statusEffectsSubsystem = new StatusEffectsSubsystem(this);

            for (int entity = 0; entity < MaxEntities; entity++)
            {
                EntityMasks[entity] = new BitSet();
                EntityMasks[entity].SetBit(ComponentType.NoComponents);

                HealthComponents[entity] = new HealthComponent();
                RegenerationComponents[entity] = new RegenerationComponent();
                SpatialComponents[entity] = new SpatialComponent();
                FlammableComponents[entity] = new FlammableComponent();
                ConsoleRendererComponents[entity] = new ConsoleRendererComponent();
            }
        }

        public uint CreateEntity()
        {
            for (uint entity = 0; entity < MaxEntities; entity++)
            {
                if (EntityMasks[entity].IsSet(ComponentType.NoComponents))
                    return entity;
            }
            return MaxEntities;
        }

        public void DestroyEntity(uint entity)
        {
            EntityMasks[entity].ClearAll();
            EntityMasks[entity].SetBit(ComponentType.NoComponents);
        }

        public void Update(float dt)
        {
            _statusEffectsSubsystem.Update(dt);
            _healthSubsystem.Update(dt);
            _consoleDisplaySubsystem.Update(dt);
        }

    }
}
