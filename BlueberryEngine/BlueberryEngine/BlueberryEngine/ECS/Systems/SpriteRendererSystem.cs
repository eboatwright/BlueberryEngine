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

            spriteBatch.Draw(sr.texture, position, new Rectangle(0, 0, sr.texture.Width, sr.texture.Height), sr.color, t.rotation, new Vector2(sr.texture.Width / 2f, sr.texture.Height / 2f), t.scale, SpriteEffects.None, 0f);
        }
    }
}
