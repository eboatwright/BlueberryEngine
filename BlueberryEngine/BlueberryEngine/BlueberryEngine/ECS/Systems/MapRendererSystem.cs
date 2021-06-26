using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine.ECS {
    public class MapRendererSystem : IDrawSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public MapRendererSystem() {
            requirements.Add("map");
        }

        public void Draw(Entity entity, Scene scene, SpriteBatch spriteBatch) {
            Vector2 camScroll = new Vector2();
            if (entity.tags.Contains("followCamera")) {
                Camera cam = (Camera)scene.FindEntityOfType("camera").GetComponent("camera");
                camScroll = cam.scroll;
            }

            Map map = (Map)entity.GetComponent("map");
            for (int y = 0; y <= map.map.GetUpperBound(0); y++)
                for (int x = 0; x <= map.map.GetUpperBound(1); x++)
                    if (map.map[y, x] > 0)
                        spriteBatch.Draw(map.tilesetImg, new Vector2(x * map.tileSize, y * map.tileSize) - camScroll, new Rectangle((map.map[y, x] - 1) * map.tileSize, 0, map.tileSize, map.tileSize), Color.White, 0f, Vector2.One * map.tileSize / 2, 1f, SpriteEffects.None, 0);
        }
    }
}
