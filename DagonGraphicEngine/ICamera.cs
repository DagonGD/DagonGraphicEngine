using Microsoft.Xna.Framework;

namespace DagonGraphicEngine
{
    public interface ICamera
    {
        Matrix View { get; }
        Matrix Projection { get; }
    }
}
