using Microsoft.Xna.Framework;

namespace DagonGraphicEngine.Cameras
{
    public interface ICamera
    {
        Matrix View { get; }
        Matrix Projection { get; }
    }
}
