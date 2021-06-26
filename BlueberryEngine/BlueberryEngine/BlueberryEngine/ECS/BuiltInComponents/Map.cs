using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine.ECS.BuiltInComponents {
    class Map : IComponent {

        public string id { get; set; }

        public int[,] map;
        public Texture2D tilesetImg;
        public int tileSize;

        public Map(int[,] map, Texture2D tilesetImg, int tileSize) {
            id = "map";
            this.map = map;
            this.tilesetImg = tilesetImg;
            this.tileSize = tileSize;
        }
    }
}
