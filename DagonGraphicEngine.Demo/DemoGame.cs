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
        FirstPersonCamera firstPersonCamera;
        const float MoveSpeed = 0.005f;
        const float RotationSpeed = 0.005f;

        public DemoGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 800;

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
            Settings = new GameSettings
            {
                FieldOfView = MathHelper.ToRadians(60.0f),
                RangeOfVisibility = 30f,
                EnableDefaultLighting = true
            };

            

            graphics.PreferMultiSampling = true;
            RasterizerState rasterizerState1 = new RasterizerState();
            rasterizerState1.CullMode = CullMode.None;
            graphics.GraphicsDevice.RasterizerState = rasterizerState1;

            var worldComponent = new WorldComponent(this);
            Components.Add(worldComponent);
            Components.Add(new AxiesComponent(this));

            firstPersonCamera = new FirstPersonCamera(this, this.World.Units.Find(u=>u is Player));
            Camera = firstPersonCamera;

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
            // TODO: Add your update logic here
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            var distance = gameTime.ElapsedGameTime.Milliseconds * MoveSpeed;
            var rotationAngle = gameTime.ElapsedGameTime.Milliseconds * RotationSpeed;

            /*if (keyboardState.IsKeyDown(Keys.W))
            {
                firstPersonCamera.MoveForward(distance);
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                firstPersonCamera.MoveForward(-distance);
            }

            if (keyboardState.IsKeyDown(Keys.A))
            {
                firstPersonCamera.MoveRight(-distance);
            }

            if (keyboardState.IsKeyDown(Keys.D))
            {
                firstPersonCamera.MoveRight(distance);
            }

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                firstPersonCamera.MoveUp(distance);
            }

            if (keyboardState.IsKeyDown(Keys.C))
            {
                firstPersonCamera.MoveUp(-distance);
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                firstPersonCamera.RotateRight(rotationAngle);
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                firstPersonCamera.RotateRight(-rotationAngle);
            }*/


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(World.SkyColor);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
