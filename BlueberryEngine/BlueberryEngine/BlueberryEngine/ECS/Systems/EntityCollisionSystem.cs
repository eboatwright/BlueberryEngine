using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace BlueberryEngine {
    public class EntityCollisionSystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public EntityCollisionSystem() {
            requirements.Add("transform");
            requirements.Add("boxCollider");
            requirements.Add("rigidBody");
        }

        public void Update(Entity entity, Scene scene, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            Transform t = (Transform)entity.GetComponent("transform");
            RigidBody rb = (RigidBody)entity.GetComponent("rigidBody");
            BoxCollider collider = (BoxCollider)entity.GetComponent("boxCollider");

            rb.velocity.X *= rb.friction.X;
            t.position.X += rb.velocity.X;

            foreach(Entity otherEntity in scene.FindEntitiesOfType("boxCollider")) {
                if (otherEntity == entity || otherEntity.GetComponent("transform") == null || otherEntity.GetComponent("clickable") != null) continue;

                if(Collision.BoxCollidersOverlap(entity, otherEntity)) {
                    Transform otherTransform = (Transform)otherEntity.GetComponent("transform");
                    BoxCollider otherCollider = (BoxCollider)otherEntity.GetComponent("boxCollider");
                    if (rb.velocity.X > 0f)
                        t.position.X = otherTransform.position.X - (collider.size.X / 2f) - (otherCollider.size.X / 2f);
                    else if (rb.velocity.X < 0f)
                        t.position.X = otherTransform.position.X + (collider.size.X / 2f) + (otherCollider.size.X / 2f);
                    rb.velocity.X = 0f;
                }
            }

            rb.velocity.Y += rb.gravity;
            rb.velocity.Y *= rb.friction.Y;
            t.position.Y += rb.velocity.Y;

            foreach (Entity otherEntity in scene.FindEntitiesOfType("boxCollider")) {
                if (otherEntity == entity || otherEntity.GetComponent("transform") == null || otherEntity.GetComponent("clickable") != null) continue;

                if(Collision.BoxCollidersOverlap(entity, otherEntity)) {
                    Transform otherTransform = (Transform)otherEntity.GetComponent("transform");
                    BoxCollider otherCollider = (BoxCollider)otherEntity.GetComponent("boxCollider");
                    if (rb.velocity.Y > 0f)
                        t.position.Y = otherTransform.position.Y - (collider.size.Y / 2f) - (otherCollider.size.Y / 2f);
                    else if(rb.velocity.Y < 0f)
                        t.position.Y = otherTransform.position.Y + (collider.size.Y / 2f) + (otherCollider.size.Y / 2f);
                    rb.velocity.Y = 0f;
                }
            }
        }
    }
}
