///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using BETrainerRdr2.Menu;

namespace BETrainerRdr2
{
    /// <summary>
    /// Language control
    /// </summary>
    public static class Language
    {
        /// <summary>
        /// Default language code.
        /// </summary>
        public const string DEFAULT = ENGLISH;

        /// <summary>
        /// Language code for English
        /// </summary>
        public const string ENGLISH = "enUS";

        /// <summary>
        /// Language code for Chinese Simplified
        /// </summary>
        public const string CHINESE_SIMPLIFIED = "zhCN";

        /// <summary>
        /// Sets trainer language to English
        /// </summary>
        /// <param name="sender">Source menu item</param>
        public static void SetToEnglish(MenuItem sender)
        {
            Trainer.LanguageCode = ENGLISH;
            Feature.Config.DoAutoSave();
        }

        /// <summary>
        /// Sets trainer language to Chinese Simplified
        /// </summary>
        /// <param name="sender">Source menu item</param>
        public static void SetToChineseSimplified(MenuItem sender)
        {
            Trainer.LanguageCode = CHINESE_SIMPLIFIED;
            Feature.Config.DoAutoSave();
        }
    }
}
