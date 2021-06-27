using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine.UI {
    public class PanelRendererSystem : IDrawSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public PanelRendererSystem() {
            requirements.Add("transform");
            requirements.Add("panelRenderer");
        }

        public void Draw(Entity entity, Scene scene, SpriteBatch spriteBatch) {
            Transform t = (Transform)entity.GetComponent("transform");
            PanelRenderer panel = (PanelRenderer)entity.GetComponent("panelRenderer");

            for(int x = 0; x < t.scale.X; x++)
                for(int y = 0; y < t.scale.Y; y++) {
                    int rectX = 0, rectY = 0;

                    if (x > 0) rectX = 1;
                    if (x == t.scale.X - 1) rectX = 2;

                    if (y > 0) rectY = 1;
                    if (y == t.scale.Y - 1) rectY = 2;

                    spriteBatch.Draw(panel.texture, t.position + new Vector2(x * panel.tileSize, y * panel.tileSize), new Rectangle(rectX * panel.tileSize, rectY * panel.tileSize, panel.tileSize, panel.tileSize), panel.color, 0f, new Vector2((t.scale.X * panel.tileSize) / 2f, (t.scale.Y * panel.tileSize) / 2f), 1f, SpriteEffects.None, 0f);
                }
        }
    }
}
