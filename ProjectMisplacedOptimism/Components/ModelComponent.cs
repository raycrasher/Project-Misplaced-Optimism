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
        public ModelComponent(Model model)
        {
            Model = model;
        }
        public bool IsVisible { get; set; } = true;
        public Model Model { get; set; }
    }
}
