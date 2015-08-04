using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DagonGraphicEngine
{
    public class Player : Unit
    {
        private Texture2D _playerTexture;
        private SpriteBatch _spriteBatch;
        private BasicEffect _basicEffect;

        public Player(DagonGame game, Texture2D playerTexture):base(game)
        {
            _playerTexture = playerTexture;
            _spriteBatch = new SpriteBatch(_game.GraphicsDevice);
            _basicEffect = new BasicEffect(_game.GraphicsDevice)
            {
                TextureEnabled = true,
                VertexColorEnabled = true,
            };
        }

        public override void Draw(GameTime gameTime)
        {
            _basicEffect.World = Matrix.CreateConstrainedBillboard(Position, Matrix.Invert(_game.Camera.View).Translation, Vector3.Down, null, null)
                * Matrix.CreateScale(1f/256f, 1f/256f, 1f/256f);
            _basicEffect.View = _game.Camera.View;
            _basicEffect.Projection = _game.Camera.Projection;

            _spriteBatch.Begin(0, null, null, DepthStencilState.DepthRead, RasterizerState.CullNone, _basicEffect);
            _spriteBatch.Draw(_playerTexture, Vector2.Zero, Color.White);
            _spriteBatch.End();
        }
    }
}
