using Microsoft.Xna.Framework;

namespace BlueberryEngine {
    class Transform : IComponent {

        public string id { get; set; }

        public Vector2 position;
        public Vector2 scale;

        public float rotation;

        public Transform(Vector2 position, Vector2 scale, float rotation) {
            id = "transform";
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
        }
    }
}
