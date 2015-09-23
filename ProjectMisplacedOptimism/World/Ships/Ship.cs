using Artemis.Interface;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism.World.Ships
{
    public class Ship: IComponent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Model Model { get; set; }
        public HandlingParameters Handling { get; set; }
    }
}
