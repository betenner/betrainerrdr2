///////////////////////////////////////////////
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
using System.Drawing;
using RDR2;
using RDR2.Native;
using BETrainerRdr2.Menu;

namespace BETrainerRdr2
{
    /// <summary>
    /// Trainer features
    /// </summary>
    public static partial class Feature
    {
        /// <summary>
        /// Updates all features
        /// </summary>
        public static void Update()
        {
            Player.Update();
            Vehicle.Update();
            Weapon.Update();
            DateTimeSpeed.Update();
            //World.UpdateFeatures();
            Weather.Update();
            Misc.Update();
        }

        /// <summary>
        /// Initialize features
        /// </summary>
        public static void Init()
        {
            Debug.Log("Feature.Init");
            Player.Init();
            Location.Init();
            Vehicle.Init();
            Weapon.Init();
            DateTimeSpeed.Init();
            //World.InitFeatures();
            Weather.Init();
            Misc.Init();
        }
    }
}
