using Microsoft.Xna.Framework.Input;

namespace BlueberryEngine {

    /// <summary>
    /// Implement this interface for systems that are updated every frame
    /// </summary>
    public interface IUpdateSystem : ISystem {

        public void Update(Entity entity, Scene scene, float deltaTime, MouseState mouse, KeyboardState keyboard);
    }
}
