﻿using Artemis;
using Artemis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMisplacedOptimism.Components
{
    public class UpdateableComponent: IComponent
    {
        public Action<Entity> UpdateFunction { get; set; }
    }
}
