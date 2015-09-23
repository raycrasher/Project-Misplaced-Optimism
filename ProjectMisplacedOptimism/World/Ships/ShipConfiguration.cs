using Artemis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism.World.Ships
{
    public class ShipConfiguration: IComponent
    {
        public Ship Ship { get; set; }
        public HandlingParameters ActualHandling { get; set; }
    }
}
