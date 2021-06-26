using System;

namespace BlueberryEngine.ECS.UI {
    public class Clickable : IComponent {

        public string id { get; set; }

        public Delegate onClick;

        public Clickable(Delegate onClick) {
            id = "clickable";
            this.onClick = onClick;
        }
    }
}
