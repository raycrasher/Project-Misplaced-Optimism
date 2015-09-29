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
    public class FreeMovementControlSystem : Artemis.System.EntityComponentProcessingSystem<Transform, SimpleMovementComponent, PlayerInputComponent>
    {
        public override void Process(Entity entity, Transform xform, SimpleMovementComponent movement, PlayerInputComponent input)
        {
            Vector3 velocity = Vector3.Zero;
            if (Game.Keyboard.IsKeyDown(input.ForwardKey)) velocity += xform.LocalMatrix.Forward.AsNormalized() * movement.LinearSpeed;
            else if (Game.Keyboard.IsKeyDown(input.BackKey)) velocity += xform.LocalMatrix.Backward.AsNormalized() * movement.LinearSpeed;

            if (Game.Keyboard.IsKeyDown(input.RightKey)) velocity += xform.LocalMatrix.Right.AsNormalized() * movement.LinearSpeed;
            else if (Game.Keyboard.IsKeyDown(input.LeftKey)) velocity += xform.LocalMatrix.Left.AsNormalized() * movement.LinearSpeed;

            if (Game.Keyboard.IsKeyDown(input.UpKey)) velocity += xform.LocalMatrix.Up.AsNormalized() * movement.LinearSpeed;
            else if (Game.Keyboard.IsKeyDown(input.DownKey)) velocity += xform.LocalMatrix.Down.AsNormalized() * movement.LinearSpeed;

            xform.LocalMatrix = xform.LocalMatrix * Matrix.CreateTranslation(velocity);
        }
    }
}
