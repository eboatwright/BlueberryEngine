using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace BlueberryEngine.ECS {

    /// <summary>
    /// Implement this interface for systems that should draw every draw call
    /// </summary>
    public interface IDrawSystem : ISystem {

        public void Draw(Entity entity, SpriteBatch spriteBatch);
    }
}
