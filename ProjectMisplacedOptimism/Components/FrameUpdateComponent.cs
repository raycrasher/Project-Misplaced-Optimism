using Artemis;
using Artemis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism.Components
{
    public class FrameUpdateComponent: IComponent
    {

        public FrameUpdateComponent(Action<Entity> action = null)
        {
            this.UpdateFunction = action;
        }

        public Action<Entity> UpdateFunction { get; set; }
    }
}
