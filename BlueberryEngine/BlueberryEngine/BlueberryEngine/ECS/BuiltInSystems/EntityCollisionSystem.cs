using System.Collections.Generic;
using BlueberryEngine.ECS.BuiltInComponents;
using Microsoft.Xna.Framework.Input;

namespace BlueberryEngine.ECS.BuiltInSystems {
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
                if (otherEntity == entity || otherEntity.GetComponent("transform") == null) continue;

                if(Collision.BoxCollidersOverlap(entity, otherEntity)) {
                    Transform otherTransform = (Transform)otherEntity.GetComponent("transform");
                    BoxCollider otherCollider = (BoxCollider)otherEntity.GetComponent("boxCollider");
                    if(rb.velocity.X < 0f)
                        t.position.X = otherTransform.position.X + (otherCollider.size.X / 2) + (collider.size.X / 2);
                    else if(rb.velocity.X > 0f)
                        t.position.X = otherTransform.position.X - (otherCollider.size.X / 2) - (collider.size.X / 2);
                    rb.velocity.X = 0f;
                }
            }

            rb.velocity.Y += rb.gravity;
            rb.velocity.Y *= rb.friction.Y;
            t.position.Y += rb.velocity.Y;

            foreach (Entity otherEntity in scene.FindEntitiesOfType("boxCollider")) {
                if (otherEntity == entity || otherEntity.GetComponent("transform") == null) continue;

                if (Collision.BoxCollidersOverlap(entity, otherEntity)) {
                    Transform otherTransform = (Transform)otherEntity.GetComponent("transform");
                    BoxCollider otherCollider = (BoxCollider)otherEntity.GetComponent("boxCollider");
                    if (rb.velocity.Y < 0f)
                        t.position.Y = otherTransform.position.Y + (otherCollider.size.Y / 2) + (collider.size.Y / 2);
                    else if (rb.velocity.Y > 0f)
                        t.position.Y = otherTransform.position.Y - (otherCollider.size.Y / 2) - (collider.size.Y / 2);
                    rb.velocity.Y = 0f;
                }
            }
        }
    }
}
