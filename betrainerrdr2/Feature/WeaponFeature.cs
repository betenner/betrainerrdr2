///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using BETrainerRdr2.Menu;
using RDR2;
using RDR2.Native;

namespace BETrainerRdr2
{
    public static partial class Feature
    {
        /// <summary>
        /// Weapon features
        /// </summary>
        public static class Weapon
        {
            private static readonly float[] DAMAGE_MULTIPLIERS =
            {
                .01f, .05f, .1f, .2f, .5f, .8f, 1f, 1.5f, 2f, 3f, 5f, 10f, 20f, 50f, 100f
            };

            public const int DEFAULT_DAMAGE_MULTIPLIER_INDEX = 6;

            private static int _damageMultiplierIndex = DEFAULT_DAMAGE_MULTIPLIER_INDEX;
            public static int DamageMultiplierIndex 
            {
                get
                {
                    return _damageMultiplierIndex;
                }
                set
                {
                    int index = value;
                    if (index >= DAMAGE_MULTIPLIERS.Length) index = DAMAGE_MULTIPLIERS.Length - 1;
                    else if (index < 0) index = 0;
                    _damageMultiplierIndex = index;
                    MenuStorage.MenuItems.Weapon.DamageMultiplier.Data = _damageMultiplierIndex;
                    MenuStorage.MenuItems.Weapon.DamageMultiplier.Text = GetDamageMultiplierStr();
                    Function.Call(Hash.SET_PLAYER_WEAPON_DAMAGE_MODIFIER, Game.Player.Handle, DAMAGE_MULTIPLIERS[_damageMultiplierIndex]);
                    Config.DoAutoSave();
                }
            }

            public static bool InfiniteAmmo = false;

            public static void GiveSpecifiedWeapon(MenuItem sender)
            {
                int hash = Function.Call<int>(Hash.GET_HASH_KEY, sender.Data.ToString());
                Function.Call(Hash.GIVE_DELAYED_WEAPON_TO_PED, Game.Player.Character.Handle, hash, 100, 1, 0x2cd419dc);
                Function.Call(Hash.SET_PED_AMMO, Game.Player.Character.Handle, hash, 100);
                Function.Call(Hash.SET_CURRENT_PED_WEAPON, Game.Player.Character.Handle, hash, 1, 0, 0, 0);
            }

            /// <summary>
            /// Sets infinite ammo
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetInfiniteAmmo(MenuItem sender)
            {
                InfiniteAmmo = sender.On;
                Config.DoAutoSave();
            }

            public static MLString GetDamageMultiplierStr()
            {
                return Utils.FormatML(MenuText.Weapon.I031_DAMAGE_MULTIPLIER, DAMAGE_MULTIPLIERS[DamageMultiplierIndex]);
            }

            public static void OnDamageMultiplierInc(MenuItem sender)
            {
                if (sender != null && sender.Data != null && sender.Data is int)
                {
                    int index = (int)sender.Data + 1;
                    if (index >= DAMAGE_MULTIPLIERS.Length) index = DAMAGE_MULTIPLIERS.Length - 1;
                    DamageMultiplierIndex = index;
                    sender.Data = DamageMultiplierIndex;
                    sender.Text = GetDamageMultiplierStr();
                    Function.Call(Hash.SET_PLAYER_WEAPON_DAMAGE_MODIFIER, Game.Player.Handle, DAMAGE_MULTIPLIERS[DamageMultiplierIndex]);
                }
            }

            public static void OnDamageMultiplierDec(MenuItem sender)
            {
                if (sender != null && sender.Data != null && sender.Data is int)
                {
                    int index = (int)sender.Data - 1;
                    if (index < 0) index = 0;
                    DamageMultiplierIndex = index;
                    sender.Data = DamageMultiplierIndex;
                    sender.Text = GetDamageMultiplierStr();
                    Function.Call(Hash.SET_PLAYER_WEAPON_DAMAGE_MODIFIER, Game.Player.Handle, DAMAGE_MULTIPLIERS[DamageMultiplierIndex]);
                }
            }

            /// <summary>
            /// Updates weapon features
            /// </summary>
            public static void Update()
            {
                // Infinite ammo
                if (InfiniteAmmo)
                {
                    unsafe
                    {
                        int hash;
                        if (Function.Call<bool>(Hash.GET_CURRENT_PED_WEAPON, Game.Player.Character.Handle, &hash, 0, 0, 0))
                        {
                            if (Function.Call<bool>(Hash.IS_WEAPON_VALID, hash))
                            {
                                int maxAmmo;
                                if (Function.Call<bool>(Hash.GET_MAX_AMMO, Game.Player.Character.Handle, &maxAmmo, hash))
                                {
                                    Function.Call(Hash.SET_PED_AMMO, Game.Player.Character.Handle, hash, maxAmmo);
                                    maxAmmo = Function.Call<int>(Hash.GET_MAX_AMMO_IN_CLIP, Game.Player.Character.Handle, hash, 1);
                                    if (maxAmmo > 0) Function.Call(Hash.SET_AMMO_IN_CLIP, Game.Player.Character.Handle, hash, maxAmmo);
                                }
                            }
                        }
                    }
                }
            }

            /// <summary>
            /// Initializes features
            /// </summary>
            public static void Init()
            {
                Debug.Log("Weapon.Init");
                Debug.Log("Weapon.Init.SetInfiniteAmmo");
                SetInfiniteAmmo(MenuStorage.MenuItems.Weapon.InfiniteAmmo);
            }
        }
    }
}
