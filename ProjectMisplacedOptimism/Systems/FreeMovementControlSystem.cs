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
            if (Game.Keyboard.IsKeyDown(input.ForwardKey)) velocity.Y += movement.LinearSpeed;
            else if (Game.Keyboard.IsKeyDown(input.BackKey)) velocity.Y -= movement.LinearSpeed;

            if (Game.Keyboard.IsKeyDown(input.RightKey)) velocity.X += movement.LinearSpeed;
            else if (Game.Keyboard.IsKeyDown(input.LeftKey)) velocity.X -= movement.LinearSpeed;

            if (Game.Keyboard.IsKeyDown(input.UpKey)) velocity.Z += movement.LinearSpeed;
            else if (Game.Keyboard.IsKeyDown(input.DownKey)) velocity.Z -= movement.LinearSpeed;


        }
    }
}
