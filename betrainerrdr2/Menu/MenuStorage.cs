///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using System.Collections.Generic;
using BETrainerRdr2.Teleport;
using BETrainerRdr2.Vehicle;
using BETrainerRdr2.Weapon;
using BETrainerRdr2.Weather;
using BETrainerRdr2.Model;

namespace BETrainerRdr2.Menu
{
    /// <summary>
    /// Storage for menus
    /// </summary>
    public static class MenuStorage
    {
        // Menu stack
        private static Stack<Menu> _menuStack = null;

        /// <summary>
        /// All menus
        /// </summary>
        public static class Menus
        {
            /// <summary>
            /// Main menu
            /// </summary>
            public static Menu Main = null;

            /// <summary>
            /// Player menu
            /// </summary>
            public static Menu Player = null;

            /// <summary>
            /// Player sub menus
            /// </summary>
            public static class Players
            {
                /// <summary>
                /// Player cash menu
                /// </summary>
                public static Menu Cash = null;

                /// <summary>
                /// Player wanted menu
                /// </summary>
                public static Menu Wanted = null;

                /// <summary>
                /// Player Model &amp; Skin &amp; Props menu
                /// </summary>
                public static Menu MSP = null;

                /// <summary>
                /// Model &amp; Skin &amp; Props sub menus
                /// </summary>
                public static class MSPs
                {
                    /// <summary>
                    /// Player Model selector menu
                    /// </summary>
                    public static Menu Model = null;

                    /// <summary>
                    /// Model selecter submenus
                    /// </summary>
                    public static class Models
                    {
                        /// <summary>
                        /// Player Model selector animal menu
                        /// </summary>
                        public static Menu Animals = null;

                        /// <summary>
                        /// Player Model selector character menu
                        /// </summary>
                        public static Menu NPCs = null;
                    }

                    /// <summary>
                    /// Player skin categories menu
                    /// </summary>
                    public static Menu Skin = null;

                    // Skin sub menus
                    public static class Skins
                    {
                        /// <summary>
                        /// Player skin drawable selector menu
                        /// </summary>
                        public static Menu Drawable = null;

                        /// <summary>
                        /// Player skin texture selector menu
                        /// </summary>
                        public static Menu Texture = null;

                    }

                    /// <summary>
                    /// Player Prop categories menu
                    /// </summary>
                    public static Menu Prop = null;

                    /// <summary>
                    /// Props sub menus
                    /// </summary>
                    public static class Props
                    {
                        /// <summary>
                        /// Player Prop selector menu
                        /// </summary>
                        public static Menu Drawable = null;

                        /// <summary>
                        /// Player Prop texture selector menu
                        /// </summary>
                        public static Menu Texture = null;

                    }

                    /// <summary>
                    /// Player model &amp; skin &amp; props custom sets menu
                    /// </summary>
                    public static Menu CustomSet = null;

                    /// <summary>
                    /// Custom sets sub menus
                    /// </summary>
                    public static class CustomSets
                    {
                        /// <summary>
                        /// Player model &amp; skin &amp; props custom set item menu
                        /// </summary>
                        public static Menu Item = null;
                    }
                }
            }

            /// <summary>
            /// Location menu
            /// </summary>
            public static Menu Location = null;

            /// <summary>
            /// Location sub menus
            /// </summary>
            public static class Locations
            {
                /// <summary>
                /// Location Teleporter menu
                /// </summary>
                public static Menu LTeleporter = null;

                /// <summary>
                /// Custom location teleporter menu
                /// </summary>
                public static Menu CLTeleporter = null;

                /// <summary>
                /// Custom location teleporter sub menus
                /// </summary>
                public static class CLTeleporters
                {
                    /// <summary>
                    /// Custom location teleporter item menu
                    /// </summary>
                    public static Menu Item = null;
                }

                /// <summary>
                /// XYZ teleporter menu
                /// </summary>
                public static Menu XyzTeleporter = null;

                /// <summary>
                /// XYZ teleporter sub menus
                /// </summary>
                public static class XyzTeleporters
                {
                    /// <summary>
                    /// XYZ teleporter - teleport by offset menu
                    /// </summary>
                    public static Menu Offset = null;

                    /// <summary>
                    /// XYZ teleporter - teleport to coordinates menu
                    /// </summary>
                    public static Menu Coordinates = null;
                }
            }

            /// <summary>
            /// Vehicle menu
            /// </summary>
            public static Menu Vehicle = null;

            /// <summary>
            /// Vehicle sub menus
            /// </summary>
            public static class Vehicles
            {
                /// <summary>
                /// Vehicle boost menu
                /// </summary>
                public static Menu VehicleBoost = null;

                /// <summary>
                /// Spawn vehicle menu
                /// </summary>
                public static Menu SpawnVehicle = null;

                /// <summary>
                /// Custom vehicles menu
                /// </summary>
                public static Menu CustomVehicle = null;

                /// <summary>
                /// Custom vehicle sub menus
                /// </summary>
                public static class CustomVehicles
                {
                    public static Menu Item = null;
                }

                /// <summary>
                /// Vehicle paint menu
                /// </summary>
                public static Menu Paint = null;

                /// <summary>
                /// Paint sub menus
                /// </summary>
                public static class Paints
                {
                    /// <summary>
                    /// Primary color menu
                    /// </summary>
                    public static Menu PrimaryColor = null;

                    /// <summary>
                    /// Secondary color menu
                    /// </summary>
                    public static Menu SecondaryColor = null;

                    /// <summary>
                    /// Pearl topcoat menu
                    /// </summary>
                    public static Menu PearlTopcoat = null;

                    /// <summary>
                    /// Wheels menu
                    /// </summary>
                    public static Menu Wheels = null;

                    /// <summary>
                    /// Vehicle paint livery menu
                    /// </summary>
                    public static Menu Livery = null;
                }

                /// <summary>
                /// Vehicle modifications menu
                /// </summary>
                public static Menu Mod = null;

                /// <summary>
                /// Mods menu
                /// </summary>
                public static class Mods
                {
                    /// <summary>
                    /// Mod item menu item
                    /// </summary>
                    public static Menu ModItem = null;
                }

                /// <summary>
                /// Vehicle doors menu
                /// </summary>
                public static Menu Doors = null;

                /// <summary>
                /// Vehicle speed meter menu
                /// </summary>
                public static Menu SpeedMeter = null;
            }

            /// <summary>
            /// Weapon menu
            /// </summary>
            public static Menu Weapon = null;

            /// <summary>
            /// Weapon sub menus
            /// </summary>
            public static class Weapons
            {
                /// <summary>
                /// Get specific weapon menu
                /// </summary>
                public static Menu GetSpecificWeapon = null;
            }

            /// <summary>
            /// Model menu
            /// </summary>
            public static Menu Model = null;

            public static class Models
            {
                public static Menu Animal = null;
                public static Menu Human = null;

                public static class Animals
                {
                    public static Menu Horse = null;
                    public static Menu Dog = null;
                    public static Menu Fish = null;
                    public static Menu Other = null;
                }

                public static class Humans
                {
                    public static Menu Cutscene = null;
                    public static Menu MaleYoung = null;
                    public static Menu MaleMiddle = null;
                    public static Menu MaleOld = null;
                    public static Menu FemaleYoung = null;
                    public static Menu FemaleMiddle = null;
                    public static Menu FemaleOld = null;
                    public static Menu Misc = null;
                }
            }

            /// <summary>
            /// Date time speed menu
            /// </summary>
            public static Menu DateTimeSpeed = null;

            /// <summary>
            /// Date time speed sub menus
            /// </summary>
            public static class DateTimeSpeeds
            {
                public static Menu SetDateTime = null;
                public static Menu SetGameSpeed = null;
                public static Menu SetAimingSpeed = null;
            }

            /// <summary>
            /// World menu
            /// </summary>
            public static Menu World = null;

            /// <summary>
            /// Weather menu
            /// </summary>
            public static Menu Weather = null;

            /// <summary>
            /// Misc menu
            /// </summary>
            public static Menu Misc = null;

            /// <summary>
            /// Configuration menu
            /// </summary>
            public static Menu Configuration = null;

            /// <summary>
            /// Lanugage menu
            /// </summary>
            public static Menu Language = null;
        }

        /// <summary>
        /// Menu items
        /// </summary>
        public static class MenuItems
        {
            /// <summary>
            /// Player menu items
            /// </summary>
            public static class Player
            {
                public static MenuItem Invincible = null;
                public static MenuItem InfiniteAbility = null;
                public static MenuItem InfiniteStamina = null;
                public static MenuItem SuperJump = null;
                public static MenuItem Noiseless = null;

                /// <summary>
                /// Wanted menu items
                /// </summary>
                public static class Wanted
                {
                    public static MenuItem ClearBounty = null;
                    public static MenuItem NeverWanted = null;
                    public static MenuItem EveryoneIgnored = null;
                }

                /// <summary>
                /// Model & Skin & Props custom set menu items
                /// </summary>
                public static class MSPCustomSet
                {
                    public static MenuItem Create = null;

                    /// <summary>
                    /// Item
                    /// </summary>
                    public static class Item
                    {
                        public static MenuItem Apply = null;
                        public static MenuItem Rename = null;
                        public static MenuItem Overwrite = null;
                        public static MenuItem Delete = null;
                    }
                }
            }

            /// <summary>
            /// Location menu items
            /// </summary>
            public static class Location
            {
                public static MenuItem ShowCoordinate = null;

                /// <summary> 
                /// Custom locatoin teleporter menu items
                /// </summary>
                public static class CustomLocationTeleporter
                {
                    public static MenuItem SaveCurrentLocation = null;

                    /// <summary>
                    /// Custom location teleporter item menu items
                    /// </summary>
                    public static class Item
                    {
                        public static MenuItem Teleport = null;
                        public static MenuItem Rename = null;
                        public static MenuItem Overwrite = null;
                        public static MenuItem Delete = null;
                    }
                }

                /// <summary>
                /// XYZ teleporter menu items
                /// </summary>
                public static class XyzTeleporter
                {
                    /// <summary>
                    /// Teleport by offsets menu items
                    /// </summary>
                    public static class Offset
                    {
                        public static MenuItem X = null;
                        public static MenuItem Y = null;
                        public static MenuItem Z = null;
                    }

                    /// <summary>
                    /// Teleport by coordinates menu items
                    /// </summary>
                    public static class Coordinates
                    {
                        public static MenuItem X = null;
                        public static MenuItem Y = null;
                        public static MenuItem Z = null;
                    }
                }
            }
        
            /// <summary>
            /// Vehicle menu items
            /// </summary>
            public static class Vehicle
            {
                public static MenuItem Invincible = null;
                public static MenuItem InfiniteStamina = null;
                public static MenuItem SeatBelt = null;
                public static MenuItem SpawnIntoVehicle = null;

                public static class SpawnVehicle
                {
                    public static MenuItem Boat = null;
                    public static MenuItem Train = null;
                    public static MenuItem Wagon = null;
                    public static MenuItem WagonOnly = null;
                    public static MenuItem Cannon = null;
                    public static MenuItem Misc = null;
                }

                /// <summary>
                /// Vehicle boost menu items
                /// </summary>
                public static class VehicleBoost
                {
                    public static MenuItem BoostProgressive = null;
                    public static MenuItem BoostProgressiveSpeedInc = null;
                    public static MenuItem BoostInstant = null;
                    public static MenuItem BoostInstantSpeed = null;

                }

                /// <summary>
                /// Custom vehicle menu items
                /// </summary>
                public static class CustomVehicle
                {
                    public static MenuItem SaveCurrent = null;
                    
                    /// <summary>
                    /// Custom vehicle item menu items
                    /// </summary>
                    public static class Item
                    {
                        public static MenuItem Spawn = null;
                        public static MenuItem Rename = null;
                        public static MenuItem Overwrite = null;
                        public static MenuItem Delete = null;
                    }
                }

                /// <summary>
                /// Paint menu items
                /// </summary>
                public static class Paint
                {
                    public static MenuItem PrimaryColor = null;
                    public static MenuItem SecondaryColor = null;
                    public static MenuItem PearlTopcoat = null;
                    public static MenuItem Wheels = null;
                    public static MenuItem Livery = null;
                }

                /// <summary>
                /// Mod menu items
                /// </summary>
                public static class Mod
                {
                    public static MenuItem AllPerformance = null;
                    public static MenuItem AllArmor = null;
                    public static MenuItem RemoveAll = null;
                }

                /// <summary>
                /// Speed meter menu items
                /// </summary>
                public static class SpeedMeter
                {
                    public static MenuItem Show = null;
                    public static MenuItem ShowInMetric = null;
                    public static MenuItem ShowWithoutVehicle = null;
                }
            }
        
            /// <summary>
            /// Weapon menu items
            /// </summary>
            public static class Weapon
            {
                public static MenuItem GetAllWeapons = null;
                public static MenuItem GetSpecificWeapon = null;
                public static MenuItem InfiniteAmmo = null;
                public static MenuItem PermanentParachute = null;
                public static MenuItem NoReload = null;
                public static MenuItem FireAmmo = null;
                public static MenuItem ExplosiveAmmo = null;
                public static MenuItem ExplosiveMelee = null;
                public static MenuItem VehicleRockets = null;
                public static MenuItem DamageMultiplier = null;
            }

            /// <summary>
            /// Date time speed menu items
            /// </summary>
            public static class DateTimeSpeed
            {
                public static MenuItem SetDateTime = null;
                public static MenuItem SetGameSpeed = null;
                public static MenuItem SetAimingSpeed = null;
                public static MenuItem HourForward = null;
                public static MenuItem HourBackward = null;
                public static MenuItem DayForward = null;
                public static MenuItem DayBackward = null;
                public static MenuItem ShowTime = null;
                public static MenuItem Paused = null;
                public static MenuItem SyncWithSystem = null;
                public static MenuItem UseRealTimeScale = null;

                /// <summary>
                /// Set date time menu items
                /// </summary>
                public static class SetDateTimeMenu
                {
                    public static MenuItem Year = null;
                    public static MenuItem Month = null;
                    public static MenuItem Day = null;
                    public static MenuItem Hour = null;
                    public static MenuItem Minute = null;
                    public static MenuItem Second = null;
                    public static MenuItem SetToCurrent = null;
                    public static MenuItem SetToSystem = null;
                }

                /// <summary>
                /// Set game speed menu items
                /// </summary>
                public static class SetGameSpeedMenu
                {
                    public static MenuItem Speed = null;
                    public static MenuItem SetTo100 = null;
                    public static MenuItem SetTo075 = null;
                    public static MenuItem SetTo050 = null;
                    public static MenuItem SetTo025 = null;
                    public static MenuItem SetTo010 = null;
                    public static MenuItem SetTo000 = null;
                }

                /// <summary>
                /// Set aiming speed menu items
                /// </summary>
                public static class SetAimingSpeedMenu
                {
                    public static MenuItem Speed = null;
                    public static MenuItem SetTo100 = null;
                    public static MenuItem SetTo075 = null;
                    public static MenuItem SetTo050 = null;
                    public static MenuItem SetTo025 = null;
                    public static MenuItem SetTo010 = null;
                    public static MenuItem SetTo000 = null;
                }
            }

            /// <summary>
            /// World menu items
            /// </summary>
            public static class World
            {
                public static MenuItem MoonGravity = null;
                public static MenuItem RandomCops = null;
                public static MenuItem RandomTrains = null;
                public static MenuItem RandomBoats = null;
                public static MenuItem GarbageTrucks = null;
                public static MenuItem RestrictedZones = null;
            }

            /// <summary>
            /// Weather menu items
            /// </summary>
            public static class Weather
            {
                public static MenuItem Wind = null;
                public static MenuItem Freeze = null;
            }

            /// <summary>
            /// Misc menu items
            /// </summary>
            public static class Misc
            {
                //public static MenuItem PortableRadio = null;
                public static MenuItem HideHud = null;
                //public static MenuItem NextRadioTrack = null;
                public static MenuItem RevealMap = null;
            }

            /// <summary>
            /// Configuration menu items
            /// </summary>
            public static class Configuration
            {
                public static MenuItem AutoSave = null;
            }

            /// <summary>
            /// Language menu items
            /// </summary>
            public static class Language
            {
                public static MenuItem English = null;
                public static MenuItem ChineseTraditional = null;
            }
        }

        /// <summary>
        /// Gets whether the specified menu is in the menu stack
        /// </summary>
        /// <param name="menu">Menu object</param>
        /// <returns>true if in the menu stack; otherwise false</returns>
        public static bool IsMenuInStack(Menu menu)
        {
            return _menuStack.Contains(menu);
        }

        /// <summary>
        /// Gets the current menu
        /// </summary>
        /// <returns></returns>
        public static Menu GetCurrentMenu()
        {
            if (_menuStack.Count > 0) return _menuStack.Peek();
            else return null;
        }

        /// <summary>
        /// Returns to the specified menu in certain depth
        /// </summary>
        /// <param name="depth">Depth of the menu</param>
        public static void ReturnToMenuByDepth(int depth)
        {
            if (depth <= 0 && Trainer.ShowingTrainerMenu)
            {
                Trainer.ShowingTrainerMenu = false;
            }
            if (_menuStack.Count > depth)
            {
                for (int i = 0; i < _menuStack.Count - depth; i++)
                {
                    _menuStack.Pop();
                }
            }
        }

        /// <summary>
        /// Returns to the previous menu.
        /// If there's no previous menu then nothing will happen.
        /// </summary>
        public static void ReturnToPrevMenu()
        {
            if (_menuStack.Count > 1)
            {
                _menuStack.Pop();
            }
            else if (_menuStack.Count == 1 && Trainer.ShowingTrainerMenu)
            {
                Trainer.ShowingTrainerMenu = false;
            }
        }

        /// <summary>
        /// Enters a new menu
        /// </summary>
        /// <param name="menu">Sub menu</param>
        public static void EnterMenu(Menu menu)
        {
            _menuStack.Push(menu);
            if (menu != null && menu.SelectedItem != null)
            {
                menu.SelectedItem.OnHighlighted();
            }
        }

        /// <summary>
        /// Initialize all menus
        /// </summary>
        public static void InitMenus()
        {
            Debug.Log("Menu.MenuStorage.InitMenus");
            _menuStack = new Stack<Menu>();
            InitPlayerMenu();
            InitLocationMenu();
            InitVehicleMenu();
            InitWeaponMenu();
            InitModelMenu();
            InitDateTimeSpeedMenu();
            //InitWorldMenu();
            InitWeatherMenu();
            InitMiscMenu();
            InitConfigurationMenu();
            //InitLanguageMenu();
            InitMainMenu();
        }

        /// <summary>
        /// Initializes model menu
        /// </summary>
        private static void InitModelMenu()
        {
            Menus.Model = new Menu(MenuText.Main.MODEL);
            
            Menus.Models.Animal = new Menu(MenuText.Model.ANIMAL);
            Menus.Models.Animals.Horse = new Menu(MenuText.Model.Animal.HORSE);
            AddModelMenuItems(Menus.Models.Animals.Horse, ModelData.ModelType.Animal | ModelData.ModelType.Horse);
            Menus.Models.Animals.Dog = new Menu(MenuText.Model.Animal.DOG);
            AddModelMenuItems(Menus.Models.Animals.Dog, ModelData.ModelType.Animal | ModelData.ModelType.Dog);
            Menus.Models.Animals.Fish = new Menu(MenuText.Model.Animal.FISH);
            AddModelMenuItems(Menus.Models.Animals.Fish, ModelData.ModelType.Animal | ModelData.ModelType.Fish);
            Menus.Models.Animals.Other = new Menu(MenuText.Model.Animal.OTHER);
            AddModelMenuItems(Menus.Models.Animals.Other, ModelData.ModelType.Animal, ModelData.ModelType.Horse | ModelData.ModelType.Dog | ModelData.ModelType.Fish);
            AddMenuItem(Menus.Models.Animal, MenuText.Model.Animal.HORSE, false, false, Menus.Models.Animals.Horse);
            AddMenuItem(Menus.Models.Animal, MenuText.Model.Animal.DOG, false, false, Menus.Models.Animals.Dog);
            AddMenuItem(Menus.Models.Animal, MenuText.Model.Animal.FISH, false, false, Menus.Models.Animals.Fish);
            AddMenuItem(Menus.Models.Animal, MenuText.Model.Animal.OTHER, false, false, Menus.Models.Animals.Other);

            Menus.Models.Human = new Menu(MenuText.Model.HUMAN);
            Menus.Models.Humans.Cutscene = new Menu(MenuText.Model.Human.CUTSCENE);
            AddModelMenuItems(Menus.Models.Humans.Cutscene, ModelData.ModelType.Cutscene, ModelData.ModelType.Animal);
            Menus.Models.Humans.MaleYoung = new Menu(MenuText.Model.Human.MALE_YOUNG);
            AddModelMenuItems(Menus.Models.Humans.MaleYoung, ModelData.ModelType.Male | ModelData.ModelType.Young, ModelData.ModelType.Animal | ModelData.ModelType.Cutscene);
            Menus.Models.Humans.MaleMiddle = new Menu(MenuText.Model.Human.MALE_MIDDLE);
            AddModelMenuItems(Menus.Models.Humans.MaleMiddle, ModelData.ModelType.Male | ModelData.ModelType.MiddleAged, ModelData.ModelType.Animal | ModelData.ModelType.Cutscene);
            Menus.Models.Humans.MaleOld = new Menu(MenuText.Model.Human.MALE_OLD);
            AddModelMenuItems(Menus.Models.Humans.MaleOld, ModelData.ModelType.Male | ModelData.ModelType.Old, ModelData.ModelType.Animal | ModelData.ModelType.Cutscene);
            Menus.Models.Humans.FemaleYoung = new Menu(MenuText.Model.Human.FEMALE_YOUNG);
            AddModelMenuItems(Menus.Models.Humans.FemaleYoung, ModelData.ModelType.Female | ModelData.ModelType.Young, ModelData.ModelType.Animal | ModelData.ModelType.Cutscene);
            Menus.Models.Humans.FemaleMiddle = new Menu(MenuText.Model.Human.FEMALE_MIDDLE);
            AddModelMenuItems(Menus.Models.Humans.FemaleMiddle, ModelData.ModelType.Female | ModelData.ModelType.MiddleAged, ModelData.ModelType.Animal | ModelData.ModelType.Cutscene);
            Menus.Models.Humans.FemaleOld = new Menu(MenuText.Model.Human.FEMALE_OLD);
            AddModelMenuItems(Menus.Models.Humans.FemaleOld, ModelData.ModelType.Female | ModelData.ModelType.Old, ModelData.ModelType.Animal | ModelData.ModelType.Cutscene);
            Menus.Models.Humans.Misc = new Menu(MenuText.Model.Human.MISC);
            AddModelMenuItems(Menus.Models.Humans.Misc, ModelData.ModelType.None, ModelData.ModelType.Animal | ModelData.ModelType.Cutscene | ModelData.ModelType.Male | ModelData.ModelType.Female | ModelData.ModelType.Young | ModelData.ModelType.MiddleAged | ModelData.ModelType.Old);
            AddMenuItem(Menus.Models.Human, MenuText.Model.Human.CUTSCENE, false, false, Menus.Models.Humans.Cutscene);
            AddMenuItem(Menus.Models.Human, MenuText.Model.Human.MALE_YOUNG, false, false, Menus.Models.Humans.MaleYoung);
            AddMenuItem(Menus.Models.Human, MenuText.Model.Human.MALE_MIDDLE, false, false, Menus.Models.Humans.MaleMiddle);
            AddMenuItem(Menus.Models.Human, MenuText.Model.Human.MALE_OLD, false, false, Menus.Models.Humans.MaleOld);
            AddMenuItem(Menus.Models.Human, MenuText.Model.Human.FEMALE_YOUNG, false, false, Menus.Models.Humans.FemaleYoung);
            AddMenuItem(Menus.Models.Human, MenuText.Model.Human.FEMALE_MIDDLE, false, false, Menus.Models.Humans.FemaleMiddle);
            AddMenuItem(Menus.Models.Human, MenuText.Model.Human.FEMALE_OLD, false, false, Menus.Models.Humans.FemaleOld);
            AddMenuItem(Menus.Models.Human, MenuText.Model.Human.MISC, false, false, Menus.Models.Humans.Misc);

            AddMenuItem(Menus.Model, MenuText.Model.ANIMAL, false, false, Menus.Models.Animal);
            AddMenuItem(Menus.Model, MenuText.Model.HUMAN, false, false, Menus.Models.Human);
        }

        private static void AddModelMenuItems(Menu parent, ModelData.ModelType includeType, ModelData.ModelType excludeType = ModelData.ModelType.None)
        {
            foreach (var md in ModelStorage.MODELS)
            {
                if ((md.Type & includeType) == includeType && (md.Type & excludeType) == ModelData.ModelType.None)
                {
                    AddMenuItem(parent, md.Name, false, false, null, Feature.Model.Spawn, null, null, md);
                }
            }
        }

        /// <summary>
        /// Initializes misc menu
        /// </summary>
        private static void InitMiscMenu()
        {
            Menus.Misc = new Menu(MenuText.Misc.TITLE);
            //MenuItems.Misc.PortableRadio = AddMenuItem(Menus.Misc, MenuText.Misc.PORTABLE_RADIO, true, Feature.Misc.PortableRadio, null, Feature.Misc.SetPortableRadio);
            MenuItems.Misc.HideHud = AddMenuItem(Menus.Misc, MenuText.Misc.HIDE_HUD, true, Feature.Misc.HideHud, null, Feature.Misc.SetHideHud);
            //MenuItems.Misc.NextRadioTrack = AddMenuItem(Menus.Misc, MenuText.Misc.NEXT_RADIO_TRACK, false, false, null, Feature.Misc.NextRadioTrack);
            MenuItems.Misc.RevealMap = AddMenuItem(Menus.Misc, MenuText.Misc.REVEAL_MAP, false, false, null, Feature.Misc.RevealMap);
        }

        /// <summary>
        /// Initializes weather menu
        /// </summary>
        private static void InitWeatherMenu()
        {
            Menus.Weather = new Menu(MenuText.Weather.TITLE);
            MenuItems.Weather.Wind = AddMenuItem(Menus.Weather, MenuText.Weather.WIND, true, Feature.Weather.Wind, null, Feature.Weather.SetWind);
            MenuItems.Weather.Freeze = AddMenuItem(Menus.Weather, MenuText.Weather.FREEZE_WEATHER, true, Feature.Weather.Freeze, null, Feature.Weather.SetFreeze);
            for (int i = 0; i < WeatherStorage.WEATHERS.Length; i++)
            {
                AddMenuItem(Menus.Weather, WeatherStorage.WEATHERS[i].Name, false, false, null, Feature.Weather.SetWeather, null, null, WeatherStorage.WEATHERS[i]);
            }
        }

        /// <summary>
        /// Initializes date time speed menu
        /// </summary>
        private static void InitDateTimeSpeedMenu()
        {
            Menus.DateTimeSpeed = new Menu(MenuText.DateTimeSpeed.TITLE);
            InitSetDateTimeMenu();
            MenuItems.DateTimeSpeed.SetDateTime = AddMenuItem(Menus.DateTimeSpeed, MenuText.DateTimeSpeed.SET_DATETIME, false, false, Menus.DateTimeSpeeds.SetDateTime, null, Feature.DateTimeSpeed.PreEnterSetDateTime);
            InitSetGameSpeedMenu();
            MenuItems.DateTimeSpeed.SetGameSpeed = AddMenuItem(Menus.DateTimeSpeed, MenuText.DateTimeSpeed.SET_GAME_SPEED, false, false, Menus.DateTimeSpeeds.SetGameSpeed);
            InitSetAimingSpeedMenu();
            MenuItems.DateTimeSpeed.SetAimingSpeed = AddMenuItem(Menus.DateTimeSpeed, MenuText.DateTimeSpeed.SET_AIMING_SPEED, false, false, Menus.DateTimeSpeeds.SetAimingSpeed);
            MenuItems.DateTimeSpeed.HourForward = AddMenuItem(Menus.DateTimeSpeed, MenuText.DateTimeSpeed.HOUR_FORWARD, false, false, null, Feature.DateTimeSpeed.HourForward);
            MenuItems.DateTimeSpeed.HourBackward = AddMenuItem(Menus.DateTimeSpeed, MenuText.DateTimeSpeed.HOUR_BACKWARD, false, false, null, Feature.DateTimeSpeed.HourBackward);
            MenuItems.DateTimeSpeed.DayForward = AddMenuItem(Menus.DateTimeSpeed, MenuText.DateTimeSpeed.DAY_FORWARD, false, false, null, Feature.DateTimeSpeed.DayForward);
            MenuItems.DateTimeSpeed.DayBackward = AddMenuItem(Menus.DateTimeSpeed, MenuText.DateTimeSpeed.DAY_BACKWARD, false, false, null, Feature.DateTimeSpeed.DayBackward);
            MenuItems.DateTimeSpeed.ShowTime = AddMenuItem(Menus.DateTimeSpeed, MenuText.DateTimeSpeed.SHOW_TIME, true, Feature.DateTimeSpeed.ShowTime, null, Feature.DateTimeSpeed.SetShowTime);
            MenuItems.DateTimeSpeed.Paused = AddMenuItem(Menus.DateTimeSpeed, MenuText.DateTimeSpeed.TIME_PAUSED, true, Feature.DateTimeSpeed.Paused, null, Feature.DateTimeSpeed.SetPaused);
            MenuItems.DateTimeSpeed.SyncWithSystem = AddMenuItem(Menus.DateTimeSpeed, MenuText.DateTimeSpeed.SYNC_WITH_SYSTEM, true, Feature.DateTimeSpeed.SyncWithSystem, null, Feature.DateTimeSpeed.SetSyncWithSystem);
            MenuItems.DateTimeSpeed.UseRealTimeScale = AddMenuItem(Menus.DateTimeSpeed, MenuText.DateTimeSpeed.USE_REAL_TIME_SCALE, true, Feature.DateTimeSpeed.UseRealTimeScale, null, Feature.DateTimeSpeed.SetUseRealTimeScale);
        }

        /// <summary>
        /// Initializes set aiming speed menu
        /// </summary>
        private static void InitSetAimingSpeedMenu()
        {
            Menus.DateTimeSpeeds.SetAimingSpeed = new Menu(MenuText.DateTimeSpeed.SET_AIMING_SPEED);
            MenuItems.DateTimeSpeed.SetAimingSpeedMenu.Speed = AddMenuItem(Menus.DateTimeSpeeds.SetAimingSpeed, null);
            Feature.DateTimeSpeed.UpdateAimingSpeed();
            MenuItems.DateTimeSpeed.SetAimingSpeedMenu.Speed.ShowLeftRightAdjustableSign = true;
            MenuItems.DateTimeSpeed.SetAimingSpeedMenu.Speed.LeftPressed += Feature.DateTimeSpeed.DecAimingSpeed;
            MenuItems.DateTimeSpeed.SetAimingSpeedMenu.Speed.RightPressed += Feature.DateTimeSpeed.IncAimingSpeed;
            MenuItems.DateTimeSpeed.SetAimingSpeedMenu.SetTo100 = AddMenuItem(Menus.DateTimeSpeeds.SetAimingSpeed, MenuText.DateTimeSpeed.SetAimingSpeed.SET_TO_100, false, false, null, Feature.DateTimeSpeed.SetAimingSpeedTo100);
            MenuItems.DateTimeSpeed.SetAimingSpeedMenu.SetTo075 = AddMenuItem(Menus.DateTimeSpeeds.SetAimingSpeed, MenuText.DateTimeSpeed.SetAimingSpeed.SET_TO_75, false, false, null, Feature.DateTimeSpeed.SetAimingSpeedTo075);
            MenuItems.DateTimeSpeed.SetAimingSpeedMenu.SetTo025 = AddMenuItem(Menus.DateTimeSpeeds.SetAimingSpeed, MenuText.DateTimeSpeed.SetAimingSpeed.SET_TO_50, false, false, null, Feature.DateTimeSpeed.SetAimingSpeedTo050);
            MenuItems.DateTimeSpeed.SetAimingSpeedMenu.SetTo050 = AddMenuItem(Menus.DateTimeSpeeds.SetAimingSpeed, MenuText.DateTimeSpeed.SetAimingSpeed.SET_TO_25, false, false, null, Feature.DateTimeSpeed.SetAimingSpeedTo025);
            MenuItems.DateTimeSpeed.SetAimingSpeedMenu.SetTo010 = AddMenuItem(Menus.DateTimeSpeeds.SetAimingSpeed, MenuText.DateTimeSpeed.SetAimingSpeed.SET_TO_10, false, false, null, Feature.DateTimeSpeed.SetAimingSpeedTo010);
            MenuItems.DateTimeSpeed.SetAimingSpeedMenu.SetTo000 = AddMenuItem(Menus.DateTimeSpeeds.SetAimingSpeed, MenuText.DateTimeSpeed.SetAimingSpeed.SET_TO_0, false, false, null, Feature.DateTimeSpeed.SetAimingSpeedTo000);
        }

        /// <summary>
        /// Initializes set game speed menu
        /// </summary>
        private static void InitSetGameSpeedMenu()
        {
            Menus.DateTimeSpeeds.SetGameSpeed = new Menu(MenuText.DateTimeSpeed.SET_GAME_SPEED);
            MenuItems.DateTimeSpeed.SetGameSpeedMenu.Speed = AddMenuItem(Menus.DateTimeSpeeds.SetGameSpeed, null);
            Feature.DateTimeSpeed.UpdateGameSpeed();
            MenuItems.DateTimeSpeed.SetGameSpeedMenu.Speed.ShowLeftRightAdjustableSign = true;
            MenuItems.DateTimeSpeed.SetGameSpeedMenu.Speed.LeftPressed += Feature.DateTimeSpeed.DecGameSpeed;
            MenuItems.DateTimeSpeed.SetGameSpeedMenu.Speed.RightPressed += Feature.DateTimeSpeed.IncGameSpeed;
            MenuItems.DateTimeSpeed.SetGameSpeedMenu.SetTo100 = AddMenuItem(Menus.DateTimeSpeeds.SetGameSpeed, MenuText.DateTimeSpeed.SetGameSpeed.SET_TO_100, false, false, null, Feature.DateTimeSpeed.SetGameSpeedTo100);
            MenuItems.DateTimeSpeed.SetGameSpeedMenu.SetTo075 = AddMenuItem(Menus.DateTimeSpeeds.SetGameSpeed, MenuText.DateTimeSpeed.SetGameSpeed.SET_TO_75, false, false, null, Feature.DateTimeSpeed.SetGameSpeedTo075);
            MenuItems.DateTimeSpeed.SetGameSpeedMenu.SetTo025 = AddMenuItem(Menus.DateTimeSpeeds.SetGameSpeed, MenuText.DateTimeSpeed.SetGameSpeed.SET_TO_50, false, false, null, Feature.DateTimeSpeed.SetGameSpeedTo050);
            MenuItems.DateTimeSpeed.SetGameSpeedMenu.SetTo050 = AddMenuItem(Menus.DateTimeSpeeds.SetGameSpeed, MenuText.DateTimeSpeed.SetGameSpeed.SET_TO_25, false, false, null, Feature.DateTimeSpeed.SetGameSpeedTo025);
            MenuItems.DateTimeSpeed.SetGameSpeedMenu.SetTo010 = AddMenuItem(Menus.DateTimeSpeeds.SetGameSpeed, MenuText.DateTimeSpeed.SetGameSpeed.SET_TO_10, false, false, null, Feature.DateTimeSpeed.SetGameSpeedTo010);
            MenuItems.DateTimeSpeed.SetGameSpeedMenu.SetTo000 = AddMenuItem(Menus.DateTimeSpeeds.SetGameSpeed, MenuText.DateTimeSpeed.SetGameSpeed.SET_TO_0, false, false, null, Feature.DateTimeSpeed.SetGameSpeedTo000);
        }

        /// <summary>
        /// Initializes set date time menu
        /// </summary>
        private static void InitSetDateTimeMenu()
        {
            Menus.DateTimeSpeeds.SetDateTime = new Menu(MenuText.DateTimeSpeed.SetDateTime.TITLE);
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Year = AddMenuItem(Menus.DateTimeSpeeds.SetDateTime, null, false, false, null, Feature.DateTimeSpeed.Set);
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Year.ShowLeftRightAdjustableSign = true;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Year.LeftPressed += Feature.DateTimeSpeed.DecYear;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Year.RightPressed += Feature.DateTimeSpeed.IncYear;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Month = AddMenuItem(Menus.DateTimeSpeeds.SetDateTime, null, false, false, null, Feature.DateTimeSpeed.Set);
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Month.ShowLeftRightAdjustableSign = true;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Month.LeftPressed += Feature.DateTimeSpeed.DecMonth;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Month.RightPressed += Feature.DateTimeSpeed.IncMonth;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Day = AddMenuItem(Menus.DateTimeSpeeds.SetDateTime, null, false, false, null, Feature.DateTimeSpeed.Set);
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Day.ShowLeftRightAdjustableSign = true;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Day.LeftPressed += Feature.DateTimeSpeed.DecDay;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Day.RightPressed += Feature.DateTimeSpeed.IncDay;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Hour = AddMenuItem(Menus.DateTimeSpeeds.SetDateTime, null, false, false, null, Feature.DateTimeSpeed.Set);
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Hour.ShowLeftRightAdjustableSign = true;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Hour.LeftPressed += Feature.DateTimeSpeed.DecHour;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Hour.RightPressed += Feature.DateTimeSpeed.IncHour;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Minute = AddMenuItem(Menus.DateTimeSpeeds.SetDateTime, null, false, false, null, Feature.DateTimeSpeed.Set);
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Minute.ShowLeftRightAdjustableSign = true;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Minute.LeftPressed += Feature.DateTimeSpeed.DecMinute;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Minute.RightPressed += Feature.DateTimeSpeed.IncMinute;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Second = AddMenuItem(Menus.DateTimeSpeeds.SetDateTime, null, false, false, null, Feature.DateTimeSpeed.Set);
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Second.ShowLeftRightAdjustableSign = true;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Second.LeftPressed += Feature.DateTimeSpeed.DecSecond;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.Second.RightPressed += Feature.DateTimeSpeed.IncSecond;
            MenuItems.DateTimeSpeed.SetDateTimeMenu.SetToCurrent = AddMenuItem(Menus.DateTimeSpeeds.SetDateTime, MenuText.DateTimeSpeed.SetDateTime.SET_TO_CURRENT, false, false, null, Feature.DateTimeSpeed.SetToCurrent);
            MenuItems.DateTimeSpeed.SetDateTimeMenu.SetToSystem = AddMenuItem(Menus.DateTimeSpeeds.SetDateTime, MenuText.DateTimeSpeed.SetDateTime.SET_TO_SYSTEM, false, false, null, Feature.DateTimeSpeed.SetToSystem);
        }

        /// <summary>
        /// Initializes weapon menu
        /// </summary>
        private static void InitWeaponMenu()
        {
            Menus.Weapon = new Menu(MenuText.Weapon.TITLE);
            Menus.Weapon.Width = 400;
            Menus.Weapon.PageTextOffset = new System.Drawing.Point(330, 8);
            Menus.Weapon.ToggleTextOffset = new System.Drawing.Point(350, 8);
            Menus.Weapon.LeftRightAdjustableSignOffset = new System.Drawing.Point(360, 8);
            //MenuItems.Weapon.GetAllWeapons = AddMenuItem(Menus.Weapon, MenuText.Weapon.GET_ALL_WEAPONS, false, false, null, Feature.Weapon.GetAllWeapons);
            InitSpecificWeaponMenu();
            MenuItems.Weapon.GetSpecificWeapon = AddMenuItem(Menus.Weapon, MenuText.Weapon.GET_SPECIFIC_WEAPON, false, false, Menus.Weapons.GetSpecificWeapon);
            MenuItems.Weapon.InfiniteAmmo = AddMenuItem(Menus.Weapon, MenuText.Weapon.INFINITE_AMMO, true, Feature.Weapon.InfiniteAmmo, null, Feature.Weapon.SetInfiniteAmmo);

            // Damage multiplier
            MenuItems.Weapon.DamageMultiplier = AddMenuItem(Menus.Weapon, MenuText.Weapon.I031_DAMAGE_MULTIPLIER, false, false, null, null, null, null, Feature.Weapon.DEFAULT_DAMAGE_MULTIPLIER_INDEX);
            MenuItems.Weapon.DamageMultiplier.Text = Feature.Weapon.GetDamageMultiplierStr();
            MenuItems.Weapon.DamageMultiplier.ShowLeftRightAdjustableSign = true;
            MenuItems.Weapon.DamageMultiplier.LeftPressed += Feature.Weapon.OnDamageMultiplierDec;
            MenuItems.Weapon.DamageMultiplier.RightPressed += Feature.Weapon.OnDamageMultiplierInc;
        }

        /// <summary>
        /// Initializes get specific weapon menu
        /// </summary>
        private static void InitSpecificWeaponMenu()
        {
            Menus.Weapons.GetSpecificWeapon = new Menu(MenuText.Weapon.SpecificWeapon.TITLE);
            Menus.Weapons.GetSpecificWeapon.Width = 400;
            Menus.Weapons.GetSpecificWeapon.PageTextOffset = new System.Drawing.Point(330, 8);
            foreach (var weap in WeaponStorage.WEAPONS)
            {
                AddMenuItem(Menus.Weapons.GetSpecificWeapon, weap.Name, false, false, null, Feature.Weapon.GiveSpecifiedWeapon, null, null, weap.InternalValue);
            }
        }

        /// <summary>
        /// Initialize player menu
        /// </summary>
        private static void InitPlayerMenu()
        {
            const int DEFAULT_CASH_AMOUNT = 10000;
            const string POSITIVE_SIGN = "+";

            Menus.Player = new Menu(MenuText.Player.TITLE);

            InitPlayerWantedMenu();
            AddMenuItem(Menus.Player, MenuText.Player.WANTED, false, false, Menus.Players.Wanted);

            // Cash menu
            MenuItem miCash = AddMenuItem(Menus.Player, MenuText.Player.CASH, false, false, null, Feature.Player.ChangeCash, null, null, DEFAULT_CASH_AMOUNT);
            miCash.ShowLeftRightAdjustableSign = true;
            miCash.LeftPressed += Feature.Player.DecreaseCash;
            miCash.RightPressed += Feature.Player.IncreaseCash;
            miCash.Text = Utils.FormatML(MenuText.Player.CASH, POSITIVE_SIGN, DEFAULT_CASH_AMOUNT / 100f);

            AddMenuItem(Menus.Player, MenuText.Player.HEAL, false, false, null, Feature.Player.QuickHeal);
            MenuItems.Player.Invincible = AddMenuItem(Menus.Player, MenuText.Player.INVINCIBLE, true, Feature.Player.Invincible, null, Feature.Player.SetInvincible);
            MenuItems.Player.InfiniteAbility = AddMenuItem(Menus.Player, MenuText.Player.INFINITE_ABILITY, true, Feature.Player.InfiniteAbility, null, Feature.Player.SetInfiniteAbility);
            MenuItems.Player.InfiniteStamina = AddMenuItem(Menus.Player, MenuText.Player.INFINITE_STAMINA, true, Feature.Player.InfiniteStamina, null, Feature.Player.SetInfiniteStamina);
            MenuItems.Player.SuperJump = AddMenuItem(Menus.Player, MenuText.Player.SUPER_JUMP, true, Feature.Player.SuperJump, null, Feature.Player.SetSuperJump);
            MenuItems.Player.Noiseless = AddMenuItem(Menus.Player, MenuText.Player.NOISELESS, true, Feature.Player.Noiseless, null, Feature.Player.SetNoiseless);
        }

        /// <summary>
        /// Initialize player wanted menu
        /// </summary>
        private static void InitPlayerWantedMenu()
        {
            Menus.Players.Wanted = new Menu(MenuText.Player.Wanted.TITLE);
            MenuItems.Player.Wanted.ClearBounty = AddMenuItem(Menus.Players.Wanted, MenuText.Player.Wanted.I001_CLEAR_BOUNTY, false, false, null, Feature.Player.Wanted.ClearBounty);
            MenuItems.Player.Wanted.NeverWanted = AddMenuItem(Menus.Players.Wanted, MenuText.Player.Wanted.NEVER_WANTED, true, Feature.Player.Wanted.NeverWanted, null, Feature.Player.Wanted.SetNeverWanted);
            MenuItems.Player.Wanted.EveryoneIgnored = AddMenuItem(Menus.Players.Wanted, MenuText.Player.Wanted.EVERYONE_IGNORED, true, Feature.Player.Wanted.EveryoneIgnored, null, Feature.Player.Wanted.SetEveryoneIgonred);
        }

        /// <summary>
        /// Initialize location menu
        /// </summary>
        private static void InitLocationMenu()
        {
            Menus.Location = new Menu(MenuText.Location.TITLE);
            InitLocationTeleporterMenu();
            AddMenuItem(Menus.Location, MenuText.Location.LOCATION_TELEPORTER, false, false, Menus.Locations.LTeleporter);
            InitCustomLocationTeleporterMenu();
            InitCustomLocationTeleporterItemMenu();
            AddMenuItem(Menus.Location, MenuText.Location.CUSTOM_LOCATION_TELEPORTER, false, false, Menus.Locations.CLTeleporter, null, Feature.Location.CustomLocationTeleporter.GenerateTargetList);
            InitXyzTeleporterMenu();
            AddMenuItem(Menus.Location, MenuText.Location.XYZ_TELEPORTER, false, false, Menus.Locations.XyzTeleporter);
            MenuItems.Location.ShowCoordinate = AddMenuItem(Menus.Location, MenuText.Location.SHOW_COORDINATE, true, Feature.Location.ShowCoordinates, null, Feature.Location.SetShowCoordinates);
        }

        /// <summary>
        /// Initialize location - location teleporter menu
        /// </summary>
        private static void InitLocationTeleporterMenu()
        {
            Menus.Locations.LTeleporter = new Menu(MenuText.Location.LocationTeleporter.TITLE);
            AddMenuItem(Menus.Locations.LTeleporter, MenuText.Location.LocationTeleporter.MAP_MARKER, false, false, null, Feature.Location.LocationTeleporter.MapMarker);
            foreach (TeleportCategory tc in TeleportTargetStorage.CATEGORIES)
            {
                Menu menu = new Menu(tc.Name);
                AddTeleportTargetsToMenu(menu, tc.Targets);
                AddMenuItem(Menus.Locations.LTeleporter, tc.Name, false, false, menu);
            }
        }

        /// <summary>
        /// Initialize location - custom location teleporter menu
        /// </summary>
        private static void InitCustomLocationTeleporterMenu()
        {
            Menus.Locations.CLTeleporter = new Menu(MenuText.Location.CustomLocationTeleporter.TITLE);
            Menus.Locations.CLTeleporter.Width = 600;
            Menus.Locations.CLTeleporter.HasSubmenuSignOffset = new System.Drawing.Point(570, 5);
            Menus.Locations.CLTeleporter.PageTextOffset = new System.Drawing.Point(535, 5);
            MenuItems.Location.CustomLocationTeleporter.SaveCurrentLocation = AddMenuItem(Menus.Locations.CLTeleporter, MenuText.Location.CustomLocationTeleporter.SAVE, false, false, null, Feature.Location.CustomLocationTeleporter.SaveCurrentLocation);
        }

        /// <summary>
        /// Initialize location - custom location teleporter - item menu
        /// </summary>
        private static void InitCustomLocationTeleporterItemMenu()
        {
            Menus.Locations.CLTeleporters.Item = new Menu(null);
            Menus.Locations.CLTeleporters.Item.Width = 700;
            Menus.Locations.CLTeleporters.Item.HasSubmenuSignOffset = new System.Drawing.Point(670, 5);
            MenuItems.Location.CustomLocationTeleporter.Item.Teleport = AddMenuItem(Menus.Locations.CLTeleporters.Item, MenuText.Location.CustomLocationTeleporter.Item.TELEPORT, false, false, null, Feature.Location.CustomLocationTeleporter.Teleport);
            MenuItems.Location.CustomLocationTeleporter.Item.Rename = AddMenuItem(Menus.Locations.CLTeleporters.Item, MenuText.Location.CustomLocationTeleporter.Item.RENAME, false, false, null, Feature.Location.CustomLocationTeleporter.Rename);
            MenuItems.Location.CustomLocationTeleporter.Item.Overwrite = AddMenuItem(Menus.Locations.CLTeleporters.Item, MenuText.Location.CustomLocationTeleporter.Item.OVERWRITE, false, false, null, Feature.Location.CustomLocationTeleporter.Overwrite);
            MenuItems.Location.CustomLocationTeleporter.Item.Delete = AddMenuItem(Menus.Locations.CLTeleporters.Item, MenuText.Location.CustomLocationTeleporter.Item.DELETE, false, false, null, Feature.Location.CustomLocationTeleporter.Delete);
        }

        /// <summary>
        /// Initialize xyz teleporter menu
        /// </summary>
        private static void InitXyzTeleporterMenu()
        {
            Menus.Locations.XyzTeleporter = new Menu(MenuText.Location.XyzTeleporter.TITLE);
            InitXyzTeleporterOffsetMenu();
            AddMenuItem(Menus.Locations.XyzTeleporter, MenuText.Location.XyzTeleporter.OFFSET, false, false, Menus.Locations.XyzTeleporters.Offset);
            InitXyzTeleporterCoordinatesMenu();
            AddMenuItem(Menus.Locations.XyzTeleporter, MenuText.Location.XyzTeleporter.COORDINATES, false, false, Menus.Locations.XyzTeleporters.Coordinates, Feature.Location.XyzTeleporter.Coordinates.EnterMenu);
            AddMenuItem(Menus.Locations.XyzTeleporter, MenuText.Location.XyzTeleporter.RANDOM, false, false, null, Feature.Location.XyzTeleporter.Random);
        }

        /// <summary>
        /// Initialize xyz teleporter offset menu
        /// </summary>
        private static void InitXyzTeleporterOffsetMenu()
        {
            Menus.Locations.XyzTeleporters.Offset = new Menu(MenuText.Location.XyzTeleporter.Offset.TITLE);
            MenuItems.Location.XyzTeleporter.Offset.X = AddMenuItem(Menus.Locations.XyzTeleporters.Offset, MenuText.Location.XyzTeleporter.Offset.X, false, false, null, Feature.Location.XyzTeleporter.Offset.SetX);
            MenuItems.Location.XyzTeleporter.Offset.X.ShowLeftRightAdjustableSign = true;
            MenuItems.Location.XyzTeleporter.Offset.X.LeftPressed += Feature.Location.XyzTeleporter.Offset.DecX;
            MenuItems.Location.XyzTeleporter.Offset.X.RightPressed += Feature.Location.XyzTeleporter.Offset.IncX;
            MenuItems.Location.XyzTeleporter.Offset.Y = AddMenuItem(Menus.Locations.XyzTeleporters.Offset, MenuText.Location.XyzTeleporter.Offset.Y, false, false, null, Feature.Location.XyzTeleporter.Offset.SetY);
            MenuItems.Location.XyzTeleporter.Offset.Y.ShowLeftRightAdjustableSign = true;
            MenuItems.Location.XyzTeleporter.Offset.Y.LeftPressed += Feature.Location.XyzTeleporter.Offset.DecY;
            MenuItems.Location.XyzTeleporter.Offset.Y.RightPressed += Feature.Location.XyzTeleporter.Offset.IncY;
            MenuItems.Location.XyzTeleporter.Offset.Z = AddMenuItem(Menus.Locations.XyzTeleporters.Offset, MenuText.Location.XyzTeleporter.Offset.Z, false, false, null, Feature.Location.XyzTeleporter.Offset.SetZ);
            MenuItems.Location.XyzTeleporter.Offset.Z.ShowLeftRightAdjustableSign = true;
            MenuItems.Location.XyzTeleporter.Offset.Z.LeftPressed += Feature.Location.XyzTeleporter.Offset.DecZ;
            MenuItems.Location.XyzTeleporter.Offset.Z.RightPressed += Feature.Location.XyzTeleporter.Offset.IncZ;
            AddMenuItem(Menus.Locations.XyzTeleporters.Offset, MenuText.Location.XyzTeleporter.Offset.RESET, false, false, null, Feature.Location.XyzTeleporter.Offset.Reset);
            AddMenuItem(Menus.Locations.XyzTeleporters.Offset, MenuText.Location.XyzTeleporter.Offset.TELEPORT, false, false, null, Feature.Location.XyzTeleporter.Offset.Teleport);
            Feature.Location.XyzTeleporter.Offset.UpdateXMenuText();
            Feature.Location.XyzTeleporter.Offset.UpdateYMenuText();
            Feature.Location.XyzTeleporter.Offset.UpdateZMenuText();
        }

        /// <summary>
        /// INitialize xyz teleporter coordinates menu
        /// </summary>
        private static void InitXyzTeleporterCoordinatesMenu()
        {
            Menus.Locations.XyzTeleporters.Coordinates = new Menu(MenuText.Location.XyzTeleporter.Coordinates.TITLE);
            MenuItems.Location.XyzTeleporter.Coordinates.X = AddMenuItem(Menus.Locations.XyzTeleporters.Coordinates, MenuText.Location.XyzTeleporter.Coordinates.X, false, false, null, Feature.Location.XyzTeleporter.Coordinates.SetX);
            MenuItems.Location.XyzTeleporter.Coordinates.X.ShowLeftRightAdjustableSign = true;
            MenuItems.Location.XyzTeleporter.Coordinates.X.LeftPressed += Feature.Location.XyzTeleporter.Coordinates.DecX;
            MenuItems.Location.XyzTeleporter.Coordinates.X.RightPressed += Feature.Location.XyzTeleporter.Coordinates.IncX;
            MenuItems.Location.XyzTeleporter.Coordinates.Y = AddMenuItem(Menus.Locations.XyzTeleporters.Coordinates, MenuText.Location.XyzTeleporter.Coordinates.Y, false, false, null, Feature.Location.XyzTeleporter.Coordinates.SetY);
            MenuItems.Location.XyzTeleporter.Coordinates.Y.ShowLeftRightAdjustableSign = true;
            MenuItems.Location.XyzTeleporter.Coordinates.Y.LeftPressed += Feature.Location.XyzTeleporter.Coordinates.DecY;
            MenuItems.Location.XyzTeleporter.Coordinates.Y.RightPressed += Feature.Location.XyzTeleporter.Coordinates.IncY;
            MenuItems.Location.XyzTeleporter.Coordinates.Z = AddMenuItem(Menus.Locations.XyzTeleporters.Coordinates, MenuText.Location.XyzTeleporter.Coordinates.Z, false, false, null, Feature.Location.XyzTeleporter.Coordinates.SetZ);
            MenuItems.Location.XyzTeleporter.Coordinates.Z.ShowLeftRightAdjustableSign = true;
            MenuItems.Location.XyzTeleporter.Coordinates.Z.LeftPressed += Feature.Location.XyzTeleporter.Coordinates.DecZ;
            MenuItems.Location.XyzTeleporter.Coordinates.Z.RightPressed += Feature.Location.XyzTeleporter.Coordinates.IncZ;
            AddMenuItem(Menus.Locations.XyzTeleporters.Coordinates, MenuText.Location.XyzTeleporter.Coordinates.RESET, false, false, null, Feature.Location.XyzTeleporter.Coordinates.Reset);
            AddMenuItem(Menus.Locations.XyzTeleporters.Coordinates, MenuText.Location.XyzTeleporter.Coordinates.TELEPORT, false, false, null, Feature.Location.XyzTeleporter.Coordinates.Teleport);
            Feature.Location.XyzTeleporter.Coordinates.UpdateXMenuText();
            Feature.Location.XyzTeleporter.Coordinates.UpdateYMenuText();
            Feature.Location.XyzTeleporter.Coordinates.UpdateZMenuText();
        }

        /// <summary>
        /// Initialize vehicle menu
        /// </summary>
        private static void InitVehicleMenu()
        {
            Menus.Vehicle = new Menu(MenuText.Vehicle.TITLE);
            InitVehicleSpawnMenu();
            AddMenuItem(Menus.Vehicle, MenuText.Vehicle.SPAWN, false, false, Menus.Vehicles.SpawnVehicle);
            InitVehicleSpeedMeterMenu();
            AddMenuItem(Menus.Vehicle, MenuText.Vehicle.SPEED_METER, false, false, Menus.Vehicles.SpeedMeter);
            MenuItems.Vehicle.Invincible = AddMenuItem(Menus.Vehicle, MenuText.Vehicle.INVINCIBLE, true, Feature.Vehicle.Invincible, null, Feature.Vehicle.SetInvincible);
            MenuItems.Vehicle.InfiniteStamina = AddMenuItem(Menus.Vehicle, MenuText.Vehicle.I091_INFINITE_STAMINA, true, Feature.Vehicle.InfiniteStamina, null, Feature.Vehicle.SetInfiniteStamina);
            MenuItems.Vehicle.SpawnIntoVehicle = AddMenuItem(Menus.Vehicle, MenuText.Vehicle.SPAWN_INTO, true, Feature.Vehicle.SpawnIntoVehicle, null, Feature.Vehicle.SetSpawnIntoVehicle);
            InitVehicleBoostMenu();
            AddMenuItem(Menus.Vehicle, MenuText.Vehicle.VEHICLE_BOOST, false, false, Menus.Vehicles.VehicleBoost);
        }

        /// <summary>
        /// Initialize vehicle boost menu
        /// </summary>
        private static void InitVehicleBoostMenu()
        {
            Menus.Vehicles.VehicleBoost = new Menu(MenuText.Vehicle.VehicleBoost.TITLE);
            Menus.Vehicles.VehicleBoost.Width = 700;
            Menus.Vehicles.VehicleBoost.LeftRightAdjustableSignOffset = new System.Drawing.Point(660, 5);
            Menus.Vehicles.VehicleBoost.ToggleTextOffset = new System.Drawing.Point(650, 5);
            MenuItems.Vehicle.VehicleBoost.BoostProgressive = AddMenuItem(Menus.Vehicles.VehicleBoost, MenuText.Vehicle.VehicleBoost.BOOST_PROGRESSIVE, true, Feature.Vehicle.VehicleBoost.BoostProgressive, null, Feature.Vehicle.VehicleBoost.SetBoostProgressive);
            MenuItems.Vehicle.VehicleBoost.BoostProgressiveSpeedInc = AddMenuItem(Menus.Vehicles.VehicleBoost, MenuText.Vehicle.VehicleBoost.BOOST_PROGRESSIVE_SPEED_INC);
            MenuItems.Vehicle.VehicleBoost.BoostProgressiveSpeedInc.ShowLeftRightAdjustableSign = true;
            MenuItems.Vehicle.VehicleBoost.BoostProgressiveSpeedInc.LeftPressed += Feature.Vehicle.VehicleBoost.DecBoostProgressiveSpeed;
            MenuItems.Vehicle.VehicleBoost.BoostProgressiveSpeedInc.RightPressed += Feature.Vehicle.VehicleBoost.IncBoostProgressiveSpeed;
            MenuItems.Vehicle.VehicleBoost.BoostInstant = AddMenuItem(Menus.Vehicles.VehicleBoost, MenuText.Vehicle.VehicleBoost.BOOST_INSTANT, true, Feature.Vehicle.VehicleBoost.BoostInstant, null, Feature.Vehicle.VehicleBoost.SetBoostInstant);
            MenuItems.Vehicle.VehicleBoost.BoostInstantSpeed = AddMenuItem(Menus.Vehicles.VehicleBoost, MenuText.Vehicle.VehicleBoost.BOOST_INSTANT_SPEED);
            MenuItems.Vehicle.VehicleBoost.BoostInstantSpeed.ShowLeftRightAdjustableSign = true;
            MenuItems.Vehicle.VehicleBoost.BoostInstantSpeed.LeftPressed += Feature.Vehicle.VehicleBoost.DecBoostInstantSpeed;
            MenuItems.Vehicle.VehicleBoost.BoostInstantSpeed.RightPressed += Feature.Vehicle.VehicleBoost.IncBoostInstantSpeed;
            Feature.Vehicle.VehicleBoost.UpdateBoostProgressiveSpeed();
            Feature.Vehicle.VehicleBoost.UpdateBoostInstantSpeed();
        }

        /// <summary>
        /// Initialize vehicle speed meter menu
        /// </summary>
        private static void InitVehicleSpeedMeterMenu()
        {
            Menus.Vehicles.SpeedMeter = new Menu(MenuText.Vehicle.SpeedMeter.TITLE);
            MenuItems.Vehicle.SpeedMeter.Show = AddMenuItem(Menus.Vehicles.SpeedMeter, MenuText.Vehicle.SpeedMeter.SHOW, true, Feature.Vehicle.SpeedMeter.Show, null, Feature.Vehicle.SpeedMeter.SetShow);
            MenuItems.Vehicle.SpeedMeter.ShowInMetric = AddMenuItem(Menus.Vehicles.SpeedMeter, MenuText.Vehicle.SpeedMeter.SHOW_IN_METRIC, true, Feature.Vehicle.SpeedMeter.ShowInMetric, null, Feature.Vehicle.SpeedMeter.SetShowInMetric);
            MenuItems.Vehicle.SpeedMeter.ShowWithoutVehicle = AddMenuItem(Menus.Vehicles.SpeedMeter, MenuText.Vehicle.SpeedMeter.SHOW_WITHOUT_VEHICLE, true, Feature.Vehicle.SpeedMeter.ShowWithoutVehicle, null, Feature.Vehicle.SpeedMeter.SetShowWithoutVehicle);
        }

        /// <summary>
        /// Initialize vehicle spawn menu
        /// </summary>
        private static void InitVehicleSpawnMenu()
        {
            Menus.Vehicles.SpawnVehicle = new Menu(MenuText.Vehicle.Spawn.TITLE);
            Menu subMenuBoat = new Menu(MenuText.Vehicle.Spawn.BOAT);
            Menu subMenuTrain = new Menu(MenuText.Vehicle.Spawn.TRAIN);
            Menu subMenuWagon = new Menu(MenuText.Vehicle.Spawn.WAGON);
            Menu subMenuWagonOnly = new Menu(MenuText.Vehicle.Spawn.WAGON_ONLY);
            Menu subMenuCannon = new Menu(MenuText.Vehicle.Spawn.CANNON);
            Menu subMenuMisc = new Menu(MenuText.Vehicle.Spawn.MISC);
            MenuItems.Vehicle.SpawnVehicle.Boat = AddMenuItem(Menus.Vehicles.SpawnVehicle, MenuText.Vehicle.Spawn.BOAT, false, false, subMenuBoat);
            MenuItems.Vehicle.SpawnVehicle.Train = AddMenuItem(Menus.Vehicles.SpawnVehicle, MenuText.Vehicle.Spawn.TRAIN, false, false, subMenuTrain);
            MenuItems.Vehicle.SpawnVehicle.Wagon = AddMenuItem(Menus.Vehicles.SpawnVehicle, MenuText.Vehicle.Spawn.WAGON, false, false, subMenuWagon);
            MenuItems.Vehicle.SpawnVehicle.WagonOnly = AddMenuItem(Menus.Vehicles.SpawnVehicle, MenuText.Vehicle.Spawn.WAGON_ONLY, false, false, subMenuWagonOnly);
            MenuItems.Vehicle.SpawnVehicle.Cannon = AddMenuItem(Menus.Vehicles.SpawnVehicle, MenuText.Vehicle.Spawn.CANNON, false, false, subMenuCannon);
            MenuItems.Vehicle.SpawnVehicle.Misc = AddMenuItem(Menus.Vehicles.SpawnVehicle, MenuText.Vehicle.Spawn.MISC, false, false, subMenuMisc);
            foreach (string modelName in VehicleStorage.VEHICLE_MODELS)
            {
                VehicleData.VehicleInfo vi = VehicleData.GetVehicleInfo(modelName);
                VehicleData vd = new VehicleData(modelName, modelName);
                Menu subMenu = null;
                switch (vi.Type)
                {
                    case VehicleData.VehicleType.Boat:
                        subMenu = subMenuBoat;
                        break;

                    case VehicleData.VehicleType.Cannon:
                        subMenu = subMenuCannon;
                        break;

                    case VehicleData.VehicleType.Misc:
                        subMenu = subMenuMisc;
                        break;

                    case VehicleData.VehicleType.Train:
                        subMenu = subMenuTrain;
                        break;

                    case VehicleData.VehicleType.Wagon:
                        subMenu = subMenuWagon;
                        break;
                }
                vd.Info = vi;
                AddMenuItem(subMenu, modelName, false, false, null, Feature.Vehicle.SpawnVehicle, null, null, vd);
                if (vi.Type == VehicleData.VehicleType.Wagon) AddMenuItem(subMenuWagonOnly, modelName, false, false, null, Feature.Vehicle.SpawnVehicle, null, null, new VehicleData(vd.InternalValue)
                {
                    Info = vi,
                    WagonOnly = true,
                });
            }
        }

        /// <summary>
        /// Initialize configuration menu
        /// </summary>
        private static void InitConfigurationMenu()
        {
            Menus.Configuration = new Menu(MenuText.Configuration.TITLE);
            AddMenuItem(Menus.Configuration, MenuText.Configuration.SAVE, false, false, null, Feature.Config.Save);
            AddMenuItem(Menus.Configuration, MenuText.Configuration.LOAD, false, false, null, Feature.Config.Load);
            AddMenuItem(Menus.Configuration, MenuText.Configuration.AUTO_SAVE, true, Feature.Config.AutoSave, null, Feature.Config.SetAutoSave);
        }

        /// <summary>
        /// Initialize main menu
        /// </summary>
        private static void InitMainMenu()
        {
            Menus.Main = new Menu(MenuText.Main.TITLE);
            AddMenuItem(Menus.Main, MenuText.Main.PLAYER, false, false, Menus.Player);
            AddMenuItem(Menus.Main, MenuText.Main.LOCATION, false, false, Menus.Location);
            AddMenuItem(Menus.Main, MenuText.Main.VEHICLE, false, false, Menus.Vehicle);
            AddMenuItem(Menus.Main, MenuText.Main.WEAPON, false, false, Menus.Weapon);
            AddMenuItem(Menus.Main, MenuText.Main.MODEL, false, false, Menus.Model);
            AddMenuItem(Menus.Main, MenuText.Main.DATE_TIME_SPEED, false, false, Menus.DateTimeSpeed);
            AddMenuItem(Menus.Main, MenuText.Main.WEATHER, false, false, Menus.Weather);
            AddMenuItem(Menus.Main, MenuText.Main.MISC, false, false, Menus.Misc);
            AddMenuItem(Menus.Main, MenuText.Main.CONFIGURATION, false, false, Menus.Configuration);

            EnterMenu(Menus.Main);
        }

        /// <summary>
        /// Adds a menu item into menu
        /// </summary>
        /// <param name="parent">Parent menu</param>
        /// <param name="text">Text</param>
        /// <param name="toggle">Is toggle</param>
        /// <param name="on">Is on</param>
        /// <param name="subMenu">Sub menu</param>
        /// <param name="activateEventHandler">Activated event handler</param>
        /// <param name="highlightedEventHandler">Highlighted event handler</param>
        /// <param name="preActivateEventHandler">Pre-activated event handler</param>
        public static MenuItem AddMenuItem(Menu parent, MLString text, bool toggle = false, bool on = false, Menu subMenu = null, MenuItemEventHandler activateEventHandler = null, MenuItemEventHandler preActivateEventHandler = null, MenuItemEventHandler highlightedEventHandler = null, object data = null)
        {
            MenuItem mi = new MenuItem()
            {
                Text = text,
                IsToggle = toggle,
                On = on,
                SubMenu = subMenu
            };
            if (activateEventHandler != null) mi.Activated += activateEventHandler;
            if (preActivateEventHandler != null) mi.PreActivated += preActivateEventHandler;
            if (highlightedEventHandler != null) mi.Highlighted += highlightedEventHandler;
            mi.Data = data;
            parent.Add(mi);

            Debug.Log("Created MenuItem: {0}", text);
            return mi;
        }

        /// <summary>
        /// Adds teleport targets into menu
        /// </summary>
        /// <param name="parent">Parent menu</param>
        /// <param name="targets">Teleport targets</param>
        private static void AddTeleportTargetsToMenu(Menu parent, TeleportTarget[] targets)
        {
            foreach (TeleportTarget tt in targets)
            {
                MenuItem mi = AddMenuItem(parent, tt.Name, false, false, null, Feature.Location.LocationTeleporter.Target, null, null, tt);
            }
        }
    }
}
