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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BETrainerRdr2.SkinProps
{
    /// <summary>
    /// Skin/Prop detail info
    /// </summary>
    public struct SkinPropDetail
    {
        /// <summary>
        /// Count of available drawables
        /// </summary>
        public int DrawableCount;

        /// <summary>
        /// Count of available textures
        /// </summary>
        public int TextureCount;

        /// <summary>
        /// Category index
        /// </summary>
        public int Category;

        /// <summary>
        /// Drawable index
        /// </summary>
        public int Drawable;

        /// <summary>
        /// Texture index
        /// </summary>
        public int Texture;
    }
}
