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
        }

        /// <summary>
        /// Message text
        /// </summary>
        public static class Message
        {
            public static readonly MLString PLAYER_BOUNTY_CLEARED = new MLString("Player's bounty is cleared.");
            public static readonly MLString PLAYER_HEALED = Utils.CSML("Player healed.", "玩家已被治愈。");
            public static readonly MLString PLAYER_RESET_SKIN = Utils.CSML("Skin reset to default.", "皮肤已重置为默认。");
            public static readonly MLString PLAYER_MODEL_SET = Utils.CSML("Model set to {0}.", "模型更改为“{0}”。");
            public static readonly MLString PLAYER_RANDOM_SKIN = Utils.CSML("Skin ranomized.", "皮肤已随机。");
            public static readonly MLString PLAYER_RANDOM_PROPS = Utils.CSML("Props ranomized.", "饰品已随机。");
            public static readonly MLString PLAYER_INVALID_NAME = Utils.CSML("Invalid name.", "非法名称。");
            public static readonly MLString PLAYER_MSPCS_APPLIED = Utils.CSML("MSP custom set applied.", "外观方案已应用。");
            public static readonly MLString PLAYER_MSPCS_CREATED = Utils.CSML("MSP custom set created.", "外观方案已创建。");
            public static readonly MLString PLAYER_MSPCS_DELETED = Utils.CSML("MSP custom set deleted.", "外观方案已删除。");
            public static readonly MLString PLAYER_MSPCS_RENAMED = Utils.CSML("MSP custom set renamed.", "外观方案已重命名。");
            public static readonly MLString PLAYER_MSPCS_OVERWRITTEN = Utils.CSML("MSP custom set overwritten.", "外观方案已覆盖。");

            public static readonly MLString TP_NO_MAP_MARKER_FOUND = Utils.CSML("No map marker found.", "未找到地图标记。");
            public static readonly MLString TP_MAP_MARKER = Utils.CSML("Teleported to map marker.", "已传送到地图标记。");
            public static readonly MLString TP_TARGET = Utils.CSML("Teleported to target location.", "已传送到目标地点。");
            public static readonly MLString TP_SCENERY_LOADED = Utils.CSML("Scenery loaded.", "场景已加载。");
            public static readonly MLString TP_SCENERY_UNLOADED = Utils.CSML("Scenery unloaded.", "场景已卸除。");

            public static readonly MLString CL_SAVED = Utils.CSML("Custom location saved.", "自定义地点已保存。");
            public static readonly MLString CL_TELEPORTED = Utils.CSML("Teleported to custom location.", "已传送到自定义地点。");
            public static readonly MLString CL_RENAMED = Utils.CSML("Custom location renamed.", "自定义地点已重命名。");
            public static readonly MLString CL_OVERWRITTEN = Utils.CSML("Custom location overwritten.", "自定义地点已覆盖。");
            public static readonly MLString CL_DELETED = Utils.CSML("Custom location deleted.", "自定义地点已删除。");

            public static readonly MLString XYZ_TELEPORTED = Utils.CSML("Teleported.", "已传送。");
            public static readonly MLString XYZ_RANDOM_TELEPORTED = Utils.CSML("Teleported to a random location.", "已传送到随机地点。");

            public static readonly MLString VEHICLE_NOT_MOUNTED = Utils.CSML("Player isn't mounted.", "玩家未骑马。");
            public static readonly MLString VEHICLE_NOT_IN_VEHICLE = Utils.CSML("Player isn't in a vehicle.", "玩家没有在载具内。");
            public static readonly MLString VEHICLE_SPAWNED = Utils.CSML("{0} spawned.", "“{0}”已生成。");
            public static readonly MLString VEHICLE_REPAIRED = Utils.CSML("Vehicle repaired.", "载具已修复。");
            public static readonly MLString VEHICLE_CLEANED = Utils.CSML("Vehicle cleaned.", "载具已清洁。");

            public static readonly MLString MODEL_SPAWNED = "{0} spawned.";

            public static readonly MLString VP_NO_PEARL = Utils.CSML("Pearl topcoat can't be applied to current paint type.", "当前喷漆种类无法应用高亮层");
            public static readonly MLString VP_NO_WHEEL = Utils.CSML("Can't change the color of the default wheel.", "默认轮胎无法更改颜色。");

            public static readonly MLString VM_ALL_PERFORMANCE = Utils.CSML("Applied all performance upgrades.", "所有性能项目已升级。");
            public static readonly MLString VM_ALL_ARMOR = Utils.CSML("Applied all armor upgrades.", "所有护甲项目已升级。");
            public static readonly MLString VM_REMOVE_ALL = Utils.CSML("Removed all upgrades.", "已移除所有升级项目。");
            public static readonly MLString VM_APPLIED = Utils.CSML("{0} applied.", "“{0}”已应用。");
            public static readonly MLString VM_WINDOW_TINT_CHANGED = Utils.CSML("Window tint changed.", "窗户贴膜颜色已更改。");
            public static readonly MLString VM_LICENSE_PLATE_CHANGED = Utils.CSML("License plate changed.", "车牌号已更改。");
            public static readonly MLString VM_WHEEL_CATEGORY_CHANGED = Utils.CSML("Wheel category changed.", "轮子种类已更改。");
            public static readonly MLString VM_WHEELS_CHANGED = Utils.CSML("Wheels changed.", "轮子已更改。");
            public static readonly MLString VM_TYRES_CHANGED = Utils.CSML("Tyres changed.", "轮胎已更改。");

            public static readonly MLString CV_SPAWN = Utils.CSML("Custom vehicle spawned.", "自定义载具已生成。");
            public static readonly MLString CV_SAVED = Utils.CSML("Custom vehicle saved.", "自定义载具已保存。");
            public static readonly MLString CV_RENAMED = Utils.CSML("Custom vehicle renamed.", "自定义载具已重命名。");
            public static readonly MLString CV_OVERWRITTEN = Utils.CSML("Custom vehicle overwritten.", "自定义载具已覆盖。");
            public static readonly MLString CV_DELETED = Utils.CSML("Custom vehicle deleted.", "自定义载具已删除。");
            public static readonly MLString CV_CV = Utils.CSML("Custom vehicle", "自定义载具");
            public static readonly MLString CV_SPAWN_FAILED = Utils.CSML("Custom vehicle spawn failed.", "生成自定义载具失败。");

            public static readonly MLString WEAPON_ALL = Utils.CSML("All weapons acquired.", "已获得所有武器。");

            public static readonly MLString WEATHER_SET = Utils.CSML("Weather set to {0}.", "天气已更改为“{0}”。");

            public static readonly MLString TRAINER_INITIALIZING = Utils.CSML(TRAINER_NAME + " " + TRAINER_VERSION + " initializing...", TRAINER_NAME + " " + TRAINER_VERSION + " 初始化中...");
            public static readonly MLString TRAINER_INITIALIZED = Utils.CSML(TRAINER_NAME + " " + TRAINER_VERSION + " initializing...", TRAINER_NAME + " " + TRAINER_VERSION + " 初始化完成。");

            public static readonly MLString CONFIGURATION_CREATING = Utils.CSML("Configuration not found, creating a new one...", "未发现配置文件，生成中...");
            public static readonly MLString CONFIGURATION_SAVED = Utils.CSML("Configuration saved.", "配置文件已保存。");
            public static readonly MLString CONFIGURATION_LOADED = Utils.CSML("Configuration loaded.", "配置文件已加载。");
            public static readonly MLString CONFIGURATION_MSPCS_SAVED = Utils.CSML("MSP custom sets saved.", "外观方案已保存。");

            public static readonly MLString MAP_REVEALED = "Map is revealed.";
        }
    }
}
