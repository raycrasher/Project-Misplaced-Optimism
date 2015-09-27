using ProjectMisplacedOptimism.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Artemis.System;
using ProjectMisplacedOptimism.Components;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectMisplacedOptimism.Framework
{
    public class MainGameState: GameState
    {
        public Artemis.EntityWorld World { get; private set; }
        public SceneGraph SceneGraph { get; private set; }
        Camera _camera;

        public override void LoadContent()
        {
            _camera = new Camera();
            _camera.SceneGraphNode = new SceneGraphNode();
            _camera.ViewMatrix = Matrix.CreateLookAt(new Vector3(1, 1, 1), new Vector3(0, 0, 0), Vector3.UnitY);
            _camera.ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(45.0f), Game.Instance.GraphicsDevice.Viewport.AspectRatio,
                1.0f, 10000.0f); ;
            EntitySystem.BlackBoard.SetEntry("ActiveCamera", _camera);


            World = new Artemis.EntityWorld();
            World.SystemManager.SetSystem(new Systems.ModelRendererSystem(), Artemis.Manager.GameLoopType.Draw, 1, Artemis.Manager.ExecutionType.Synchronous);
            World.SetEntityTemplate("ship", new EntityTemplates.ShipEntityTemplate());
            SceneGraph = new SceneGraph();
            EntitySystem.BlackBoard.SetEntry("SceneGraph", SceneGraph);

            LoadTestContent();
        }

        private void LoadTestContent()
        {
            var ship=World.CreateEntityFromTemplate("ship", "test");
        }

        public override void Update(GameTime gameTime)
        {
            World.Update();
        }

        public override void Draw(GameTime gameTime)
        {
            Game.Instance.GraphicsDevice.Clear(Color.CornflowerBlue);
            World.Draw();
        }
    }
}
