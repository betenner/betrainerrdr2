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

namespace BETrainerRdr2.Weather
{
    /// <summary>
    /// Weather data
    /// </summary>
    public class WeatherData
    {
        /// <summary>
        /// Name
        /// </summary>
        public MLString Name = null;

        /// <summary>
        /// Internal name
        /// </summary>
        public string InternalName = null;

        /// <summary>
        /// Creates a weather data
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="internalName">Internal name</param>
        public WeatherData(MLString name, string internalName)
        {
            Name = name;
            InternalName = internalName;
        }
    }
}
