using ProjectMisplacedOptimism.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Artemis.System;

namespace ProjectMisplacedOptimism.Framework
{
    public class MainGameState: GameState
    {
        public Artemis.EntityWorld World { get; private set; }
        public SceneGraph SceneGraph { get; private set; }


        public override void LoadContent()
        {
            World = new Artemis.EntityWorld();
            SceneGraph = new SceneGraph();
            EntitySystem.BlackBoard.SetEntry("SceneGraph", SceneGraph);
        }
    }
}
