using Microsoft.Xna.Framework;
using System;

namespace DagonGraphicEngine.Units
{
    public abstract class Unit
    {
        public Vector3 Position { get; set; }
        public Vector3 NewPosition { get; private set; }
        public float Angle { get; set; }
        public float Pitch { get; set; } = 0f;
        public Vector3 Acceleration { get; set; }
        public float Speed { get; private set; }
        public Vector3 Hight { get; private set; }

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

        public void MoveForward(float dist)
        {
            Vector3 direction = new Vector3((float)Math.Cos(Angle - Math.PI / 2), 0, (float)Math.Sin(Angle - Math.PI / 2));
            direction.Normalize();
            Position += direction * dist;
        }

        public void MoveRight(float dist)
        {
            Vector3 direction = new Vector3((float)Math.Cos(Angle), 0, (float)Math.Sin(Angle));
            direction.Normalize();
            Position += direction * dist;
        }

        public void RotateRight(float angle)
        {
            Angle += angle;
        }

        public void RotateUp(float angle)
        {
            Pitch += angle;
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
