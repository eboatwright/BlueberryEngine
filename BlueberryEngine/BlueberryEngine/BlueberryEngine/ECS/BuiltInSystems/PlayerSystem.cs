using System.Collections.Generic;
using BlueberryEngine.ECS.BuiltInComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BlueberryEngine.ECS.BuiltInSystems {
    public class PlayerSystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public PlayerSystem() {
            requirements.Add("transform");
            requirements.Add("player");
        }

        public void Update(Entity entity, Scene scene, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            RigidBody rb = (RigidBody)entity.GetComponent("rigidBody");
            Player player = (Player)entity.GetComponent("player");

            Vector2 input = Vector2.Zero;

            if (keyboard.IsKeyDown(player.up))
                input.Y = -1;
            if (keyboard.IsKeyDown(player.down))
                input.Y = 1;
            if (keyboard.IsKeyDown(player.left))
                input.X = -1;
            if (keyboard.IsKeyDown(player.right))
                input.X = 1;

            input = BMath.Normalize(input);
            rb.velocity += input * player.moveSpeed;
        }
    }
}
