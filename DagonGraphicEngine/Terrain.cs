using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace DagonGraphicEngine
{
    public class Terrain
    {
        private readonly float[][] _hightMap;

        private readonly VertexPositionColor[] vertexData;

        private readonly DagonGame _game;

        private readonly BasicEffect _basicEffect;

        public Terrain(DagonGame game, int width, int length)
        {
            _basicEffect = new BasicEffect(game.GraphicsDevice) { VertexColorEnabled = true };
            _game = game;

            _hightMap = new float[width + 1][];

            var random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < width + 1; i++)
            {
                _hightMap[i] = new float[length + 1];

                for (int j = 0; j < length + 1; j++)
                {
                    _hightMap[i][j] = (float)(random.NextDouble() / 2);
                }
            }

            vertexData = new VertexPositionColor[_hightMap.Length * _hightMap[0].Length * 2 * 3];

            var index = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    vertexData[index] = CreateVertex(i, j, Color.Green);
                    index++;
                    vertexData[index] = CreateVertex(i + 1, j, Color.Green);
                    index++;
                    vertexData[index] = CreateVertex(i, j + 1, Color.Green);
                    index++;

                    vertexData[index] = CreateVertex(i + 1, j, Color.Green);
                    index++;
                    vertexData[index] = CreateVertex(i + 1, j + 1, Color.Green);
                    index++;
                    vertexData[index] = CreateVertex(i, j + 1, Color.Green);
                    index++;
                }
            }
        }

        private VertexPositionColor CreateVertex(int i, int j, Color color)
        {
            return new VertexPositionColor(new Vector3(i, _hightMap[i][j], j), color);
        }

        public void Draw(GameTime gameTime)
        {
            _basicEffect.View = _game.Camera.View;
            _basicEffect.Projection = _game.Camera.Projection;

            foreach (var pass in _basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                _game.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, vertexData, 0, vertexData.Length / 3);
            }
        }
    }
}
