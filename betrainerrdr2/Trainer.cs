///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using System;
using RDR2;

namespace BETrainerRdr2
{
    public class Trainer : Script
    {
        /// <summary>
        /// Is the trainer initializing
        /// </summary>
        public static bool IsInitializing = false;

        /// <summary>
        /// Frame counter
        /// </summary>
        public static int FrameCounter = 0;

        /// <summary>
        /// Whether showing the trainer menu
        /// </summary>
        public static bool ShowingTrainerMenu = false;

        /// <summary>
        /// Language code
        /// </summary>
        public static string LanguageCode = Language.ENGLISH;

        public Trainer()
        {
            IsInitializing = true;

            // Show trainer info
            Utils.ShowNotification(GlobalConst.Message.TRAINER_INITIALIZING);

            // Load configurations
            Configuration.Load();

            // Initialization
            Menu.MenuStorage.InitMenus();

            // Init features
            Feature.Init();

            // Key handling
            this.KeyDown += Trainer_KeyDown;

            // Tick handling
            this.Tick += Trainer_Tick;
            //Debug.Log("Interval: {0}", this.Interval);
            //this.Interval = 1;

            Utils.ShowNotification(GlobalConst.Message.TRAINER_INITIALIZED);

            IsInitializing = false;
        }

        void Trainer_Tick(object sender, EventArgs e)
        {
            if (Game.IsPaused) return;
            
            FrameCounter++;

            Update();
            Draw();
        }

        void Trainer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Game.IsPaused) return;

            if (e.KeyCode == Configuration.InputKey.StopVehicle)
            {
                Feature.Vehicle.StopVehicle();
            }

            else if (e.KeyCode == Configuration.InputKey.MenuBack)
            {
                if (ShowingTrainerMenu)
                {
                    Menu.MenuStorage.ReturnToPrevMenu();
                }
            }
            
            else if (e.KeyCode == Configuration.InputKey.MenuDown)
            {
                if (ShowingTrainerMenu)
                {
                    Menu.Menu menu = Menu.MenuStorage.GetCurrentMenu();
                    if (menu != null) menu.MoveDown();
                }
            }
            
            else if (e.KeyCode == Configuration.InputKey.MenuLeft)
            {
                if (ShowingTrainerMenu)
                {
                    Menu.Menu menu = Menu.MenuStorage.GetCurrentMenu();
                    if (menu != null) menu.MoveLeft();
                }
            }
            
            else if (e.KeyCode == Configuration.InputKey.MenuRight)
            {
                if (ShowingTrainerMenu)
                {
                    Menu.Menu menu = Menu.MenuStorage.GetCurrentMenu();
                    if (menu != null) menu.MoveRight();
                }
            }
            
            else if (e.KeyCode == Configuration.InputKey.MenuSelect)
            {
                if (ShowingTrainerMenu)
                {
                    Menu.Menu menu = Menu.MenuStorage.GetCurrentMenu();
                    if (menu != null) menu.Activate();
                }
            }
            
            else if (e.KeyCode == Configuration.InputKey.MenuUp)
            {
                if (ShowingTrainerMenu)
                {
                    Menu.Menu menu = Menu.MenuStorage.GetCurrentMenu();
                    if (menu != null) menu.MoveUp();
                }
            }
            
            else if (e.KeyCode == Configuration.InputKey.ToggleMenu)
            {
                ShowingTrainerMenu = !ShowingTrainerMenu;
                Menu.MenuStorage.PlayMenuBeep();
            }

        }

        void Draw()
        {
            if (ShowingTrainerMenu)
            {
                Menu.Menu menu = Menu.MenuStorage.GetCurrentMenu();
                if (menu != null) menu.Draw();
            }

            Feature.Location.Draw();
            Feature.DateTimeSpeed.Draw();
        }

        void Update()
        {
            Feature.Update();
        }
    }
}
