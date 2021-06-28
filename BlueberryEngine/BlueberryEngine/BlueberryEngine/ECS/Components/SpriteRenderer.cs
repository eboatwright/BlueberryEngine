using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine {
    public class SpriteRenderer : IComponent {

        public string id { get; set; }

        public Texture2D texture;
        public Color color;
        public Vector2 tileSize;
        public int x;

        public SpriteRenderer(Texture2D texture, Color color, Vector2 tileSize) {
            id = "spriteRenderer";
            this.texture = texture;
            this.color = color;
            this.tileSize = tileSize;

            x = 0;
        }
    }
}
