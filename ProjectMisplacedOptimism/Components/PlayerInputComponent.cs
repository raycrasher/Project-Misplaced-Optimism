using Artemis.Interface;
using Microsoft.Xna.Framework.Input;
using ProjectMisplacedOptimism.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism.Components
{
    public class PlayerInputComponent: IComponent
    {
        public Keys ForwardKey { get; set; } = Keys.W;
        public Keys BackKey { get; set; } = Keys.S;
        public Keys LeftKey { get; set; } = Keys.A;
        public Keys RightKey { get; set; } = Keys.D;
        public Keys UpKey { get; set; } = Keys.LeftShift;
        public Keys DownKey { get; set; } = Keys.LeftControl;
        public Keys RollCwKey { get; set; } = Keys.E;
        public Keys RollCcwKey { get; set; } = Keys.Q;
    }
}
