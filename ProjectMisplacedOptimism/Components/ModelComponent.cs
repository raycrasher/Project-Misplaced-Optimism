using Artemis.Interface;
using Microsoft.Xna.Framework.Graphics;
using ProjectMisplacedOptimism.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism.Components
{
    public class ModelComponent: IComponent
    {
        public Model Model { get; set; }
        public SceneGraphNode SceneGraphNode { get; set; }
    }
}
