using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BlueberryEngine.UI {
    public class ClickableSystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public ClickableSystem() {
            requirements.Add("transform");
            requirements.Add("clickable");
            requirements.Add("boxCollider");
        }

        public void Update(Entity entity, Scene scene, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            Transform t = (Transform)entity.GetComponent("transform");
            Clickable c = (Clickable)entity.GetComponent("clickable");
            BoxCollider col = (BoxCollider)entity.GetComponent("boxCollider");

            Vector2 mousePosition = mouse.Position.ToVector2() / Globals.SCREEN_SCALE;

            Entity m = new Entity("mouse");
            m.AddComponents(new List<IComponent>() {
                new Transform(mousePosition, Vector2.One, 0f),
                new BoxCollider(new Vector2(1, 1)),
            });

            if (mouse.LeftButton == ButtonState.Pressed) {
                if (Collision.BoxCollidersOverlap(m, entity) && c.mouseUp)
                    c.onClick();
                c.mouseUp = false;
            } else {
                c.mouseUp = true;
            }
        }
    }
}
