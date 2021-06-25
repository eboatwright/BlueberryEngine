using System.Collections.Generic;

namespace BlueberryEngine.ECS {
    public class Entity {

        public string id;

        public List<IComponent> components = new List<IComponent>();
        public List<string> tags = new List<string>();

        public bool destroyed = false;
        public bool enabled = true;

        public Entity(string id) {
            this.id = id;
        }

        public void Destroy() {
            destroyed = true;
        }

        public void AddComponent(IComponent component) {
            components.Add(component);
        }

        public void AddComponents(List<IComponent> components) {
            foreach (IComponent component in components)
                this.components.Add(component);
        }

        public void RemoveComponent(string componentId) {
            foreach (IComponent component in components)
                if (component.id == componentId)
                    components.Remove(component);
        }

        public IComponent GetComponent(string componentId) {
            foreach (IComponent component in components)
                if (component.id == componentId)
                    return component;
            return null;
        }

        public bool HasComponent(string componentId) {
            IComponent component = GetComponent(componentId);
            return component != null;
        }
    }
}
