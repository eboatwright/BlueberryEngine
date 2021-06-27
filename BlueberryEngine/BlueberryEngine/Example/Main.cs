using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using BlueberryEngine;
using BlueberryEngine.UI;
using System;

namespace eboatwright.Example {
    public class Main : Game {

        private GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public SpriteFont font;

        public Scene scene;

        public Main() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            graphics.PreferredBackBufferWidth = Globals.SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = Globals.SCREEN_HEIGHT;
            graphics.ApplyChanges();
            Window.Title = Globals.SCREEN_TITLE;

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("fnt/smallFont");

            scene = new Scene("scene");

            scene.CreateEntity("map", new List<IComponent>() {
                new Map(new int[,]{
                    {1, 2, 1, 1, 2, 2, 1, 1, 1, 1, 2, 2, 2, 1},
                    {2, 1, 2, 1, 2, 3, 3, 3, 2, 1, 2, 1, 2, 2},
                    {2, 1, 1, 2, 3, 2, 1, 2, 3, 1, 2, 2, 1, 1},
                    {2, 1, 2, 2, 3, 1, 2, 1, 3, 1, 2, 2, 1, 2},
                    {2, 1, 2, 1, 3, 1, 2, 2, 3, 1, 2, 1, 2, 2},
                    {1, 2, 1, 1, 2, 3, 2, 3, 1, 1, 2, 2, 2, 1},
                    {2, 1, 2, 1, 2, 1, 2, 2, 2, 1, 2, 1, 2, 2},
                    {2, 1, 1, 2, 2, 2, 1, 2, 1, 1, 2, 2, 1, 1},
                    {2, 1, 2, 2, 1, 1, 2, 1, 1, 1, 2, 2, 1, 2},
                }, new List<int> { 3 }, Content.Load<Texture2D>("img/tileset"), 24)
            }).AddTags(new List<string>() { "followCamera" });

            scene.CreateEntity("crate", new List<IComponent>() {
                new Transform(new Vector2(50, 50), Vector2.One, 0f),
                new SpriteRenderer(Content.Load<Texture2D>("img/crate"), Color.White),
                new BoxCollider(new Vector2(24, 24)),
            }).AddTags(new List<string>() { "followCamera" });

            Entity blueberry = scene.CreateEntity("blueberry", new List<IComponent>() {
                new Transform(Vector2.Zero, Vector2.One, 0f),
                new SpriteRenderer(Content.Load<Texture2D>("img/blueberry"), Color.White),
                new RigidBody(0f, Vector2.One * 0.78f),
                new BoxCollider(new Vector2(19, 18)),
                new Player(0.9f, Keys.W, Keys.S, Keys.A, Keys.D),
            });
            blueberry.AddTags(new List<string>() { "followCamera", "faceMouse" });

            scene.CreateEntity("testButton", new List<IComponent>() {
                new Transform(new Vector2(24, 24), new Vector2(2, 2), 0f),
                new BoxCollider(new Vector2(2 * 24, 2 * 24)),
                new Clickable(ButtonOnClick),
                new PanelRenderer(Content.Load<Texture2D>("img/uiPanel"), Color.White),
            });

            scene.CreateEntity("camera", new List<IComponent>() {
                new Camera(Vector2.Zero, (Transform)blueberry.GetComponent("transform"), 0.1f),
            });

            scene
                .AddUpdateSystem(new TopDownPlayerSystem())
                .AddUpdateSystem(new MapCollisionSystem())
                .AddUpdateSystem(new FaceMouseSystem())
                .AddUpdateSystem(new CameraSystem())
                .AddUpdateSystem(new ClickableSystem())
                .AddDrawSystem(new MapRendererSystem())
                .AddDrawSystem(new SpriteRendererSystem())
                .AddDrawSystem(new PanelRendererSystem());
        }

        protected override void Update(GameTime gameTime) {
            scene.Update((float)gameTime.ElapsedGameTime.TotalSeconds * 60f, Mouse.GetState(), Keyboard.GetState());
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.Texture, null, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(Globals.SCREEN_SCALE));

            scene.Draw(spriteBatch);

            spriteBatch.End();
        }

        public void ButtonOnClick() {
            Console.WriteLine("Button Clicked!");
        }
    }
}
