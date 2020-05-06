///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using RDR2;
using RDR2.Native;
using BETrainerRdr2.Menu;
using System;

namespace BETrainerRdr2
{
    public static partial class Feature
    {
        /// <summary>
        /// Player features
        /// </summary>
        public static class Player
        {
            public static bool Invincible = false;
            public static bool InfiniteAbility = false;
            public static bool InfiniteStamina = false;
            public static bool SuperJump = false;
            public static bool Noiseless = false;

            private const float NOISENESS_MULTIPLIER = 1.0f;
            private const float NOISELESS_MULTIPLIER = 0.0f;

            /// <summary>
            /// Initialize player features
            /// </summary>
            public static void Init()
            {
                Debug.Log("Player.Init");
                Debug.Log("Player.Init.SetInvincible");
                SetInvincible(MenuStorage.MenuItems.Player.Invincible);
                Debug.Log("Player.Init.SetInfiniteAbility");
                SetInfiniteAbility(MenuStorage.MenuItems.Player.InfiniteAbility);
                Debug.Log("Player.Init.SetSuperJump");
                SetSuperJump(MenuStorage.MenuItems.Player.SuperJump);
                Debug.Log("Player.Init.SetNoiseless");
                SetNoiseless(MenuStorage.MenuItems.Player.Noiseless);

                Debug.Log("Player.Init.Wanted.SetNeverWanted");
                Wanted.SetNeverWanted(MenuStorage.MenuItems.Player.Wanted.NeverWanted);
                Debug.Log("Player.Init.Wanted.SetEveryoneIgonred");
                Wanted.SetEveryoneIgonred(MenuStorage.MenuItems.Player.Wanted.EveryoneIgnored);
            }

            /// <summary>
            /// Updates player features
            /// </summary>
            public static void Update()
            {
                if (Invincible)
                {
                    Function.Call(Hash.SET_PLAYER_INVINCIBLE, Game.Player.Handle, true);
                }

                if (InfiniteStamina)
                {
                    Function.Call(Hash.RESTORE_PLAYER_STAMINA, Game.Player.Handle, 100f);
                }

                if (InfiniteAbility)
                {
                    Function.Call((Hash)GlobalConst.CustomHash.RESTORE_SPECIAL_ABILITY, Game.Player.Handle, -1, false);
                }

                if (SuperJump)
                {
                    Function.Call(Hash.SET_SUPER_JUMP_THIS_FRAME, Game.Player.Handle);
                }

                if (Noiseless)
                {
                    Function.Call(Hash.SET_PLAYER_NOISE_MULTIPLIER, Game.Player.Handle, NOISELESS_MULTIPLIER);
                    Function.Call(Hash.SET_PLAYER_SNEAKING_NOISE_MULTIPLIER, Game.Player.Handle, NOISELESS_MULTIPLIER);
                }

                Wanted.UpdateEveryoneIgnored();
                Wanted.UpdateNeverWanted();
            }

            /// <summary>
            /// Quick heal player
            /// </summary>
            public static void QuickHeal(MenuItem sender)
            {
                Game.Player.Character.Health = Game.Player.Character.MaxHealth;
                Function.Call(Hash.CLEAR_PED_WETNESS, Game.Player.Character.Handle);
                Function.Call(Hash.RESTORE_PLAYER_STAMINA, Game.Player.Handle, 100f);
                Function.Call((Hash)GlobalConst.CustomHash.RESTORE_SPECIAL_ABILITY, Game.Player.Handle, -1, false);
                Utils.ShowNotification(GlobalConst.Message.PLAYER_HEALED);
            }

            /// <summary>
            /// Sets player invincibility status
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetInvincible(MenuItem sender)
            {
                Invincible = sender.On;
                if (!Invincible) Function.Call(Hash.SET_PLAYER_INVINCIBLE, Game.Player.Handle, false);
                Config.DoAutoSave();
            }

            /// <summary>
            /// Sets player infinite ability
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetInfiniteAbility(MenuItem sender)
            {
                InfiniteAbility = sender.On;
                Config.DoAutoSave();
            }

            public static void SetInfiniteStamina(MenuItem sender)
            {
                InfiniteStamina = sender.On;
                Config.DoAutoSave();
            }

            /// <summary>
            /// Sets player super jump
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetSuperJump(MenuItem sender)
            {
                SuperJump = sender.On;
                Config.DoAutoSave();
            }

            /// <summary>
            /// Sets player noiseless
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetNoiseless(MenuItem sender)
            {
                Noiseless = sender.On;
                if (!Noiseless)
                {
                    Function.Call(Hash.SET_PLAYER_NOISE_MULTIPLIER, Game.Player.Handle, NOISENESS_MULTIPLIER);
                    Function.Call(Hash.SET_PLAYER_SNEAKING_NOISE_MULTIPLIER, Game.Player.Handle, NOISENESS_MULTIPLIER);
                }
                Config.DoAutoSave();
            }

            /// <summary>
            /// Change player's cash
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void ChangeCash(MenuItem sender)
            {
                if (sender != null && sender.Data != null && sender.Data.GetType() == typeof(int))
                {
                    int amount = (int)sender.Data;
                    if (amount < 0)
                    {
                        if (Math.Abs(amount) >= RDR2.Player.Money)
                        {
                            RDR2.Player.Money = 0;
                        }
                        else
                        {
                            RDR2.Player.Money += amount;
                        }
                    }
                    else
                    {
                        if (amount >= int.MaxValue - RDR2.Player.Money)
                        {
                            RDR2.Player.Money = int.MaxValue;
                        }
                        else
                        {
                            RDR2.Player.Money += amount;
                        }
                    }
                }
            }

            /// <summary>
            /// Decreases cash amount for changing
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void DecreaseCash(MenuItem sender)
            {
                if (sender != null && sender.Data != null && sender.Data.GetType() == typeof(int))
                {
                    int amount = (int)sender.Data;
                    if (amount == 1)
                    {
                        amount = -1;
                    }
                    else if (amount > 0)
                    {
                        amount /= 10;
                    }
                    else if (amount == -100000000)
                    {
                        amount = 100000000;
                    }
                    else
                    {
                        amount *= 10;
                    }
                    sender.Text = Utils.FormatML(MenuText.Player.CASH, (amount < 0 ? "-" : "+"), Math.Abs(amount) / 100f);
                    sender.Data = amount;
                }
            }

            /// <summary>
            /// Increases cash amount for changing
            /// </summary>
            /// <param name="sender">Source menu</param>
            public static void IncreaseCash(MenuItem sender)
            {
                if (sender != null && sender.Data != null && sender.Data.GetType() == typeof(int))
                {
                    int amount = (int)sender.Data;
                    if (amount == -1)
                    {
                        amount = 1;
                    }
                    else if (amount < 0)
                    {
                        amount /= 10;
                    }
                    else if (amount == 100000000)
                    {
                        amount = -100000000;
                    }
                    else
                    {
                        amount *= 10;
                    }
                    sender.Text = Utils.FormatML(MenuText.Player.CASH, (amount < 0 ? "-" : "+"), Math.Abs(amount) / 100f);
                    sender.Data = amount;
                }
            }

            /// <summary>
            /// Wanted features
            /// </summary>
            public static class Wanted
            {
                public static bool NeverWanted = false;
                public static bool EveryoneIgnored = false;

                /// <summary>
                /// Sets player never wanted
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void SetNeverWanted(MenuItem sender)
                {
                    NeverWanted = sender.On;
                    if (!NeverWanted) Function.Call(Hash.SET_WANTED_LEVEL_MULTIPLIER, 1f);
                    Config.DoAutoSave();
                }

                public static void ClearBounty(MenuItem sender)
                {
                    Function.Call((Hash)GlobalConst.CustomHash.CLEAR_CURRENT_PURSUIT);
                    Function.Call((Hash)GlobalConst.CustomHash.SET_PLAYER_PRICE_ON_A_HEAD, Game.Player.Handle, 0);
                    Function.Call(Hash._SET_WANTED_INTENSITY_FOR_PLAYER, Game.Player.Handle, 0);
                    Utils.ShowNotification(GlobalConst.Message.PLAYER_BOUNTY_CLEARED);
                }

                /// <summary>
                /// Updates never wanted
                /// </summary>
                public static void UpdateNeverWanted()
                {
                    if (NeverWanted)
                    {
                        Function.Call((Hash)GlobalConst.CustomHash.CLEAR_CURRENT_PURSUIT);
                        Function.Call((Hash)GlobalConst.CustomHash.SET_PLAYER_PRICE_ON_A_HEAD, Game.Player.Handle, 0);
                        Function.Call(Hash._SET_WANTED_INTENSITY_FOR_PLAYER, Game.Player.Handle, 0);
                        Function.Call(Hash.SET_WANTED_LEVEL_MULTIPLIER, 0f);
                    }
                }

                /// <summary>
                /// Sets player ignored by everyone
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void SetEveryoneIgonred(MenuItem sender)
                {
                    EveryoneIgnored = sender.On;
                    if (!EveryoneIgnored) Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player.Handle, false);
                    Config.DoAutoSave();
                }

                /// <summary>
                /// Updates player ignored by everyone
                /// </summary>
                public static void UpdateEveryoneIgnored()
                {
                    if (EveryoneIgnored) Function.Call(Hash.SET_EVERYONE_IGNORE_PLAYER, Game.Player.Handle, true);
                }
            }
        }
    }
}
