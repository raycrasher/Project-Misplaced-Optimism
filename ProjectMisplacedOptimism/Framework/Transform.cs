using Artemis.Interface;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism.Framework
{
    public class Transform: IComponent
    {
        
        private Matrix _worldMatrix = Matrix.Identity;
        private Matrix _localMatrix = Matrix.Identity;
        private bool _worldMatrixNeedsUpdate = true;
        private Transform _parent;

        public Matrix LocalMatrix {
            get {
                return _localMatrix;
            }
            set {
                _worldMatrixNeedsUpdate = true;
                _localMatrix = value;
            }
        }

        public Transform Parent {
            get {
                return _parent;
            }
            set
            {
                // note: should we check for cyclic dependencies?
                if (value == this) throw new InvalidOperationException("You cannot assign a scene graph parent to itself.");
                _parent = value;
            }
        }

        public bool WorldMatrixNeedsUpdate
        {
            get
            {
                if (_worldMatrixNeedsUpdate) return true;
                if (Parent == null) return _worldMatrixNeedsUpdate;
                return Parent.WorldMatrixNeedsUpdate;
            }
        }

        public Matrix WorldMatrix {
            get
            {
                if (WorldMatrixNeedsUpdate)
                {
                    if (Parent == null) _worldMatrix = _localMatrix;
                    else _worldMatrix = _localMatrix * Parent.WorldMatrix;
                    _worldMatrixNeedsUpdate = false;
                }
                return _worldMatrix;
            }
        }

        public void SetTransform(Vector3 position, float yaw, float pitch, float roll, Vector3 scale)
        {
            LocalMatrix = Matrix.CreateScale(position) * Matrix.CreateFromYawPitchRoll(yaw, pitch, roll) * Matrix.CreateTranslation(scale);
        }
    }
}
