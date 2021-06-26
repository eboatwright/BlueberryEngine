using Microsoft.Xna.Framework;

namespace BlueberryEngine.ECS {
    public class RigidBody : IComponent {

        public string id { get; set; }

        public float gravity;
        public Vector2 friction;
        public Vector2 velocity = new Vector2();

        public RigidBody(float gravity, Vector2 friction) {
            id = "rigidBody";
            this.gravity = gravity;
            this.friction = friction;
        }
    }
}
