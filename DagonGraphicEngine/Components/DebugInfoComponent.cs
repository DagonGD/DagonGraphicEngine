using DagonGraphicEngine.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace DagonGraphicEngine.Components
{
    public class DebugInfoComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private Unit _unit;

        private int _fps;
        private int _frameCounter;
        private TimeSpan _elapsedTime = TimeSpan.Zero;

        public DebugInfoComponent(DagonGame game, Unit player):base(game)
        {
            _spriteBatch = new SpriteBatch(game.GraphicsDevice);
            _font = game.Content.Load<SpriteFont>("arial");
            _unit = player;
            _fps = 0;
            _frameCounter = 0;
        }

        public override void Update(GameTime gameTime)
        {
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime > TimeSpan.FromSeconds(1))
            {
                _elapsedTime -= TimeSpan.FromSeconds(1);
                _fps = _frameCounter;
                _frameCounter = 0;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _frameCounter++;

            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, $"Position: ({_unit.Position})", Vector2.Zero, Color.White);
            _spriteBatch.DrawString(_font, $"Acceleration: ({_unit.Acceleration})", new Vector2(0, 20f), Color.White);
            _spriteBatch.DrawString(_font, $"Angle: {MathHelper.ToDegrees(_unit.Angle)}", new Vector2(0, 40f), Color.White);
            _spriteBatch.DrawString(_font, $"Hight: {_unit.Hight}", new Vector2(0, 60f), Color.White);
            _spriteBatch.DrawString(_font, $"Fps: {_fps}", new Vector2(0, 80f), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
