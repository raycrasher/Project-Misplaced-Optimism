using Artemis.Interface;
using Microsoft.Xna.Framework;
using ProjectMisplacedOptimism.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism.Components
{
    public class CameraComponent: IComponent
    {
        public SceneGraphNode SceneGraphNode { get; set; } = new SceneGraphNode();
        public Matrix ViewMatrix { get; set; } = Matrix.Identity;
        public Matrix ProjectionMatrix { get; set; } = Matrix.Identity;
    }
}
