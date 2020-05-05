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
using BETrainerRdr2.Menu;

namespace BETrainerRdr2
{
    public static partial class Feature
    {
        /// <summary>
        /// Configuration features
        /// </summary>
        public static class Config
        {
            public static bool AutoSave = false;

            /// <summary>
            /// Sets auto save
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetAutoSave(Menu.MenuItem sender)
            {
                AutoSave = sender.On;
            }

            /// <summary>
            /// Do auto save
            /// </summary>
            public static void DoAutoSave()
            {
                if (!AutoSave || Trainer.IsInitializing) return;
                Configuration.Save(false);
            }

            /// <summary>
            /// Save current configuration
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void Save(MenuItem sender)
            {
                Configuration.Save();
            }

            /// <summary>
            /// Load current configuration
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void Load(MenuItem sender)
            {
                Configuration.Load();
                MenuStorage.InitMenus();
                Feature.Init();
            }
        }
    }
}
