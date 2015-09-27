using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Artemis.Attributes;
using ProjectMisplacedOptimism.Components;

namespace ProjectMisplacedOptimism.Framework.EntityTemplates
{
    [ArtemisEntityTemplate("ship")]
    public class ShipEntityTemplate : Artemis.Interface.IEntityTemplate
    {
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            var shipDef = Game.WorldConfiguration.Ships[args[0] as string];
            entity.AddComponent(new ModelComponent(shipDef.Model));
            entity.AddComponent(new SceneGraphNode());
            entity.AddComponent(shipDef);
            return entity;
        }
    }
}
