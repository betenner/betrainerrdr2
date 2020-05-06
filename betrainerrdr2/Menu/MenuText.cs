///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

namespace BETrainerRdr2.Menu
{
    /// <summary>
    /// Menu text
    /// </summary>
    public static class MenuText
    {
        /// <summary>
        /// Main menu
        /// </summary>
        public static class Main
        {
            public static readonly MLString TITLE = GlobalConst.TRAINER_NAME + " " + GlobalConst.TRAINER_VERSION;
            public static readonly MLString PLAYER = "Player";
            public static readonly MLString LOCATION = "Location";
            public static readonly MLString VEHICLE = "Vehicle";
            public static readonly MLString WEAPON = "Weapon";
            public static readonly MLString DATE_TIME_SPEED = "Date & Time & Speed";
            public static readonly MLString WORLD = "World";
            public static readonly MLString WEATHER = "Weather";
            public static readonly MLString MISC = "Misc";
            public static readonly MLString CONFIGURATION = "Configuration";
            public static readonly MLString LANGUAGE = "Language";
            public static readonly MLString MODEL = "Model";
        }

        public static class Model
        {
            public static readonly MLString ANIMAL = "Animal";
            public static readonly MLString HUMAN = "Human";
            public static class Animal
            {
                public static readonly MLString HORSE = "Horse";
                public static readonly MLString DOG = "Dog";
                public static readonly MLString FISH = "Fish";
                public static readonly MLString OTHER = "Other";
            }
            public static class Human
            {
                public static readonly MLString MALE_YOUNG = "Male Young";
                public static readonly MLString MALE_MIDDLE = "Male MIddle";
                public static readonly MLString MALE_OLD = "Male Old";
                public static readonly MLString FEMALE_YOUNG = "Female Young";
                public static readonly MLString FEMALE_MIDDLE = "Female MIddle";
                public static readonly MLString FEMALE_OLD = "Female Old";
                public static readonly MLString CUTSCENE = "Cutscene NPC";
                public static readonly MLString MISC = "Misc";
            }
        }

        /// <summary>
        /// Player menu
        /// </summary>
        public static class Player
        {
            public static readonly MLString TITLE = "Player Options";
            public static readonly MLString MODEL_SKIN_PROPS = "Model & Skin & Props";
            public static readonly MLString WANTED = "Wanted";
            public static readonly MLString CASH = "Cash {0}${1:#,0.00}";
            public static readonly MLString HEAL = "Quick Heal";
            public static readonly MLString INVINCIBLE = "Invincible";
            public static readonly MLString INFINITE_ABILITY = "Infinite Ability";
            public static readonly MLString FAST_RUN = "Fast Run";
            public static readonly MLString FAST_SWIM = "Fast Swim";
            public static readonly MLString SUPER_JUMP = "Super Jump";
            public static readonly MLString NOISELESS = "Noiseless";
            public static readonly MLString INFINITE_STAMINA = "Infinite Stamina";

            /// <summary>
            /// Wanted menu
            /// </summary>
            public static class Wanted
            {
                public static readonly MLString TITLE = "Wanted Options";
                public static readonly MLString I001_CLEAR_BOUNTY = new MLString("Clear Bounty");
                public static readonly MLString NEVER_WANTED = "Never Wanted";
                public static readonly MLString POLICE_IGNORED = "Police Ignores Me";
                public static readonly MLString EVERYONE_IGNORED = "Everyone Ignores Me";
                public static readonly MLString WANTED_UP = "Wanted Level Up";
                public static readonly MLString WANTED_DOWN = "Wanted Level Down";
            }

            /// <summary>
            /// Model & Skin & Props menu
            /// </summary>
            public static class ModelSkinProps
            {
                public static readonly MLString TITLE = "Model & Skin & Props";
                public static readonly MLString CUSTOM_SETS = "Custom Sets";
                public static readonly MLString SET_MODEL = "Set Model";
                public static readonly MLString SET_SKIN = "Set Skin";
                public static readonly MLString SET_PROPS = "Set Props";
                public static readonly MLString RANDOM_MODEL = "Random Model";
                public static readonly MLString RANDOM_SKIN = "Random Skin";
                public static readonly MLString RANDOM_PROPS = "Random Props";
                public static readonly MLString RESET_SKIN = "Reset Skin";
                public static readonly MLString CLEAR_PROPS = "Clear Props";

                /// <summary>
                /// Custom sets menu
                /// </summary>
                public static class CustomSet
                {
                    public static readonly MLString TITLE = "Custom Sets";
                    public static readonly MLString CREATE = "Create New Set";

                    /// <summary>
                    /// Item menu
                    /// </summary>
                    public static class Item
                    {
                        public static readonly MLString APPLY = "Apply";
                        public static readonly MLString RENAME = "Rename";
                        public static readonly MLString OVERWRITE = "Overwrite with Current";
                        public static readonly MLString DELETE = "Delete";
                    }
                }

                /// <summary>
                /// Model selector menu
                /// </summary>
                public static class ModelSelector
                {
                    public static readonly MLString TITLE = "Model Selector";
                    public static readonly MLString MICHAEL = "Michael";
                    public static readonly MLString FRANKLIN = "Franklin";
                    public static readonly MLString TREVOR = "Trevor";
                    public static readonly MLString ANIMALS = "Animals";
                    public static readonly MLString NPCS = "NPCs";
                    public static readonly MLString RANDOM = "Random";

                    /// <summary>
                    /// Model selector animals menu
                    /// </summary>
                    public static class Animals
                    {
                        public static readonly MLString TITLE = "Model Selector - Animals";
                    }

                    /// <summary>
                    /// Model selector NPCs menu
                    /// </summary>
                    public static class NPCs
                    {
                        public static readonly MLString TITLE = "Model Selector - NPCs";
                    }
                }

                /// <summary>
                /// Skin categories menu
                /// </summary>
                public static class SkinCategories
                {
                    public static readonly MLString TITLE = "Skin Categories";
                    public static readonly MLString SLOT = "Slot {0}: {1} ({2})";
                    public static readonly MLString NO_AVAILABLE_SLOT = "No Available Slot";

                    /// <summary>
                    /// Drawable selector menu
                    /// </summary>
                    public static class DrawableSelector
                    {
                        public static readonly MLString TITLE = "Drawable Selector";
                        public static readonly MLString DRAWABLE = "Drawable #{0} ({1})";

                        /// <summary>
                        /// Texture selector menu
                        /// </summary>
                        public static class TextureSelector
                        {
                            public static readonly MLString TITLE = "Texture Selector";
                            public static readonly MLString TEXTURE = "Texture #{0}";
                        }
                    }
                }

                /// <summary>
                /// Props categories menu
                /// </summary>
                public static class PropCategories
                {
                    public static readonly MLString TITLE = "Prop Categories";
                    public static readonly MLString SLOT = "Slot {0}: {1} ({2})";
                    public static readonly MLString NO_AVAILABLE_SLOT = "No Available Slot";

                    /// <summary>
                    /// Drawable selector menu
                    /// </summary>
                    public static class PropsSelector
                    {
                        public static readonly MLString TITLE = "Prop Selector";
                        public static readonly MLString NOTHING = "Nothing";
                        public static readonly MLString PROP = "Prop #{0} ({1})";

                        /// <summary>
                        /// Texture selector menu
                        /// </summary>
                        public static class TextureSelector
                        {
                            public static readonly MLString TITLE = "Texture Selector";
                            public static readonly MLString TEXTURE = "Texture #{0}";
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Location menu
        /// </summary>
        public static class Location
        {
            public static readonly MLString TITLE = "Location Options";
            public static readonly MLString LOCATION_TELEPORTER = "Location Teleporter";
            public static readonly MLString CUSTOM_LOCATION_TELEPORTER = "Custom Location Teleporter";
            public static readonly MLString XYZ_TELEPORTER = "XYZ Teleporter";
            public static readonly MLString SHOW_COORDINATE = "Show Coordinates";

            /// <summary>
            /// Location teleporter menu
            /// </summary>
            public static class LocationTeleporter
            {
                public static readonly MLString TITLE = "Location Teleporter";
                public static readonly MLString MAP_MARKER = "Map Marker";
                public static readonly MLString MAP_LOCATIONS = "Map Locations";
                public static readonly MLString LANDMARKS = "Landmarks";
                public static readonly MLString ROOF_HIGH = "Roof & High Places";
                public static readonly MLString UNDERWATER = "Underwater Places";
                public static readonly MLString INTERIORS = "Interiors";
                public static readonly MLString SPECIALS = "Special Places";
                public static readonly MLString STUNT_JUMPS = "Stunt Jumps";
                public static readonly MLString SPACESHIP_PARTS = "Spaceship Parts";
                public static readonly MLString LETTER_SCRAPS = "Letter Scraps";
            }

            /// <summary>
            /// Custom location teleporter menu
            /// </summary>
            public static class CustomLocationTeleporter
            {
                public static readonly MLString TITLE = "Custom Location Teleporter";
                public static readonly MLString SAVE = "Save Current Location";

                /// <summary>
                /// Custom loactoin teleporter item menu
                /// </summary>
                public static class Item
                {
                    public static readonly MLString TELEPORT = "Teleport";
                    public static readonly MLString RENAME = "Rename";
                    public static readonly MLString OVERWRITE = "Overwrite With Current Location";
                    public static readonly MLString DELETE = "Delete";
                }
            }

            /// <summary>
            /// XYZ teleporter menu
            /// </summary>
            public static class XyzTeleporter
            {
                public static readonly MLString TITLE = "XYZ Teleporter";
                public static readonly MLString OFFSET = "Teleport by Offsets";
                public static readonly MLString COORDINATES = "Teleport to Coordinates";
                public static readonly MLString RANDOM = "Teleport to Random Location";

                /// <summary>
                /// Teleport by Offsets menu
                /// </summary>
                public static class Offset
                {
                    public static readonly MLString TITLE = "Teleport by Offsets";
                    public static readonly MLString X = "X: {0:#0.000000}";
                    public static readonly MLString Y = "Y: {0:#0.000000}";
                    public static readonly MLString Z = "Z: {0:#0.000000}";
                    public static readonly MLString RESET = "Reset";
                    public static readonly MLString TELEPORT = "Teleport";
                }

                /// <summary>
                /// Teleport to coordinates menu
                /// </summary>
                public static class Coordinates
                {
                    public static readonly MLString TITLE = "Ttleport to Coordinates";
                    public static readonly MLString X = "X: {0:#0.000000}";
                    public static readonly MLString Y = "Y: {0:#0.000000}";
                    public static readonly MLString Z = "Z: {0:#0.000000}";
                    public static readonly MLString RESET = "Reset to Current Location";
                    public static readonly MLString TELEPORT = "Teleport";
                }
            }
        }

        /// <summary>
        /// Vehicle menu
        /// </summary>
        public static class Vehicle
        {
            public static readonly MLString TITLE = "Vehicle Options";
            public static readonly MLString SPAWN = "Spawn Vehicle";
            public static readonly MLString CUSTOM = "Custom Vehicles";
            public static readonly MLString PAINT = "Paints";
            public static readonly MLString MODS = "Modifications";
            public static readonly MLString DOORS = "Door Control";
            public static readonly MLString SPEED_METER = "Speed Meter";
            public static readonly MLString REPAIR = "Repair Vehicle";
            public static readonly MLString CLEAN = "Clean Vehicle";
            public static readonly MLString INVINCIBLE = "Invincible";
            public static readonly MLString I091_INFINITE_STAMINA = "Infinite Stamina";
            public static readonly MLString SEAT_BELT = "Seat Belt";
            public static readonly MLString SPAWN_INTO = "Spawn into Vehicle";
            public static readonly MLString VEHICLE_BOOST = "Vehicle Boost";

            /// <summary>
            /// Vehicle boost menu
            /// </summary>
            public static class VehicleBoost
            {
                public static readonly MLString TITLE = "Vehicle Boost";
                public static readonly MLString BOOST_PROGRESSIVE = "Progressive Boost";
                public static readonly MLString BOOST_PROGRESSIVE_SPEED_INC = "Progressive Boost Speed Increment: {0:#0.00}m/s ({1:#0.0}km/h, {2:#0.0}mph)";
                public static readonly MLString BOOST_INSTANT = "Instant Boost";
                public static readonly MLString BOOST_INSTANT_SPEED = "Instant Boost Speed: {0:#0}m/s ({1:#0.0}km/h, {2:#0.0}mph)";
            }

            /// <summary>
            /// Spawn menu
            /// </summary>
            public static class Spawn
            {
                public static readonly MLString TITLE = "Spawn Vehicle";
                public static readonly MLString BOAT = "Boat";
                public static readonly MLString TRAIN = "Train";
                public static readonly MLString WAGON = "Wagon";
                public static readonly MLString WAGON_ONLY = "Wagon Only";
                public static readonly MLString CANNON = "Cannon";
                public static readonly MLString MISC = "Misc";
            }

            /// <summary>
            /// Custom vehicle menu
            /// </summary>
            public static class CustomVehicle
            {
                public static readonly MLString TITLE = "Custom Vehicle Options";
                public static readonly MLString SAVE = "Save Current Vehicle";
                public static readonly MLString ITEM = "[{0}]";

                /// <summary>
                /// Item menu
                /// </summary>
                public static class Item
                {
                    public static readonly MLString TITLE = "[{0}]";
                    public static readonly MLString SPAWN = "Spawn";
                    public static readonly MLString RENAME = "Rename";
                    public static readonly MLString OVERWRITE = "Overwrite With Current Vehicle";
                    public static readonly MLString DELETE = "Delete";
                }
            }

            /// <summary>
            /// Paint menu
            /// </summary>
            public static class Paint
            {
                public static readonly MLString TITLE = "Choose a Part to Paint";
                public static readonly MLString PRIMARY = "Primary Color";
                public static readonly MLString SECONDARY = "Secondary Color";
                public static readonly MLString PEARL_TOPCOAT = "Pearl Topcoat";
                public static readonly MLString WHEELS = "Wheels";
                public static readonly MLString LIVERY = "Liveries ({0})";

                public static readonly MLString CHOOSE_PAINT_TYPE = "Choose Paint Type";
                public static readonly MLString CHOOSE_COLOR = "Choose Color";

                /// <summary>
                /// Livery menu
                /// </summary>
                public static class Livery
                {
                    public static readonly MLString TITLE = "Choose Livery";
                    public static readonly MLString ITEM = "Livery #{0}";
                }
            }

            /// <summary>
            /// Mod menu
            /// </summary>
            public static class Mod
            {
                public static readonly MLString TITLE = "Vehicle Mod Options";
                public static readonly MLString ALL_PERFORMANCE = "Applies All Performance Upgrades";
                public static readonly MLString ALL_ARMOR = "Applies All Armor Upgrades";
                public static readonly MLString REMOVE_ALL = "Removes All Upgrades";

                public static readonly MLString FORMAT_MOD_CATEGORY = "{0} ({1})";
                public static readonly MLString TURBO_TUNING = "Turbo Tuning";
                public static readonly MLString TURBO_XEON_LIGHTS = "Turbo Xeon Lights";
                public static readonly MLString BULLETPROOF_TYRES = "Bulletproof Tyres";
                public static readonly MLString CUSTOM_TYRES = "Custom Tyres";
                public static readonly MLString EXTRA = "Extra #{0}";
                public static readonly MLString SET_PLATE_TEXT = "Set Plate Text";
                public static readonly MLString NO_AVAILABLE_MOD = "No Available Mod for this Vehicle";
                public static readonly MLString DEFAULT_WHEEL = "Set to Default Wheel";
                public static readonly MLString DEFAULT = "Default";
                public static readonly MLString MOD_ITEM = "{0} Item #{1}";
            }

            /// <summary>
            /// Speed meter menu
            /// </summary>
            public static class SpeedMeter
            {
                public static readonly MLString TITLE = "Speed Meter Options";
                public static readonly MLString SHOW = "Show Speed Meter";
                public static readonly MLString SHOW_IN_METRIC = "Show in Metric";
                public static readonly MLString SHOW_WITHOUT_VEHICLE = "Show Without Vehicle";
            }

            /// <summary>
            /// Door menu
            /// </summary>
            public static class Door
            {
                public static readonly MLString TITLE = "Door Control";
                public static readonly MLString INSTANT_OPEN_CLOSE = "Instant Open/Close";
                public static readonly MLString FRONT_RIGHT = "Front Right";
                public static readonly MLString FRONT_LEFT = "Front Left";
                public static readonly MLString REAR_RIGHT = "Rear Right";
                public static readonly MLString REAR_LEFT = "Rear Left";
                public static readonly MLString HOOD = "Hood";
                public static readonly MLString TRUNK = "Trunk";
                public static readonly MLString TRUNK2 = "Trunk 2";
            }
        }

        /// <summary>
        /// Weapon menu
        /// </summary>
        public static class Weapon
        {
            public static readonly MLString TITLE = "Weapon Options";
            public static readonly MLString GET_ALL_WEAPONS = "Get All Weapons";
            public static readonly MLString GET_SPECIFIC_WEAPON = "Get Specific Weapon";
            public static readonly MLString INFINITE_AMMO = "Infinite Ammo";
            public static readonly MLString PERMANENT_PARACHUTE = "Permanent Parachute";
            public static readonly MLString NO_RELOAD = "No Reload";
            public static readonly MLString FIRE_AMMO = "Fire Ammo";
            public static readonly MLString EXPLOSIVE_AMMO = "Explosive Ammo";
            public static readonly MLString EXPLOSIVE_MELEE = "Explosive Melee";
            public static readonly MLString VEHICLE_ROCKETS = "Vehicle Rockets";
            public static readonly MLString I031_DAMAGE_MULTIPLIER = new MLString("Guns Damage Multiplier: {0:0%}");

            /// <summary>
            /// Specific weapon menu
            /// </summary>
            public static class SpecificWeapon
            {
                public static readonly MLString TITLE = "Select Weapon";

                public static readonly MLString HAS = "Has this Weapon";
                public static readonly MLString FILL_AMMO_CLIP = "Fill Ammo & Clip";
                public static readonly MLString TINT = "Weapon Tint";
                public static readonly MLString SELECT_TINT = "Select Tint";
            }
        }

        /// <summary>
        /// Time menu
        /// </summary>
        public static class DateTimeSpeed
        {
            public static readonly MLString TITLE = "Date & Time & Speed Options";
            public static readonly MLString SET_DATETIME = "Set Date & Time";
            public static readonly MLString SET_GAME_SPEED = "Set Game Speed";
            public static readonly MLString SET_AIMING_SPEED = "Set Aiming Speed";
            public static readonly MLString HOUR_FORWARD = "Hour Forward";
            public static readonly MLString HOUR_BACKWARD = "Hour Backward";
            public static readonly MLString DAY_FORWARD = "Day Forward";
            public static readonly MLString DAY_BACKWARD = "Day Backward";
            public static readonly MLString SHOW_TIME = "Show Time";
            public static readonly MLString TIME_PAUSED = "Time Paused";
            public static readonly MLString SYNC_WITH_SYSTEM = "Sync with System";

            /// <summary>
            /// Set date time menu
            /// </summary>
            public static class SetDateTime
            {
                public static readonly MLString TITLE = "Set Date & Time";
                public static readonly MLString YEAR = "Year: {0:0000}";
                public static readonly MLString MONTH = "Month: {0:00}";
                public static readonly MLString DAY = "Day: {0:00}";
                public static readonly MLString HOUR = "Hour: {0:00}";
                public static readonly MLString MINUTE = "Minute: {0:00}";
                public static readonly MLString SECOND = "Second: {0:00}";
                public static readonly MLString SET_TO_CURRENT = "Set to Current";
                public static readonly MLString SET_TO_SYSTEM = "Set to System";
            }

            /// <summary>
            /// Set game speed menu
            /// </summary>
            public static class SetGameSpeed
            {
                public static readonly MLString TITLE = "Change Game Speed";
                public static readonly MLString SPEED = "Speed: {0:#0%}";
                public static readonly MLString SET_TO_100 = "Set to 100%";
                public static readonly MLString SET_TO_75 = "Set to 75%";
                public static readonly MLString SET_TO_50 = "Set to 50%";
                public static readonly MLString SET_TO_25 = "Set to 25%";
                public static readonly MLString SET_TO_10 = "Set to 10%";
                public static readonly MLString SET_TO_0 = "Set to 0%";
            }

            /// <summary>
            /// Set aiming speed menu
            /// </summary>
            public static class SetAimingSpeed
            {
                public static readonly MLString TITLE = "Change Aiming Speed";
                public static readonly MLString SPEED = "Speed: {0:#0%}";
                public static readonly MLString SET_TO_100 = "Set to 100%";
                public static readonly MLString SET_TO_75 = "Set to 75%";
                public static readonly MLString SET_TO_50 = "Set to 50%";
                public static readonly MLString SET_TO_25 = "Set to 25%";
                public static readonly MLString SET_TO_10 = "Set to 10%";
                public static readonly MLString SET_TO_0 = "Set to 0%";
            }

        }

        /// <summary>
        /// World menu
        /// </summary>
        public static class World
        {
            public static readonly MLString TITLE = "World Options";
            public static readonly MLString MOON_GRAVITY = "Moon Gravity";
            public static readonly MLString RANDOM_COPS = "Random Cops";
            public static readonly MLString RANDOM_TRAINS = "Random Trains";
            public static readonly MLString RANDOM_BOATS = "Random Boats";
            public static readonly MLString GARBAGE_TRUCKS = "Garbage Trucks";
            public static readonly MLString RESTRICTED_ZONES = "Restricted Zones";
        }

        /// <summary>
        /// Weather menu
        /// </summary>
        public static class Weather
        {
            public static readonly MLString TITLE = "Weather Options";
            public static readonly MLString WIND = "Wind";
            public static readonly MLString FREEZE_WEATHER = "Freeze Weather";
        }

        /// <summary>
        /// Misc menu
        /// </summary>
        public static class Misc
        {
            public static readonly MLString TITLE = "Misc Options";
            public static readonly MLString PORTABLE_RADIO = "Portable Radio";
            public static readonly MLString HIDE_HUD = "Hide HUD";
            public static readonly MLString NEXT_RADIO_TRACK = "Next Radio Track";
            public static readonly MLString REVEAL_MAP = new MLString("Reveal Map");
        }

        /// <summary>
        /// Configuration menu
        /// </summary>
        public static class Configuration
        {
            public static readonly MLString TITLE = "Configuration Options";
            public static readonly MLString SAVE = "Save";
            public static readonly MLString LOAD = "Load";
            public static readonly MLString AUTO_SAVE = "Auto Save";
        }

        /// <summary>
        /// Language menu
        /// </summary>
        public static class Language
        {
            public static readonly MLString TITLE = "Choose Language";
            public static readonly MLString ENGLISH = "English";
            public static readonly MLString CHINESE_TRADITIONAL = "简体中文 (Chinese Simplified)";
        }
    }
}
