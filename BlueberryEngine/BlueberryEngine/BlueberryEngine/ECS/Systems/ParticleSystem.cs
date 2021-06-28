using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using BlueberryEngine.Tools;

namespace BlueberryEngine {
    public class ParticleSystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public ParticleSystem() {
            requirements.Add("transform");
            requirements.Add("particleSpawner");
        }

        public void Update(Entity entity, Scene scene, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            ParticleSpawner spawner = (ParticleSpawner)entity.GetComponent("particleSpawner");
            Transform t = (Transform)entity.GetComponent("transform");

            spawner.spawnTimer -= deltaTime;
            if(spawner.spawnTimer <= 0f) {
                spawner.spawnTimer = spawner.spawnRate;

                Entity newParticle = scene.CreateEntity("particle", new List<IComponent>() {
                    new Transform(t.position, Vector2.One, 0f),
                    new RigidBody(spawner.particleGravity, spawner.particleFriction),
                    new SpriteRenderer(spawner.texture, spawner.color, new Vector2(5, 5)),
                    new Particle(spawner.particleLife),
                });
                newParticle.AddTags(new List<string>() { "followCamera" });

                RigidBody rb = (RigidBody)newParticle.GetComponent("rigidBody");
                SpriteRenderer sr = (SpriteRenderer)newParticle.GetComponent("spriteRenderer");
                Particle p = (Particle)newParticle.GetComponent("particle");

                rb.velocity = new Vector2(BMath.RandomRange(spawner.xVelocity.X, spawner.xVelocity.Y), BMath.RandomRange(spawner.yVelocity.X, spawner.yVelocity.Y));
                p.animationFrameTimer = p.startLife / sr.tileSize.X;

                spawner.particles.Add(newParticle);
            }

            List<Entity> reversedParticles = spawner.particles.GetRange(0, spawner.particles.Count);
            reversedParticles.Reverse();
            foreach (Entity particle in reversedParticles) {
                Particle p = (Particle)particle.GetComponent("particle");
                if(p.life <= 0f) {
                    spawner.particles.Remove(particle);
                    particle.Destroy();
                    continue;
                }

                if (p.animationFrameTimer <= 0f) {
                    SpriteRenderer sr = (SpriteRenderer)particle.GetComponent("spriteRenderer");
                    p.animationFrameTimer = p.startLife / sr.tileSize.X;

                    sr.x += (int)sr.tileSize.X;
                }

                p.animationFrameTimer -= deltaTime;
                p.life -= deltaTime;
            }
        }
    }
}
