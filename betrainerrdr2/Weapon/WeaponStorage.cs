﻿///////////////////////////////////////////////
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
    /// Weapon storage
    /// </summary>
    public static class WeaponStorage
    {
        public static readonly WeaponData[] WEAPONS = new WeaponData[]
        {
            new WeaponData("LASSO", "WEAPON_LASSO"),
            new WeaponData("FISHINGROD", "WEAPON_FISHINGROD"),
            new WeaponData("MOONSHINEJUG", "WEAPON_MOONSHINEJUG"),
            new WeaponData("CLEAVER", "WEAPON_MELEE_CLEAVER"),
            new WeaponData("HATCHET", "WEAPON_MELEE_HATCHET"),
            new WeaponData("KNIFE", "WEAPON_MELEE_KNIFE"),
            new WeaponData("MACHETE", "WEAPON_MELEE_MACHETE"),
            new WeaponData("TORCH", "WEAPON_MELEE_TORCH"),
            new WeaponData("LANTERN", "WEAPON_MELEE_LANTERN"),
            new WeaponData("DAVY LANTERN", "WEAPON_MELEE_DAVY_LANTERN"),
            new WeaponData("LANTERN ELECTRIC", "WEAPON_MELEE_LANTERN_ELECTRIC"),
            new WeaponData("BROKEN SWORD", "WEAPON_MELEE_BROKEN_SWORD"),
            new WeaponData("KNIFE CIVIL WAR", "WEAPON_MELEE_KNIFE_CIVIL_WAR"),
            new WeaponData("ANCIENT HATCHET", "WEAPON_MELEE_ANCIENT_HATCHET"),
            new WeaponData("CATTLEMAN", "WEAPON_REVOLVER_CATTLEMAN"),
            new WeaponData("DOUBLEACTION", "WEAPON_REVOLVER_DOUBLEACTION"),
            new WeaponData("SCHOFIELD", "WEAPON_REVOLVER_SCHOFIELD"),
            new WeaponData("VOLCANIC", "WEAPON_PISTOL_VOLCANIC"),
            new WeaponData("MAUSER", "WEAPON_PISTOL_MAUSER"),
            new WeaponData("SEMIAUTO", "WEAPON_PISTOL_SEMIAUTO"),
            new WeaponData("CARBINE", "WEAPON_REPEATER_CARBINE"),
            new WeaponData("WINCHESTER", "WEAPON_REPEATER_WINCHESTER"),
            new WeaponData("HENRY", "WEAPON_REPEATER_HENRY"),
            new WeaponData("SPRINGFIELD", "WEAPON_RIFLE_SPRINGFIELD"),
            new WeaponData("BOLTACTION", "WEAPON_RIFLE_BOLTACTION"),
            new WeaponData("VARMINT", "WEAPON_RIFLE_VARMINT"),
            new WeaponData("DOUBLEBARREL", "WEAPON_SHOTGUN_DOUBLEBARREL"),
            new WeaponData("SAWEDOFF", "WEAPON_SHOTGUN_SAWEDOFF"),
            new WeaponData("SEMIAUTO", "WEAPON_SHOTGUN_SEMIAUTO"),
            new WeaponData("REPEATING", "WEAPON_SHOTGUN_REPEATING"),
            new WeaponData("PUMP", "WEAPON_SHOTGUN_PUMP"),
            new WeaponData("CARCANO", "WEAPON_SNIPERRIFLE_CARCANO"),
            new WeaponData("ROLLINGBLOCK", "WEAPON_SNIPERRIFLE_ROLLINGBLOCK"),
            new WeaponData("BOW", "WEAPON_BOW"),
            new WeaponData("DYNAMITE", "WEAPON_THROWN_DYNAMITE"),
            new WeaponData("DYNAMITE VOLATILE", "WEAPON_THROWN_DYNAMITE_VOLATILE"),
            new WeaponData("MOLOTOV", "WEAPON_THROWN_MOLOTOV"),
            new WeaponData("MOLOTOV VOLATILE", "WEAPON_THROWN_MOLOTOV_VOLATILE"),
            new WeaponData("THROWING KNIVES", "WEAPON_THROWN_THROWING_KNIVES"),
            new WeaponData("TOMAHAWK", "WEAPON_THROWN_TOMAHAWK"),
            new WeaponData("BINOCULARS", "WEAPON_KIT_BINOCULARS"),
            new WeaponData("CAMERA", "WEAPON_KIT_CAMERA"),
        };

        ///// <summary>
        ///// Weapon tints
        ///// </summary>
        //public enum WeaponTint
        //{
        //    Normal = 0,
        //    Green = 1,
        //    Gold = 2,
        //    Pink = 3,
        //    Army = 4,
        //    LSPD = 5,
        //    Orange = 6,
        //    Platinum = 7,
        //}

        ///// <summary>
        ///// Weapon categories
        ///// </summary>
        //public enum WeaponCategory
        //{
        //    Melee = 0,
        //    Handguns = 1,
        //    SubmachineGuns = 2,
        //    AssaultRifles = 3,
        //    Shotguns = 4,
        //    SniperRifles = 5,
        //    HeavyWeapons = 6,
        //    ThrownWeapons = 7,
        //}

        //public const int PARACHUTE_HASH = -72657034;
        //public const int WEAPON_CATEGORY_COUNT = 8;
        //public const int TOTAL_WEAPONS_COUNT = 54;
        //public const int TOTAL_WEAPONS_SLOTS = 57;
        //public const int MAX_ATTACHMENT_SLOTS = 15;
        //public const string WEAPON_UNARMED = "WEAPON_UNARMED";

        //public static readonly MLString[] WEAPON_CATEGORY_NAMES = 
        //{ 
        //    Utils.CSML("Melee", "近戰武器"), 
        //    Utils.CSML("Handguns", "手槍"), 
        //    Utils.CSML("Submachine Guns", "機關槍"), 
        //    Utils.CSML("Assault Rifles", "衝鋒槍"), 
        //    Utils.CSML("Shotguns", "散彈槍"), 
        //    Utils.CSML("Sniper Rifles", "阻擊槍"), 
        //    Utils.CSML("Heavy Weapons", "重型武器"), 
        //    Utils.CSML("Thrown Weapons", "投擲武器"), 
        //};

        //public static readonly WeaponData[][] WEAPONS = 
        //{
        //    // Melee
        //    new WeaponData[]
        //    {
        //        new WeaponData("Knife", "WEAPON_KNIFE", false),
        //        new WeaponData("Nightstick", "WEAPON_NIGHTSTICK", false),
        //        new WeaponData("Hammer", "WEAPON_HAMMER", false),
        //        new WeaponData("Baseball Bat", "WEAPON_BAT", false),
        //        new WeaponData("Golf Club", "WEAPON_GOLFCLUB", false),
        //        new WeaponData("Crowbar", "WEAPON_CROWBAR", false),
        //        new WeaponData("Bottle", "WEAPON_BOTTLE", false),
        //        new WeaponData("Antique Dagger", "WEAPON_DAGGER", false),
        //        new WeaponData("Hatchet", "WEAPON_HATCHET", false),
        //    },

        //    // Handguns
        //    new WeaponData[]
        //    {
        //        new WeaponData("Pistol", "WEAPON_PISTOL", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_PISTOL_CLIP_02"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_PI_SUPP_02"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_PI_FLSH"),
        //            new WeaponAttachmentData("Yusuf Amir Luxury Finish", "COMPONENT_PISTOL_VARMOD_LUXE")),
        //        new WeaponData("Combat Pistol", "WEAPON_COMBATPISTOL", true, 
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_COMBATPISTOL_CLIP_02"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_PI_SUPP"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_PI_FLSH")),
        //        new WeaponData("AP Pistol", "WEAPON_APPISTOL", true, 
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_APPISTOL_CLIP_02"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_PI_SUPP"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_PI_FLSH"),
        //            new WeaponAttachmentData("Gilded Gun Metal Finish", "COMPONENT_APPISTOL_VARMOD_LUXE")),
        //        new WeaponData("Pistol .50", "WEAPON_PISTOL50", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_PISTOL50_CLIP_02"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_AR_SUPP_02"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_PI_FLSH"),
        //            new WeaponAttachmentData("Platinum Pearl Deluxe Finish", "COMPONENT_PISTOL50_VARMOD_LUXE")),
        //        new WeaponData("SNS Pistol", "WEAPON_SNSPISTOL", true, 
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_SNSPISTOL_CLIP_02")),
        //        new WeaponData("Heavy Pistol", "WEAPON_HEAVYPISTOL", true, 
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_HEAVYPISTOL_CLIP_02"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_PI_SUPP"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_PI_FLSH"),
        //            new WeaponAttachmentData("Etched Wood Grip Finish", "COMPONENT_HEAVYPISTOL_VARMOD_LUXE")),
        //        new WeaponData("Vintage Pistol", "WEAPON_VINTAGEPISTOL", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_VINTAGEPISTOL_CLIP_02"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_PI_SUPP")),
        //        new WeaponData("Stun Gun", "WEAPON_STUNGUN"),
        //        new WeaponData("Flare Gun", "WEAPON_FLAREGUN"),
        //    },

        //    // Submachine Guns
        //    new WeaponData[]
        //    {
        //        new WeaponData("Micro SMG", "WEAPON_MICROSMG", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_MICROSMG_CLIP_02"),
        //            new WeaponAttachmentData("Scope", "COMPONENT_AT_SCOPE_MACRO"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_AR_SUPP_02"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_PI_FLSH"),
        //            new WeaponAttachmentData("Yusuf Amir Luxury Finish", "COMPONENT_MICROSMG_VARMOD_LUXE")),
        //        new WeaponData("SMG", "WEAPON_SMG", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_SMG_CLIP_02"),
        //            new WeaponAttachmentData("Scope", "COMPONENT_AT_SCOPE_MACRO_02"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_PI_SUPP"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_AR_FLSH"),
        //            new WeaponAttachmentData("Yusuf Amir Luxury Finish", "COMPONENT_SMG_VARMOD_LUXE")),
        //        new WeaponData("Assault SMG", "WEAPON_ASSAULTSMG", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_ASSAULTSMG_CLIP_02"),
        //            new WeaponAttachmentData("Scope", "COMPONENT_AT_SCOPE_MACRO"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_AR_SUPP_02"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_AR_FLSH")),
        //        new WeaponData("MG", "WEAPON_MG", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_MG_CLIP_02"),
        //            new WeaponAttachmentData("Scope", "COMPONENT_AT_SCOPE_SMALL_02")),
        //        new WeaponData("Combat MG", "WEAPON_COMBATMG", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_COMBATMG_CLIP_02"),
        //            new WeaponAttachmentData("Scope", "COMPONENT_AT_SCOPE_MEDIUM"),
        //            new WeaponAttachmentData("Grip", "COMPONENT_AT_AR_AFGRIP")),
        //        new WeaponData("Gusenberg Sweeper", "WEAPON_GUSENBERG", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_GUSENBERG_CLIP_02")),
        //        new WeaponData("Combat PDW", "WEAPON_COMBATPDW", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_COMBATPDW_CLIP_02"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_AR_FLSH"),
        //            new WeaponAttachmentData("Scope", "COMPONENT_AT_SCOPE_SMALL"),
        //            new WeaponAttachmentData("Grip", "COMPONENT_AT_AR_AFGRIP")),
        //    },

        //    // Assault Rifles
        //    new WeaponData[]
        //    {
        //        new WeaponData("Assault Rifle", "WEAPON_ASSAULTRIFLE", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_ASSAULTRIFLE_CLIP_02"),
        //            new WeaponAttachmentData("Scope", "COMPONENT_AT_SCOPE_MACRO"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_AR_SUPP_02"),
        //            new WeaponAttachmentData("Grip", "COMPONENT_AT_AR_AFGRIP"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_AR_FLSH"),
        //            new WeaponAttachmentData("Yusuf Amir Luxury Finish", "COMPONENT_ASSAULTRIFLE_VARMOD_LUXE")),
        //        new WeaponData("Carbine Rifle", "WEAPON_CARBINERIFLE", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_CARBINERIFLE_CLIP_02"),
        //            new WeaponAttachmentData("Scope", "COMPONENT_AT_SCOPE_MEDIUM"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_AR_SUPP"),
        //            new WeaponAttachmentData("Grip", "COMPONENT_AT_AR_AFGRIP"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_AR_FLSH"),
        //            new WeaponAttachmentData("Yusuf Amir Luxury Finish", "COMPONENT_CARBINERIFLE_VARMOD_LUXE")),
        //        new WeaponData("Advanced Rifle", "WEAPON_ADVANCEDRIFLE", true, 
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_ADVANCEDRIFLE_CLIP_02"),
        //            new WeaponAttachmentData("Scope", "COMPONENT_AT_SCOPE_SMALL"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_AR_SUPP"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_AR_FLSH"),
        //            new WeaponAttachmentData("Gilded Gun Metal Finish", "COMPONENT_ADVANCEDRIFLE_VARMOD_LUXE")),
        //        new WeaponData("Special Carbine", "WEAPON_SPECIALCARBINE", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_SPECIALCARBINE_CLIP_02"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_AR_FLSH"),
        //            new WeaponAttachmentData("Scope", "COMPONENT_AT_SCOPE_MEDIUM"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_AR_SUPP_02"),
        //            new WeaponAttachmentData("Grip", "COMPONENT_AT_AR_AFGRIP")),
        //        new WeaponData("Bullpup Rifle", "WEAPON_BULLPUPRIFLE", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_BULLPUPRIFLE_CLIP_02"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_AR_FLSH"),
        //            new WeaponAttachmentData("Scope", "COMPONENT_AT_SCOPE_SMALL"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_AR_SUPP"),
        //            new WeaponAttachmentData("Grip", "COMPONENT_AT_AR_AFGRIP")),
        //    },

        //    // Shotguns
        //    new WeaponData[]
        //    {
        //        new WeaponData("Pump Shotgun", "WEAPON_PUMPSHOTGUN", true,
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_SR_SUPP"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_AR_FLSH")),
        //        new WeaponData("Sawed-Off Shotgun", "WEAPON_SAWNOFFSHOTGUN", true,
        //            new WeaponAttachmentData("Gilded Gun Metal Finish", "COMPONENT_SAWNOFFSHOTGUN_VARMOD_LUXE")),
        //        new WeaponData("Bullpup Shotgun", "WEAPON_BULLPUPSHOTGUN", true,
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_AR_FLSH"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_AR_SUPP_02"),
        //            new WeaponAttachmentData("Grip", "COMPONENT_AT_AR_AFGRIP")),
        //        new WeaponData("Assault Shotgun", "WEAPON_ASSAULTSHOTGUN", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_ASSAULTSHOTGUN_CLIP_02"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_AR_SUPP"),
        //            new WeaponAttachmentData("Grip", "COMPONENT_AT_AR_AFGRIP")),
        //        new WeaponData("Musket", "WEAPON_MUSKET"),
        //        new WeaponData("Heavy Shotgun", "WEAPON_HEAVYSHOTGUN", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_HEAVYSHOTGUN_CLIP_02"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_AR_FLSH"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_AR_SUPP_02"),
        //            new WeaponAttachmentData("Grip", "COMPONENT_AT_AR_AFGRIP")),
        //    },

        //    // Sniper Rifles
        //    new WeaponData[]
        //    {
        //        new WeaponData("Sniper Rifle", "WEAPON_SNIPERRIFLE", true,
        //            new WeaponAttachmentData("Advanced Scope", "COMPONENT_AT_SCOPE_MAX"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_AR_SUPP_02"),
        //            new WeaponAttachmentData("Etched Wood Grip Finish", "COMPONENT_SNIPERRIFLE_VARMOD_LUXE")),
        //        new WeaponData("Heavy Sniper", "WEAPON_HEAVYSNIPER", true,
        //            new WeaponAttachmentData("Normal Scope", "COMPONENT_AT_SCOPE_LARGE")),
        //        new WeaponData("Marksman Rifle", "WEAPON_MARKSMANRIFLE", true,
        //            new WeaponAttachmentData("Extended Magazine", "COMPONENT_MARKSMANRIFLE_CLIP_02"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_AR_FLSH"),
        //            new WeaponAttachmentData("Suppressor", "COMPONENT_AT_AR_SUPP"),
        //            new WeaponAttachmentData("Grip", "COMPONENT_AT_AR_AFGRIP"),
        //            new WeaponAttachmentData("Yusuf Amir Luxury Finish", "COMPONENT_MARKSMANRIFLE_VARMOD_LUXE")),
        //    },

        //    // Heavy Weapons
        //    new WeaponData[]
        //    {
        //        new WeaponData("Grenade Launcher", "WEAPON_GRENADELAUNCHER", true,
        //            new WeaponAttachmentData("Scope", "COMPONENT_AT_SCOPE_SMALL"),
        //            new WeaponAttachmentData("Flashlight", "COMPONENT_AT_AR_FLSH"),
        //            new WeaponAttachmentData("Grip", "COMPONENT_AT_AR_AFGRIP")),
        //        new WeaponData("RPG", "WEAPON_RPG"),
        //        new WeaponData("Minigun", "WEAPON_MINIGUN"),
        //        new WeaponData("Fireworks Launcher", "WEAPON_FIREWORK"),
        //        new WeaponData("Railgun", "WEAPON_RAILGUN"),
        //        new WeaponData("Homing Launcher", "WEAPON_HOMINGLAUNCHER"),
        //    },

        //    // Thrown Weapons
        //    new WeaponData[]
        //    {
        //        new WeaponData("Grenade", "WEAPON_GRENADE", false),
        //        new WeaponData("Sticky Bomb", "WEAPON_STICKYBOMB", false),
        //        new WeaponData("Proximity Mine", "WEAPON_PROXMINE", false),
        //        new WeaponData("Teargas", "WEAPON_SMOKEGRENADE", false),
        //        new WeaponData("Molotov", "WEAPON_MOLOTOV", false),
        //        new WeaponData("Fire Extinguisher", "WEAPON_FIREEXTINGUISHER", false),
        //        new WeaponData("Jerry Can", "WEAPON_PETROLCAN", false),
        //        new WeaponData("Snowball", "WEAPON_SNOWBALL", false),
        //        new WeaponData("Flare", "WEAPON_FLARE", false),
        //    },
        //};
    }
}
