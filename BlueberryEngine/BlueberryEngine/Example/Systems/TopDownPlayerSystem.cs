using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using BlueberryEngine;
using BlueberryEngine.Tools;
using System;

namespace eboatwright.Example {
    public class TopDownPlayerSystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public TopDownPlayerSystem() {
            requirements.Add("transform");
            requirements.Add("player");
            requirements.Add("animator");
        }

        public void Update(Entity entity, Scene scene, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            RigidBody rb = (RigidBody)entity.GetComponent("rigidBody");
            Player player = (Player)entity.GetComponent("player");
            Animator anim = (Animator)entity.GetComponent("animator");

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
            rb.velocity += input * player.moveSpeed * deltaTime;

            if (Math.Abs(input.X) + Math.Abs(input.Y) == 0)
                anim.ChangeAnimation("idle");
            else anim.ChangeAnimation("moving");
        }
    }
}
