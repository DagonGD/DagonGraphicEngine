using Microsoft.Xna.Framework;
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
                Boxes = new List<Box>
                {
                    new Box(_game)
                    {
                        Dimentions = new Vector3(5f,1f,5f),
                        World = Matrix.Identity
                    }
                },

                Units = new List<Unit>
                {
                    new Player()
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
