using Microsoft.Xna.Framework;

namespace BlueberryEngine {
    public class Camera : IComponent {

        public string id { get; set; }

        public Vector2 scroll;
        public Transform follow;
        public float lerpSpeed;
        public Vector2 boundsX, boundsY;

        public Camera(Vector2 startScroll, Transform follow, float lerpSpeed, Vector2 boundsX, Vector2 boundsY) {
            id = "camera";
            scroll = startScroll;
            this.follow = follow;
            this.lerpSpeed = lerpSpeed;
            this.boundsX = boundsX;
            this.boundsY = boundsY;
        }
    }
}
