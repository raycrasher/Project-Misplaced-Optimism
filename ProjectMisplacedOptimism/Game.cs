using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectMisplacedOptimism.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        public static Game Instance { get; private set; }

        public static GraphicsDeviceManager GraphicsManager { get; private set; }
        public static Properties.Settings Settings { get { return Properties.Settings.Default; } }
        public static GameTime CurrentUpdateTime { get; private set; }
        public static GameState State { get; set; }
        public static SpriteBatch GlobalSpriteBatch { get; private set; }

        private Game()
        {
            Instance = this;
            GraphicsManager = new GraphicsDeviceManager(this);
            GraphicsManager.PreferredBackBufferWidth = Settings.GraphicsWidth;
            GraphicsManager.PreferredBackBufferHeight = Settings.GraphicsHeight;
            GraphicsManager.IsFullScreen = Settings.Fullscreen;
            GraphicsManager.SynchronizeWithVerticalRetrace = Settings.VSync;
            IsFixedTimeStep = Settings.FrameLimit <= 0;
            if (IsFixedTimeStep)
                TargetElapsedTime = TimeSpan.FromSeconds(1d / Settings.FrameLimit);
            Content.RootDirectory = Settings.DataFolder;
            GraphicsManager.ApplyChanges();

            Artemis.System.EntitySystem.BlackBoard.SetEntry("ContentManager", Content);
            Artemis.System.EntitySystem.BlackBoard.SetEntry("GraphicsDevice", GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            CurrentUpdateTime = gameTime;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        static void Main(string[] args)
        {
            new Game();
            Instance.Run();
        }
    }
}
