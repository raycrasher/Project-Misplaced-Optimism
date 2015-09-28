using ProjectMisplacedOptimism.World.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism.World
{
    public class GameConfiguration
    {
        public DateTime StartTime { get; set; }
        public Dictionary<string, Ship> Ships { get; set; }
    }
}
