using System;
using Microsoft.Xna.Framework;

namespace DagonGraphicEngine.Units
{
    public class Player : Unit
    {
        public Player(DagonGame game):base(game)
        {
            Speed = 0.005f;
        }

        public override void Draw(GameTime gameTime)
        {
            
        }
    }
}
