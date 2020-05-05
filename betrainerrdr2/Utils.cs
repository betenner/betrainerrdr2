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
using RDR2;
using RDR2.UI;
using RDR2.Native;
using System.Windows.Forms;
using System.Xml.Serialization;
using RDR2.Math;
using System.Collections.Specialized;

namespace BETrainerRdr2
{
    /// <summary>
    /// Utilities
    /// </summary>
    public static class Utils
    {
        private const int GROUND_CHECK_WAIT = 100;
        private const float GROUND_CHECK_Z_OFFSET = 3f;
        private static readonly float[] GROUND_CHECK_HEIGHTS =
        {
            100f, 150f, 50f, 0f, 200f, 250f, 300f, 350f, 400f,
            450f, 500f, 550f, 600f, 650f, 700f, 750f, 800f
        };

        /// <summary>
        /// Shows a notification above in-game mini-map
        /// </summary>
        /// <param name="message">Message to show</param>
        public static void ShowNotification(MLString message)
        {
            RDR2.UI.Screen.ShowSubtitle(ML(message));
        }

        /// <summary>
        /// Draw a rectangle
        /// </summary>
        /// <param name="x">X position in pixel</param>
        /// <param name="y">Y position in pixel</param>
        /// <param name="width">Width in pixel</param>
        /// <param name="height">Height in pixel</param>
        /// <param name="color">Color</param>
        /// <param name="screenWidth">Screen width in pixel</param>
        /// <param name="screenHeight">Screen height in pixel</param>
        public static void DrawRect(int x, int y, int width, int height, Color color, int screenWidth = GlobalConst.DEFAULT_SCREEN_WIDTH, int screenHeight = GlobalConst.DEFAULT_SCREEN_HEIGHT)
        {
            float xp = (float)x / screenWidth;
            float yp = (float)y / screenHeight;
            float wp = (float)width / screenWidth;
            float hp = (float)height / screenHeight;
            Function.Call(Hash.DRAW_RECT, xp + wp / 2f, yp + hp / 2f, wp, hp, color.R, color.G, color.B, color.A, 0, 0);
        }

        /// <summary>
        /// Draw text
        /// </summary>
        /// <param name="text">Text to drawn</param>
        /// <param name="x">X position in pixel</param>
        /// <param name="y">Y position in pixel</param>
        /// <param name="align">Horizontal alignment</param>
        /// <param name="color">Color</param>
        /// <param name="scale">Scale</param>
        /// <param name="shadowOffset">Offset of shadow</param>
        /// <param name="shadowColor">Color of shadow</param>
        /// <param name="screenHeight">Height of screen in pixel</param>
        /// <param name="screenWidth">Width of screen in pixel</param>
        public static void DrawText(MLString text, float x, float y, GlobalConst.HAlignment align, Color color, float scale = 0.35f, int shadowOffset = 0, Color shadowColor = new Color(), int screenWidth = GlobalConst.DEFAULT_SCREEN_WIDTH, int screenHeight = GlobalConst.DEFAULT_SCREEN_HEIGHT)
        {
            //TextElement tl = new TextElement(ML(text), new PointF(x, y), scale, color, align, showShadow, showOutline);
            //tl.Draw();

            Function.Call(Hash.SET_TEXT_SCALE, scale, scale);
            Function.Call(Hash._SET_TEXT_COLOR, color.R, color.G, color.B, color.A);
            Function.Call(Hash.SET_TEXT_CENTRE, align == GlobalConst.HAlignment.Center);
            Function.Call(Hash.SET_TEXT_DROPSHADOW, shadowOffset, shadowColor.R, shadowColor.G, shadowColor.B, shadowColor.A);
            Function.Call((Hash)GlobalConst.CustomHash.DRAW_TEXT, Function.Call<string>((Hash)GlobalConst.CustomHash.CREATE_STRING, 10, "LITERAL_STRING", ML(text)), (float)x / screenWidth, (float)y / screenHeight);
        }

        /// <summary>
        /// Play a sound
        /// </summary>
        /// <param name="sound">Sound name</param>
        /// <param name="soundSet">Sound set name</param>
        public static void PlaySound(string sound, string soundSet)
        {
            //Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, sound, soundSet, 0);
        }

        /// <summary>
        /// Shows the in-game keyboard screen and gets the inputted text.
        /// </summary>
        /// <param name="titleId">Title ID (not the title itself!)</param>
        /// <param name="prePopulatedText">Text shows in the input area after keyboard open</param>
        /// <param name="maxInputLength">Max input length</param>
        /// <returns>User inputted text or null if nothing inputted.</returns>
        public static string ShowInGameKeyboard(string titleId = null, string prePopulatedText = null, int maxInputLength = 64)
        {
            Script.Wait(100);

            Function.Call(Hash.DISPLAY_ONSCREEN_KEYBOARD, true, (titleId == null ? "HUD_TITLE" : titleId), "", (prePopulatedText == null ? "" : prePopulatedText), "", "", "", maxInputLength + 1);

            while (Function.Call<int>(Hash.UPDATE_ONSCREEN_KEYBOARD) == 0)
            {
                Script.Wait(0);
            }

            return Function.Call<string>(Hash.GET_ONSCREEN_KEYBOARD_RESULT);
        }

        /// <summary>
        /// Converts m/s into km/h
        /// </summary>
        /// <param name="mps">m/s</param>
        /// <returns></returns>
        public static float Mps2Kph(float mps)
        {
            return mps * 18f / 5f;
        }

        /// <summary>
        /// Converts km/h into mph
        /// </summary>
        /// <param name="kph">km/h</param>
        /// <returns></returns>
        public static float Kph2Mph(float kph)
        {
            return kph * 0.6213711f;
        }

        /// <summary>
        /// Converts m/s into mph
        /// </summary>
        /// <param name="mps">m/s</param>
        /// <returns></returns>
        public static float Mps2Mph(float mps)
        {
            return Kph2Mph(Mps2Kph(mps));
        }

        /// <summary>
        /// Parses an int value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static int ParseInt(string value, int? defaultValue = null)
        {
            int v = 0;
            if (int.TryParse(value, out v)) return v;
            return defaultValue ?? 0;
        }

        /// <summary>
        /// Parses an float value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static float ParseFloat(string value, float? defaultValue = null)
        {
            float v = 0f;
            if (float.TryParse(value, out v)) return v;
            return defaultValue ?? 0f;
        }

        /// <summary>
        /// Parses a boolean value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static bool ParseBool(string value)
        {
            int v = ParseInt(value);
            return (v == 1);
        }

        /// <summary>
        /// Parses a boolean string value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static bool ParseBoolStr(string value, bool? defaultValue = null)
        {
            bool v = false;
            if (bool.TryParse(value, out v)) return v;
            return defaultValue ?? false;
        }

        /// <summary>
        /// Parses a nullable boolean value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static bool? ParseNullableBool(string value)
        {
            int v = ParseInt(value);
            if (v == 0) return false;
            if (v == 1) return true;
            return null;
        }

        /// <summary>
        /// Parses a key
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static Keys ParseKey(string value, Keys? defaultValue = null)
        {
            Keys key = Keys.None;
            if (Enum.TryParse<Keys>(value, out key)) return key;
            return defaultValue ?? Keys.None;
        }

        /// <summary>
        /// Generates a multi-language string with a default string and a Chinese Simplified string
        /// </summary>
        /// <param name="defaultString">Default string</param>
        /// <param name="chineseSimplified">Chinese simplified string</param>
        /// <returns></returns>
        public static MLString CSML(string defaultString, string chineseSimplified = null)
        {
            return new MLString(defaultString, new KeyValuePair<string, string>(Language.CHINESE_SIMPLIFIED, chineseSimplified ?? defaultString));
        }

        /// <summary>
        /// Gets the string with current language code.
        /// </summary>
        /// <param name="str">Multi-string</param>
        /// <returns></returns>
        public static string ML(MLString str)
        {
            return str[Trainer.LanguageCode];
        }

        /// <summary>
        /// Format a multi-language string.
        /// </summary>
        /// <param name="format">String format</param>
        /// <param name="args">Arguments</param>
        /// <returns></returns>
        public static string FormatML(MLString format, params object[] args)
        {
            return string.Format(ML(format), args);
        }

        /// <summary>
        ///  Format a multi-language string.
        /// </summary>
        /// <param name="format">String format</param>
        /// <param name="arg">Argument</param>
        /// <returns></returns>
        public static string FormatML(MLString format, MLString arg)
        {
            return string.Format(ML(format), ML(arg));
        }

        /// <summary>
        /// Gets the handle of the player container.
        /// </summary>
        /// <returns></returns>
        public static int GetPlayerContainerHandle()
        {
            int handle = Game.Player.Character.Handle;
            if (Game.Player.Character.IsOnMount)
            {
                handle = Game.Player.Character.CurrentMount.Handle;
            }
            if (Game.Player.Character.IsInVehicle())
            {
                handle = Game.Player.Character.CurrentVehicle.Handle;
            }
            return handle;
        }

        /// <summary>
        /// Teleports player to target position without ground check.
        /// </summary>
        /// <param name="pos">Target position.</param>
        public static void TeleportWithoutGroundCheck(RDR2.Math.Vector3 pos)
        {
            int handle = Utils.GetPlayerContainerHandle();
            Function.Call(Hash.SET_ENTITY_COORDS, handle, pos.X, pos.Y, pos.Z, 0, 0, 1, false);
        }

        /// <summary>
        /// Teleports player to target position with ground check.
        /// </summary>
        /// <param name="pos">Target position.</param>
        public static void TeleportWithGroundCheck(RDR2.Math.Vector3 pos)
        {
            int handle = Utils.GetPlayerContainerHandle();
            unsafe
            {
                if (!Function.Call<bool>(Hash.GET_GROUND_Z_FOR_3D_COORD, pos.X, pos.Y, GROUND_CHECK_HEIGHTS[0], &pos.Z, false))
                {
                    foreach (float z in GROUND_CHECK_HEIGHTS)
                    {
                        Function.Call(Hash.SET_ENTITY_COORDS_NO_OFFSET, handle, pos.X, pos.Y, z, 0, 0, 1);
                        Script.Wait(GROUND_CHECK_WAIT);
                        if (Function.Call<bool>(Hash.GET_GROUND_Z_FOR_3D_COORD, pos.X, pos.Y, z, &pos.Z, false))
                        {
                            pos.Z += GROUND_CHECK_Z_OFFSET;
                            break;
                        }
                    }
                }
            }
            Function.Call(Hash.SET_ENTITY_COORDS, handle, pos.X, pos.Y, pos.Z, 0, 0, 1, false);
        }
    }
}
