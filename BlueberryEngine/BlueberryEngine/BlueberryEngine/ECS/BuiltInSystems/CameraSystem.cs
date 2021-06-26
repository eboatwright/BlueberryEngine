using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using BlueberryEngine.ECS.BuiltInComponents;
using Microsoft.Xna.Framework;

namespace BlueberryEngine.ECS.BuiltInSystems {
    public class CameraSystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public CameraSystem() {
            requirements.Add("camera");
        }

        public void Update(Entity entity, Scene scene, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            Camera camera = (Camera)entity.GetComponent("camera");
            if (camera.follow == null) return;
            camera.scroll = Vector2.Lerp(camera.scroll, camera.follow.position - new Vector2(Globals.SCREEN_WIDTH / Globals.SCREEN_SCALE / 2f, Globals.SCREEN_HEIGHT / Globals.SCREEN_SCALE / 2f), camera.lerpSpeed * deltaTime);
        }
    }
}
