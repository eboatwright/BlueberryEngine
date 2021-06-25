using BlueberryEngine.ECS;
using Microsoft.Xna.Framework.Input;

namespace eboatwright.Example {
    public class Player : IComponent {

        public string id { get; set; }

        public float moveSpeed, friction;
        public Keys up, down, left, right;

        public Player(float moveSpeed, float friction, Keys up, Keys down, Keys left, Keys right) {
            id = "player";

            this.moveSpeed = moveSpeed;
            this.friction = friction;

            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
        }
    }
}
