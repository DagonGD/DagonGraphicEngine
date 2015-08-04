using DagonGraphicEngine.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace DagonGraphicEngine.Demo
{
    public class Warrior:SpriteUnit
    {
        public Warrior(DagonGame game):base(game, game.Content.Load<Texture2D>("warrior"))
        {
            Speed = 0.001f;
        }

        public override void Update(GameTime gameTime)
        {
            var target = _game.World.Units.SingleOrDefault(u => u is Player);

            if(target != null)
            {
                var direction = target.Position - this.Position;
                direction.Y = 0;
                direction.Normalize();

                this.Position += direction * this.Speed * gameTime.ElapsedGameTime.Milliseconds;
            }

            base.Update(gameTime);
        }
    }
}
