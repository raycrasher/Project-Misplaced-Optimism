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
        Camera _camera;

        public override void LoadContent()
        {
            _camera = new Camera();
            EntitySystem.BlackBoard.SetEntry("ActiveCamera", _camera);

            World = new Artemis.EntityWorld();
            World.SystemManager.SetSystem(new Systems.ModelRendererSystem(), Artemis.Manager.GameLoopType.Draw, 1, Artemis.Manager.ExecutionType.Synchronous);
            World.SystemManager.SetSystem(new Systems.FrameUpdateSystem(), Artemis.Manager.GameLoopType.Update, 0, Artemis.Manager.ExecutionType.Synchronous);
            World.SystemManager.SetSystem(new Systems.FreeMovementControlSystem(), Artemis.Manager.GameLoopType.Update, 1, Artemis.Manager.ExecutionType.Synchronous);
            
            World.SetEntityTemplate("ship", new EntityTemplates.ShipEntityTemplate());

            //create camera
            var cameraEntity = World.CreateEntity();
            _camera.SceneGraphNode.SetTransform(Vector3.One, 10, 10, 10, Vector3.One); ;
            _camera.UpdateMatrices();
            cameraEntity.AddComponent(_camera);
            cameraEntity.AddComponent(_camera.SceneGraphNode);
            cameraEntity.AddComponent(new SimpleMovementComponent());
            cameraEntity.AddComponent(new PlayerInputComponent());
            cameraEntity.AddComponent(new FrameUpdateComponent(e=>_camera.UpdateMatrices()));

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
