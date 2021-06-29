using System;
using System.Collections.Generic;

namespace BlueberryEngine {
    public class Animator : IComponent {

        public string id { get; set; }

        public List<Animation> animations;
        public Animation currentAnimation;
        public float timer;
        public int animationIndex;
        public bool doingUninterruptableAnimation;

        public Animator(List<Animation> animations) {
            id = "animator";
            this.animations = animations;
            currentAnimation = animations[0];
        }

        public void ChangeAnimation(string name) {
            if (doingUninterruptableAnimation || name == currentAnimation.name) return;
            foreach (Animation animation in animations)
                if (animation.name == name) {
                    currentAnimation = animation;
                    doingUninterruptableAnimation = animation.uninterruptable;
                    timer = 0f;
                    animationIndex = 0;
                    return;
                }
        }
    }

    public class Animation {

        public string name;
        public List<int> frames;
        public float timeBetweenFrames;
        public bool uninterruptable;

        public Animation(string name, List<int> frames, float timeBetweenFrames, bool uninterruptable) {
            this.name = name;
            this.frames = frames;
            this.timeBetweenFrames = timeBetweenFrames;
            this.uninterruptable = uninterruptable;
        }
    }
}
