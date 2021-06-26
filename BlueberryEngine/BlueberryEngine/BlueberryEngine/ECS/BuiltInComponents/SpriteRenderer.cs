using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine.ECS.BuiltInComponents {
    public class SpriteRenderer : IComponent {

        public string id { get; set; }

        public Texture2D texture;
        public Color color;

        public SpriteRenderer(Texture2D texture, Color color) {
            id = "spriteRenderer";
            this.texture = texture;
            this.color = color;
        }
    }
}
