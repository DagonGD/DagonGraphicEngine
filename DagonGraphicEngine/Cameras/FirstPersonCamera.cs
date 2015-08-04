using DagonGraphicEngine.Units;
using Microsoft.Xna.Framework;

namespace DagonGraphicEngine.Cameras
{
    public class FirstPersonCamera : ICamera
    {
        private Unit _unit;

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
                return Matrix.CreateTranslation(-_unit.Position - _unit.Hight)
                    * Matrix.CreateRotationY(_unit.Angle)
                    * Matrix.CreateRotationX(_unit.Pitch);
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
