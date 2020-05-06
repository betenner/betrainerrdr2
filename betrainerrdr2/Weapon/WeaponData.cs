///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

namespace BETrainerRdr2.Weapon
{
    /// <summary>
    /// Weapon data
    /// </summary>
    public class WeaponData
    {
        /// <summary>
        /// Name of the weapon
        /// </summary>
        public string Name { get; } = null;

        /// <summary>
        /// Internal value of the weapon
        /// </summary>
        public string InternalValue { get; } = null;

        public WeaponData(string name, string internalValue = null)
        {
            Name = name;
            InternalValue = internalValue ?? name;
        }
    }
}
