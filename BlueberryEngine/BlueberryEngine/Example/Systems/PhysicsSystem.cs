using System.Collections.Generic;
using BlueberryEngine.ECS;
using Microsoft.Xna.Framework.Input;

namespace eboatwright.Example {
    public class PhysicsSystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public PhysicsSystem() {
            requirements.Add("transform");
            requirements.Add("rigidBody");
        }

        public void Update(Entity entity, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            Transform t = (Transform)entity.GetComponent("transform");
            RigidBody rb = (RigidBody)entity.GetComponent("rigidBody");

            rb.velocity.Y += rb.gravity;
            rb.velocity *= rb.friction;
            t.position += rb.velocity;
        }
    }
}
