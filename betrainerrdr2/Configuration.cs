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
using System.IO;
using System.Windows.Forms;
using BEGroup.Utility;
using BETrainerRdr2.Teleport;

namespace BETrainerRdr2
{
    /// <summary>
    /// Configurations
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Input key configurations
        /// </summary>
        public static class InputKey
        {
            /// <summary>
            /// Key to toggle trainer menu
            /// </summary>
            public static Keys ToggleMenu = Keys.F5;

            /// <summary>
            /// Key to move menu cursor up
            /// </summary>
            public static Keys MenuUp = Keys.NumPad8;

            /// <summary>
            /// Key to move menu cursor down
            /// </summary>
            public static Keys MenuDown = Keys.NumPad2;

            /// <summary>
            /// Key to move menu cursor left
            /// </summary>
            public static Keys MenuLeft = Keys.NumPad4;

            /// <summary>
            /// Key to move menu cursor right
            /// </summary>
            public static Keys MenuRight = Keys.NumPad6;

            /// <summary>
            /// Key to select current menu item
            /// </summary>
            public static Keys MenuSelect = Keys.NumPad5;

            /// <summary>
            /// Key to return to previous menu
            /// </summary>
            public static Keys MenuBack = Keys.NumPad0;

            /// <summary>
            /// Key to boost vehicle progressively
            /// </summary>
            public static Keys BoostVehicleProgressive = Keys.NumPad3;

            /// <summary>
            /// Key to boost vehicle instantly
            /// </summary>
            public static Keys BoostVehicleInstant = Keys.NumPad9;

            /// <summary>
            /// Key to stop vehicle
            /// </summary>
            public static Keys StopVehicle = Keys.NumPad7;

            /// <summary>
            /// Key to launch vehicle rockets
            /// </summary>
            public static Keys VehicleRocket = Keys.Add;
        }

        // Configuration file
        private const string CONFIG_FILE = ".\\scripts\\BETrainerRdr2.ini";

        // Configuration sections & keys below:
        private const string CONFIG_TRAINER = "Trainer";
        private const string CONFIG_TRAINER_AUTO_SAVE = "AutoSave";

        private const string CONFIG_KEYS = "Keys";
        private const string CONFIG_KEYS_TOGGLE_MENU = "ToggleMenu";
        private const string CONFIG_KEYS_MENU_UP = "MenuUp";
        private const string CONFIG_KEYS_MENU_DOWN = "MenuDown";
        private const string CONFIG_KEYS_MENU_LEFT = "MenuLeft";
        private const string CONFIG_KEYS_MENU_RIGHT = "MenuRight";
        private const string CONFIG_KEYS_MENU_SELECT = "MenuSelect";
        private const string CONFIG_KEYS_MENU_BACK = "MenuBack";
        private const string CONFIG_KEYS_BOOST_VEHICLE = "BoostVehicle";
        private const string CONFIG_KEYS_BOOST_VEHICLE_INSTANT = "BoostVehicleInstant";
        private const string CONFIG_KEYS_STOP_VEHICLE = "StopVehicle";
        private const string CONFIG_KEYS_VEHICLE_ROCKET = "VehicleRocket";

        private const string CONFIG_PLAYER = "Player";
        private const string CONFIG_PLAYER_INVINCIBLE = "Invincible";
        private const string CONFIG_PLAYER_INFINITE_ABILITY = "InfiniteAbility";
        private const string CONFIG_PLAYER_INFINITE_STAMINA = "InfiniteStamina";
        private const string CONFIG_PLAYER_SUPER_JUMP = "SuperJump";
        private const string CONFIG_PLAYER_NOISELESS = "Noiseless";
        private const string CONFIG_PLAYER_NEVER_WANTED = "NeverWanted";
        private const string CONFIG_PLAYER_EVERYONE_IGNORED = "EveryoneIgnored";

        private const string CONFIG_LOCATION = "Location";
        private const string CONFIG_LOCATION_SHOW_COORDINATES = "ShowCoordinates";

        private const string CONFIG_VEHICLE = "Vehicle";
        private const string CONFIG_VEHICLE_INVINCIBLE = "Invincible";
        private const string CONFIG_VEHICLE_INFINITE_STAMINA = "InfiniteStamina";
        private const string CONFIG_VEHICLE_SPAWN_INTO = "SpawnIntoVehicle";
        private const string CONFIG_VEHICLE_BOOST_PROGRESSIVE = "BoostProgressive";
        private const string CONFIG_VEHICLE_BOOST_PROGRESSIVE_SPEED_INC = "BoostProgressiveSpeedInc";
        private const string CONFIG_VEHICLE_BOOST_INSTANT = "BoostInstant";
        private const string CONFIG_VEHICLE_BOOST_INSTANT_SPEED = "BoostInstantSpeed";
        private const string CONFIG_VEHICLE_SPEEDMETER_SHOW = "SpeedMeterShow";
        private const string CONFIG_VEHICLE_SPEEDMETER_SHOW_IN_METRIC = "SpeedMeterShowInMetric";
        private const string CONFIG_VEHICLE_SPEEDMETER_SHOW_WITHOUT_VEHICLE = "SpeedMeterShowWithoutVehicle";

        private const string CONFIG_WEAPON = "Weapon";
        private const string CONFIG_WEAPON_INFINITE_AMMO = "InfiniteAmmo";
        private const string CONFIG_WEAPON_DAMAGE_MULTIPLIER_INDEX = "DamageMultiplierIndex";

        private const string CONFIG_TIME = "Time";
        private const string CONFIG_TIME_SHOW_TIME = "ShowTime";
        private const string CONFIG_TIME_PAUSED = "Paused";
        private const string CONFIG_TIME_SYNC_WITH_SYSTEM = "SyncWithSystem";
        private const string CONFIG_TIME_USE_REAL_TIME_SCALE = "UseRealTimeScale";
        private const string CONFIG_AIMING_SPEED = "AimingSpeed";

        private const string CONFIG_WEATHER = "Weather";
        private const string CONFIG_WEATHER_WIND = "Wind";
        private const string CONFIG_WEATHER_FREEZE = "Freeze";

        private const string CONFIG_MISC = "Misc";
        private const string CONFIG_MISC_HIDE_HUD = "HideHUD";

        private const string CONFIG_LANGUAGE = "Language";
        private const string CONFIG_LANGUAGE_VALUE = "Value";

        /// <summary>
        /// Load configurations
        /// </summary>
        public static void Load()
        {
            if (!File.Exists(CONFIG_FILE))
            {
                Utils.ShowNotification(GlobalConst.Message.CONFIGURATION_CREATING);
                Save();
                return;
            }

            try
            {
                IniFile ini = new IniFile(CONFIG_FILE);

                // Trainer
                Feature.Config.AutoSave = Utils.ParseBoolStr(ini.GetValue(CONFIG_TRAINER, CONFIG_TRAINER_AUTO_SAVE));

                // Keys
                InputKey.ToggleMenu = Utils.ParseKey(ini.GetValue(CONFIG_KEYS, CONFIG_KEYS_TOGGLE_MENU), InputKey.ToggleMenu);
                InputKey.MenuUp = Utils.ParseKey(ini.GetValue(CONFIG_KEYS, CONFIG_KEYS_MENU_UP), InputKey.MenuUp);
                InputKey.MenuDown = Utils.ParseKey(ini.GetValue(CONFIG_KEYS, CONFIG_KEYS_MENU_DOWN), InputKey.MenuDown);
                InputKey.MenuLeft = Utils.ParseKey(ini.GetValue(CONFIG_KEYS, CONFIG_KEYS_MENU_LEFT), InputKey.MenuLeft);
                InputKey.MenuRight = Utils.ParseKey(ini.GetValue(CONFIG_KEYS, CONFIG_KEYS_MENU_RIGHT), InputKey.MenuRight);
                InputKey.MenuSelect = Utils.ParseKey(ini.GetValue(CONFIG_KEYS, CONFIG_KEYS_MENU_SELECT), InputKey.MenuSelect);
                InputKey.MenuBack = Utils.ParseKey(ini.GetValue(CONFIG_KEYS, CONFIG_KEYS_MENU_BACK), InputKey.MenuBack);
                InputKey.BoostVehicleProgressive = Utils.ParseKey(ini.GetValue(CONFIG_KEYS, CONFIG_KEYS_BOOST_VEHICLE), InputKey.BoostVehicleProgressive);
                InputKey.BoostVehicleInstant = Utils.ParseKey(ini.GetValue(CONFIG_KEYS, CONFIG_KEYS_BOOST_VEHICLE_INSTANT), InputKey.BoostVehicleInstant);
                InputKey.StopVehicle = Utils.ParseKey(ini.GetValue(CONFIG_KEYS, CONFIG_KEYS_STOP_VEHICLE), InputKey.StopVehicle);
                InputKey.VehicleRocket = Utils.ParseKey(ini.GetValue(CONFIG_KEYS, CONFIG_KEYS_VEHICLE_ROCKET), InputKey.VehicleRocket);

                // Player
                Feature.Player.Invincible = Utils.ParseBoolStr(ini.GetValue(CONFIG_PLAYER, CONFIG_PLAYER_INVINCIBLE)); 
                Feature.Player.InfiniteAbility = Utils.ParseBoolStr(ini.GetValue(CONFIG_PLAYER, CONFIG_PLAYER_INFINITE_ABILITY));
                Feature.Player.InfiniteStamina = Utils.ParseBoolStr(ini.GetValue(CONFIG_PLAYER, CONFIG_PLAYER_INFINITE_STAMINA));
                Feature.Player.SuperJump = Utils.ParseBoolStr(ini.GetValue(CONFIG_PLAYER, CONFIG_PLAYER_SUPER_JUMP)); 
                Feature.Player.Noiseless = Utils.ParseBoolStr(ini.GetValue(CONFIG_PLAYER, CONFIG_PLAYER_NOISELESS)); 
                Feature.Player.Wanted.NeverWanted = Utils.ParseBoolStr(ini.GetValue(CONFIG_PLAYER, CONFIG_PLAYER_NEVER_WANTED)); 
                Feature.Player.Wanted.EveryoneIgnored = Utils.ParseBoolStr(ini.GetValue(CONFIG_PLAYER, CONFIG_PLAYER_EVERYONE_IGNORED)); 

                // Location
                Feature.Location.ShowCoordinates = Utils.ParseBoolStr(ini.GetValue(CONFIG_LOCATION, CONFIG_LOCATION_SHOW_COORDINATES)); 
                Location.LoadCustomLocations();

                // Vehicle
                Feature.Vehicle.Invincible = Utils.ParseBoolStr(ini.GetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_INVINCIBLE));
                Feature.Vehicle.InfiniteStamina = Utils.ParseBoolStr(ini.GetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_INFINITE_STAMINA));
                Feature.Vehicle.SpawnIntoVehicle = Utils.ParseBoolStr(ini.GetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_SPAWN_INTO));
                Feature.Vehicle.SpeedMeter.Show = Utils.ParseBoolStr(ini.GetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_SPEEDMETER_SHOW));
                Feature.Vehicle.SpeedMeter.ShowInMetric = Utils.ParseBoolStr(ini.GetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_SPEEDMETER_SHOW_IN_METRIC));
                Feature.Vehicle.SpeedMeter.ShowWithoutVehicle = Utils.ParseBoolStr(ini.GetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_SPEEDMETER_SHOW_WITHOUT_VEHICLE));
                Feature.Vehicle.VehicleBoost.BoostProgressive = Utils.ParseBoolStr(ini.GetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_BOOST_PROGRESSIVE));
                Feature.Vehicle.VehicleBoost.BoostProgressiveSpeedInc = Utils.ParseFloat(ini.GetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_BOOST_PROGRESSIVE_SPEED_INC), Feature.Vehicle.VehicleBoost.BoostProgressiveSpeedInc);
                Feature.Vehicle.VehicleBoost.BoostInstant = Utils.ParseBoolStr(ini.GetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_BOOST_INSTANT));
                Feature.Vehicle.VehicleBoost.BoostInstantSpeed = Utils.ParseFloat(ini.GetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_BOOST_INSTANT_SPEED), Feature.Vehicle.VehicleBoost.BoostInstantSpeed);

                // Weapon
                Feature.Weapon.InfiniteAmmo = Utils.ParseBoolStr(ini.GetValue(CONFIG_WEAPON, CONFIG_WEAPON_INFINITE_AMMO));
                Feature.Weapon.DamageMultiplierIndex = Utils.ParseInt(ini.GetValue(CONFIG_WEAPON, CONFIG_WEAPON_DAMAGE_MULTIPLIER_INDEX), Feature.Weapon.DamageMultiplierIndex);

                // Time
                Feature.DateTimeSpeed.ShowTime = Utils.ParseBoolStr(ini.GetValue(CONFIG_TIME, CONFIG_TIME_SHOW_TIME));
                Feature.DateTimeSpeed.Paused = Utils.ParseBoolStr(ini.GetValue(CONFIG_TIME, CONFIG_TIME_PAUSED));
                Feature.DateTimeSpeed.SyncWithSystem = Utils.ParseBoolStr(ini.GetValue(CONFIG_TIME, CONFIG_TIME_SYNC_WITH_SYSTEM));
                Feature.DateTimeSpeed.AimingSpeed = Utils.ParseFloat(ini.GetValue(CONFIG_TIME, CONFIG_AIMING_SPEED), Feature.DateTimeSpeed.AimingSpeed);
                Feature.DateTimeSpeed.SetUseRealTimeScale(Utils.ParseBoolStr(ini.GetValue(CONFIG_TIME, CONFIG_TIME_USE_REAL_TIME_SCALE)));

                // Weather
                Feature.Weather.Wind = Utils.ParseBoolStr(ini.GetValue(CONFIG_WEATHER, CONFIG_WEATHER_WIND));
                Feature.Weather.Freeze = Utils.ParseBoolStr(ini.GetValue(CONFIG_WEATHER, CONFIG_WEATHER_FREEZE));

                // Misc
                //Feature.Misc.PortableRadio = Utils.ParseBoolStr(ini.GetValue(CONFIG_MISC, CONFIG_MISC_PORTABLE_RADIO));
                Feature.Misc.HideHud = Utils.ParseBoolStr(ini.GetValue(CONFIG_MISC, CONFIG_MISC_HIDE_HUD));

                // Language
                Trainer.LanguageCode = ini.GetValue(CONFIG_LANGUAGE, CONFIG_LANGUAGE_VALUE) ?? Trainer.LanguageCode;

                Utils.ShowNotification(GlobalConst.Message.CONFIGURATION_LOADED);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Save configurations
        /// </summary> 
        public static void Save(bool showNotification = true)
        {
            if (File.Exists(CONFIG_FILE))
            {
                File.Delete(CONFIG_FILE);
            }

            try
            {
                IniFile ini = new IniFile(CONFIG_FILE);

                // Trainer
                ini.SetValue(CONFIG_TRAINER, CONFIG_TRAINER_AUTO_SAVE, Feature.Config.AutoSave.ToString());

                // Keys
                ini.SetValue(CONFIG_KEYS, CONFIG_KEYS_STOP_VEHICLE, Enum.GetName(typeof(Keys), InputKey.StopVehicle));
                ini.SetValue(CONFIG_KEYS, CONFIG_KEYS_BOOST_VEHICLE, Enum.GetName(typeof(Keys), InputKey.BoostVehicleProgressive));
                ini.SetValue(CONFIG_KEYS, CONFIG_KEYS_BOOST_VEHICLE_INSTANT, Enum.GetName(typeof(Keys), InputKey.BoostVehicleInstant));
                ini.SetValue(CONFIG_KEYS, CONFIG_KEYS_MENU_BACK, Enum.GetName(typeof(Keys), InputKey.MenuBack));
                ini.SetValue(CONFIG_KEYS, CONFIG_KEYS_MENU_DOWN, Enum.GetName(typeof(Keys), InputKey.MenuDown));
                ini.SetValue(CONFIG_KEYS, CONFIG_KEYS_MENU_LEFT, Enum.GetName(typeof(Keys), InputKey.MenuLeft));
                ini.SetValue(CONFIG_KEYS, CONFIG_KEYS_MENU_RIGHT, Enum.GetName(typeof(Keys), InputKey.MenuRight));
                ini.SetValue(CONFIG_KEYS, CONFIG_KEYS_MENU_SELECT, Enum.GetName(typeof(Keys), InputKey.MenuSelect));
                ini.SetValue(CONFIG_KEYS, CONFIG_KEYS_MENU_UP, Enum.GetName(typeof(Keys), InputKey.MenuUp));
                ini.SetValue(CONFIG_KEYS, CONFIG_KEYS_TOGGLE_MENU, Enum.GetName(typeof(Keys), InputKey.ToggleMenu));
                ini.SetValue(CONFIG_KEYS, CONFIG_KEYS_VEHICLE_ROCKET, Enum.GetName(typeof(Keys), InputKey.VehicleRocket));

                // Player
                ini.SetValue(CONFIG_PLAYER, CONFIG_PLAYER_INVINCIBLE, Feature.Player.Invincible.ToString());
                ini.SetValue(CONFIG_PLAYER, CONFIG_PLAYER_INFINITE_ABILITY, Feature.Player.InfiniteAbility.ToString());
                ini.SetValue(CONFIG_PLAYER, CONFIG_PLAYER_INFINITE_STAMINA, Feature.Player.InfiniteStamina.ToString());
                ini.SetValue(CONFIG_PLAYER, CONFIG_PLAYER_SUPER_JUMP, Feature.Player.SuperJump.ToString());
                ini.SetValue(CONFIG_PLAYER, CONFIG_PLAYER_NOISELESS, Feature.Player.Noiseless.ToString());
                ini.SetValue(CONFIG_PLAYER, CONFIG_PLAYER_NEVER_WANTED, Feature.Player.Wanted.NeverWanted.ToString());
                ini.SetValue(CONFIG_PLAYER, CONFIG_PLAYER_EVERYONE_IGNORED, Feature.Player.Wanted.EveryoneIgnored.ToString());

                // Location
                ini.SetValue(CONFIG_LOCATION, CONFIG_LOCATION_SHOW_COORDINATES, Feature.Location.ShowCoordinates.ToString());

                // Vehicle
                ini.SetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_INVINCIBLE, Feature.Vehicle.Invincible.ToString());
                ini.SetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_INFINITE_STAMINA, Feature.Vehicle.InfiniteStamina.ToString());
                ini.SetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_SPAWN_INTO, Feature.Vehicle.SpawnIntoVehicle.ToString());
                ini.SetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_SPEEDMETER_SHOW, Feature.Vehicle.SpeedMeter.Show.ToString());
                ini.SetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_SPEEDMETER_SHOW_IN_METRIC, Feature.Vehicle.SpeedMeter.ShowInMetric.ToString());
                ini.SetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_SPEEDMETER_SHOW_WITHOUT_VEHICLE, Feature.Vehicle.SpeedMeter.ShowWithoutVehicle.ToString());
                ini.SetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_BOOST_PROGRESSIVE, Feature.Vehicle.VehicleBoost.BoostProgressive.ToString());
                ini.SetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_BOOST_PROGRESSIVE_SPEED_INC, Feature.Vehicle.VehicleBoost.BoostProgressiveSpeedInc.ToString());
                ini.SetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_BOOST_INSTANT, Feature.Vehicle.VehicleBoost.BoostInstant.ToString());
                ini.SetValue(CONFIG_VEHICLE, CONFIG_VEHICLE_BOOST_INSTANT_SPEED, Feature.Vehicle.VehicleBoost.BoostInstantSpeed.ToString());

                // Weapon
                ini.SetValue(CONFIG_WEAPON, CONFIG_WEAPON_INFINITE_AMMO, Feature.Weapon.InfiniteAmmo.ToString());
                ini.SetValue(CONFIG_WEAPON, CONFIG_WEAPON_DAMAGE_MULTIPLIER_INDEX, Feature.Weapon.DamageMultiplierIndex.ToString());

                // Time
                ini.SetValue(CONFIG_TIME, CONFIG_TIME_SHOW_TIME, Feature.DateTimeSpeed.ShowTime.ToString());
                ini.SetValue(CONFIG_TIME, CONFIG_TIME_PAUSED, Feature.DateTimeSpeed.Paused.ToString());
                ini.SetValue(CONFIG_TIME, CONFIG_TIME_SYNC_WITH_SYSTEM, Feature.DateTimeSpeed.SyncWithSystem.ToString());
                ini.SetValue(CONFIG_TIME, CONFIG_TIME_USE_REAL_TIME_SCALE, Feature.DateTimeSpeed.UseRealTimeScale.ToString());
                ini.SetValue(CONFIG_TIME, CONFIG_AIMING_SPEED, Feature.DateTimeSpeed.AimingSpeed.ToString());

                // Misc
                ini.SetValue(CONFIG_MISC, CONFIG_MISC_HIDE_HUD, Feature.Misc.HideHud.ToString());

                // Language
                ini.SetValue(CONFIG_LANGUAGE, CONFIG_LANGUAGE_VALUE, Trainer.LanguageCode.ToString());

                ini.Save();

                if (showNotification) Utils.ShowNotification(GlobalConst.Message.CONFIGURATION_SAVED);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Location configurations
        /// </summary>
        public static class Location
        {
            private const string CONFIG_FILE_CUSTOM_LOCATIONS = ".\\scripts\\BETrainerRdr2_CustomLocations.ini";

            private const string CONFIG_CL = "CustomLocations";
            private const string CONFIG_CL_COUNT = "Count";
            private const string CONFIG_CL_ENTRY = "{0:000}";

            /// <summary>
            /// Custom locations
            /// </summary>
            public static List<SimpleTeleportTarget> Targets = null;

            /// <summary>
            /// Saves custom locations
            /// </summary>
            public static void SaveCustomLocations()
            {
                if (File.Exists(CONFIG_FILE_CUSTOM_LOCATIONS)) File.Delete(CONFIG_FILE_CUSTOM_LOCATIONS);
                if (Targets == null || Targets.Count == 0) return;

                IniFile ini = new IniFile(CONFIG_FILE_CUSTOM_LOCATIONS);

                ini.SetValue(CONFIG_CL, CONFIG_CL_COUNT, Targets.Count.ToString());
                for (int i = 0; i < Targets.Count; i++)
                {
                    ini.SetValue(CONFIG_CL, Utils.FormatML(CONFIG_CL_ENTRY, i + 1), Targets[i].Serialize());
                }

                ini.Save();
            }

            /// <summary>
            /// Loads all custom locations
            /// </summary>
            public static void LoadCustomLocations()
            {
                Targets = new List<SimpleTeleportTarget>();
                if (!File.Exists(CONFIG_FILE_CUSTOM_LOCATIONS)) return;

                IniFile ini = new IniFile(CONFIG_FILE_CUSTOM_LOCATIONS);

                int count = Utils.ParseInt(ini.GetValue(CONFIG_CL, CONFIG_CL_COUNT));
                if (count <= 0) return;

                Targets.Capacity = count;

                for (int i = 0; i < count; i++)
                {
                    SimpleTeleportTarget target = SimpleTeleportTarget.Deserialize(ini.GetValue(CONFIG_CL, Utils.FormatML(CONFIG_CL_ENTRY, i + 1)));
                    if (target != null) Targets.Add(target);
                }
                Targets.Sort();
            }
        }
    }
}
