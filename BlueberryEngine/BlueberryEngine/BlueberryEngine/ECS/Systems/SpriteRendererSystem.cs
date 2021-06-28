using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine {
    public class SpriteRendererSystem : IDrawSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public SpriteRendererSystem() {
            requirements.Add("transform");
            requirements.Add("spriteRenderer");
        }

        public void Draw(Entity entity, Scene scene, SpriteBatch spriteBatch) {
            Transform t = (Transform)entity.GetComponent("transform");
            SpriteRenderer sr = (SpriteRenderer)entity.GetComponent("spriteRenderer");

            Vector2 position = t.position;
            if(entity.tags.Contains("followCamera")) {
                Camera cam = (Camera)scene.FindComponent("camera");
                position -= cam.scroll;
            }

            spriteBatch.Draw(sr.texture, position, new Rectangle(sr.x, 0, (int)sr.tileSize.X, (int)sr.tileSize.Y), sr.color, t.rotation, sr.tileSize / 2f, t.scale, SpriteEffects.None, 0f);
        }
    }
}
