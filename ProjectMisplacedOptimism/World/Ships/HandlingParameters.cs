using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism.World.Ships
{
    /// <summary>
    /// A ship's handling parameters. All values are in newtons.
    /// </summary>
    public struct HandlingParameters
    {
        public float Forward;
        public float Side;
        public float Lift;
        public float Back;
        public float Yaw;
        public float Roll;
        public float Pitch;
    }
}
