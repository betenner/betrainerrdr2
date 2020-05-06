///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

namespace BETrainerRdr2
{
    /// <summary>
    /// Global constants & enumerations
    /// </summary>
    public static class GlobalConst
    {
        /// <summary>
        /// Horizental alignment
        /// </summary>
        public enum HAlignment
        {
            Left,
            Center,
        }

        /// <summary>
        /// Trainer name
        /// </summary>
        public const string TRAINER_NAME = "RDR2 BE Trainer.NET";

        /// <summary>
        /// Trainer version
        /// </summary>
        public const string TRAINER_VERSION = "v1.00";

        /// <summary>
        /// Default screen width
        /// </summary>
        public const int DEFAULT_SCREEN_WIDTH = 1920;

        /// <summary>
        /// Default screen height
        /// </summary>
        public const int DEFAULT_SCREEN_HEIGHT = 1080;

        /// <summary>
        /// Comma replacement in serialization
        /// </summary>
        public const string SERIALIZATION_COMMA_REPLACEMENT = "#_C_#";

        /// <summary>
        /// Comma in serializtion
        /// </summary>
        public const string SERIALIZATION_COMMA = ",";

        /// <summary>
        /// Custom function hashes
        /// </summary>
        public static class CustomHash
        {
            public const ulong RESTORE_SPECIAL_ABILITY = 0x1D77B47AFA584E90;
            public const ulong FREEZE_WEATHER = 0xD74ACDF7DB8114AF;
            public const ulong DRAW_TEXT = 0xD79334A4BB99BAD1;
            public const ulong CREATE_STRING = 0xFA925AC00EB830B9;
            public const ulong CLEAR_CURRENT_PURSUIT = 0x55F37F5F3F2475E1;
            public const ulong SET_PLAYER_PRICE_ON_A_HEAD = 0x093A9D1F72DF0D19;
            public const ulong SET_MINIMAP_REVEALED = 0x4B8F743A4A6D2FF8;
            public const ulong REVEAL_MAP = 0xF8096DF9B87246E3;
            public const ulong SET_PED_VISIBLE = 0x283978A15512B2FE;
            public const ulong SET_PED_STAMINA = 0x675680D089BFA21F;
        }

        /// <summary>
        /// Message text
        /// </summary>
        public static class Message
        {
            public static readonly MLString PLAYER_BOUNTY_CLEARED = new MLString("Player's bounty is cleared.");
            public static readonly MLString PLAYER_HEALED = "Player healed.";
            public static readonly MLString PLAYER_RESET_SKIN = "Skin reset to default.";
            public static readonly MLString PLAYER_MODEL_SET = "Model set to {0}.";
            public static readonly MLString PLAYER_RANDOM_SKIN = "Skin ranomized.";
            public static readonly MLString PLAYER_RANDOM_PROPS = "Props ranomized.";
            public static readonly MLString PLAYER_INVALID_NAME = "Invalid name.";
            public static readonly MLString PLAYER_MSPCS_APPLIED = "MSP custom set applied.";
            public static readonly MLString PLAYER_MSPCS_CREATED = "MSP custom set created.";
            public static readonly MLString PLAYER_MSPCS_DELETED = "MSP custom set deleted.";
            public static readonly MLString PLAYER_MSPCS_RENAMED = "MSP custom set renamed.";
            public static readonly MLString PLAYER_MSPCS_OVERWRITTEN = "MSP custom set overwritten.";

            public static readonly MLString TP_NO_MAP_MARKER_FOUND = "No map marker found.";
            public static readonly MLString TP_MAP_MARKER = "Teleported to map marker.";
            public static readonly MLString TP_TARGET = "Teleported to target location.";
            public static readonly MLString TP_SCENERY_LOADED = "Scenery loaded.";
            public static readonly MLString TP_SCENERY_UNLOADED = "Scenery unloaded.";

            public static readonly MLString CL_SAVED = "Custom location saved.";
            public static readonly MLString CL_TELEPORTED = "Teleported to custom location.";
            public static readonly MLString CL_RENAMED = "Custom location renamed.";
            public static readonly MLString CL_OVERWRITTEN = "Custom location overwritten.";
            public static readonly MLString CL_DELETED = "Custom location deleted.";

            public static readonly MLString XYZ_TELEPORTED = "Teleported.";
            public static readonly MLString XYZ_RANDOM_TELEPORTED = "Teleported to a random location.";

            public static readonly MLString VEHICLE_NOT_MOUNTED = "Player isn't mounted.";
            public static readonly MLString VEHICLE_NOT_IN_VEHICLE = "Player isn't in a vehicle.";
            public static readonly MLString VEHICLE_SPAWNED = "{0} spawned.";
            public static readonly MLString VEHICLE_REPAIRED = "Vehicle repaired.";
            public static readonly MLString VEHICLE_CLEANED = "Vehicle cleaned.";

            public static readonly MLString MODEL_SPAWNED = "{0} spawned.";

            public static readonly MLString VP_NO_PEARL = "Pearl topcoat can't be applied to current paint type.";
            public static readonly MLString VP_NO_WHEEL = "Can't change the color of the default wheel.";

            public static readonly MLString VM_ALL_PERFORMANCE = "Applied all performance upgrades.";
            public static readonly MLString VM_ALL_ARMOR = "Applied all armor upgrades.";
            public static readonly MLString VM_REMOVE_ALL = "Removed all upgrades.";
            public static readonly MLString VM_APPLIED = "{0} applied.";
            public static readonly MLString VM_WINDOW_TINT_CHANGED = "Window tint changed.";
            public static readonly MLString VM_LICENSE_PLATE_CHANGED = "License plate changed.";
            public static readonly MLString VM_WHEEL_CATEGORY_CHANGED = "Wheel category changed.";
            public static readonly MLString VM_WHEELS_CHANGED = "Wheels changed.";
            public static readonly MLString VM_TYRES_CHANGED = "Tyres changed.";

            public static readonly MLString CV_SPAWN = "Custom vehicle spawned.";
            public static readonly MLString CV_SAVED = "Custom vehicle saved.";
            public static readonly MLString CV_RENAMED = "Custom vehicle renamed.";
            public static readonly MLString CV_OVERWRITTEN = "Custom vehicle overwritten.";
            public static readonly MLString CV_DELETED = "Custom vehicle deleted.";
            public static readonly MLString CV_CV = "Custom vehicle";
            public static readonly MLString CV_SPAWN_FAILED = "Custom vehicle spawn failed.";

            public static readonly MLString WEAPON_ALL = "All weapons acquired.";

            public static readonly MLString WEATHER_SET = "Weather set to {0}.";

            public static readonly MLString TRAINER_INITIALIZING = TRAINER_NAME + " " + TRAINER_VERSION + " initializing...";
            public static readonly MLString TRAINER_INITIALIZED = TRAINER_NAME + " " + TRAINER_VERSION + " initializing...";

            public static readonly MLString CONFIGURATION_CREATING = "Configuration not found, creating a new one...";
            public static readonly MLString CONFIGURATION_SAVED = "Configuration saved.";
            public static readonly MLString CONFIGURATION_LOADED = "Configuration loaded.";
            public static readonly MLString CONFIGURATION_MSPCS_SAVED = "MSP custom sets saved.";

            public static readonly MLString MAP_REVEALED = "Map is revealed.";
        }
    }
}
