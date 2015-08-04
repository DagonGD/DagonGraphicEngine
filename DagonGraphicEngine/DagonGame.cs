using Microsoft.Xna.Framework;

using DagonGraphicEngine.Cameras;
using Microsoft.Xna.Framework.Input;

namespace DagonGraphicEngine
{
    public class DagonGame: Game
    {
        protected override void Initialize()
        {
            Mouse.SetPosition(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            base.Initialize();
        }

        public ICamera Camera { get; set; }
        public World World { get; set; }
        public GameSettings Settings { get; set; }
    }
}
