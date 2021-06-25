using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlueberryEngine.ECS;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace eboatwright.Example {
    public class Main : Game {

        private GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public Scene scene;
        public Entity blueberry;

        public Main() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
            Window.Title = "Blueberry Engine";

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            scene = new Scene("scene");

            blueberry = scene.CreateEntity("blueberry", new List<IComponent>() {
                new Transform(Vector2.Zero, Vector2.One, 0f),
                new SpriteRenderer(Content.Load<Texture2D>("img/blueberry"), Color.White),
                new Player(2f, 0.85f, Keys.W, Keys.S, Keys.A, Keys.D),
                new FaceMouse(),
            });

            scene
                .AddUpdateSystem(new PlayerSystem())
                .AddUpdateSystem(new PhysicsSystem())
                .AddUpdateSystem(new FaceMouseSystem())
                .AddDrawSystem(new SpriteRendererSystem());
        }

        protected override void Update(GameTime gameTime) {
            scene.Update((float)gameTime.ElapsedGameTime.TotalSeconds / 60f, Mouse.GetState(), Keyboard.GetState());
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(3f));

            scene.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
