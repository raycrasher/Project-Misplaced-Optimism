using ProjectMisplacedOptimism.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;

namespace ProjectMisplacedOptimism.Systems
{
    public class FrameUpdateSystem : Artemis.System.EntityComponentProcessingSystem<FrameUpdateComponent>
    {
        public override void Process(Entity entity, FrameUpdateComponent component)
        {
            component.UpdateFunction(entity);
        }
    }

}
