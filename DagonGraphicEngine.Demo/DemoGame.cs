using DagonGraphicEngine.Cameras;
using DagonGraphicEngine.Components;
using DagonGraphicEngine.Units;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DagonGraphicEngine.Demo
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DemoGame : DagonGame
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public DemoGame()
        {
            Settings = new GameSettings
            {
                FieldOfView = MathHelper.ToRadians(60.0f),
                RangeOfVisibility = 30f,
                EnableDefaultLighting = true,
                RotationSpeed = 0.005f,
                ScreenWidth = 1280,
                ScreenHight = 800,
                IsFullScreen = false,
                MouseSensitivity = 0.02f
            };

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Settings.ScreenWidth;
            graphics.PreferredBackBufferHeight = Settings.ScreenHight;
            graphics.IsFullScreen = Settings.IsFullScreen;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferMultiSampling = true;
            RasterizerState rasterizerState1 = new RasterizerState();
            rasterizerState1.CullMode = CullMode.None;
            graphics.GraphicsDevice.RasterizerState = rasterizerState1;

            var worldComponent = new WorldComponent(this);
            Components.Add(worldComponent);
            //Components.Add(new AxiesComponent(this));

            var player = World.Units.Find(u => u is Player);
            Camera = new FirstPersonCamera(this, player);
            Components.Add(new DebugInfoComponent(this, player));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(World.SkyColor);

            base.Draw(gameTime);
        }
    }
}
