using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace DagonGraphicEngine
{
    public class Terrain
    {
        private readonly float[][] _hightMap;

        private readonly VertexPositionNormalTexture[] vertexData;

        private readonly DagonGame _game;

        private readonly BasicEffect _basicEffect;

        public Texture2D LandTexture
        {
            set
            {
                _basicEffect.Texture = value;
            }
        }

        public Terrain(DagonGame game, int width, int length)
        {
            _basicEffect = new BasicEffect(game.GraphicsDevice) { TextureEnabled = true};
            _basicEffect.EnableDefaultLighting();
            _basicEffect.PreferPerPixelLighting = true;

            _basicEffect.FogEnabled = true;
            _basicEffect.FogStart = game.Settings.RangeOfVisibility / 2f;
            _basicEffect.FogEnd = game.Settings.RangeOfVisibility;
            _basicEffect.FogColor = Color.CornflowerBlue.ToVector3();

            //_basicEffect.

            _game = game;

            _hightMap = new float[width + 1][];

            var random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < width + 1; i++)
            {
                _hightMap[i] = new float[length + 1];

                for (int j = 0; j < length + 1; j++)
                {
                    _hightMap[i][j] = (float)(random.NextDouble() / 4);
                }
            }

            vertexData = new VertexPositionNormalTexture[_hightMap.Length * _hightMap[0].Length * 2 * 3];

            var index = 0;
            //TODO make map width*length size
            for (int i = 0; i < width-1; i++)
            {
                for (int j = 0; j < length-1; j++)
                {
                    vertexData[index] = CreateVertex(i, j, new Vector2(0, 0));
                    index++;
                    vertexData[index] = CreateVertex(i + 1, j, new Vector2(1, 0));
                    index++;
                    vertexData[index] = CreateVertex(i, j + 1, new Vector2(0, 1));
                    index++;

                    vertexData[index] = CreateVertex(i + 1, j, new Vector2(1, 0));
                    index++;
                    vertexData[index] = CreateVertex(i + 1, j + 1, new Vector2(1, 1));
                    index++;
                    vertexData[index] = CreateVertex(i, j + 1, new Vector2(0, 1));
                    index++;
                }
            }
        }

        private VertexPositionNormalTexture CreateVertex(int i, int j, Vector2 textureCoord)
        {
            var position = new Vector3(i, _hightMap[i][j], j);
            var v1 = new Vector3(i, _hightMap[i][j+1], j+1) - position;
            var v2 = new Vector3(i+1, _hightMap[i+1][j], j) - position;
            var cross = Vector3.Cross(v1, v2);
            var normal = Vector3.Normalize(cross);

            return new VertexPositionNormalTexture(position, normal, textureCoord);
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
