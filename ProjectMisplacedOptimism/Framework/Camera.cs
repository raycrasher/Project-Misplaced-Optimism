﻿using Artemis.Interface;
using Microsoft.Xna.Framework;
using ProjectMisplacedOptimism.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism.Framework
{
    public class Camera: IComponent
    {
        public SceneGraphNode SceneGraphNode { get; set; }
            = new SceneGraphNode();

        public Matrix ViewMatrix { get; set; }
            = Matrix.CreateLookAt(new Vector3(1, 1, 1), new Vector3(0, 0, 0), Vector3.UnitY);

        public Matrix ProjectionMatrix { get; set; }
            = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(45.0f), Game.Instance.GraphicsDevice.Viewport.AspectRatio,
                1.0f, 10000.0f);

        public void UpdateMatrices()
        {
            var matrix = SceneGraphNode.WorldMatrix;
            ViewMatrix = Matrix.CreateLookAt(matrix.Translation, matrix.Forward, matrix.Up);
        }
    }
}
