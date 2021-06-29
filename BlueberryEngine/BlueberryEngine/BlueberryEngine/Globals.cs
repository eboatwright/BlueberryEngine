using Microsoft.Xna.Framework;

namespace BlueberryEngine {
    /// <summary>
    /// Change these variables for things like window size and title
    /// </summary>
    public static class Globals {

        public const float SCREEN_SCALE = 3f;
        public const int SCREEN_WIDTH = 960;
        public const int SCREEN_HEIGHT = 600;
        public const string SCREEN_TITLE = "Blueberry Engine - eboatwright";

        public static void SETUP_WINDOW(GraphicsDeviceManager graphics, GameWindow window) {
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            graphics.ApplyChanges();
            window.Title = SCREEN_TITLE;
        }

        public static Vector2 GET_SCREEN_SCALE() {
            return new Vector2(SCREEN_WIDTH / SCREEN_SCALE, SCREEN_HEIGHT / SCREEN_SCALE);
        }
    }
}
