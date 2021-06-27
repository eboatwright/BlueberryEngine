using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BlueberryEngine.UI {
    public class UISystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public UISystem() {
            requirements.Add("transform");
            requirements.Add("clickable");
            requirements.Add("boxCollider");
        }

        public void Update(Entity entity, Scene scene, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            Transform t = (Transform)entity.GetComponent("transform");
            Clickable c = (Clickable)entity.GetComponent("clickable");
            BoxCollider col = (BoxCollider)entity.GetComponent("boxCollider");

            Vector2 mousePosition = mouse.Position.ToVector2() / Globals.SCREEN_SCALE;
            Camera cam = (Camera)scene.FindComponent("camera");
            if (cam != null)
                mousePosition += cam.scroll;

            Entity m = new Entity("mouse");
            m.AddComponents(new List<IComponent>() {
                new Transform(mousePosition, Vector2.One, 0f),
                new BoxCollider(new Vector2(10, 10)),
            });

            if (mouse.LeftButton == ButtonState.Pressed) {
                if (Collision.BoxCollidersOverlap(m, entity) && c.mouseUp) {
                    c.mouseUp = false;
                    c.onClick();
                }
            } else {
                c.mouseUp = true;
            }
        }
    }
}
