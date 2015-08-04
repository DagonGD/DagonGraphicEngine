using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DagonGraphicEngine.Units
{
    public class SpriteUnit : Unit
    {
        private Texture2D _texture;
        private SpriteBatch _spriteBatch;
        private BasicEffect _basicEffect;

        public SpriteUnit(DagonGame game, Texture2D texture):base(game)
        {
            _texture = texture;
            _spriteBatch = new SpriteBatch(_game.GraphicsDevice);
            _basicEffect = new BasicEffect(_game.GraphicsDevice)
            {
                TextureEnabled = true,
                VertexColorEnabled = true,
            };
        }

        public override void Draw(GameTime gameTime)
        {
            _basicEffect.World = Matrix.CreateScale(1f / 256f, 1f / 256f, 1f / 256f)
                * Matrix.CreateRotationX(MathHelper.ToRadians(180))
                * Matrix.CreateTranslation(new Vector3(-0.5f, 1f, 0f))
                * Matrix.CreateConstrainedBillboard(Position, Matrix.Invert(_game.Camera.View).Translation, Vector3.Up, null, null);
            _basicEffect.View = _game.Camera.View;
            _basicEffect.Projection = _game.Camera.Projection;

            _spriteBatch.Begin(0, null, null, DepthStencilState.DepthRead, RasterizerState.CullNone, _basicEffect);
            _spriteBatch.Draw(_texture, Vector2.Zero, Color.White);
            _spriteBatch.End();
        }
    }
}
