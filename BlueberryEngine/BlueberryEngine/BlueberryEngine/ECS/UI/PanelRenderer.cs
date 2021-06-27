using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine.UI {
    public class PanelRenderer : IComponent {

        public string id { get; set; }

        public Texture2D texture;
        public Color color;
        public int tileSize;

        public PanelRenderer(Texture2D texture, Color color) {
            id = "panelRenderer";
            this.texture = texture;
            this.color = color;
            this.tileSize = texture.Width / 3;
        }
    }
}
