using System.Collections.Generic;
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
        }
    }
}
