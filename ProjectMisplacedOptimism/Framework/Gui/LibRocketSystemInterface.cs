using System;

namespace ProjectMisplacedOptimism.Framework.Gui
{
    class LibRocketSystemInterface : LibRocketNet.SystemInterface
    {
        protected override float GetElapsedTime()
        {
            return (float)Game.CurrentUpdateTime.ElapsedGameTime.TotalSeconds;
        }

        protected override bool LogMessage(LibRocketNet.LogType type, string message)
        {
            Console.WriteLine("GUI: {0}", message);
            return true;
        }

        protected override void JoinPath(ref string translatedPath, string documentPath, string path)
        {
            Console.WriteLine("{0} {1}", documentPath, path);
            base.JoinPath(ref translatedPath, documentPath, path);
        }
    }
}
