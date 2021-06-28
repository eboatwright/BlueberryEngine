using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using BlueberryEngine.Tools;

namespace BlueberryEngine {
    public class MapCollisionSystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public MapCollisionSystem() {
            requirements.Add("transform");
            requirements.Add("boxCollider");
            requirements.Add("rigidBody");
        }

        public void Update(Entity entity, Scene scene, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            Transform t = (Transform)entity.GetComponent("transform");
            RigidBody rb = (RigidBody)entity.GetComponent("rigidBody");
            BoxCollider collider = (BoxCollider)entity.GetComponent("boxCollider");
            Map map = (Map)scene.FindComponent("map");

            Entity tile = new Entity("tile");
            tile.AddComponents(new List<IComponent>() {
                new Transform(new Vector2(), Vector2.One, 0f),
                new BoxCollider(Vector2.One * map.tileSize),
            });
            Transform tileTransform = (Transform)tile.GetComponent("transform");
            BoxCollider tileBoxCollider = (BoxCollider)tile.GetComponent("boxCollider");

            rb.velocity.X *= rb.friction.X;
            t.position.X += rb.velocity.X;

            for(int y = 0; y <= map.map.GetUpperBound(0); y++)
                for(int x = 0; x <= map.map.GetUpperBound(1); x++)
                    if (map.collidableTiles.Contains(map.map[y, x])) {
                        ((Transform)tile.GetComponent("transform")).position = new Vector2(x * map.tileSize, y * map.tileSize);
                        if (Collision.BoxCollidersOverlap(entity, tile)) {
                            if (rb.velocity.X < 0f)
                                t.position.X = tileTransform.position.X + (tileBoxCollider.size.X / 2f) + (collider.size.X / 2f);
                            else if (rb.velocity.X > 0f)
                                t.position.X = tileTransform.position.X - (tileBoxCollider.size.X / 2f) - (collider.size.X / 2f);
                            rb.velocity.X = 0f;
                        }
                    }

            rb.velocity.Y += rb.gravity;
            rb.velocity.Y *= rb.friction.Y;
            t.position.Y += rb.velocity.Y;

            for (int y = 0; y <= map.map.GetUpperBound(0); y++)
                for (int x = 0; x <= map.map.GetUpperBound(1); x++)
                    if (map.collidableTiles.Contains(map.map[y, x])) {
                        ((Transform)tile.GetComponent("transform")).position = new Vector2(x * map.tileSize, y * map.tileSize);
                        if (Collision.BoxCollidersOverlap(entity, tile)) {
                            if (rb.velocity.Y < 0f)
                                t.position.Y = tileTransform.position.Y + (tileBoxCollider.size.Y / 2f) + (collider.size.Y / 2f);
                            else if (rb.velocity.Y > 0f)
                                t.position.Y = tileTransform.position.Y - (tileBoxCollider.size.Y / 2f) - (collider.size.Y / 2f);
                            rb.velocity.Y = 0f;
                        }
                    }
        }
    }
}
