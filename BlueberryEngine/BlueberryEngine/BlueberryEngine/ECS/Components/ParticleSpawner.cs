using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine {
    public class ParticleSpawner : IComponent {

        public string id { get; set; }

        public List<Entity> particles = new List<Entity>();

        public float particleLife;
        public float particleGravity;
        public Vector2 particleFriction;
        public Vector2 xVelocity, yVelocity;

        public float spawnRate, spawnTimer;
        public Texture2D texture;
        public Color color;

        public ParticleSpawner(float particleLife, float particleGravity, Vector2 particleFriction, Vector2 xVelocity, Vector2 yVelocity, float spawnRate, Texture2D texture, Color color) {
            id = "particleSpawner";
            this.particleLife = particleLife;
            this.particleGravity = particleGravity;
            this.particleFriction = particleFriction;
            this.xVelocity = xVelocity;
            this.yVelocity = yVelocity;

            this.spawnRate = spawnTimer = spawnRate;
            this.texture = texture;
            this.color = color;
        }
    }
}
