using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine.UI {
    public class TextRendererSystem : IDrawSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public TextRendererSystem() {
            requirements.Add("transform");
            requirements.Add("textRenderer");
        }

        public void Draw(Entity entity, Scene scene, SpriteBatch spriteBatch) {
            Transform t = (Transform)entity.GetComponent("transform");
            TextRenderer text = (TextRenderer)entity.GetComponent("textRenderer");

            Vector2 offset = new Vector2();
            foreach(char c in text.text) {
                if (c == '`')
                    offset = new Vector2(0, offset.Y + text.texture.Height + 2);
                else {
                    if (c != ' ')
                        spriteBatch.Draw(text.texture, t.position + offset, new Rectangle(text.charOrder.IndexOf(c) * text.width, 0, text.width, text.texture.Height), text.color);

                    offset.X += text.width + 1;
                }
            }
        }
    }
}
