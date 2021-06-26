using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine.OOP {
    public class Scene {

        public List<Entity> entities = new List<Entity>();

        public Scene() {}

        public void Update(float deltaTime) {
            List<Entity> reversedEntities = entities;
            reversedEntities.Reverse();
            foreach (Entity entity in reversedEntities) {
                if (entity.destroyed)
                    entities.Remove(entity);
                else entity.Update(deltaTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (Entity entity in entities)
                entity.Draw(spriteBatch);
        }

        public Entity AddEntity(Entity entity) {
            entities.Add(entity);
            return entity;
        }
    }
}
