using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using ProjectMisplacedOptimism.Framework;
using ProjectMisplacedOptimism.Components;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace ProjectMisplacedOptimism.Systems
{
    public class FreeMovementControlSystem : Artemis.System.EntityComponentProcessingSystem<SceneGraphNode, SimpleMovementComponent, PlayerInputComponent>
    {
        public override void Process(Entity entity, SceneGraphNode sceneNode, SimpleMovementComponent movement, PlayerInputComponent input)
        {
            Vector3 velocity = Vector3.Zero;
            if (Game.Keyboard.IsKeyDown(input.ForwardKey)) velocity += sceneNode.LocalMatrix.Forward.AsNormalized() * movement.LinearSpeed;
            else if (Game.Keyboard.IsKeyDown(input.BackKey)) velocity += sceneNode.LocalMatrix.Backward.AsNormalized() * movement.LinearSpeed;

            if (Game.Keyboard.IsKeyDown(input.RightKey)) velocity += sceneNode.LocalMatrix.Right.AsNormalized() * movement.LinearSpeed;
            else if (Game.Keyboard.IsKeyDown(input.LeftKey)) velocity += sceneNode.LocalMatrix.Left.AsNormalized() * movement.LinearSpeed;

            if (Game.Keyboard.IsKeyDown(input.UpKey)) velocity += sceneNode.LocalMatrix.Up.AsNormalized() * movement.LinearSpeed;
            else if (Game.Keyboard.IsKeyDown(input.DownKey)) velocity += sceneNode.LocalMatrix.Down.AsNormalized() * movement.LinearSpeed;

            sceneNode.LocalMatrix = sceneNode.LocalMatrix * Matrix.CreateTranslation(velocity);
        }
    }
}
