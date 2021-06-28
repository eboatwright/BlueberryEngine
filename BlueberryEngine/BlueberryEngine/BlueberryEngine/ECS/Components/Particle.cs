namespace BlueberryEngine {
    public class Particle : IComponent {

        public string id { get; set; }

        public float startLife, life, animationFrameTimer;

        public Particle(float life) {
            id = "particle";
            startLife = this.life = life;
        }
    }
}
