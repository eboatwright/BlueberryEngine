using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace BlueberryEngine {
    public class AnimationSystem : IUpdateSystem {

        public List<string> requirements { get; set; } = new List<string>();

        public AnimationSystem() {
            requirements.Add("animator");
            requirements.Add("spriteRenderer");
        }

        public void Update(Entity entity, Scene scene, float deltaTime, MouseState mouse, KeyboardState keyboard) {
            Animator anim = (Animator)entity.GetComponent("animator");

            anim.timer -= deltaTime;
            if(anim.timer <= 0f) {
                anim.timer = anim.currentAnimation.timeBetweenFrames;
                anim.animationIndex++;

                if(anim.animationIndex >= anim.currentAnimation.frames.Count) {
                    anim.animationIndex = 0;
                    anim.doingUninterruptableAnimation = false;
                }

                SpriteRenderer sr = (SpriteRenderer)entity.GetComponent("spriteRenderer");
                sr.x = anim.currentAnimation.frames[anim.animationIndex] * (int)sr.tileSize.X;
            }
        }
    }
}
