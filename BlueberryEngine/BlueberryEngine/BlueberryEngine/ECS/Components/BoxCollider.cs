using Microsoft.Xna.Framework;

namespace BlueberryEngine {
    public class BoxCollider : IComponent {

        public string id { get; set; }

        public Vector2 size;

        public BoxCollider(Vector2 size) {
            id = "boxCollider";
            this.size = size;
        }
    }
}
