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
using BETrainerRdr2.Menu;
using System.Drawing;
using RDR2;
using RDR2.Native;

namespace BETrainerRdr2
{
    public partial class Feature
    {
        /// <summary>
        /// Date time speed features
        /// </summary>
        public static class DateTimeSpeed
        {
            private static StringBuilder sbShowTime = new StringBuilder(15);
            private const string SHOW_TIME_FORMAT = "{0:HH:mm} / {1:HH:mm}";
            private static readonly Point SHOWTIME_POS = new Point(960, 920);
            private const float SHOWTIME_SCALE = 0.45f;
            private static readonly Color SHOWTIME_TEXT_COLOR = Color.White;
            private const GlobalConst.HAlignment SHOWTIME_ALIGN = GlobalConst.HAlignment.Center;
            private const float DEFAULT_SPEED = 1.0f;
            private const float SPEED_075 = 0.75f;
            private const float SPEED_050 = 0.50f;
            private const float SPEED_025 = 0.25f;
            private const float SPEED_010 = 0.10f;
            private const float SPEED_000 = 0.00f;
            private const float SPEED_DELTA = 0.01f;

            public static bool ShowTime = false;
            public static bool Paused = false;
            public static bool SyncWithSystem = false;
            public static float AimingSpeed = DEFAULT_SPEED;
            public static bool UseRealTimeScale = false;

            private static float _gameSpeed = DEFAULT_SPEED;

            private static DateTime _setDateTime = DateTime.Now;
            private static DateTime _lastRealDateTime;
            private static DateTime _lastGameDateTime;

            /// <summary>
            /// Initializes features
            /// </summary>
            public static void Init()
            {
                Debug.Log("DateTimeSpeed.Init");
                Debug.Log("DateTimeSpeed.Init.SetPaused");
                SetPaused(MenuStorage.MenuItems.DateTimeSpeed.Paused);
                Debug.Log("DateTimeSpeed.Init.SetShowTime");
                SetShowTime(MenuStorage.MenuItems.DateTimeSpeed.ShowTime);
                Debug.Log("DateTimeSpeed.Init.SetSyncWithSystem");
                SetSyncWithSystem(MenuStorage.MenuItems.DateTimeSpeed.SyncWithSystem);
            }

            /// <summary>
            /// Updates features
            /// </summary>
            public static void Update()
            {
                // Sync
                if (SyncWithSystem)
                {
                    SetGameDateTime(DateTime.Now);
                }

                // Use real time scale
                else if (UseRealTimeScale)
                {
                    long span = DateTime.Now.Ticks - _lastRealDateTime.Ticks;
                    SetGameDateTime(_lastGameDateTime.AddTicks(span));
                }

                // Game & aiming speed
                if (Game.Player.CanControlCharacter && Game.Player.IsAiming)
                {
                    Game.TimeScale = AimingSpeed;
                }
                else if (Game.Player.CanControlCharacter)
                {
                    Game.TimeScale = _gameSpeed;
                }
                else
                {
                    Game.TimeScale = DEFAULT_SPEED;
                }
            }

            public static void Draw()
            {
                DrawTime();
            }

            private static void DrawTime()
            {
                // Show time
                if (ShowTime)
                {
                    sbShowTime.Clear();
                    sbShowTime.AppendFormat(SHOW_TIME_FORMAT, GetGameDateTime(), DateTime.Now);

                    Utils.DrawText(sbShowTime.ToString(), SHOWTIME_POS.X, SHOWTIME_POS.Y,
                        SHOWTIME_ALIGN, SHOWTIME_TEXT_COLOR, SHOWTIME_SCALE);
                }
            }

            /// <summary>
            /// Pre-enters set date time menu
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void PreEnterSetDateTime(MenuItem sender)
            {
                _setDateTime = GetGameDateTime();
                RefreshSetDateTimeMenu();
            }

            /// <summary>
            /// Hour forward
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void HourForward(MenuItem sender)
            {
                SetHourForward(1);
            }

            /// <summary>
            /// Hour backward
            /// </summary>
            /// <param name="sender"></param>
            public static void HourBackward(MenuItem sender)
            {
                SetHourBackward(1);
            }

            /// <summary>
            /// Day forward
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void DayForward(MenuItem sender)
            {
                SetHourForward(24);
            }

            /// <summary>
            /// Day backward
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void DayBackward(MenuItem sender)
            {
                SetHourBackward(24);
            }

            /// <summary>
            /// Sets hour backward
            /// </summary>
            /// <param name="hours">Hours</param>
            private static void SetHourBackward(int hours)
            {
                SetHourForward(-hours);
            }

            /// <summary>
            /// Sets hour forward
            /// </summary>
            /// <param name="hours">Hours</param>
            private static void SetHourForward(int hours)
            {
                DateTime time = GetGameDateTime();
                SetGameDateTime(time.AddHours(hours));
            }

            /// <summary>
            /// Sets in-game date time
            /// </summary>
            /// <param name="dateTime">Date time</param>
            private static void SetGameDateTime(DateTime dateTime)
            {
                SetGameDateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
            }

            /// <summary>
            /// Sets in-game date time
            /// </summary>
            /// <param name="year">Year</param>
            /// <param name="month">Month</param>
            /// <param name="day">Day</param>
            /// <param name="hour">Hour</param>
            /// <param name="minute">Minute</param>
            /// <param name="second">Second</param>
            private static void SetGameDateTime(int year, int month, int day, int hour, int minute, int second)
            {
                Function.Call(Hash.SET_CLOCK_DATE, day, month, year);
                Function.Call(Hash.SET_CLOCK_TIME, hour, minute, second);
            }

            /// <summary>
            /// Gets the current in-game date time
            /// </summary>
            /// <returns></returns>
            public static DateTime GetGameDateTime()
            {
                int year = Function.Call<int>(Hash.GET_CLOCK_YEAR);
                int month = Function.Call<int>(Hash.GET_CLOCK_MONTH);
                int day = Function.Call<int>(Hash.GET_CLOCK_DAY_OF_MONTH);
                int hour = Function.Call<int>(Hash.GET_CLOCK_HOURS);
                int minute = Function.Call<int>(Hash.GET_CLOCK_MINUTES);
                int second = Function.Call<int>(Hash.GET_CLOCK_SECONDS);
                try
                {
                    return new DateTime(year, month, day, hour, minute, second);
                }
                catch
                {
                    return DateTime.Now;
                }

            }

            /// <summary>
            /// Sets show time
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetShowTime(MenuItem sender)
            {
                ShowTime = sender.On;
                Config.DoAutoSave();
            }

            /// <summary>
            /// Sets paused
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetPaused(MenuItem sender)
            {
                Paused = sender.On;
                Function.Call(Hash.PAUSE_CLOCK, Paused);
                Config.DoAutoSave();
            }

            /// <summary>
            /// Sets sync with system
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetSyncWithSystem(MenuItem sender)
            {
                SyncWithSystem = sender.On;
                Config.DoAutoSave();
            }

            /// <summary>
            /// Increases year
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void IncYear(MenuItem sender)
            {
                _setDateTime = _setDateTime.AddYears(1);
                RefreshSetDateTimeMenu();
            }

            /// <summary>
            /// Decreases year
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void DecYear(MenuItem sender)
            {
                _setDateTime = _setDateTime.AddYears(-1);
                RefreshSetDateTimeMenu();
            }

            /// <summary>
            /// Increases Month
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void IncMonth(MenuItem sender)
            {
                _setDateTime = _setDateTime.AddMonths(1);
                RefreshSetDateTimeMenu();
            }

            /// <summary>
            /// Decreases Month
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void DecMonth(MenuItem sender)
            {
                _setDateTime = _setDateTime.AddMonths(-1);
                RefreshSetDateTimeMenu();
            }

            /// <summary>
            /// Increases Day
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void IncDay(MenuItem sender)
            {
                _setDateTime = _setDateTime.AddDays(1);
                RefreshSetDateTimeMenu();
            }

            /// <summary>
            /// Decreases Day
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void DecDay(MenuItem sender)
            {
                _setDateTime = _setDateTime.AddDays(-1);
                RefreshSetDateTimeMenu();
            }

            /// <summary>
            /// Increases Hour
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void IncHour(MenuItem sender)
            {
                _setDateTime = _setDateTime.AddHours(1);
                RefreshSetDateTimeMenu();
            }

            /// <summary>
            /// Decreases Hour
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void DecHour(MenuItem sender)
            {
                _setDateTime = _setDateTime.AddHours(-1);
                RefreshSetDateTimeMenu();
            }

            /// <summary>
            /// Increases Minute
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void IncMinute(MenuItem sender)
            {
                _setDateTime = _setDateTime.AddMinutes(1);
                RefreshSetDateTimeMenu();
            }

            /// <summary>
            /// Decreases Minute
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void DecMinute(MenuItem sender)
            {
                _setDateTime = _setDateTime.AddMinutes(-1);
                RefreshSetDateTimeMenu();
            }

            /// <summary>
            /// Increases Second
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void IncSecond(MenuItem sender)
            {
                _setDateTime.AddSeconds(1);
                RefreshSetDateTimeMenu();
            }

            /// <summary>
            /// Decreases Second
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void DecSecond(MenuItem sender)
            {
                _setDateTime = _setDateTime.AddSeconds(-1);
                RefreshSetDateTimeMenu();
            }

            /// <summary>
            /// Sets date time
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void Set(MenuItem sender)
            {
                SetGameDateTime(_setDateTime);
            }

            /// <summary>
            /// Sets to current date time
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetToCurrent(MenuItem sender)
            {
                _setDateTime = GetGameDateTime();
                RefreshSetDateTimeMenu();
                SetGameDateTime(_setDateTime);
            }

            /// <summary>
            /// Sets to system date time
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetToSystem(MenuItem sender)
            {
                _setDateTime = DateTime.Now;
                RefreshSetDateTimeMenu();
                SetGameDateTime(_setDateTime);
            }

            /// <summary>
            /// Refreshes set date time menu
            /// </summary>
            public static void RefreshSetDateTimeMenu()
            {
                MenuStorage.MenuItems.DateTimeSpeed.SetDateTimeMenu.Year.Text = Utils.FormatML(MenuText.DateTimeSpeed.SetDateTime.YEAR, _setDateTime.Year);
                MenuStorage.MenuItems.DateTimeSpeed.SetDateTimeMenu.Month.Text = Utils.FormatML(MenuText.DateTimeSpeed.SetDateTime.MONTH, _setDateTime.Month);
                MenuStorage.MenuItems.DateTimeSpeed.SetDateTimeMenu.Day.Text = Utils.FormatML(MenuText.DateTimeSpeed.SetDateTime.DAY, _setDateTime.Day);
                MenuStorage.MenuItems.DateTimeSpeed.SetDateTimeMenu.Hour.Text = Utils.FormatML(MenuText.DateTimeSpeed.SetDateTime.HOUR, _setDateTime.Hour);
                MenuStorage.MenuItems.DateTimeSpeed.SetDateTimeMenu.Minute.Text = Utils.FormatML(MenuText.DateTimeSpeed.SetDateTime.MINUTE, _setDateTime.Minute);
                MenuStorage.MenuItems.DateTimeSpeed.SetDateTimeMenu.Second.Text = Utils.FormatML(MenuText.DateTimeSpeed.SetDateTime.SECOND, _setDateTime.Second);
            }

            /// <summary>
            /// Updates game speed in menu
            /// </summary>
            public static void UpdateGameSpeed()
            {
                MenuStorage.MenuItems.DateTimeSpeed.SetGameSpeedMenu.Speed.Text = Utils.FormatML(MenuText.DateTimeSpeed.SetGameSpeed.SPEED, _gameSpeed);
            }

            /// <summary>
            /// Updates aiming speed in menu
            /// </summary>
            public static void UpdateAimingSpeed()
            {
                MenuStorage.MenuItems.DateTimeSpeed.SetAimingSpeedMenu.Speed.Text = Utils.FormatML(MenuText.DateTimeSpeed.SetAimingSpeed.SPEED, AimingSpeed);
            }

            /// <summary>
            /// Sets game speed to 100%
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetGameSpeedTo100(MenuItem sender)
            {
                _gameSpeed = DEFAULT_SPEED;
                UpdateGameSpeed();
            }

            /// <summary>
            /// Sets game speed to 75%
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetGameSpeedTo075(MenuItem sender)
            {
                _gameSpeed = SPEED_075;
                UpdateGameSpeed();
            }

            /// <summary>
            /// Sets game speed to 50%
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetGameSpeedTo050(MenuItem sender)
            {
                _gameSpeed = SPEED_050;
                UpdateGameSpeed();
            }

            /// <summary>
            /// Sets game speed to 25%
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetGameSpeedTo025(MenuItem sender)
            {
                _gameSpeed = SPEED_025;
                UpdateGameSpeed();
            }

            /// <summary>
            /// Sets game speed to 10%
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetGameSpeedTo010(MenuItem sender)
            {
                _gameSpeed = SPEED_010;
                UpdateGameSpeed();
            }

            /// <summary>
            /// Sets game speed to 00%
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetGameSpeedTo000(MenuItem sender)
            {
                _gameSpeed = SPEED_000;
                UpdateGameSpeed();
            }

            /// <summary>
            /// Sets aiming speed to 100%
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetAimingSpeedTo100(MenuItem sender)
            {
                AimingSpeed = DEFAULT_SPEED;
                UpdateAimingSpeed();
            }

            /// <summary>
            /// Sets aiming speed to 75%
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetAimingSpeedTo075(MenuItem sender)
            {
                AimingSpeed = SPEED_075;
                UpdateAimingSpeed();
            }

            /// <summary>
            /// Sets aiming speed to 50%
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetAimingSpeedTo050(MenuItem sender)
            {
                AimingSpeed = SPEED_050;
                UpdateAimingSpeed();
            }

            /// <summary>
            /// Sets aiming speed to 25%
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetAimingSpeedTo025(MenuItem sender)
            {
                AimingSpeed = SPEED_025;
                UpdateAimingSpeed();
            }

            /// <summary>
            /// Sets aiming speed to 10%
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetAimingSpeedTo010(MenuItem sender)
            {
                AimingSpeed = SPEED_010;
                UpdateAimingSpeed();
            }

            /// <summary>
            /// Sets aiming speed to 00%
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetAimingSpeedTo000(MenuItem sender)
            {
                AimingSpeed = SPEED_000;
                UpdateAimingSpeed();
            }

            /// <summary>
            /// Increases game speed
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void IncGameSpeed(MenuItem sender)
            {
                _gameSpeed += SPEED_DELTA;
                if (_gameSpeed > DEFAULT_SPEED) _gameSpeed = DEFAULT_SPEED;
                UpdateGameSpeed();
            }

            /// <summary>
            /// Decreases game speed
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void DecGameSpeed(MenuItem sender)
            {
                _gameSpeed -= SPEED_DELTA;
                if (_gameSpeed < SPEED_000) _gameSpeed = SPEED_000;
                UpdateGameSpeed();
            }

            /// <summary>
            /// Increases aiming speed
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void IncAimingSpeed(MenuItem sender)
            {
                AimingSpeed += SPEED_DELTA;
                if (AimingSpeed > DEFAULT_SPEED) AimingSpeed = DEFAULT_SPEED;
                UpdateAimingSpeed();
            }

            /// <summary>
            /// Decreases aiming speed
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void DecAimingSpeed(MenuItem sender)
            {
                AimingSpeed -= SPEED_DELTA;
                if (AimingSpeed < SPEED_000) AimingSpeed = SPEED_000;
                UpdateAimingSpeed();
            }

            /// <summary>
            /// Sets use real time scale.
            /// </summary>
            /// <param name="sender">Source menu item</param>
            public static void SetUseRealTimeScale(MenuItem sender)
            {
                SetUseRealTimeScale(sender.On);            }

            /// <summary>
            /// Sets use real time scale.
            /// </summary>
            /// <param name="on">Is on</param>
            public static void SetUseRealTimeScale(bool on)
            {
                UseRealTimeScale = on;
                if (UseRealTimeScale)
                {
                    _lastRealDateTime = DateTime.Now;
                    _lastGameDateTime = GetGameDateTime();
                }
                Config.DoAutoSave();
            }
        }
    }
}

