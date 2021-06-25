using System.Collections.Generic;
using BlueberryEngine.ECS;
using Microsoft.Xna.Framework.Input;

namespace eboatwright.Example {
    public class PlayerSystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public PlayerSystem() {
            requirements.Add("transform");
            requirements.Add("player");
        }

        public void Update(Entity entity, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            Transform t = (Transform)entity.GetComponent("transform");
            Player player = (Player)entity.GetComponent("player");

            if (keyboard.IsKeyDown(player.up))
                t.position.Y -= player.moveSpeed;
            if (keyboard.IsKeyDown(player.down))
                t.position.Y += player.moveSpeed;
            if (keyboard.IsKeyDown(player.left))
                t.position.X -= player.moveSpeed;
            if (keyboard.IsKeyDown(player.right))
                t.position.X += player.moveSpeed;
        }
    }
}
