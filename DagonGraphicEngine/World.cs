using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace DagonGraphicEngine
{
    public class World
    {
        public List<Box> Boxes { get; set; }
        public List<Unit> Units { get; set; }
        public Terrain Terrain { get; set; }
        public Vector3 Gravity { get; set; }

        public World()
        {
            Gravity = new Vector3(0f, -9.8f, 0f);
        }

        public void Draw(GameTime gameTime)
        {
            Terrain.Draw(gameTime);

            foreach(var box in Boxes)
            {
                box.Draw(gameTime);
            }

            foreach (var unit in Units)
            {
                unit.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var unit in Units)
            {
                unit.Update(gameTime);
            }

            //TODO collision detection

            foreach (var unit in Units)
            {
                //unit.ApplyNewPosition();
            }
        }
    }
}
