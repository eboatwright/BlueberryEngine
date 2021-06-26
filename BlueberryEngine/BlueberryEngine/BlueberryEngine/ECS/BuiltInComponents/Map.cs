using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine.ECS.BuiltInComponents {
    public class Map : IComponent {

        public string id { get; set; }

        public int[,] map;
        public List<int> collidableTiles;
        public Texture2D tilesetImg;
        public int tileSize;

        public Map(int[,] map, List<int> collidableTiles, Texture2D tilesetImg, int tileSize) {
            id = "map";
            this.map = map;
            this.collidableTiles = collidableTiles;
            this.tilesetImg = tilesetImg;
            this.tileSize = tileSize;
        }
    }
}
