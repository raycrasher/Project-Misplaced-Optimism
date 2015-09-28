using Artemis.Interface;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism.Components
{
    public class SimpleMovementComponent: IComponent
    {
        public float LinearSpeed { get; set; } = 2;
        public float AngularSpeed { get; set; } = 0.1f;
    }
}
