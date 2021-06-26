using Microsoft.Xna.Framework.Input;

namespace BlueberryEngine.ECS {
    public class Player : IComponent {

        public string id { get; set; }

        public float moveSpeed;
        public Keys up, down, left, right;

        public Player(float moveSpeed, Keys up, Keys down, Keys left, Keys right) {
            id = "player";

            this.moveSpeed = moveSpeed;

            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
        }
    }
}
