using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace BlueberryEngine {
    public class NonCollisionPhysicsSystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public NonCollisionPhysicsSystem() {
            requirements.Add("transform");
            requirements.Add("rigidBody");
        }

        public void Update(Entity entity, Scene scene, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            if (entity.tags.Contains("seperatePhysics")) return;

            Transform t = (Transform)entity.GetComponent("transform");
            RigidBody rb = (RigidBody)entity.GetComponent("rigidBody");

            rb.velocity.Y += rb.gravity;
            rb.velocity *= rb.friction;
            t.position += rb.velocity;
        }
    }
}
