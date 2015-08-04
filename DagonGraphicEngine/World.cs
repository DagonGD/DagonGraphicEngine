using Microsoft.Xna.Framework;
using System.Collections.Generic;
using DagonGraphicEngine.Units;

namespace DagonGraphicEngine
{
    public class World
    {
        public List<Box> Boxes { get; set; }
        public List<Unit> Units { get; set; }
        public Terrain Terrain { get; set; }
        public Vector3 Gravity { get; set; }
        public Color SkyColor { get; set; }

        public World()
        {
            Gravity = new Vector3(0f, -9.8f, 0f);
            SkyColor = Color.CornflowerBlue;
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

            foreach (var unit in Units)
            {
                //TODO check collision with terrain
                if (unit.Position.Y < 0)
                {
                    //TODO damage to unit
                    unit.Velocity = Vector3.Zero;
                    unit.Acceleration = Vector3.Zero;
                }
                else
                {
                    unit.ApplyNewPosition();
                }
            }
        }
    }
}
