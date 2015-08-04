using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using DagonGraphicEngine.Units;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace DagonGraphicEngine.Demo
{
    public class WorldComponent : DrawableGameComponent
    {
        private readonly DagonGame _game;

        public WorldComponent(DemoGame game) : base(game)
        {
            _game = game;

            _game.World = new World
            {
                Boxes = new List<Box>(),
            };

            _game.World.Units = new List<Unit>
            {
                new Player(_game)
                {
                    Position = new Vector3(50f,10f,50f)
                },
                new Warrior(_game)
                {
                    Position = new Vector3(60f,0f,60f)
                },
                new Warrior(_game)
                {
                    Position = new Vector3(70f,0f,70f)
                },
                new Warrior(_game)
                {
                    Position = new Vector3(80f,0f,80f)
                }
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
            var player = _game.World.Units.SingleOrDefault(u => u is Player);
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

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                player.Jump();
            }

            if (keyboardState.IsKeyDown(Keys.C))
            {
                player.Crawl();
            }
            else
            {
                player.Stand();
            }

            if(_game.IsActive)
            {
                var mouseState = Mouse.GetState();
                var centerX = _game.Window.ClientBounds.Width / 2;
                var centerY = _game.Window.ClientBounds.Height / 2;

                player.RotateRight((mouseState.X- centerX )* _game.Settings.MouseSensitivity);
                player.RotateUp((mouseState.Y - centerY) * _game.Settings.MouseSensitivity);

                if(player.Pitch < -MathHelper.PiOver2)
                {
                    player.Pitch = -MathHelper.PiOver2;
                }

                if (player.Pitch > MathHelper.PiOver2)
                {
                    player.Pitch = MathHelper.PiOver2;
                }

                Mouse.SetPosition(centerX, centerY);
            }

            _game.World.Update(gameTime);

            base.Update(gameTime);
        }
    }
}
