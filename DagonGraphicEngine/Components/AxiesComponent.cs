using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DagonGraphicEngine.Components
{
    public class AxiesComponent : DrawableGameComponent
    {
        private const float Length = 10.0f;
        private readonly DagonGame _game;
        private readonly BasicEffect _basicEffect;

        public AxiesComponent(DagonGame game): base (game)
        {
            _game = game;
            _basicEffect = new BasicEffect(game.GraphicsDevice) { VertexColorEnabled = true };
        }

        public override void Draw(GameTime gameTime)
        {
            _basicEffect.View = _game.Camera.View;
            _basicEffect.Projection = _game.Camera.Projection;

            foreach (var pass in _basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                VertexPositionColor[] vertexData = new VertexPositionColor[6];
                vertexData[0] = new VertexPositionColor(new Vector3(0f, 0f, 0f), Color.Red);
                vertexData[1] = new VertexPositionColor(new Vector3(Length, 0f, 0f), Color.Red);

                vertexData[2] = new VertexPositionColor(new Vector3(0f, 0f, 0f), Color.Green);
                vertexData[3] = new VertexPositionColor(new Vector3(0f, Length, 0f), Color.Green);

                vertexData[4] = new VertexPositionColor(new Vector3(0f, 0f, 0f), Color.Blue);
                vertexData[5] = new VertexPositionColor(new Vector3(0f, 0f, Length), Color.Blue);

                _game.GraphicsDevice.DrawUserPrimitives(PrimitiveType.LineList, vertexData, 0, 3);
            }

            base.Draw(gameTime);
        }
    }
}
