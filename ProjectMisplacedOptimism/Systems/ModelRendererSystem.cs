using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using ProjectMisplacedOptimism.Components;
using Artemis.Attributes;
using Microsoft.Xna.Framework.Graphics;
using ProjectMisplacedOptimism.Framework;

namespace ProjectMisplacedOptimism.Systems
{
    [ArtemisEntitySystem(
        ExecutionType = Artemis.Manager.ExecutionType.Synchronous, 
        GameLoopType = Artemis.Manager.GameLoopType.Draw, 
        Layer = 0)]
    public class ModelRendererSystem : Artemis.System.EntityComponentProcessingSystem<ModelComponent, SceneGraphNode>
    {
        private CameraComponent _activeCamera;

        public GraphicsDevice Device { get; private set; }
        
        public override void LoadContent()
        {
            base.LoadContent();
            Device = BlackBoard.GetEntry<GraphicsDevice>("ActiveGraphicsDevice");
        }

        protected override void Begin()
        {
            _activeCamera = BlackBoard.GetEntry<CameraComponent>("ActiveCamera");
            base.Begin();
        }

        public override void Process(Entity entity, ModelComponent modelComponent, SceneGraphNode sceneGraphNode)
        {
            foreach (var mesh in modelComponent.Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = sceneGraphNode.WorldMatrix;
                    effect.View = _activeCamera.ViewMatrix;
                    effect.Projection = _activeCamera.ProjectionMatrix;
                }
                mesh.Draw();
            }
        }
    }
}
