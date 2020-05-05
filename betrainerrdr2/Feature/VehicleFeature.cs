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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BETrainerRdr2.Menu;
using BETrainerRdr2.Vehicle;
using RDR2;
using RDR2.Native;
using RDR2.Math;

namespace BETrainerRdr2
{
    public static partial class Feature
    {
        /// <summary>
        /// Vehicle features
        /// </summary>
        public static class Vehicle
        {
            public const float FULL_HEALTH = 2000f;
            public const int DOOR_COUNT = 6;
            public const int PED_FLAG_THROUGH_WINDSCREEN = 32;
            public const float SPAWN_X_OFFSET = 0f;
            public const float SPAWN_Y_OFFSET = 5f;
            public const float SPAWN_Z_OFFSET = 0f;
            public const int SPAWN_WAIT = 100;
            public const int VEHICLE_MENU_DEPTH = 2;

            public static bool Invincible = false;
            private static bool _invincibleUpdated = true;
            public static bool InfiniteStamina = false;
            public static bool SeatBelt = false;
            //private static bool _seatBeltUpdated = true;
            public static bool SpawnIntoVehicle = false;

            /// <summary>
            /// Checks whether the player is in a vehicle.
            /// </summary>
            /// <param name="showNotification">If player isn't in a vehicle, whether showing a notification</param>
            /// <returns>true if player is in a vehicle; otherwise false</returns>
            private static bool CheckInVehicle(bool showNotification = true)
            {
                if (Game.Player.Character.IsInVehicle()) return true;
                if (showNotification) Utils.ShowNotification(GlobalConst.Message.VEHICLE_NOT_IN_VEHICLE);
                return false;
            }

            private static bool CheckMounted(bool showNotification = true)
            {
                if (Game.Player.Character.IsOnMount) return true;
                if (showNotification) Utils.ShowNotification(GlobalConst.Message.VEHICLE_NOT_MOUNTED);
                return false;
            }

            private static bool CheckInTrain()
            {
                if (!Game.Player.Character.IsInVehicle()) return false;
                return Game.Player.Character.CurrentVehicle.Model.IsTrain;
            }

            /// <summary>
            /// Updates vehicle features
            /// </summary>
            public static void Update()
            {
                int mount = -1;
                int vehicle = -1;
                if (Game.Player.Character.IsOnMount) mount = Game.Player.Character.CurrentMount.Handle;
                if (Game.Player.Character.IsInVehicle()) vehicle = Game.Player.Character.CurrentVehicle.Handle;

                // Invincible
                if (vehicle != -1 && _invincibleUpdated)
                {
                    Function.Call(Hash.SET_ENTITY_INVINCIBLE, vehicle, Invincible);
                    _invincibleUpdated = false;
                }
                if (mount != -1 && _invincibleUpdated)
                {
                    Function.Call(Hash.SET_ENTITY_INVINCIBLE, mount, Invincible);
                    _invincibleUpdated = false;
                }

                // Inifinite stamina
                if (mount != -1)
                {
                    Function.Call((Hash)GlobalConst.CustomHash.SET_PED_STAMINA, mount, 100f);
                }

                // Boost
                VehicleBoost.UpdateBoostInstant();
                VehicleBoost.UpdateBoostProgressive();

                // Speed meter
                SpeedMeter.UpdateSpeedMeter();
            }

            /// <summary>
            /// Initializes vehicle features
            /// </summary>
            public static void Init()
            {
                Debug.Log("Vehicle.Init");
                Debug.Log("Vehicle.Init.SetInvincible");
                SetInvincible(MenuStorage.MenuItems.Vehicle.Invincible);
                //SetSeatBelt(MenuStorage.MenuItems.Vehicle.SeatBelt);
                Debug.Log("Vehicle.Init.SetSpawnIntoVehicle");
                SetSpawnIntoVehicle(MenuStorage.MenuItems.Vehicle.SpawnIntoVehicle);

                Debug.Log("Vehicle.Init.SpeedMeter.SetShow");
                SpeedMeter.SetShow(MenuStorage.MenuItems.Vehicle.SpeedMeter.Show);
                Debug.Log("Vehicle.Init.SpeedMeter.SetShowInMetric");
                SpeedMeter.SetShowInMetric(MenuStorage.MenuItems.Vehicle.SpeedMeter.ShowInMetric);
                Debug.Log("Vehicle.Init.SpeedMeter.SetShowWithoutVehicle");
                SpeedMeter.SetShowWithoutVehicle(MenuStorage.MenuItems.Vehicle.SpeedMeter.ShowWithoutVehicle);

                Debug.Log("Vehicle.Init.VehicleBoost.SetBoostProgressive");
                VehicleBoost.SetBoostProgressive(MenuStorage.MenuItems.Vehicle.VehicleBoost.BoostProgressive);
                Debug.Log("Vehicle.Init.VehicleBoost.SetBoostInstant");
                VehicleBoost.SetBoostInstant(MenuStorage.MenuItems.Vehicle.VehicleBoost.BoostInstant);
            }

            /// <summary>
            /// Stops current vehicle
            /// </summary>
            public static void StopVehicle()
            {
                if (CheckInVehicle(false))
                {
                    Game.Player.Character.CurrentVehicle.Speed = 0f;
                }
            }

            /// <summary>
            /// Sets invincible
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetInvincible(MenuItem sender)
            {
                Invincible = sender.On;
                Config.DoAutoSave();
                _invincibleUpdated = true;
            }

            public static void SetInfiniteStamina(MenuItem sender)
            {
                InfiniteStamina = sender.On;
                Config.DoAutoSave();
            }

            /// <summary>
            /// Sets spawn into vehicle
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetSpawnIntoVehicle(MenuItem sender)
            {
                SpawnIntoVehicle = sender.On;
                Config.DoAutoSave();
            }

            ///// <summary>
            ///// Spawns the specified vehicle
            ///// </summary>
            ///// <param name="sender">Source menu item</param>
            //public static void SpawnVehicle(MenuItem sender)
            //{
            //    SpawnVehicle(sender.Data as VehicleData, true);
            //}

            ///// <summary>
            ///// Spawns the specified vehicle
            ///// </summary>
            ///// <param name="data">Vehicle data</param>
            ///// <param name="cleanUp">Whether mark the spawned vehicle as no longer needed</param>
            ///// <returns>Vehicle handle</returns>
            //private static int SpawnVehicle(VehicleData data, bool cleanUp)
            //{
            //    return SpawnVehicle(data.InternalValue, data.Name, cleanUp);
            //}

            /// <summary>
            /// Spawns the specified vehicle
            /// </summary>
            /// <param name="sender">MenuItem</param>
            /// <returns>Vehicle handle</returns>
            public static unsafe void SpawnVehicle(MenuItem sender)
            {
                VehicleData vd = sender.Data as VehicleData;
                string modelName = vd.InternalValue;
                int model = Function.Call<int>(Hash.GET_HASH_KEY, modelName);

                if (Function.Call<bool>(Hash.IS_MODEL_IN_CDIMAGE, model) && Function.Call<bool>(Hash.IS_MODEL_A_VEHICLE, model))
                {
                    Function.Call(Hash.REQUEST_MODEL, model);
                    while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, model)) Script.Wait(0);
                    Vector3 offset = vd.Info.SpawnCoordOffset;
                    float headingOffset = vd.Info.SpawnHeadingOffset;
                    float playerHeading = Function.Call<float>(Hash.GET_ENTITY_HEADING, Game.Player.Character.Handle) + 5f;
                    float heading = playerHeading + headingOffset;
                    Vector3 coord = Function.Call<RDR2.Math.Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, Game.Player.Character.Handle, offset.X, offset.Y, offset.Z);
                    int vehicle = Function.Call<int>(Hash.CREATE_VEHICLE, model, coord.X, coord.Y, coord.Z, heading, 0, 0, vd.WagonOnly, 0);
                    Function.Call(Hash.DECOR_SET_BOOL, vehicle, "wagon_block_honor", true);
                    Function.Call(Hash.SET_VEHICLE_ON_GROUND_PROPERLY, vehicle, 0);
                    Script.Wait(SPAWN_WAIT);

                    if (SpawnIntoVehicle)
                    {
                        Function.Call(Hash.SET_ENTITY_HEADING, vehicle, playerHeading);
                        Function.Call(Hash.SET_PED_INTO_VEHICLE, Game.Player.Character.Handle, vehicle, -1);
                    }

                    Function.Call(Hash.SET_VEHICLE_AS_NO_LONGER_NEEDED, &vehicle);
                    Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model);
                    Utils.ShowNotification(Utils.FormatML(GlobalConst.Message.VEHICLE_SPAWNED, vd.Name));
                }
            }

            /// <summary>
            /// Speed meter features
            /// </summary>
            public static class SpeedMeter
            {
                private static readonly Point SPEEDMETER_POS = new Point(960, 945);
                private const float SPEEDMETER_SCALE = 0.45f;
                private static readonly Color SPEEDMETER_TEXT_COLOR = Color.White;
                private static readonly Color SPEEDMETER_SHADOW_COLOR = Color.Black;
                private const int SPEEDMETER_SHADOW_OFFSET = 3;
                private const GlobalConst.HAlignment SPEEDMETER_ALIGN = GlobalConst.HAlignment.Center;
                private const string SPEEDMETER_FORMAT_MPH = "{0:#0} mph";
                private const string SPEEDMETER_FORMAT_KPH = "{0:#0} km/h";
                private const RDR2.UI.Font SPEEDMETER_FONT = RDR2.UI.Font.ChaletLondon;
                private const float SPEEDMETER_SPEED_FACTOR_KPH = 3.6f;
                private const float SPEEDMETER_SPEED_FACTOR_MPH = 3.6f / 1.609344f;

                public static bool Show = false;
                public static bool ShowInMetric = false;
                public static bool ShowWithoutVehicle = false;

                /// <summary>
                /// Sets show
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void SetShow(MenuItem sender)
                {
                    Show = sender.On;
                    Config.DoAutoSave();
                }

                /// <summary>
                /// Sets show in metric
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void SetShowInMetric(MenuItem sender)
                {
                    ShowInMetric = sender.On;
                    Config.DoAutoSave();
                }

                /// <summary>
                /// Sets show without vehicle
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void SetShowWithoutVehicle(MenuItem sender)
                {
                    ShowWithoutVehicle = sender.On;
                    Config.DoAutoSave();
                }

                /// <summary>
                /// Updates and show speed meter
                /// </summary>
                public static void UpdateSpeedMeter()
                {
                    if (Show && (Game.Player.Character.IsInVehicle() || Game.Player.Character.IsOnMount || ShowWithoutVehicle))
                    {
                        int handle = Utils.GetPlayerContainerHandle();

                        float speed = Function.Call<float>(Hash.GET_ENTITY_SPEED, handle);
                        speed *= (ShowInMetric ? SPEEDMETER_SPEED_FACTOR_KPH : SPEEDMETER_SPEED_FACTOR_MPH);

                        Utils.DrawText(Utils.FormatML((ShowInMetric ? SPEEDMETER_FORMAT_KPH : SPEEDMETER_FORMAT_MPH), speed),
                            SPEEDMETER_POS.X, SPEEDMETER_POS.Y, SPEEDMETER_ALIGN, SPEEDMETER_TEXT_COLOR, SPEEDMETER_SCALE, SPEEDMETER_SHADOW_OFFSET, SPEEDMETER_SHADOW_COLOR);
                    }
                }
            }

            /// <summary>
            /// Vehicle boost features
            /// </summary>
            public static class VehicleBoost
            {
                public const float PROGRESSIVE_SPEED_INC = 0.1f;
                public const float PROGRESSIVE_SPEED_INC_MIN = 0f;
                public const float PROGRESSIVE_SPEED_INC_MAX = 2f;
                public const float PROGRESSIVE_SPEED_INC_DELTA = 0.05f;
                public const float INSTANT_SPEED = 25f;
                public const float INSTANT_SPEED_MIN = 0f;
                public const float INSTANT_SPEED_DELTA = 5f;
                public const float MAX_SPEED = 628f;    // 2 mach XD

                public static bool BoostProgressive = false;
                public static bool BoostInstant = false;
                public static float BoostProgressiveSpeedInc = PROGRESSIVE_SPEED_INC;
                public static float BoostInstantSpeed = INSTANT_SPEED;

                /// <summary>
                /// Sets progressive boost
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void SetBoostProgressive(MenuItem sender)
                {
                    BoostProgressive = sender.On;
                    Config.DoAutoSave();
                }

                /// <summary>
                /// Sets instant boost
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void SetBoostInstant(MenuItem sender)
                {
                    BoostInstant = sender.On;
                    Config.DoAutoSave();
                }

                /// <summary>
                /// Update progressive boost
                /// </summary>
                public static void UpdateBoostProgressive()
                {
                    if (!BoostProgressive || !Game.IsKeyPressed(Configuration.InputKey.BoostVehicleProgressive) || !CheckInVehicle(false)) return;

                    Game.Player.Character.CurrentVehicle.Speed += BoostProgressiveSpeedInc;
                }

                /// <summary>
                /// Update instant boost
                /// </summary>
                public static void UpdateBoostInstant()
                {
                    if (!BoostInstant || !Game.IsKeyPressed(Configuration.InputKey.BoostVehicleInstant) || !CheckInVehicle(false)) return;

                    Game.Player.Character.CurrentVehicle.Speed = BoostInstantSpeed;
                }

                /// <summary>
                /// Increases progressive boost speed
                /// </summary>
                public static void IncBoostProgressiveSpeed(MenuItem sender)
                {
                    BoostProgressiveSpeedInc += PROGRESSIVE_SPEED_INC_DELTA;
                    if (BoostProgressiveSpeedInc > PROGRESSIVE_SPEED_INC_MAX) BoostProgressiveSpeedInc = PROGRESSIVE_SPEED_INC_MAX;
                    UpdateBoostProgressiveSpeed();
                    Config.DoAutoSave();
                }

                /// <summary>
                /// Decreases progressive boost speed
                /// </summary>
                public static void DecBoostProgressiveSpeed(MenuItem sender)
                {
                    BoostProgressiveSpeedInc -= PROGRESSIVE_SPEED_INC_DELTA;
                    if (BoostProgressiveSpeedInc < PROGRESSIVE_SPEED_INC_MIN) BoostProgressiveSpeedInc = PROGRESSIVE_SPEED_INC_MIN;
                    UpdateBoostProgressiveSpeed();
                    Config.DoAutoSave();
                }

                /// <summary>
                /// Updates progressive boost speed
                /// </summary>
                public static void UpdateBoostProgressiveSpeed()
                {
                    MenuStorage.MenuItems.Vehicle.VehicleBoost.BoostProgressiveSpeedInc.Text =
                        Utils.FormatML(MenuText.Vehicle.VehicleBoost.I02_BOOST_PROGRESSIVE_SPEED_INC, BoostProgressiveSpeedInc, Utils.Mps2Kph(BoostProgressiveSpeedInc), Utils.Mps2Mph(BoostProgressiveSpeedInc));
                }

                /// <summary>
                /// Increases progressive boost speed
                /// </summary>
                public static void IncBoostInstantSpeed(MenuItem sender)
                {
                    BoostInstantSpeed += INSTANT_SPEED_DELTA;
                    if (BoostInstantSpeed > MAX_SPEED) BoostInstantSpeed = MAX_SPEED;
                    UpdateBoostInstantSpeed();
                    Config.DoAutoSave();
                }

                /// <summary>
                /// Decreases progressive boost speed
                /// </summary>
                public static void DecBoostInstantSpeed(MenuItem sender)
                {
                    BoostInstantSpeed -= INSTANT_SPEED_DELTA;
                    if (BoostInstantSpeed < INSTANT_SPEED_MIN) BoostInstantSpeed = INSTANT_SPEED_MIN;
                    UpdateBoostInstantSpeed();
                    Config.DoAutoSave();
                }

                /// <summary>
                /// Updates progressive boost speed
                /// </summary>
                public static void UpdateBoostInstantSpeed()
                {
                    MenuStorage.MenuItems.Vehicle.VehicleBoost.BoostInstantSpeed.Text =
                        Utils.FormatML(MenuText.Vehicle.VehicleBoost.I04_BOOST_INSTANT_SPEED, BoostInstantSpeed, Utils.Mps2Kph(BoostInstantSpeed), Utils.Mps2Mph(BoostInstantSpeed));
                }
            }
        }
    }
}
