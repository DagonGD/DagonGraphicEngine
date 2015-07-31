using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DagonGraphicEngine
{
    public class Box
    {
        public Vector3 Dimentions { get; set; }
        public Matrix World { get; set; }

        private readonly BasicEffect _basicEffect;
        private readonly DagonGame _game;
        VertexPositionColor[] vertexData;

        public Box(DagonGame game)
        {
            _basicEffect = new BasicEffect(game.GraphicsDevice) { VertexColorEnabled = true };
            _game = game;            
        }

        public void Draw(GameTime gameTime)
        {
            _basicEffect.Projection = _game.Camera.Projection;
            _basicEffect.View = _game.Camera.View;

            vertexData = new VertexPositionColor[4];
            vertexData[0] = new VertexPositionColor(new Vector3(0f, 0f, 0f), Color.Green);
            vertexData[1] = new VertexPositionColor(new Vector3(Dimentions.X, 0f, 0f), Color.Red);
            vertexData[2] = new VertexPositionColor(new Vector3(0f, 0f, Dimentions.Z), Color.Green);
            vertexData[3] = new VertexPositionColor(new Vector3(Dimentions.X, 0f, Dimentions.Z), Color.Red);

            foreach (var pass in _basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                _game.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, vertexData, 0, 2);
            }
        }
    }
}
