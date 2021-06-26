using Microsoft.Xna.Framework;

namespace BlueberryEngine.OOP {
    public class BoxCollider {

        public Vector2 position, size;

        public BoxCollider(Vector2 position, Vector2 size) {
            this.position = position;
            this.size = size;
        }
    }
}
