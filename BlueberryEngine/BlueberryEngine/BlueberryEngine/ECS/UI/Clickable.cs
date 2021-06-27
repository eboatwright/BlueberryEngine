namespace BlueberryEngine.UI {
    public class Clickable : IComponent {

        public string id { get; set; }

        public delegate void OnClick();
        public OnClick onClick;
        public bool mouseUp;

        public Clickable(OnClick onClick) {
            id = "clickable";
            this.onClick = new OnClick(onClick);
        }
    }
}
