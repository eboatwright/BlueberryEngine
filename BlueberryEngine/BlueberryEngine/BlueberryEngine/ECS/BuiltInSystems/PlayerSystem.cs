using System.Collections.Generic;
using BlueberryEngine.ECS.BuiltInComponents;
using Microsoft.Xna.Framework.Input;

namespace BlueberryEngine.ECS.BuiltInSystems {
    public class PlayerSystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public PlayerSystem() {
            requirements.Add("transform");
            requirements.Add("player");
        }

        public void Update(Entity entity, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            RigidBody rb = (RigidBody)entity.GetComponent("rigidBody");
            Player player = (Player)entity.GetComponent("player");

            if (keyboard.IsKeyDown(player.up))
                rb.velocity.Y -= player.moveSpeed;
            if (keyboard.IsKeyDown(player.down))
                rb.velocity.Y += player.moveSpeed;
            if (keyboard.IsKeyDown(player.left))
                rb.velocity.X -= player.moveSpeed;
            if (keyboard.IsKeyDown(player.right))
                rb.velocity.X += player.moveSpeed;
        }
    }
}
