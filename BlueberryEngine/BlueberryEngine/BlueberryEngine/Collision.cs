using BlueberryEngine.ECS.BuiltInComponents;
using Microsoft.Xna.Framework;

namespace BlueberryEngine.Collision {
    public static class Collision {

        public static bool BoxCollidersOverlap(ECS.Entity a, ECS.Entity b) {
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

        public static bool RectsOverlap(OOP.BoxCollider a, OOP.BoxCollider b) {
            return
                a.position.X - a.size.X / 2 < b.position.X + b.size.X / 2 &&
                a.position.X + a.size.X / 2 > b.position.X - b.size.X / 2 &&
                a.position.Y - a.size.Y / 2 < b.position.Y + b.size.Y / 2 &&
                a.position.Y + a.size.Y / 2 > b.position.Y - b.size.Y / 2;
        }
    }
}
