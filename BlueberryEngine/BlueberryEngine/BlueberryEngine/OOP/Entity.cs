using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine.OOP {
    public abstract class Entity {

        public Scene scene;
        public bool destroyed;

        public Entity(Scene scene) {
            this.scene = scene;
        }

        public void Destroy() {
            destroyed = true;
        }

        public abstract void Update(float deltaTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
