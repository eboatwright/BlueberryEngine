using BlueberryEngine.ECS;

namespace eboatwright.Example {
    public class FaceMouse : IComponent {

        public string id { get; set; }

        public FaceMouse() {
            id = "faceMouse";
        }
    }
}
