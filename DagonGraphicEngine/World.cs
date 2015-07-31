using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace DagonGraphicEngine
{
    public class World
    {
        public List<Box> Boxes { get; set; }
        public List<Unit> Units { get; set; }

        public void Draw(GameTime gameTime)
        {
            foreach(var box in Boxes)
            {
                box.Draw(gameTime);
            }
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
