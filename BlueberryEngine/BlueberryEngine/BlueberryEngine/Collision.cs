using Microsoft.Xna.Framework;

namespace BlueberryEngine {
    /// <summary>
    /// Contains basic collision functions
    /// </summary>
    public static class Collision {

        public static bool BoxCollidersOverlap(Entity a, Entity b) {
            Vector2 aPosition = ((Transform)a.GetComponent("transform")).position;
            Vector2 bPosition = ((Transform)b.GetComponent("transform")).position;
            Vector2 aSize = ((BoxCollider)a.GetComponent("boxCollider")).size;
            Vector2 bSize = ((BoxCollider)b.GetComponent("boxCollider")).size;

            return
                aPosition.X - aSize.X / 2 < bPosition.X + bSize.X / 2 &&
                aPosition.X + aSize.X / 2 > bPosition.X - bSize.X / 2 &&
                aPosition.Y - aSize.Y / 2 < bPosition.Y + bSize.Y / 2 &&
                aPosition.Y + aSize.Y / 2 > bPosition.Y - bSize.Y / 2;
        }
    }
}
