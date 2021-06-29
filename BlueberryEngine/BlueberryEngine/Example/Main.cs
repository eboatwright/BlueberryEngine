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
                new SpriteRenderer(Content.Load<Texture2D>("img/crate"), Color.White, new Vector2(24, 24)),
                new BoxCollider(new Vector2(24, 24)),
            }).AddTags(new List<string>() { "followCamera" });

            Entity blueberry = scene.CreateEntity("blueberry", new List<IComponent>() {
                new Transform(Vector2.Zero, Vector2.One, 0f),
                new SpriteRenderer(Content.Load<Texture2D>("img/blueberry"), Color.White, new Vector2(19, 18)),
                new RigidBody(0f, Vector2.One * 0.78f),
                new BoxCollider(new Vector2(19, 18)),
                new Player(0.9f, Keys.W, Keys.S, Keys.A, Keys.D),
                new Animator(new List<Animation>(){
                    new Animation("idle", new List<int>() { 0, 1 }, 15f, false),
                    new Animation("moving", new List<int>() { 2, 3 }, 5f, false),
                }),
            });
            blueberry.AddTags(new List<string>() { "followCamera", "faceMouse", "seperatePhysics" });

            scene.CreateEntity("particleTest", new List<IComponent>() {
                new Transform(Vector2.Zero, Vector2.One, 0f),
                new ParticleSpawner(30f, 0f, Vector2.One * 0.95f, new Vector2(-0.8f, 0.8f), new Vector2(-0.8f, 0.8f), 8f, Content.Load<Texture2D>("img/particle"), Color.CornflowerBlue),
            });

            scene.CreateEntity("testButton", new List<IComponent>() {
                new Transform(new Vector2(24, 24), new Vector2(2, 2), 0f),
                new BoxCollider(new Vector2(2 * 24, 2 * 24)),
                new Clickable(ButtonOnClick),
                new PanelRenderer(Content.Load<Texture2D>("img/uiPanel"), Color.White),
            });

            scene.CreateEntity("testText", new List<IComponent>() {
                new Transform(new Vector2(5, 5), Vector2.One, 0f),
                new TextRenderer(Content.Load<Texture2D>("img/exclaimFont"), "hello`world!", Color.Black, 5, new List<char>(){ 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '?', '.', ',', '"', '-', '=', '+', '(', ')', ':', ';', '/', '$' }),
            });

            scene.CreateEntity("camera", new List<IComponent>() {
                new Camera(Vector2.Zero, (Transform)blueberry.GetComponent("transform"), 0.1f, new Vector2(-64f, 64f), new Vector2(-64f, 64f)),
            });

            scene
                .AddUpdateSystem(new NonCollisionPhysicsSystem())
                .AddUpdateSystem(new TopDownPlayerSystem())
                .AddUpdateSystem(new MapCollisionSystem())
                .AddUpdateSystem(new FaceMouseSystem())
                .AddUpdateSystem(new CameraSystem())
                .AddUpdateSystem(new ClickableSystem())
                .AddUpdateSystem(new ParticleSystem())
                .AddUpdateSystem(new AnimationSystem())

                .AddDrawSystem(new MapRendererSystem())
                .AddDrawSystem(new SpriteRendererSystem())
                .AddDrawSystem(new PanelRendererSystem())
                .AddDrawSystem(new TextRendererSystem());
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
