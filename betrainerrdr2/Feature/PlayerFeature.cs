﻿using RDR2;
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
            public static bool FastRun = false;
            public static bool FastSwim = false;
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
                    Function.Call(Hash.SET_PLAYER_INVINCIBLE, true);
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
                    sender.Text = Utils.FormatML(MenuText.Player.I03_CASH, (amount < 0 ? "-" : "+"), Math.Abs(amount) / 100f);
                    sender.Data = amount;
                    if (sender.Parent.PlayBeep) MenuStorage.PlayMenuBeep();
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
                    sender.Text = Utils.FormatML(MenuText.Player.I03_CASH, (amount < 0 ? "-" : "+"), Math.Abs(amount) / 100f);
                    sender.Data = amount;
                    if (sender.Parent.PlayBeep) MenuStorage.PlayMenuBeep();
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

        //    /// <summary>
        //    /// Model features
        //    /// </summary>
        //    public static class PlayerModel
        //    {
        //        private const int SET_MODEL_WAIT = 100;

        //        /// <summary>
        //        /// Change player's model back to Michael when being wasted or busted to prevent game from infinite loop
        //        /// </summary>
        //        public static void ValidatePlayerModel()
        //        {
        //            if (Game.Player.IsDead || Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED, Game.Player.Handle, true))
        //            {
        //                int hashMichael = Function.Call<int>(Hash.GET_HASH_KEY, ModelStorage.MODEL_MICHAEL.Hash);
        //                int hashFranklin = Function.Call<int>(Hash.GET_HASH_KEY, ModelStorage.MODEL_FRANKLIN.Hash);
        //                int hashTrevor = Function.Call<int>(Hash.GET_HASH_KEY, ModelStorage.MODEL_TREVOR.Hash);
        //                if (Game.Player.Character.Model.Hash != hashMichael &&
        //                    Game.Player.Character.Model.Hash != hashFranklin &&
        //                    Game.Player.Character.Model.Hash != hashTrevor)
        //                {
        //                    SetModel(ModelStorage.MODEL_MICHAEL);

        //                    // Wait until player is resurrected
        //                    while (Game.Player.IsDead || Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED, Game.Player.Handle, true)) Script.Wait(0);
        //                }
        //            }
        //        }

        //        /// <summary>
        //        /// Set to specified Model
        //        /// </summary>
        //        /// <param name="model">Model data</param>
        //        public static void SetModel(ModelData model)
        //        {
        //            int modelHash = Function.Call<int>(Hash.GET_HASH_KEY, model.Hash);
        //            SetModel(modelHash, model.Name);
        //        }

        //        /// <summary>
        //        /// Set to specified Model
        //        /// </summary>
        //        /// <param name="modelHash">Model hash</param>
        //        /// <param name="modelName">Name of the model</param>
        //        public static void SetModel(int modelHash, string modelName)
        //        {
        //            RDR2.Model m = new RDR2.Model(modelHash);
        //            m.Request();

        //            if (m.IsInCdImage && m.IsValid)
        //            {
        //                while (!m.IsLoaded) Script.Wait(0);

        //                int? vehicle = null;
        //                if (Game.Player.Character.IsInVehicle())
        //                {
        //                    vehicle = Game.Player.Character.CurrentVehicle.Handle;
        //                }

        //                WeaponSet set = Weapon.GetCurrentWeaponSet();

        //                Function.Call(Hash.SET_PLAYER_MODEL, Game.Player.Handle, m.Hash);
        //                Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character.Handle);
        //                if (!string.IsNullOrEmpty(modelName))
        //                {
        //                    Utils.ShowNotification(Utils.FormatML(GlobalConst.Message.PLAYER_MODEL_SET, modelName));
        //                }
        //                Script.Wait(0);

        //                if (vehicle.HasValue)
        //                {
        //                    Function.Call(Hash.SET_PED_INTO_VEHICLE, Game.Player.Character.Handle, vehicle, -1);
        //                }

        //                Weapon.ApplyWeaponSet(set);

        //                Script.Wait(SET_MODEL_WAIT);
        //                m.MarkAsNoLongerNeeded();
        //            }
        //        }

        //        /// <summary>
        //        /// Set to Michael
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void SetToMichael(MenuItem sender)
        //        {
        //            SetModel(ModelStorage.MODEL_MICHAEL);
        //        }

        //        /// <summary>
        //        /// Set to Franklin
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void SetToFranklin(MenuItem sender)
        //        {
        //            SetModel(ModelStorage.MODEL_FRANKLIN);
        //        }

        //        /// <summary>
        //        /// Set to Trevor
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void SetToTrevor(MenuItem sender)
        //        {
        //            SetModel(ModelStorage.MODEL_TREVOR);
        //        }

        //        /// <summary>
        //        /// Reset skin
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void ResetSkin(MenuItem sender)
        //        {
        //            Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character.Handle);
        //            Utils.ShowNotification(GlobalConst.Message.PLAYER_RESET_SKIN);
        //        }

        //        /// <summary>
        //        /// Sets to a random model
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void SetToRandomModel(MenuItem sender)
        //        {
        //            ModelData Model = null;
        //            Random rnd = new Random();
        //            if (rnd.NextDouble() < (double)ModelStorage.MODEL_ANIMALS.Length / ModelStorage.MODEL_NPCS.Length)
        //            {
        //                Model = ModelStorage.MODEL_ANIMALS[rnd.Next(ModelStorage.MODEL_ANIMALS.Length)];
        //            }
        //            else
        //            {
        //                Model = ModelStorage.MODEL_NPCS[rnd.Next(ModelStorage.MODEL_NPCS.Length)];
        //            }
        //            SetModel(Model);
        //        }

        //        /// <summary>
        //        /// Sets to specified Model
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void SetToModel(MenuItem sender)
        //        {
        //            if (sender.Data == null) return;
        //            SetModel(sender.Data as ModelData);
        //        }
        //    }

        //    /// <summary>
        //    /// Skin features
        //    /// </summary>
        //    public static class Skin
        //    {
        //        /// <summary>
        //        /// Chosen drawable index of each category
        //        /// </summary>
        //        public static int[] ChosenDrawables = new int[SkinPropUtils.SKIN_CATEGORY_COUNT];

        //        /// <summary>
        //        /// Chosen texture index of each drawable in each category
        //        /// </summary>
        //        public static int[][] ChosenTextures = new int[SkinPropUtils.SKIN_CATEGORY_COUNT][];

        //        /// <summary>
        //        /// Static constructor
        //        /// </summary>
        //        static Skin()
        //        {
        //            for (int i = 0; i < SkinPropUtils.SKIN_CATEGORY_COUNT; i++)
        //            {
        //                ChosenTextures[i] = new int[SkinPropUtils.SKIN_CATEGORY_DRAWABLE_MAX_COUNT];
        //            }
        //        }

        //        private const int SET_SKIN_WAIT_TIME = 100;

        //        /// <summary>
        //        /// Gets the current skin drawables and textures
        //        /// </summary>
        //        public static void GetCurrentSkinSet()
        //        {
        //            for (int i = 0; i < SkinPropUtils.SKIN_CATEGORY_COUNT; i++)
        //            {
        //                ChosenDrawables[i] = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character.Handle, i);
        //                int textureCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character.Handle, i, ChosenDrawables[i]);
        //                for (int j = 0; j < textureCount; j++)
        //                {
        //                    ChosenTextures[i][j] = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character.Handle, i, j);
        //                }
        //            }
        //        }

        //        /// <summary>
        //        /// Generates the skin categories menu
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void GenerateSkinCategoriesMenu(MenuItem sender)
        //        {
        //            GetCurrentSkinSet();
        //            MenuStorage.Menus.Players.MSPs.Skin.Clear();
        //            int count = 0;
        //            for (int i = 0; i < SkinPropUtils.SKIN_CATEGORY_COUNT; i++)
        //            {
        //                int drawableCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character.Handle, i);
        //                int textureCount = 0;
        //                if (drawableCount == 1)
        //                {
        //                    textureCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character.Handle, i, 0);
        //                }
        //                if (drawableCount > 1 || textureCount > 1)
        //                {
        //                    count++;
        //                    MenuItem mi = MenuStorage.AddMenuItem(MenuStorage.Menus.Players.MSPs.Skin, Utils.FormatML(MenuText.Player.ModelSkinProps.SkinCategories.I01_SLOT, i + 1,
        //                        SkinPropUtils.GetSkinCategoryDesc(i), drawableCount), false, false, MenuStorage.Menus.Players.MSPs.Skins.Drawable, GenerateSkinDrawableSelectorMenu);
        //                    mi.Data = new SkinPropDetail() { Category = i, DrawableCount = drawableCount };
        //                }
        //            }
        //            if (count == 0)
        //            {
        //                MenuStorage.AddMenuItem(MenuStorage.Menus.Players.MSPs.Skin, MenuText.Player.ModelSkinProps.SkinCategories.I02_NO_AVAILABLE_SLOT);
        //            }
        //        }

        //        /// <summary>
        //        /// Generates the skin drawable selector menu
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void GenerateSkinDrawableSelectorMenu(MenuItem sender)
        //        {
        //            SkinPropDetail detail = (SkinPropDetail)sender.Data;
        //            MenuStorage.Menus.Players.MSPs.Skins.Drawable.Clear();
        //            for (int i = 0; i < detail.DrawableCount; i++)
        //            {
        //                int textureCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character.Handle, detail.Category, i);
        //                MenuItem mi = MenuStorage.AddMenuItem(MenuStorage.Menus.Players.MSPs.Skins.Drawable, Utils.FormatML(MenuText.Player.ModelSkinProps.SkinCategories.DrawableSelector.I01_DRAWABLE, i, textureCount),
        //                    false, false, (textureCount > 1 ? MenuStorage.Menus.Players.MSPs.Skins.Texture : null), GenerateSkinTextureSelectorMenu);
        //                mi.Data = new SkinPropDetail() { Drawable = i, Category = detail.Category, TextureCount = textureCount };
        //                mi.Highlighted += SetSkinDrawable;
        //            }
        //            MenuStorage.Menus.Players.MSPs.Skins.Drawable.SelectedIndex = ChosenDrawables[detail.Category];
        //        }

        //        /// <summary>
        //        /// Generates the skin texture selector menu
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void GenerateSkinTextureSelectorMenu(MenuItem sender)
        //        {
        //            SkinPropDetail detail = (SkinPropDetail)sender.Data;
        //            MenuStorage.Menus.Players.MSPs.Skins.Texture.Clear();
        //            for (int i = 0; i < detail.TextureCount; i++)
        //            {
        //                MenuItem mi = MenuStorage.AddMenuItem(MenuStorage.Menus.Players.MSPs.Skins.Texture, Utils.FormatML(MenuText.Player.ModelSkinProps.SkinCategories.DrawableSelector.TextureSelector.I01_TEXTURE, i));
        //                mi.Data = new SkinPropDetail() { Drawable = detail.Drawable, Texture = i, Category = detail.Category };
        //                mi.Highlighted += SetSkinDrawableTexture;
        //            }
        //            MenuStorage.Menus.Players.MSPs.Skins.Texture.SelectedIndex = ChosenTextures[detail.Category][detail.Drawable];
        //        }

        //        /// <summary>
        //        /// Set skin drawable
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void SetSkinDrawable(MenuItem sender)
        //        {
        //            SkinPropDetail detail = (SkinPropDetail)sender.Data;
        //            int currentDrawable = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character.Handle, detail.Category);
        //            int currentTexture = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character.Handle, detail.Category, currentDrawable);
        //            if (currentDrawable != detail.Drawable || currentTexture != ChosenTextures[detail.Category][detail.Drawable])
        //            {
        //                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character.Handle, detail.Category, detail.Drawable, ChosenTextures[detail.Category][detail.Drawable], 0);
        //                ChosenDrawables[detail.Category] = detail.Drawable;
        //                Script.Wait(SET_SKIN_WAIT_TIME);
        //            }
        //        }

        //        /// <summary>
        //        /// Set skin drawable texture
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void SetSkinDrawableTexture(MenuItem sender)
        //        {
        //            SkinPropDetail detail = (SkinPropDetail)sender.Data;
        //            int currentDrawable = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, Game.Player.Character.Handle, detail.Category);
        //            int currentTexture = Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, Game.Player.Character.Handle, detail.Category, currentDrawable);
        //            if (currentDrawable != detail.Drawable || currentTexture != detail.Texture)
        //            {
        //                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character.Handle, detail.Category, detail.Drawable, detail.Texture, 0);
        //                ChosenDrawables[detail.Category] = detail.Drawable;
        //                ChosenTextures[detail.Category][detail.Drawable] = detail.Texture;
        //                Script.Wait(SET_SKIN_WAIT_TIME);
        //            }
        //        }

        //        /// <summary>
        //        /// Set skin to random drawable and texture
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void RandomSkin(MenuItem sender)
        //        {
        //            MenuStorage.Menus.Players.MSPs.Skin.Clear();
        //            for (int category = 0; category < SkinPropUtils.SKIN_CATEGORY_COUNT; category++)
        //            {
        //                List<SkinPropDetail> list = new List<SkinPropDetail>();
        //                int drawableCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_DRAWABLE_VARIATIONS, Game.Player.Character.Handle, category);
        //                int textureCount = 0;
        //                if (drawableCount == 1)
        //                {
        //                    textureCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character.Handle, category, 0);
        //                }
        //                if (drawableCount > 1 || textureCount > 1)
        //                {
        //                    for (int drawableIndex = 0; drawableIndex < drawableCount; drawableIndex++)
        //                    {
        //                        textureCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_TEXTURE_VARIATIONS, Game.Player.Character.Handle, category, drawableIndex);
        //                        for (int textureIndex = 0; textureIndex < textureCount; textureIndex++)
        //                        {
        //                            list.Add(new SkinPropDetail() { Category = category, Drawable = drawableIndex, Texture = textureIndex });
        //                        }
        //                    }
        //                    if (list.Count > 0)
        //                    {
        //                        SkinPropDetail detail = list[(new Random()).Next(list.Count)];
        //                        Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character.Handle, detail.Category, detail.Drawable, detail.Texture, 0);
        //                        ChosenDrawables[detail.Category] = detail.Drawable;
        //                        ChosenTextures[detail.Category][detail.Drawable] = detail.Texture;
        //                    }
        //                }
        //            }
        //            Script.Wait(SET_SKIN_WAIT_TIME);
        //            Utils.ShowNotification(GlobalConst.Message.PLAYER_RANDOM_SKIN);
        //        }
        //    }

        //    /// <summary>
        //    /// Prop features
        //    /// </summary>
        //    public static class Prop
        //    {
        //        /// <summary>
        //        /// Chosen drawable index of each category
        //        /// </summary>
        //        public static int[] ChosenDrawables = new int[SkinPropUtils.PROP_CATEGORY_COUNT];

        //        /// <summary>
        //        /// Chosen texture index of each drawable in each category
        //        /// </summary>
        //        public static int[][] ChosenTextures = new int[SkinPropUtils.PROP_CATEGORY_COUNT][];

        //        /// <summary>
        //        /// Static constructor
        //        /// </summary>
        //        static Prop()
        //        {
        //            for (int i = 0; i < SkinPropUtils.PROP_CATEGORY_COUNT; i++)
        //            {
        //                ChosenTextures[i] = new int[SkinPropUtils.PROP_CATEGORY_DRAWABLE_MAX_COUNT];
        //            }
        //        }

        //        const int SET_PROP_WAIT_TIME = 100;

        //        /// <summary>
        //        /// Gets the current prop drawables and textures
        //        /// </summary>
        //        public static void GetCurrentPropSet()
        //        {
        //            for (int i = 0; i < SkinPropUtils.PROP_CATEGORY_COUNT; i++)
        //            {
        //                ChosenDrawables[i] = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character.Handle, i);
        //                int textureCount = Function.Call<int>((Hash)0xA6E7F1CEB523E171, Game.Player.Character.Handle, i, ChosenDrawables[i]);
        //                for (int j = 0; j < textureCount; j++)
        //                {
        //                    ChosenTextures[i][j] = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character.Handle, i, j);
        //                }
        //            }
        //        }

        //        /// <summary>
        //        /// Generates the prop categories menu
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void GeneratePropCategoriesMenu(MenuItem sender)
        //        {
        //            GetCurrentPropSet();
        //            MenuStorage.Menus.Players.MSPs.Prop.Clear();
        //            int count = 0;
        //            for (int i = 0; i < SkinPropUtils.PROP_CATEGORY_COUNT; i++)
        //            {
        //                int drawableCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character.Handle, i);
        //                if (drawableCount > 0)
        //                {
        //                    count++;
        //                    MenuItem mi = MenuStorage.AddMenuItem(MenuStorage.Menus.Players.MSPs.Prop, Utils.FormatML(MenuText.Player.ModelSkinProps.PropCategories.I01_SLOT, i + 1,
        //                        SkinPropUtils.GetPropCategoryDesc(i), drawableCount), false, false, MenuStorage.Menus.Players.MSPs.Props.Drawable, GeneratePropSelectorMenu);
        //                    mi.Data = new SkinPropDetail() { Category = i, DrawableCount = drawableCount };
        //                }
        //            }
        //            if (count == 0)
        //            {
        //                MenuStorage.AddMenuItem(MenuStorage.Menus.Players.MSPs.Prop, MenuText.Player.ModelSkinProps.PropCategories.I02_NO_AVAILABLE_SLOT);
        //            }
        //        }

        //        /// <summary>
        //        /// Generates the prop selector menu
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void GeneratePropSelectorMenu(MenuItem sender)
        //        {
        //            SkinPropDetail detail = (SkinPropDetail)sender.Data;
        //            MenuStorage.Menus.Players.MSPs.Props.Drawable.Clear();
        //            for (int i = -1; i < detail.DrawableCount; i++)
        //            {
        //                MenuItem mi = null;
        //                int textureCount = 0;
        //                if (i == -1)
        //                {
        //                    mi = MenuStorage.AddMenuItem(MenuStorage.Menus.Players.MSPs.Props.Drawable, Utils.FormatML(MenuText.Player.ModelSkinProps.PropCategories.PropsSelector.I01_NOTHING));
        //                }
        //                else
        //                {
        //                    textureCount = Function.Call<int>((Hash)0xA6E7F1CEB523E171, Game.Player.Character.Handle, detail.Category, i);
        //                    mi = MenuStorage.AddMenuItem(MenuStorage.Menus.Players.MSPs.Props.Drawable, Utils.FormatML(MenuText.Player.ModelSkinProps.PropCategories.PropsSelector.I02_PROP, i, textureCount),
        //                        false, false, (textureCount > 1 ? MenuStorage.Menus.Players.MSPs.Props.Texture : null), GeneratePropTextureSelectorMenu);
        //                }
        //                mi.Data = new SkinPropDetail() { Drawable = i, Category = detail.Category, TextureCount = textureCount };
        //                mi.Highlighted += SetPropDrawable;
        //            }
        //            MenuStorage.Menus.Players.MSPs.Props.Drawable.SelectedIndex = ChosenDrawables[detail.Category];
        //        }

        //        /// <summary>
        //        /// Generates the prop texture selector menu
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void GeneratePropTextureSelectorMenu(MenuItem sender)
        //        {
        //            SkinPropDetail detail = (SkinPropDetail)sender.Data;
        //            MenuStorage.Menus.Players.MSPs.Props.Texture.Clear();
        //            for (int i = 0; i < detail.TextureCount; i++)
        //            {
        //                MenuItem mi = MenuStorage.AddMenuItem(MenuStorage.Menus.Players.MSPs.Props.Texture, Utils.FormatML(MenuText.Player.ModelSkinProps.PropCategories.PropsSelector.TextureSelector.I01_TEXTURE, i));
        //                mi.Data = new SkinPropDetail() { Drawable = detail.Drawable, Texture = i, Category = detail.Category };
        //                mi.Highlighted += SetPropDrawableTexture;
        //            }
        //            MenuStorage.Menus.Players.MSPs.Props.Texture.SelectedIndex = ChosenTextures[detail.Category][detail.Drawable];
        //        }

        //        /// <summary>
        //        /// Set prop drawable
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void SetPropDrawable(MenuItem sender)
        //        {
        //            SkinPropDetail detail = (SkinPropDetail)sender.Data;
        //            int currentProp = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character.Handle, detail.Category);
        //            if (currentProp != detail.Drawable)
        //            {
        //                Function.Call(Hash.CLEAR_PED_PROP, Game.Player.Character.Handle, detail.Category);
        //                if (detail.Drawable != -1)
        //                {
        //                    Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character.Handle, detail.Category, detail.Drawable, ChosenTextures[detail.Category][detail.Drawable], 0);
        //                    Script.Wait(SET_PROP_WAIT_TIME);
        //                }
        //                ChosenDrawables[detail.Category] = detail.Drawable + 1;
        //            }
        //        }

        //        /// <summary>
        //        /// Set prop drawable texture
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void SetPropDrawableTexture(MenuItem sender)
        //        {
        //            SkinPropDetail detail = (SkinPropDetail)sender.Data;
        //            int currentProp = Function.Call<int>(Hash.GET_PED_PROP_INDEX, Game.Player.Character.Handle, detail.Category);
        //            int currentTexture = Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, Game.Player.Character.Handle, detail.Category, currentProp);
        //            if (currentProp != detail.Drawable || currentTexture != detail.Texture)
        //            {
        //                Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character.Handle, detail.Category, detail.Drawable, detail.Texture, 0);
        //                ChosenDrawables[detail.Category] = detail.Drawable + 1;
        //                ChosenTextures[detail.Category][detail.Drawable] = detail.Texture;
        //                Script.Wait(SET_PROP_WAIT_TIME);
        //            }
        //        }

        //        /// <summary>
        //        /// Set skin to random drawable and texture
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void RandomProps(MenuItem sender)
        //        {
        //            MenuStorage.Menus.Players.MSPs.Prop.Clear();
        //            for (int category = 0; category < SkinPropUtils.PROP_CATEGORY_COUNT; category++)
        //            {
        //                List<SkinPropDetail> list = new List<SkinPropDetail>();
        //                int drawableCount = Function.Call<int>(Hash.GET_NUMBER_OF_PED_PROP_DRAWABLE_VARIATIONS, Game.Player.Character.Handle, category);
        //                if (drawableCount > 0)
        //                {
        //                    list.Add(new SkinPropDetail() { Category = category, Drawable = -1 });
        //                    for (int drawableIndex = 0; drawableIndex < drawableCount; drawableIndex++)
        //                    {
        //                        int textureCount = Function.Call<int>((Hash)0xA6E7F1CEB523E171, Game.Player.Character.Handle, category, drawableIndex);
        //                        for (int textureIndex = 0; textureIndex < textureCount; textureIndex++)
        //                        {
        //                            list.Add(new SkinPropDetail() { Category = category, Drawable = drawableIndex, Texture = textureIndex });
        //                        }
        //                    }
        //                    if (list.Count > 0)
        //                    {
        //                        SkinPropDetail detailRandom = list[(new Random()).Next(list.Count)];
        //                        Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character.Handle, detailRandom.Category, detailRandom.Drawable, detailRandom.Texture, 0);
        //                    }
        //                }
        //            }
        //            Script.Wait(SET_PROP_WAIT_TIME);
        //            Utils.ShowNotification(GlobalConst.Message.PLAYER_RANDOM_PROPS);
        //        }

        //        /// <summary>
        //        /// Clear all props
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void ClearProps(MenuItem sender)
        //        {
        //            Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character.Handle);
        //        }
        //    }

        //    /// <summary>
        //    /// Model & Skin & Props custom set features
        //    /// </summary>
        //    public static class MSPCustomSets
        //    {
        //        private const string FORMAT_SET_NAME = "[{0}]";
        //        private const string FORMAT_NEW_SET_NAME = "Custom Set {0}";
        //        private const int NAME_MAX_LENGTH = 40;

        //        /// <summary>
        //        /// Generates custom set item list
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void GenerateItemList(MenuItem sender)
        //        {
        //            MenuStorage.Menus.Players.MSPs.CustomSet.Clear();
        //            MenuStorage.Menus.Players.MSPs.CustomSet.Add(MenuStorage.MenuItems.Player.MSPCustomSet.Create);

        //            for (int i = 0; i < Configuration.MSPCustomSets.Items.Count; i++)
        //            {
        //                MSPCustomSet set = Configuration.MSPCustomSets.Items[i];
        //                set.Index = i;
        //                MenuItem mi = MenuStorage.AddMenuItem(MenuStorage.Menus.Players.MSPs.CustomSet, Utils.FormatML(FORMAT_SET_NAME, set.Name), false, false, MenuStorage.Menus.Players.MSPs.CustomSets.Item, Enter, null, null, set);
        //            }
        //        }

        //        /// <summary>
        //        /// Enters custom set item
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void Enter(MenuItem sender)
        //        {
        //            MSPCustomSet set = (sender.Data as MSPCustomSet);
        //            MenuStorage.Menus.Players.MSPs.CustomSets.Item.Title = Utils.FormatML(FORMAT_SET_NAME, set.Name);
        //            MenuStorage.MenuItems.Player.MSPCustomSet.Item.Apply.Data = set;
        //            MenuStorage.MenuItems.Player.MSPCustomSet.Item.Rename.Data = set;
        //            MenuStorage.MenuItems.Player.MSPCustomSet.Item.Overwrite.Data = set;
        //            MenuStorage.MenuItems.Player.MSPCustomSet.Item.Delete.Data = set;
        //            MenuStorage.Menus.Players.MSPs.CustomSets.Item.SelectedIndex = 0;
        //        }

        //        /// <summary>
        //        /// Creates a new custom set
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void Create(MenuItem sender)
        //        {
        //            string name = Utils.ShowInGameKeyboard(null, Utils.FormatML(FORMAT_NEW_SET_NAME, Configuration.MSPCustomSets.Items.Count + 1), NAME_MAX_LENGTH);
        //            if (string.IsNullOrEmpty(name)) return;

        //            MSPCustomSet set = GetCurrent();
        //            set.Name = name;

        //            Configuration.MSPCustomSets.Items.Add(set);
        //            Configuration.MSPCustomSets.Items.Sort();
        //            Configuration.MSPCustomSets.SaveMSPCustomSets();

        //            Utils.ShowNotification(GlobalConst.Message.PLAYER_MSPCS_CREATED);
        //            GenerateItemList(null);
        //        }

        //        /// <summary>
        //        /// Gets the current player MSP settings
        //        /// </summary>
        //        /// <returns>Current player's MSP settings</returns>
        //        private static MSPCustomSet GetCurrent()
        //        {
        //            Skin.GetCurrentSkinSet();
        //            Prop.GetCurrentPropSet();

        //            MSPCustomSet set = new MSPCustomSet();
        //            set.ModelHash = Function.Call<int>(Hash.GET_ENTITY_MODEL, Game.Player.Character.Handle);
        //            set.SkinDrawables = new int[SkinPropUtils.SKIN_CATEGORY_COUNT];
        //            set.SkinTextures = new int[SkinPropUtils.SKIN_CATEGORY_COUNT];
        //            for (int i = 0; i < SkinPropUtils.SKIN_CATEGORY_COUNT; i++)
        //            {
        //                set.SkinDrawables[i] = Skin.ChosenDrawables[i];
        //                set.SkinTextures[i] = Skin.ChosenTextures[i][Skin.ChosenDrawables[i]];
        //            }
        //            set.PropDrawables = new int[SkinPropUtils.PROP_CATEGORY_COUNT];
        //            set.PropTextures = new int[SkinPropUtils.PROP_CATEGORY_COUNT];
        //            for (int i = 0; i < SkinPropUtils.PROP_CATEGORY_COUNT; i++)
        //            {
        //                set.PropDrawables[i] = Prop.ChosenDrawables[i];
        //                if (Prop.ChosenDrawables[i] == -1)
        //                {
        //                    set.PropTextures[i] = 0;
        //                }
        //                else
        //                {
        //                    set.PropTextures[i] = Prop.ChosenTextures[i][Prop.ChosenDrawables[i]];
        //                }
        //            }

        //            return set;
        //        }

        //        /// <summary>
        //        /// Applies the set to player
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void Apply(MenuItem sender)
        //        {
        //            MSPCustomSet set = (sender.Data as MSPCustomSet);

        //            // Model
        //            PlayerModel.SetModel(set.ModelHash, null);

        //            // Skin
        //            for (int i = 0; i < SkinPropUtils.SKIN_CATEGORY_COUNT; i++)
        //            {
        //                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, Game.Player.Character.Handle, i, set.SkinDrawables[i], set.SkinTextures[i], 0);
        //            }

        //            // Props
        //            Function.Call(Hash.CLEAR_ALL_PED_PROPS, Game.Player.Character.Handle);
        //            for (int i = 0; i < SkinPropUtils.PROP_CATEGORY_COUNT; i++)
        //            {
        //                if (set.PropDrawables[i] != -1)
        //                {
        //                    Function.Call(Hash.SET_PED_PROP_INDEX, Game.Player.Character.Handle, i, set.PropDrawables[i], set.PropTextures[i], 0);
        //                }
        //            }

        //            Utils.ShowNotification(GlobalConst.Message.PLAYER_MSPCS_APPLIED);
        //        }

        //        /// <summary>
        //        /// Renames the set
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void Rename(MenuItem sender)
        //        {
        //            MSPCustomSet set = (sender.Data as MSPCustomSet);

        //            string name = Utils.ShowInGameKeyboard(null, set.Name, NAME_MAX_LENGTH);
        //            if (string.IsNullOrEmpty(name)) return;
        //            set.Name = name;
        //            MenuStorage.Menus.Players.MSPs.CustomSets.Item.Title = Utils.FormatML(FORMAT_SET_NAME, name);
        //            GenerateItemList(null);
        //            Configuration.MSPCustomSets.SaveMSPCustomSets();
        //            Utils.ShowNotification(GlobalConst.Message.PLAYER_MSPCS_RENAMED);
        //        }

        //        /// <summary>
        //        /// Overwrites with current
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void Overwrite(MenuItem sender)
        //        {
        //            MSPCustomSet oldSet = (sender.Data as MSPCustomSet);

        //            MSPCustomSet set = GetCurrent();
        //            set.Name = oldSet.Name;

        //            Configuration.MSPCustomSets.Items[oldSet.Index] = set;
        //            Configuration.MSPCustomSets.SaveMSPCustomSets();

        //            Utils.ShowNotification(GlobalConst.Message.PLAYER_MSPCS_OVERWRITTEN);
        //        }

        //        /// <summary>
        //        /// Deletes the set
        //        /// </summary>
        //        /// <param name="sender">Source menu item</param>
        //        public static void Delete(MenuItem sender)
        //        {
        //            MSPCustomSet set = (sender.Data as MSPCustomSet);
        //            Configuration.MSPCustomSets.Items.RemoveAt(set.Index);
        //            Configuration.MSPCustomSets.SaveMSPCustomSets();
        //            Utils.ShowNotification(GlobalConst.Message.PLAYER_MSPCS_DELETED);
        //            GenerateItemList(null);
        //            MenuStorage.ReturnToPrevMenu();
        //        }
        //    }
        }
    }
}
