using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism
{
    public class Game: Microsoft.Xna.Framework.Game
    {
        public static Game Instance { get; private set; }

        public static GraphicsDeviceManager GraphicsManager { get; private set; }
        public static Properties.Settings Settings { get { return Properties.Settings.Default; } }

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
            GraphicsManager.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
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
