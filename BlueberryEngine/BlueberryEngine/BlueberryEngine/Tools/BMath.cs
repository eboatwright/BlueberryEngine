using System;
using Microsoft.Xna.Framework;

namespace BlueberryEngine.Tools {
    public static class BMath {

        public static Vector2 Normalize(Vector2 vector2) {
            Vector2 normalized = vector2;
            normalized.Normalize();

            if (normalized.Length() > 0) return normalized;

            return Vector2.Zero;
        }

        public static float RandomRange(float min, float max) {
            Random random = new Random();
            return (float)random.NextDouble() * (max - min) + min;
        }

        public static int RandomRange(int min, int max) {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
