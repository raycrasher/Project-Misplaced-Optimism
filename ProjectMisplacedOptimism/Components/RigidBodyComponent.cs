using Artemis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulletSharp;
using Microsoft.Xna.Framework;

namespace ProjectMisplacedOptimism.Components
{
    public class RigidBodyComponent: IPhysicsUpdateableComponent
    {
        public RigidBody Body { get; set; }
        
        public Matrix Transform
        {
            get {
                return Body.CenterOfMassTransform;
            }
            
        }
    }
}
