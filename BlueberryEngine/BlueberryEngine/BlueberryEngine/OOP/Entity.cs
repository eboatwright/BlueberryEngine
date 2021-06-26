using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine.OOP {
    public abstract class Entity {

        public Scene scene;
        public Vector2 position;
        public bool destroyed;

        public Entity(Scene scene) {
            this.scene = scene;
        }

        public Entity(Scene scene, Vector2 position) {
            this.scene = scene;
            this.position = position;
        }

        public void Destroy() {
            destroyed = true;
        }

        public abstract void Update(float deltaTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
