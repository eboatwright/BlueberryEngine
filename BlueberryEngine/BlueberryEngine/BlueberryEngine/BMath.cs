using Microsoft.Xna.Framework;

namespace BlueberryEngine {
    public static class BMath {

        public static Vector2 Normalize(Vector2 vector2) {
            Vector2 normalized = vector2;
            normalized.Normalize();

            if (normalized.Length() > 0) return normalized;

            return Vector2.Zero;
        }
    }
}
