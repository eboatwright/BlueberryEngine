﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using BlueberryEngine.ECS;
using BlueberryEngine.ECS.BuiltInComponents;
using BlueberryEngine.ECS.BuiltInSystems;
using BlueberryEngine.Collision;
using System;

namespace eboatwright.Example {
    public class Main : Game {

        private GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public Scene scene;
        private Entity blueberry;
        private Entity crate;

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
                new RigidBody(0f, Vector2.One * 0.78f),
                new BoxCollider(new Vector2(19, 18)),
                new Player(0.9f, Keys.W, Keys.S, Keys.A, Keys.D),
                new FaceMouse(),
            });

            crate = scene.CreateEntity("crate", new List<IComponent>() {
                new Transform(new Vector2(50, 50), Vector2.One, 0f),
                new SpriteRenderer(Content.Load<Texture2D>("img/crate"), Color.White),
                new BoxCollider(new Vector2(24, 24)),
            });

            scene
                .AddUpdateSystem(new PlayerSystem())
                .AddUpdateSystem(new PhysicsSystem())
                .AddUpdateSystem(new FaceMouseSystem())
                .AddDrawSystem(new SpriteRendererSystem());
        }

        protected override void Update(GameTime gameTime) {
            scene.Update((float)gameTime.ElapsedGameTime.TotalSeconds / 60f, Mouse.GetState(), Keyboard.GetState());
            Console.WriteLine(Collision.BoxCollidersOverlap(blueberry, crate));
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.Texture, null, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(3f));

            scene.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
