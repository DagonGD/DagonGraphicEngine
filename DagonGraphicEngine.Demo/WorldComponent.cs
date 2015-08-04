﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using DagonGraphicEngine.Units;
using Microsoft.Xna.Framework.Input;

namespace DagonGraphicEngine.Demo
{
    public class WorldComponent:DrawableGameComponent
    {
        private readonly DagonGame _game;

        public WorldComponent(DemoGame game):base(game)
        {
            _game = game;

            _game.World = new World
            {
                Boxes = new List<Box>(),

                Units = new List<Unit>
                {
                    new Warrior(_game)
                    {
                        Position = new Vector3(5f,10f,5f)
                    },
                    new Player(_game)
                    {
                        Position = new Vector3(10f,10f,10f),
                        Angle = MathHelper.ToRadians(0)
                    }
                },
            };

            _game.World.Terrain = new Terrain(_game, 100, 100)
            {
                LandTexture = _game.Content.Load<Texture2D>("land")
            };
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            _game.World.Draw(gameTime);

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            var player = _game.World.Units.Find(u => u is Player);
            var distance = gameTime.ElapsedGameTime.Milliseconds * player.Speed;
            var rotationAngle = gameTime.ElapsedGameTime.Milliseconds * _game.Settings.RotationSpeed;

            if (keyboardState.IsKeyDown(Keys.W))
            {
                player.MoveForward(distance);
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                player.MoveForward(-distance);
            }

            if (keyboardState.IsKeyDown(Keys.A))
            {
                player.MoveRight(-distance);
            }

            if (keyboardState.IsKeyDown(Keys.D))
            {
                player.MoveRight(distance);
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                player.RotateRight(rotationAngle);
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                player.RotateRight(-rotationAngle);
            }

            if(keyboardState.IsKeyDown(Keys.Space))
            {
                player.Jump();
            }

            if(keyboardState.IsKeyDown(Keys.C))
            {
                player.Crawl();
            }
            else
            {
                player.Stand();
            }

            _game.World.Update(gameTime);

            base.Update(gameTime);
        }
    }
}
