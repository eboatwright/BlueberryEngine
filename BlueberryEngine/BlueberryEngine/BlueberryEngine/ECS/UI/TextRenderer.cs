using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine.UI {
    public class TextRenderer : IComponent {

        public string id { get; set; }

        public Texture2D texture;
        public string text;
        public Color color;
        public int width;
        public List<char> charOrder;

        public TextRenderer(Texture2D texture, string text, Color color, int width, List<char> charOrder) {
            id = "textRenderer";
            this.texture = texture;
            this.text = text;
            this.color = color;
            this.width = width;
            this.charOrder = charOrder;
        }
    }
}
