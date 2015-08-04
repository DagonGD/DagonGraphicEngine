using System;
using DagonGraphicEngine.Units;
using Microsoft.Xna.Framework;

namespace DagonGraphicEngine.Cameras
{
    public class FirstPersonCamera : ICamera
    {
        private Unit _unit;

        private Vector3 _height = new Vector3(0, 1.8f, 0);

        private Matrix _projection;
        public Matrix Projection
        {
            get
            {
                return _projection;
            }
        }

        public Matrix View
        {
            get
            {
                return Matrix.CreateTranslation(-_unit.Position - _height)
                    * Matrix.CreateRotationY(_unit.Angle);
            }
        }

        public FirstPersonCamera(DagonGame game, Unit unit)
        {
            _unit = unit;

            _projection = Matrix.CreatePerspectiveFieldOfView(
                game.Settings.FieldOfView,
                game.GraphicsDevice.Viewport.AspectRatio,
                0.1f,
                game.Settings.RangeOfVisibility);
        }
    }
}
