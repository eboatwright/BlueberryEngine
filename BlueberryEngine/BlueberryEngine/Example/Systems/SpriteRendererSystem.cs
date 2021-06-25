using System.Collections.Generic;
using BlueberryEngine.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace eboatwright.Example {
    public class SpriteRendererSystem : IDrawSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public SpriteRendererSystem() {
            requirements.Add("transform");
            requirements.Add("spriteRenderer");
        }

        public void Draw(Entity entity, SpriteBatch spriteBatch) {
            Transform t = (Transform)entity.GetComponent("transform");
            SpriteRenderer sr = (SpriteRenderer)entity.GetComponent("spriteRenderer");
            spriteBatch.Draw(sr.texture, t.position, new Rectangle(0, 0, sr.texture.Width, sr.texture.Height), sr.color, t.rotation, new Vector2(sr.texture.Width / 2f, sr.texture.Height / 2f), t.scale, SpriteEffects.None, 0f);
        }
    }
}
