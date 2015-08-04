using DagonGraphicEngine.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DagonGraphicEngine.Components
{
    public class DebugInfoComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private Unit _unit;
        public DebugInfoComponent(DagonGame game, Unit player):base(game)
        {
            _spriteBatch = new SpriteBatch(game.GraphicsDevice);
            _font = game.Content.Load<SpriteFont>("arial");
            _unit = player;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, $"Position: ({_unit.Position})", Vector2.Zero, Color.White);
            _spriteBatch.DrawString(_font, $"Acceleration: ({_unit.Acceleration})", new Vector2(0, 20f), Color.White);
            _spriteBatch.DrawString(_font, $"Angle: {MathHelper.ToDegrees(_unit.Angle)}", new Vector2(0, 40f), Color.White);
            _spriteBatch.DrawString(_font, $"Hight: {_unit.Hight}", new Vector2(0, 60f), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
