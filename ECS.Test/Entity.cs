using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Test.Components;

namespace ECS.Test
{
    public class Entity
    {
        private static int _nextId = 1;

        private readonly List<Component> _components;
        private readonly List<Component> _componentsToAdd;

        private bool _sortNeeded;
        public bool Alive { get; set; }

        public int Id { get; private set; }
        public Entity()
        {
            Id = _nextId;
            _nextId++;

            _components = new List<Component>();
            _componentsToAdd = new List<Component>();

            Alive = true;

            var b = new BitSet();
            b.
        }

        public bool FireEvent(Event e)
        {
            foreach (var component in _components)
            {
               component.FireEvent(e);
            }
            return true;
        }

        public void Init()
        {
            if (_componentsToAdd.Any())
            {
                AddAttachedComponents();
                _componentsToAdd.Clear();
                _components.Sort(new ComponentComparer());
            }
        }

        public void Update(float dt)
        {
            foreach (var component in _components)
            {
                if (component.Alive)
                    component.Update(dt);
            }

            if (_componentsToAdd.Any())
            {
                AddAttachedComponents();
                _sortNeeded = true;
                _componentsToAdd.Clear();
            }

            if (_components.Any(x => !x.Alive))
            {
                RemoveAttachedComponents();
                _sortNeeded = true;
            }

            if (_sortNeeded)
                _components.Sort(new ComponentComparer());
        }

        public void AttachComponent(Component component)
        {
            _componentsToAdd.Add(component);
        }

        private void AddAttachedComponents()
        {
            foreach (var component in _componentsToAdd)
            {
                _components.Add(component);
                component.Init(this);
            }
        }

        private void RemoveAttachedComponents()
        {
            foreach (var component in _components.Where(x => !x.Alive))
            {
                _components.Remove(component);
            }
        }
    }
}
