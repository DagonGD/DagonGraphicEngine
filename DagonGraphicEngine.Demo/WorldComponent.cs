using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace DagonGraphicEngine.Demo
{
    public class WorldComponent:DrawableGameComponent
    {
        private World _world;

        private readonly DagonGame _game;

        public WorldComponent(DemoGame game):base(game)
        {
            _game = game;
        }

        public override void Initialize()
        {
            _world = new World
            {
                Boxes = new List<Box>(),

                Units = new List<Unit>
                {
                    new Player()
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
            _world.Draw(gameTime);

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            _world.Update(gameTime);

            base.Update(gameTime);
        }
    }
}
