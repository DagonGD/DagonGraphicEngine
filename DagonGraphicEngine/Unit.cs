using Microsoft.Xna.Framework;

namespace DagonGraphicEngine
{
    public abstract class Unit
    {
        public Vector3 Position { get; set; }
        public Vector3 NewPosition { get; set; }
        public Vector3 Velocity { get; set; }
        public Vector3 Acceleration { get; set; }
        public Matrix World { get; set; }
        protected DagonGame _game;

        public Unit(DagonGame game)
        {
            _game = game;
            Velocity = Vector3.Zero;
            Acceleration = Vector3.Zero;
        }

        public void ApplyNewPosition()
        {
            Position = NewPosition;
        }

        public abstract void Draw(GameTime gameTime);

        public void Update(GameTime gameTime)
        {
            //Update gravity
            var time = gameTime.ElapsedGameTime.Milliseconds / 1000f;
            Acceleration += _game.World.Gravity * time;
            NewPosition = Position + Acceleration * time;
        }
    }
}
