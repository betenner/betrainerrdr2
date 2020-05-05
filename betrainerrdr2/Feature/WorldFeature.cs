﻿///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

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
    public partial class Feature
    {
        /// <summary>
        /// World features
        /// </summary>
        public static class World
        {
            //public static bool MoonGravity = false;
            //public static bool RandomCops = true;
            //public static bool RandomTrains = true;
            //public static bool RandomBoats = true;
            //public static bool GarbageTrucks = true;
            //public static bool RestrictedZones = true;

            ///// <summary>
            ///// Initializes features
            ///// </summary>
            //public static void InitFeatures()
            //{
            //    SetMoonGravity(MenuStorage.MenuItems.World.MoonGravity);
            //    SetRandomCops(MenuStorage.MenuItems.World.RandomCops);
            //    SetRandomTrains(MenuStorage.MenuItems.World.RandomTrains);
            //    SetRandomBoats(MenuStorage.MenuItems.World.RandomBoats);
            //    SetGarbageTrucks(MenuStorage.MenuItems.World.GarbageTrucks);
            //    SetRestrictedZones(MenuStorage.MenuItems.World.RestrictedZones);
            //}

            ///// <summary>
            ///// Updates features
            ///// </summary>
            //public static void UpdateFeatures()
            //{
            //    Function.Call(Hash.SET_CREATE_RANDOM_COPS, RandomCops);

            //    if (MoonGravity)
            //    {
            //        Function.Call(Hash.SET_GRAVITY_LEVEL, 1);
            //    }
            //    else
            //    {
            //        Function.Call(Hash.SET_GRAVITY_LEVEL, 0);
            //    }

            //    if (!RestrictedZones)
            //    {
            //        Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "am_armybase");
            //        Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "restrictedareas");
            //        Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_armybase");
            //        Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_lossantosintl");
            //        Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_prison");
            //        Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, "re_prisonvanbreak");
            //    }
            //}

            ///// <summary>
            ///// Sets moon gravity
            ///// </summary>
            ///// <param name="sender">Source menu item</param>
            //public static void SetMoonGravity(MenuItem sender)
            //{
            //    MoonGravity = sender.On;
            //    Config.DoAutoSave();
            //}

            ///// <summary>
            ///// Sets random cops
            ///// </summary>
            ///// <param name="sender">Source menu item</param>
            //public static void SetRandomCops(MenuItem sender)
            //{
            //    RandomCops = sender.On;
            //    Config.DoAutoSave();
            //}

            ///// <summary>
            ///// Sets random trains
            ///// </summary>
            ///// <param name="sender">Source menu item</param>
            //public static void SetRandomTrains(MenuItem sender)
            //{
            //    RandomTrains = sender.On;
            //    Config.DoAutoSave();
            //    Function.Call(Hash.SET_RANDOM_TRAINS, sender.On);
            //}

            ///// <summary>
            ///// Sets random boats
            ///// </summary>
            ///// <param name="sender">Source menu item</param>
            //public static void SetRandomBoats(MenuItem sender)
            //{
            //    RandomBoats = sender.On;
            //    Config.DoAutoSave();
            //    Function.Call(Hash.SET_RANDOM_BOATS, sender.On);
            //}

            ///// <summary>
            ///// Sets garbage trucks
            ///// </summary>
            ///// <param name="sender">Source menu item</param>
            //public static void SetGarbageTrucks(MenuItem sender)
            //{
            //    GarbageTrucks = sender.On;
            //    Config.DoAutoSave();
            //    Function.Call(Hash.SET_GARBAGE_TRUCKS, sender.On);
            //}

            ///// <summary>
            ///// Sets restricted zones
            ///// </summary>
            ///// <param name="sender">Source menu item</param>
            //public static void SetRestrictedZones(MenuItem sender)
            //{
            //    RestrictedZones = sender.On;
            //    Config.DoAutoSave();
            //}
        }
    }
}
