using BulletSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Microsoft.Xna.Framework;
using System.Threading;
using ProjectMisplacedOptimism.Components;
using ProjectMisplacedOptimism.Framework;

namespace ProjectMisplacedOptimism.Systems
{
    
    public class PhysicsSystem: Artemis.System.ParallelEntityProcessingSystem
    {
        public TimeSpan TimeStep { get; set; } = TimeSpan.FromSeconds(1d / 60d);
        public DynamicsWorld World { get; private set; }
        public bool ThreadIsRunning { get { return _threadIsRunning; } }

        CollisionDispatcher _collisionDispatcher;
        BroadphaseInterface _broadphaseInterface;
        CollisionConfiguration _collisionConfiguration;
        Task _worldUpdateTask;
        AutoResetEvent _worldSyncEvent;
        private bool _threadIsRunning = false;

        public PhysicsSystem() : base(Aspect.All(typeof(IPhysicsUpdateableComponent), typeof(SceneGraphNode)))
        {
        }

        protected override void Begin()
        {
            _threadIsRunning = true;
            _worldSyncEvent.WaitOne();
            base.Begin();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            _collisionConfiguration = new DefaultCollisionConfiguration();
            _collisionDispatcher = new CollisionDispatcher(_collisionConfiguration);
            _broadphaseInterface = new DbvtBroadphase();
            World = new DiscreteDynamicsWorld(_collisionDispatcher, _broadphaseInterface, null, _collisionConfiguration);
            World.Gravity = new Vector3(0, 9.8f, 0);
            _worldSyncEvent = new AutoResetEvent(false);
            _worldUpdateTask = new Task(UpdateWorld);
        }

        protected override void End()
        {
            _worldSyncEvent.Set();
            base.End();
        }

        public override void UnloadContent()
        {
            _threadIsRunning = false;
            _worldSyncEvent.Set();
            _worldUpdateTask.Wait();
            base.UnloadContent();
            World.Dispose();
        }

        public override void Process(Entity entity)
        {
            var updateable = entity.GetComponent<IPhysicsUpdateableComponent>();
            var sceneNode = entity.GetComponent<SceneGraphNode>();
            sceneNode.LocalMatrix = updateable.Transform;
        }

        void UpdateWorld()
        {
            while (_threadIsRunning)
            {
                World.StepSimulation((float)TimeStep.TotalSeconds);
                _worldSyncEvent.Set();
                _worldSyncEvent.WaitOne();
            }
        }
    }
}
