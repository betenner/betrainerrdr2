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

namespace BETrainerRdr2.Weapon
{
    /// <summary>
    /// Saved weapon item
    /// </summary>
    public class SavedWeaponItem
    {
        public int Hash = 0;
        public int AmmoInWeapon = 0;
        public int AmmoInClip = 0;
        public int Tint = 0;
        public bool HasTint = false;
        public bool[] HasAttachment = null;
        public WeaponData Data = null;
    }
}
