﻿using Microsoft.Xna.Framework;

namespace DagonGraphicEngine.Cameras
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

        public FreeCamera(DagonGame game)
        {
            _projection = Matrix.CreatePerspectiveFieldOfView(
                game.Settings.FieldOfView, 
                game.GraphicsDevice.Viewport.AspectRatio,
                0.1f, 
                game.Settings.RangeOfVisibility);

            _view = Matrix.CreateLookAt(new Vector3(8, 3, 8), new Vector3(5, 3, 5), Vector3.Up);
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
