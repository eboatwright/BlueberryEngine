using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine.OOP {
    public class Camera : Entity {

        public Vector2 scroll;
        public Entity follow;
        private float lerpSpeed;

        public Camera(Scene scene, Vector2 scroll, Entity follow, float lerpSpeed) : base(scene) {
            this.scroll = scroll;
            this.follow = follow;
            this.lerpSpeed = lerpSpeed;
        }

        public override void Update(float deltaTime) {
            if (follow == null) return;
            scroll = Vector2.Lerp(scroll, follow.position - new Vector2(Globals.SCREEN_WIDTH / Globals.SCREEN_SCALE / 2f, Globals.SCREEN_HEIGHT / Globals.SCREEN_SCALE / 2f), lerpSpeed * deltaTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {}
    }
}
