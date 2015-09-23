using ProjectMisplacedOptimism.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Artemis.System;
using Artemis.Attributes;

namespace ProjectMisplacedOptimism.Systems
{
    [ArtemisEntitySystem(ExecutionType =Artemis.Manager.ExecutionType.Synchronous, GameLoopType = Artemis.Manager.GameLoopType.Update)]
    public class WorldUpdateSystem: ProcessingSystem
    {
        public DateTime GlobalTime { get; set; } = Game.Settings.WorldStartDate;
        public CoroutineManager GlobalCoroutines { get; } = new CoroutineManager();
        DateTime _lastUpdateTime;

        public void ExecuteEventOn(DateTime time, Action action)
        {
            GlobalCoroutines.StartCoroutine(ExecuteEventOnMonitor(time, action));
        }

        public void ExecuteEventAfter(TimeSpan time, Action action)
        {
            ExecuteEventOn(GlobalTime + time, action);
        }

        private IEnumerable ExecuteEventOnMonitor(DateTime time, Action action)
        {
            while(GlobalTime < time)
                yield return null;
            action();
        }

        public override void ProcessSystem()
        {
            GlobalTime += Game.CurrentUpdateTime.ElapsedGameTime;
            if (GlobalTime - _lastUpdateTime < TimeSpan.FromSeconds(1)) return;
            _lastUpdateTime = GlobalTime;
            GlobalCoroutines.RunCoroutines(Game.CurrentUpdateTime.ElapsedGameTime);
        }
    }
}
