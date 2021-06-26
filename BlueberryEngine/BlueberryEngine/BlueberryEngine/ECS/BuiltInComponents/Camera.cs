using Microsoft.Xna.Framework;

namespace BlueberryEngine.ECS.BuiltInComponents {
    class Camera : IComponent {

        public string id { get; set; }

        public Vector2 scroll;
        public Transform follow;
        public float lerpSpeed;

        public Camera(Vector2 scroll, Transform follow, float lerpSpeed) {
            id = "camera";
            this.scroll = scroll;
            this.follow = follow;
            this.lerpSpeed = lerpSpeed;
        }
    }
}
