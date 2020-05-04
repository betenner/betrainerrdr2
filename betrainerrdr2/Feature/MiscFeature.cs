//////////////////////////////////////////////
//   BE Trainer.NET for Grand Theft Auto V
//             by BE.Tenner
//      Copyright (c) BE Group 2015-2017
//               Thanks to
//    ScriptHookV & ScriptHookVDotNet
//  Native Trainer & Enhanced Native Trainer
//////////////////////////////////////////////

using BETrainerRdr2.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDR2;
using RDR2.Native;

namespace BETrainerRdr2
{
    public static partial class Feature
    {
        /// <summary>
        /// Misc features
        /// </summary>
        public static class Misc
        {
            public static bool HideHud = false;

            /// <summary>
            /// Initializes features
            /// </summary>
            public static void Init()
            {
                Debug.Log("Misc.Init");
                Debug.Log("Misc.Init.SetHideHud");
                SetHideHud(MenuStorage.MenuItems.Misc.HideHud);
            }

            /// <summary>
            /// Updates features
            /// </summary>
            public static void Update()
            {
                if (HideHud)
                {
                    Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME);
                }
            }

            /// <summary>
            /// Sets hide HUD
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetHideHud(MenuItem sender)
            {
                HideHud = sender.On;
                Config.DoAutoSave();
            }

            public static void RevealMap(MenuItem sender)
            {
                Function.Call((Hash)GlobalConst.CustomHash.SET_MINIMAP_REVEALED, true);
                Function.Call((Hash)GlobalConst.CustomHash.REVEAL_MAP, 0);
                Utils.ShowNotification(GlobalConst.Message.MAP_REVEALED);
            }
        }
    }
}
