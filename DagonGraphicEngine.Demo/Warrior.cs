using DagonGraphicEngine.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DagonGraphicEngine.Demo
{
    public class Warrior:SpriteUnit
    {
        public Warrior(DagonGame game):base(game, game.Content.Load<Texture2D>("warrior"))
        {

        }

        public override void Update(GameTime gameTime)
        {
            //Unit custom logic here

            base.Update(gameTime);
        }
    }
}
