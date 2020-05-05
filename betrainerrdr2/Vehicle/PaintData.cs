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

namespace BETrainerRdr2.Vehicle
{
    /// <summary>
    /// Paint data for vehicle
    /// </summary>
    public class PaintData
    {
        /// <summary>
        /// Name of the paint
        /// </summary>
        public string Name = null;

        /// <summary>
        /// Value of the paint
        /// </summary>
        public int InternalValue = 0;

        /// <summary>
        /// Creates a paint data
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="internalValue">Internal value</param>
        public PaintData(string name, int internalValue)
        {
            Name = name;
            InternalValue = internalValue;
        }
    }
}
