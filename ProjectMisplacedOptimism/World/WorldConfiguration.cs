using Microsoft.Xna.Framework.Graphics;
using ProjectMisplacedOptimism.World.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism.World
{
    public class WorldConfiguration
    {
        public Dictionary<string, Ship> Ships { get; set; } = new Dictionary<string, Ship>();
        public DateTime WorldStartDate { get; set; } 

        public void LoadShips()
        {
            Ships["test"] = new Ship
            {
                Id = "test",
                Model = Game.Instance.Content.Load<Model>("Models/test-vtol"),
                Name = "Test Ship",
                Description = "A test ship for debugging",
                Handling = new HandlingParameters
                {
                    Back=10,
                    Forward=10,
                    Lift=10,
                    Pitch=1,
                    Roll=1,
                    Yaw=1,
                    Side=1
                }
            };
        }

        internal void LoadAll()
        {
            WorldStartDate = new DateTime(2350,1,1);
            LoadShips();
        }
    }
}
