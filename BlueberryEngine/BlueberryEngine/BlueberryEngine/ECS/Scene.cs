using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BlueberryEngine.ECS {
    public class Scene {

        public string id;

        public List<Entity> entities = new List<Entity>();
        public List<IUpdateSystem> updateSystems = new List<IUpdateSystem>();
        public List<IDrawSystem> drawSystems = new List<IDrawSystem>();

        public Scene(string id) {
            this.id = id;
        }

        public Entity CreateEntity(string id, List<IComponent> components) {
            Entity newEntity = new Entity(id);
            newEntity.AddComponents(components);

            AddEntity(newEntity);
            return newEntity;
        }

        public Entity AddEntity(Entity entity) {
            entities.Add(entity);
            return entity;
        }

        public Entity FindEntityOfType(string id) {
            foreach (Entity entity in entities)
                if (entity.HasComponent(id))
                    return entity;
            return null;
        }

        public List<Entity> FindEntitiesOfType(string id) {
            List<Entity> found = new List<Entity>();
            foreach (Entity entity in entities)
                if (entity.HasComponent(id))
                    found.Add(entity);
            return found;
        }

        public Entity FindEntityWithTag(string tag) {
            foreach (Entity entity in entities)
                if (entity.tags.Contains(tag))
                    return entity;
            return null;
        }

        public List<Entity> FindEntitiesWithTag(string tag) {
            List<Entity> found = new List<Entity>();
            foreach (Entity entity in entities)
                if (entity.tags.Contains(tag))
                    found.Add(entity);
            return found;
        }

        public Scene AddUpdateSystem(IUpdateSystem system) {
            updateSystems.Add(system);
            return this;
        }

        public Scene AddDrawSystem(IDrawSystem system) {
            drawSystems.Add(system);
            return this;
        }

        public void Update(float deltaTime, MouseState mouse, KeyboardState keyboard) {
            List<Entity> reversedEntities = entities;
            reversedEntities.Reverse();
            foreach(IUpdateSystem system in updateSystems)
                foreach(Entity entity in reversedEntities) {
                    if (entity.destroyed)
                        entities.Remove(entity);
                    else if (system.Matches(entity))
                        system.Update(entity, this, deltaTime, mouse, keyboard);
                }
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (IDrawSystem system in drawSystems)
                foreach (Entity entity in entities)
                    if (system.Matches(entity))
                        system.Draw(entity, this, spriteBatch);
        }
    }
}
