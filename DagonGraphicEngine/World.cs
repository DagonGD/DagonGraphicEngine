using Microsoft.Xna.Framework;
using System.Collections.Generic;
using DagonGraphicEngine.Units;
using System;
using System.Linq;

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
            var player = Units.SingleOrDefault(u => u is Player);

            foreach (var unit in Units.OrderByDescending(u => Vector3.Distance(player.Position, u.Position)))
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
                if (unit.NewPosition.Y < 0)
                {
                    //TODO damage to unit
                    unit.Position = new Vector3(unit.Position.X, 0, unit.Position.Z);
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
