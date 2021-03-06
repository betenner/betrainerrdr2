﻿///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BETrainerRdr2.Teleport
{
    /// <summary>
    /// Teleport category
    /// </summary>
    public class TeleportCategory
    {
        /// <summary>
        /// Name of this category
        /// </summary>
        public MLString Name = null;

        /// <summary>
        /// Teleport targets
        /// </summary>
        public TeleportTarget[] Targets = null;

        /// <summary>
        /// Creates a teleport category
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="targets">Targets</param>
        public TeleportCategory(MLString name, TeleportTarget[] targets)
        {
            Name = name;
            Targets = targets;
        }
    }
}
