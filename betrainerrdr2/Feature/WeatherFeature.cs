///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using BETrainerRdr2.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDR2;
using RDR2.Native;
using BETrainerRdr2.Weather;

namespace BETrainerRdr2
{
    public static partial class Feature
    {
        /// <summary>
        /// Weather features
        /// </summary>
        public static class Weather
        {
            private const float WIND_SPEED = 50f;

            public static bool Wind = false;
            public static bool Freeze = false;

            /// <summary>
            /// Initializes features
            /// </summary>
            public static void Init()
            {
                Debug.Log("Weather.Init");
                Debug.Log("Weather.Init.SetWind");
                SetWind(MenuStorage.MenuItems.Weather.Wind);
                Debug.Log("Weather.Init.SetFreeze");
                SetFreeze(MenuStorage.MenuItems.Weather.Freeze);
            }

            /// <summary>
            /// Updates features
            /// </summary>
            public static void Update()
            {
                if (Freeze) Function.Call((Hash)GlobalConst.CustomHash.FREEZE_WEATHER, true);
            }

            /// <summary>
            /// Sets wind
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetWind(MenuItem sender)
            {
                Wind = sender.On;
                Config.DoAutoSave();
                if (Wind)
                {
                    Function.Call(Hash.SET_WIND_SPEED, WIND_SPEED);
                    Function.Call(Hash.SET_WIND_DIRECTION, Game.Player.Character.Heading);
                }
                else
                {
                    Function.Call(Hash.SET_WIND_SPEED, 0f);
                }
            }

            /// <summary>
            /// Sets freeze
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetFreeze(MenuItem sender)
            {
                Freeze = sender.On;
                Config.DoAutoSave();
            }

            /// <summary>
            /// Sets weather
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetWeather(MenuItem sender)
            {
                WeatherData wd = (sender.Data as WeatherData);
                Function.Call(Hash.CLEAR_OVERRIDE_WEATHER);
                int hash = Function.Call<int>(Hash.GET_HASH_KEY, wd.InternalName);
                Function.Call(Hash._SET_WEATHER_TYPE, hash, true, true, false, 0f, false);
                Function.Call(Hash.CLEAR_WEATHER_TYPE_PERSIST);
                Utils.ShowNotification(Utils.FormatML(GlobalConst.Message.WEATHER_SET, wd.Name));
            }
        }
    }
}
