using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace DagonGraphicEngine.Demo
{
    public class WorldComponent:DrawableGameComponent
    {
        private readonly DagonGame _game;

        public WorldComponent(DemoGame game):base(game)
        {
            _game = game;
        }

        public override void Initialize()
        {
            _game.World = new World
            {
                Boxes = new List<Box>(),

                Units = new List<Unit>
                {
                    new Player(_game, _game.Content.Load<Texture2D>("player"))
                    {
                        Position = new Vector3(5f,5f,5f)
                    }
                }, 

                Terrain = new Terrain(_game, 100, 100)
                {
                    LandTexture = _game.Content.Load<Texture2D>("land")
                }
            };

            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            _game.World.Draw(gameTime);

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            _game.World.Update(gameTime);

            base.Update(gameTime);
        }
    }
}
