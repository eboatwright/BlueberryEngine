using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine {
    public class SpriteRenderer : IComponent {

        public string id { get; set; }

        public Texture2D texture;
        public Color color;
        public Vector2 tileSize;
        public int x = 0;
        public bool flip = false;

        public SpriteRenderer(Texture2D texture, Color color) {
            id = "spriteRenderer";
            this.texture = texture;
            this.color = color;
            tileSize = new Vector2(texture.Height, texture.Height);
        }

        public SpriteRenderer(Texture2D texture, Color color, Vector2 tileSize) {
            id = "spriteRenderer";
            this.texture = texture;
            this.color = color;
            this.tileSize = tileSize;
        }

        public SpriteRenderer(Texture2D texture, Color color, Vector2 tileSize, bool flip) {
            id = "spriteRenderer";
            this.texture = texture;
            this.color = color;
            this.tileSize = tileSize;
            this.flip = flip;
        }
    }
}
