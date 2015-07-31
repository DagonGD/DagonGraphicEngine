using Microsoft.Xna.Framework;

namespace DagonGraphicEngine
{
    public class FreeCamera : ICamera
    {
        private Matrix _projection;
        public Matrix Projection
        {
            get
            {
                return _projection;
            }
        }

        private Matrix _view;
        public Matrix View
        {
            get
            {
                return _view;
            }

        }

        public FreeCamera()
        {
            _projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), 2f, 0.1f, 100.0f);
            _view = Matrix.CreateLookAt(new Vector3(1, 1, 1), new Vector3(0, 1, 0), Vector3.Up);
        }

        public void MoveForward(float dist)
        {
            _view = _view * Matrix.CreateTranslation(0, 0, dist);
        }
        public void MoveRight(float dist)
        {
            _view = _view * Matrix.CreateTranslation(-dist, 0, 0);
        }

        public void MoveUp(float dist)
        {
            _view = _view * Matrix.CreateTranslation(0, -dist, 0);
        }

        public void RotateRight(float angle)
        {
            _view = _view * Matrix.CreateRotationY(angle);
        }
    }
}
