﻿///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using System;
using System.Drawing;
using RDR2;
using RDR2.Native;
using BETrainerRdr2.Menu;
using BETrainerRdr2.Teleport;

namespace BETrainerRdr2
{
    public static partial class Feature
    {
        /// <summary>
        /// Location features
        /// </summary>
        public static class Location
        {
            public static bool ShowCoordinates = false;

            private static readonly Point COORDINATE_POS = new Point(960, 970);
            private const float COORDINATE_SCALE = 0.45f;
            private static readonly Color COORDINATE_TEXT_COLOR = Color.White;
            private const GlobalConst.HAlignment COORDINATE_ALIGN = GlobalConst.HAlignment.Center;
            private const string COORDINATE_FORMAT = "X: {0:0.0000}, Y: {1:0.0000}, Z: {2:0.0000}";

            /// <summary>
            /// Initializes loction features
            /// </summary>
            public static void Init()
            {
                Debug.Log("Location.Init");
                Debug.Log("Location.Init.SetShowCoordinates");
                SetShowCoordinates(MenuStorage.MenuItems.Location.ShowCoordinate);
            }

            /// <summary>
            /// Sets show coordinates
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetShowCoordinates(MenuItem sender)
            {
                Feature.Location.ShowCoordinates = sender.On;
                Config.DoAutoSave();
            }

            public static void Draw()
            {
                DrawCoordinate();
            }

            /// <summary>
            /// Draws coordinate.
            /// </summary>
            private static void DrawCoordinate()
            {
                //Debug.Log("Drawing coordinates...");
                if (Feature.Location.ShowCoordinates)
                {
                    string coord = Utils.FormatML(COORDINATE_FORMAT, Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z);
                    Utils.DrawText(coord, COORDINATE_POS.X, COORDINATE_POS.Y, COORDINATE_ALIGN, COORDINATE_TEXT_COLOR, COORDINATE_SCALE);
                }
            }

            /// <summary>
            /// Location teleporter features
            /// </summary>
            public static class LocationTeleporter
            {
                /// <summary>
                /// Teleports player to map marker
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void MapMarker(MenuItem sender)
                {
                    if (Game.IsWaypointActive)
                    {
                        RDR2.Math.Vector3 coord = Function.Call<RDR2.Math.Vector3>(Hash._GET_WAYPOINT_COORDS);
                        Utils.TeleportWithGroundCheck(coord);
                        Utils.ShowNotification(GlobalConst.Message.TP_MAP_MARKER);
                    }
                    else
                    {
                        Utils.ShowNotification(GlobalConst.Message.TP_NO_MAP_MARKER_FOUND);
                    }
                }

                /// <summary>
                /// Teleports player to target
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void Target(MenuItem sender)
                {
                    TeleportTarget target = (sender.Data as TeleportTarget);
                    Utils.TeleportWithoutGroundCheck(target.Coords);
                    Utils.ShowNotification(GlobalConst.Message.TP_TARGET);
                }
            }

            /// <summary>
            /// Custom location teleporter features
            /// </summary>
            public static class CustomLocationTeleporter
            {
                private const string FORMAT_TARGET_NAME = "[{0}]";
                private const string FORMAT_DEFAULT_NAME = "X:{0:#0.00}, Y:{1:#0.00}, Z:{2:#0.00}";
                private const int MAX_INPUT_LENGTH = 40;

                /// <summary>
                /// Generates the custom location target list
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void GenerateTargetList(MenuItem sender)
                {
                    MenuStorage.Menus.Locations.CLTeleporter.Clear();
                    MenuStorage.Menus.Locations.CLTeleporter.Add(MenuStorage.MenuItems.Location.CustomLocationTeleporter.SaveCurrentLocation);

                    for (int i = 0; i < Configuration.Location.Targets.Count; i++)
                    {
                        SimpleTeleportTarget target = Configuration.Location.Targets[i];
                        target.Index = i;
                        MenuItem mi = MenuStorage.AddMenuItem(MenuStorage.Menus.Locations.CLTeleporter, Utils.FormatML(FORMAT_TARGET_NAME, target.Name), false, false, MenuStorage.Menus.Locations.CLTeleporters.Item, null, PreEnterTargetItem, null, target);
                    }
                }

                /// <summary>
                /// Saves the current location as a custom location
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void SaveCurrentLocation(MenuItem sender)
                {
                    RDR2.Math.Vector3 coords = Game.Player.Character.Position;
                    string name = Utils.ShowInGameKeyboard(null, Utils.FormatML(FORMAT_DEFAULT_NAME, coords.X, coords.Y, coords.Z), MAX_INPUT_LENGTH);
                    if (string.IsNullOrEmpty(name)) return;

                    SimpleTeleportTarget target = new SimpleTeleportTarget(name, coords.X, coords.Y, coords.Z);
                    Configuration.Location.Targets.Add(target);
                    Configuration.Location.Targets.Sort();
                    Configuration.Location.SaveCustomLocations();
                    GenerateTargetList(null);
                    Utils.ShowNotification(GlobalConst.Message.CL_SAVED);
                }

                /// <summary>
                /// Enters a target menu item
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void PreEnterTargetItem(MenuItem sender)
                {
                    SimpleTeleportTarget target = (sender.Data as SimpleTeleportTarget);
                    MenuStorage.Menus.Locations.CLTeleporters.Item.Title = Utils.FormatML(FORMAT_TARGET_NAME, target.Name);
                    MenuStorage.MenuItems.Location.CustomLocationTeleporter.Item.Teleport.Data = target;
                    MenuStorage.MenuItems.Location.CustomLocationTeleporter.Item.Rename.Data = target;
                    MenuStorage.MenuItems.Location.CustomLocationTeleporter.Item.Overwrite.Data = target;
                    MenuStorage.MenuItems.Location.CustomLocationTeleporter.Item.Delete.Data = target;
                    MenuStorage.Menus.Locations.CLTeleporters.Item.SelectedIndex = 0;
                }

                /// <summary>
                /// Teleports to custom location
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void Teleport(MenuItem sender)
                {
                    SimpleTeleportTarget target = (sender.Data as SimpleTeleportTarget);
                    int handle = Utils.GetPlayerContainerHandle();
                    Function.Call(Hash.SET_ENTITY_COORDS, handle, target.Coords.X, target.Coords.Y, target.Coords.Z, 0, 0, 1, false);
                    Utils.ShowNotification(GlobalConst.Message.CL_TELEPORTED);
                }

                /// <summary>
                /// Renames the custom location
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void Rename(MenuItem sender)
                {
                    SimpleTeleportTarget target = (sender.Data as SimpleTeleportTarget);

                    string name = Utils.ShowInGameKeyboard(null, target.Name, MAX_INPUT_LENGTH);
                    if (string.IsNullOrEmpty(name)) return;

                    MenuStorage.Menus.Locations.CLTeleporters.Item.Title = name;
                    Configuration.Location.Targets[target.Index].Name = name;
                    Configuration.Location.Targets.Sort();
                    Configuration.Location.SaveCustomLocations();
                    GenerateTargetList(null);
                    Utils.ShowNotification(GlobalConst.Message.CL_RENAMED);
                }

                /// <summary>
                /// Overwrite with current location
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void Overwrite(MenuItem sender)
                {
                    SimpleTeleportTarget target = (sender.Data as SimpleTeleportTarget);

                    Configuration.Location.Targets[target.Index].Coords = Game.Player.Character.Position;
                    Configuration.Location.SaveCustomLocations();
                    Utils.ShowNotification(GlobalConst.Message.CL_OVERWRITTEN);
                }

                /// <summary>
                /// Deletes the custom location
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void Delete(MenuItem sender)
                {
                    SimpleTeleportTarget target = (sender.Data as SimpleTeleportTarget);

                    Configuration.Location.Targets.RemoveAt(target.Index);
                    Configuration.Location.SaveCustomLocations();
                    GenerateTargetList(null);
                    MenuStorage.ReturnToPrevMenu();
                    Utils.ShowNotification(GlobalConst.Message.CL_DELETED);
                }
            }

            /// <summary>
            /// XYZ teleporter features
            /// </summary>
            public static class XyzTeleporter
            {
                private const float X_MAX = 4000f;
                private const float X_MIN = -4000f;
                private const float Y_MAX = 8000f;
                private const float Y_MIN = -4000f;
                private const float Z_MAX = 1000f;
                private const float Z_MIN = -200f;

                /// <summary>
                /// Teleports to a random location
                /// </summary>
                /// <param name="sender">Source menu item</param>
                public static void Random(MenuItem sender)
                {
                    Random rnd = new Random();
                    float x = (float)rnd.NextDouble() * (X_MAX - X_MIN) + X_MIN;
                    float y = (float)rnd.NextDouble() * (Y_MAX - Y_MIN) + Y_MIN;

                    Utils.TeleportWithGroundCheck(new RDR2.Math.Vector3(x, y, 0));
                    Utils.ShowNotification(GlobalConst.Message.XYZ_RANDOM_TELEPORTED);
                }

                /// <summary>
                /// Teleport by coordinates features
                /// </summary>
                public static class Coordinates
                {
                    private const float DELTA = 1f;
                    private const int MAX_INPUT_LENGTH = 20;

                    private static float _x = 0f;
                    private static float _y = 0f;
                    private static float _z = 0f;

                    private static void CX()
                    {
                        if (_x < X_MIN) _x = X_MIN;
                        else if (_x > X_MAX) _x = X_MAX;
                    }

                    private static void CY()
                    {
                        if (_y < Y_MIN) _y = Y_MIN;
                        else if (_y > Y_MAX) _y = Y_MAX;
                    }

                    private static void CZ()
                    {
                        if (_z < Z_MIN) _z = Z_MIN;
                        else if (_z > Z_MAX) _z = Z_MAX;
                    }

                    /// <summary>
                    /// Entered this menu
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void EnterMenu(MenuItem sender)
                    {
                        _x = Game.Player.Character.Position.X;
                        _y = Game.Player.Character.Position.Y;
                        _z = Game.Player.Character.Position.Z;
                        UpdateXMenuText();
                        UpdateYMenuText();
                        UpdateZMenuText();
                    }

                    /// <summary>
                    /// Updates X menu item text
                    /// </summary>
                    public static void UpdateXMenuText()
                    {
                        MenuStorage.MenuItems.Location.XyzTeleporter.Coordinates.X.Text = Utils.FormatML(MenuText.Location.XyzTeleporter.Coordinates.X, _x);
                    }

                    /// <summary>
                    /// Updates Y menu item text
                    /// </summary>
                    public static void UpdateYMenuText()
                    {
                        MenuStorage.MenuItems.Location.XyzTeleporter.Coordinates.Y.Text = Utils.FormatML(MenuText.Location.XyzTeleporter.Coordinates.Y, _y);
                    }

                    /// <summary>
                    /// Updates Z menu item text
                    /// </summary>
                    public static void UpdateZMenuText()
                    {
                        MenuStorage.MenuItems.Location.XyzTeleporter.Coordinates.Z.Text = Utils.FormatML(MenuText.Location.XyzTeleporter.Coordinates.Z, _z);
                    }

                    /// <summary>
                    /// Resets all offsets
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void Reset(MenuItem sender)
                    {
                        _x = Game.Player.Character.Position.X;
                        _y = Game.Player.Character.Position.Y;
                        _z = Game.Player.Character.Position.Z;
                        UpdateXMenuText();
                        UpdateYMenuText();
                        UpdateZMenuText();
                    }

                    /// <summary>
                    /// Increases X offset
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void IncX(MenuItem sender)
                    {
                        _x += DELTA;
                        CX();
                        UpdateXMenuText();
                    }

                    /// <summary>
                    /// Decreases X offset
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void DecX(MenuItem sender)
                    {
                        _x -= DELTA;
                        CX();
                        UpdateXMenuText();
                    }

                    /// <summary>
                    /// Increases Y offset
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void IncY(MenuItem sender)
                    {
                        _y += DELTA;
                        CY();
                        UpdateYMenuText();
                    }

                    /// <summary>
                    /// Decreases Y offset
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void DecY(MenuItem sender)
                    {
                        _y -= DELTA;
                        CY();
                        UpdateYMenuText();
                    }

                    /// <summary>
                    /// Increases Z offset
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void IncZ(MenuItem sender)
                    {
                        _z += DELTA;
                        CZ();
                        UpdateZMenuText();
                    }

                    /// <summary>
                    /// Decreases Z offset
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void DecZ(MenuItem sender)
                    {
                        _z -= DELTA;
                        CZ();
                        UpdateZMenuText();
                    }

                    /// <summary>
                    /// Sets the X value
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void SetX(MenuItem sender)
                    {
                        string value = Utils.ShowInGameKeyboard(null, _x.ToString(), MAX_INPUT_LENGTH);
                        if (string.IsNullOrEmpty(value)) return;
                        float x = 0f;
                        if (!float.TryParse(value, out x)) return;
                        _x = x;
                        CX();
                        UpdateXMenuText();
                    }

                    /// <summary>
                    /// Sets the Y value
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void SetY(MenuItem sender)
                    {
                        string value = Utils.ShowInGameKeyboard(null, _y.ToString(), MAX_INPUT_LENGTH);
                        if (string.IsNullOrEmpty(value)) return;
                        float y = 0f;
                        if (!float.TryParse(value, out y)) return;
                        _y = y;
                        CY();
                        UpdateYMenuText();
                    }

                    /// <summary>
                    /// Sets the Z value
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void SetZ(MenuItem sender)
                    {
                        string value = Utils.ShowInGameKeyboard(null, _z.ToString(), MAX_INPUT_LENGTH);
                        if (string.IsNullOrEmpty(value)) return;
                        float z = 0f;
                        if (!float.TryParse(value, out z)) return;
                        _z = z;
                        CZ();
                        UpdateZMenuText();
                    }

                    /// <summary>
                    /// Teleports by offsets
                    /// </summary>
                    /// <param name="sender"></param>
                    public static void Teleport(MenuItem sender)
                    {
                        int handle = Game.Player.Character.Handle;
                        if (Game.Player.Character.IsInVehicle())
                        {
                            handle = Game.Player.Character.CurrentVehicle.Handle;
                        }

                        Function.Call(Hash.SET_ENTITY_COORDS_NO_OFFSET, handle, _x, _y, _z, 0, 0, 1);
                        Utils.ShowNotification(GlobalConst.Message.XYZ_TELEPORTED);
                    }
                }

                /// <summary>
                /// Teleport by offset features
                /// </summary>
                public static class Offset
                {
                    private const float DELTA = 0.5f;
                    private const int MAX_INPUT_LENGTH = 20;

                    private static float _x = 0f;
                    private static float _y = 0f;
                    private static float _z = 0f;

                    private static void CX()
                    {
                        if (_x < X_MIN) _x = X_MIN;
                        else if (_x > X_MAX) _x = X_MAX;
                    }

                    private static void CY()
                    {
                        if (_y < Y_MIN) _y = Y_MIN;
                        else if (_y > Y_MAX) _y = Y_MAX;
                    }

                    private static void CZ()
                    {
                        if (_z < Z_MIN) _z = Z_MIN;
                        else if (_z > Z_MAX) _z = Z_MAX;
                    }

                    /// <summary>
                    /// Updates X menu item text
                    /// </summary>
                    public static void UpdateXMenuText()
                    {
                        MenuStorage.MenuItems.Location.XyzTeleporter.Offset.X.Text = Utils.FormatML(MenuText.Location.XyzTeleporter.Offset.X, _x);
                    }

                    /// <summary>
                    /// Updates Y menu item text
                    /// </summary>
                    public static void UpdateYMenuText()
                    {
                        MenuStorage.MenuItems.Location.XyzTeleporter.Offset.Y.Text = Utils.FormatML(MenuText.Location.XyzTeleporter.Offset.Y, _y);
                    }

                    /// <summary>
                    /// Updates Z menu item text
                    /// </summary>
                    public static void UpdateZMenuText()
                    {
                        MenuStorage.MenuItems.Location.XyzTeleporter.Offset.Z.Text = Utils.FormatML(MenuText.Location.XyzTeleporter.Offset.Z, _z);
                    }

                    /// <summary>
                    /// Resets all offsets
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void Reset(MenuItem sender)
                    {
                        _x = _y = _z = 0;
                        UpdateXMenuText();
                        UpdateYMenuText();
                        UpdateZMenuText();
                    }

                    /// <summary>
                    /// Increases X offset
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void IncX(MenuItem sender)
                    {
                        _x += DELTA;
                        CX();
                        UpdateXMenuText();
                    }

                    /// <summary>
                    /// Decreases X offset
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void DecX(MenuItem sender)
                    {
                        _x -= DELTA;
                        CX();
                        UpdateXMenuText();
                    }

                    /// <summary>
                    /// Increases Y offset
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void IncY(MenuItem sender)
                    {
                        _y += DELTA;
                        CY();
                        UpdateYMenuText();
                    }

                    /// <summary>
                    /// Decreases Y offset
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void DecY(MenuItem sender)
                    {
                        _y -= DELTA;
                        CY();
                        UpdateYMenuText();
                    }

                    /// <summary>
                    /// Increases Z offset
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void IncZ(MenuItem sender)
                    {
                        _z += DELTA;
                        CZ();
                        UpdateZMenuText();
                    }

                    /// <summary>
                    /// Decreases Z offset
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void DecZ(MenuItem sender)
                    {
                        _z -= DELTA;
                        CZ();
                        UpdateZMenuText();
                    }

                    /// <summary>
                    /// Sets the X value
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void SetX(MenuItem sender)
                    {
                        string value = Utils.ShowInGameKeyboard(null, _x.ToString(), MAX_INPUT_LENGTH);
                        if (string.IsNullOrEmpty(value)) return;
                        float x = 0f;
                        if (!float.TryParse(value, out x)) return;
                        _x = x;
                        CX();
                        UpdateXMenuText();
                    }

                    /// <summary>
                    /// Sets the Y value
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void SetY(MenuItem sender)
                    {
                        string value = Utils.ShowInGameKeyboard(null, _y.ToString(), MAX_INPUT_LENGTH);
                        if (string.IsNullOrEmpty(value)) return;
                        float y = 0f;
                        if (!float.TryParse(value, out y)) return;
                        _y = y;
                        CY();
                        UpdateYMenuText();
                    }

                    /// <summary>
                    /// Sets the Z value
                    /// </summary>
                    /// <param name="sender">Source menu item</param>
                    public static void SetZ(MenuItem sender)
                    {
                        string value = Utils.ShowInGameKeyboard(null, _z.ToString(), MAX_INPUT_LENGTH);
                        if (string.IsNullOrEmpty(value)) return;
                        float z = 0f;
                        if (!float.TryParse(value, out z)) return;
                        _z = z;
                        CZ();
                        UpdateZMenuText();
                    }

                    /// <summary>
                    /// Teleports by offsets
                    /// </summary>
                    /// <param name="sender"></param>
                    public static void Teleport(MenuItem sender)
                    {
                        int handle = Game.Player.Character.Handle;
                        if (Game.Player.Character.IsInVehicle())
                        {
                            handle = Game.Player.Character.CurrentVehicle.Handle;
                        }

                        RDR2.Math.Vector3 c = Game.Player.Character.Position;
                        Function.Call(Hash.SET_ENTITY_COORDS_NO_OFFSET, handle, c.X + _x, c.Y + _y, c.Z + _z, 0, 0, 1);
                        Utils.ShowNotification(GlobalConst.Message.XYZ_TELEPORTED);
                    }
                }
            }
        }
    }
}
