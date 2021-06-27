using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BlueberryEngine {
    public class FaceMouseSystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public FaceMouseSystem() {
            requirements.Add("transform");
        }

        public void Update(Entity entity, Scene scene, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            if (!entity.tags.Contains("faceMouse")) return;
            Vector2 mousePosition = mouse.Position.ToVector2() / Globals.SCREEN_SCALE;
            Camera cam = (Camera)scene.FindComponent("camera");
            if (cam != null)
                mousePosition += cam.scroll;
            Transform t = (Transform)entity.GetComponent("transform");
            Vector2 distance = mousePosition - t.position;
            t.rotation = (float)Math.Atan2(distance.Y, distance.X);
        }
    }
}
