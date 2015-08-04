using Microsoft.Xna.Framework;
using System;

namespace DagonGraphicEngine.Units
{
    public abstract class Unit
    {
        public Vector3 Position { get; set; }
        public Vector3 NewPosition { get; set; }
        public float Angle { get; set; }
        public Vector3 Acceleration { get; set; }
        public float Speed { get; set; }
        public Vector3 Hight { get; set; }

        protected DagonGame _game;

        public Unit(DagonGame game)
        {
            _game = game;
            Acceleration = Vector3.Zero;
            Speed = 0.005f;
            Hight = new Vector3(0, 1.8f, 0);
        }

        public void ApplyNewPosition()
        {
            Position = NewPosition;
        }

        public virtual void Update(GameTime gameTime)
        {
            //Update gravity
            var time = gameTime.ElapsedGameTime.Milliseconds / 1000f;
            Acceleration += _game.World.Gravity * time;
            NewPosition = Position + Acceleration * time;
        }

        public abstract void Draw(GameTime gameTime);

        public void RotateRight(float dist)
        {
            Angle += dist;
        }

        public void Jump()
        {
            //TODO check collision with terrain
            if (Math.Abs(Position.Y)<0.1f)
            {
                Acceleration = new Vector3(0, 5f, 0);
            }
        }

        public void Crawl()
        {
            Hight = new Vector3(0, 0.5f, 0);
        }

        public void Stand()
        {
            Hight = new Vector3(0, 1.8f, 0);
        }
    }
}
