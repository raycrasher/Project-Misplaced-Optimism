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
using Microsoft.Xna.Framework;

namespace ProjectMisplacedOptimism.Systems
{
    [ArtemisEntitySystem(
        ExecutionType = Artemis.Manager.ExecutionType.Synchronous, 
        GameLoopType = Artemis.Manager.GameLoopType.Draw, 
        Layer = 0)]
    public class ModelRendererSystem : Artemis.System.EntityComponentProcessingSystem<ModelComponent, Transform>
    {
        private Camera _activeCamera;
        Matrix[] _sharedDrawBoneMatrices = new Matrix[10];

        public GraphicsDevice Device { get; private set; }
        
        public override void LoadContent()
        {
            base.LoadContent();
            Device = BlackBoard.GetEntry<GraphicsDevice>("ActiveGraphicsDevice");
        }

        protected override void Begin()
        {
            _activeCamera = BlackBoard.GetEntry<Camera>("ActiveCamera");
            base.Begin();
        }

        public override void Process(Entity entity, ModelComponent modelComponent, Transform xform)
        {
            if (!modelComponent.IsVisible) return;
            var model = modelComponent.Model;
            int boneCount = model.Bones.Count;

            if (_sharedDrawBoneMatrices == null ||
                _sharedDrawBoneMatrices.Length < boneCount)
            {
                _sharedDrawBoneMatrices = new Matrix[boneCount];
            }

            // Look up combined bone matrices for the entire model.            
            model.CopyAbsoluteBoneTransformsTo(_sharedDrawBoneMatrices);

            // Draw the model.
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (Effect effect in mesh.Effects)
                {
                    IEffectMatrices effectMatricies = effect as IEffectMatrices;
                    if (effectMatricies == null)
                    {
                        throw new InvalidOperationException();
                    }
                    effectMatricies.World = _sharedDrawBoneMatrices[mesh.ParentBone.Index] * xform.WorldMatrix;
                    effectMatricies.View = _activeCamera.ViewMatrix;
                    effectMatricies.Projection = _activeCamera.ProjectionMatrix;
                    var basicEffect = effect as BasicEffect;
                    if( basicEffect != null){
                        basicEffect.LightingEnabled = true;
                        basicEffect.TextureEnabled = true;
                        basicEffect.AmbientLightColor = new Vector3(0.2f, 0.2f, 0.2f);
                        basicEffect.EmissiveColor = new Vector3(0, 0, 0);
                        basicEffect.SpecularPower = 0.1f;
                        basicEffect.DiffuseColor = new Vector3(0.2f,0.2f,0.2f);
                        basicEffect.DirectionalLight0.Enabled = true;
                        basicEffect.DirectionalLight0.DiffuseColor = new Vector3(0.2f);
                        basicEffect.DirectionalLight0.SpecularColor = new Vector3(0.2f);
                        basicEffect.DirectionalLight0.Direction = new Vector3(-10,-10,10);
                    }
                }

                mesh.Draw();
            }

            //modelComponent.Model.Draw(sceneGraphNode.WorldMatrix, _activeCamera.ViewMatrix, _activeCamera.ProjectionMatrix);
        }
    }
}
