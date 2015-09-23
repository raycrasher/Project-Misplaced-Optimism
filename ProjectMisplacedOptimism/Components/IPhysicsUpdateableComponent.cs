using Artemis.Interface;
using Microsoft.Xna.Framework;

namespace ProjectMisplacedOptimism.Components
{
    public interface IPhysicsUpdateableComponent: IComponent
    {
        Matrix Transform { get; }
    }
}
