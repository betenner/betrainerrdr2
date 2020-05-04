//////////////////////////////////////////////
//   BE Trainer.NET for Grand Theft Auto V
//             by BE.Tenner
//      Copyright (c) BE Group 2015-2017
//               Thanks to
//    ScriptHookV & ScriptHookVDotNet
//  Native Trainer & Enhanced Native Trainer
//////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BETrainerRdr2.Weather
{
    /// <summary>
    /// Weather storage
    /// </summary>
    public static class WeatherStorage
    {
        public static readonly WeatherData[] WEATHERS = 
        {
            new WeatherData(Utils.CSML("Sunny", "晴天"), "SUNNY"),
            new WeatherData(Utils.CSML("Misty", "轻雾"), "MISTY"),
			new WeatherData(Utils.CSML("Foggy", "霧"), "FOG"),
			new WeatherData(Utils.CSML("Cloudy", "多云"), "CLOUDS"),
			new WeatherData(Utils.CSML("Overcast", "阴天"), "OVERCAST"),
			new WeatherData(Utils.CSML("Overcast Dark", "大阴天"), "OVERCASTDARK"),
			new WeatherData(Utils.CSML("Drizzle", "小雨"), "DRIZZLE"),
			new WeatherData(Utils.CSML("Rain", "雨"), "RAIN"),
			new WeatherData(Utils.CSML("Stormy", "暴雨"), "THUNDER"),
			new WeatherData(Utils.CSML("Thunder Storm", "雷暴"), "THUNDERSTORM"),
			new WeatherData(Utils.CSML("Hurricane", "飓风"), "HURRICANE"),
		    new WeatherData(Utils.CSML("High Pressure", "高气压"), "HIGHPRESSURE"),
		    new WeatherData(Utils.CSML("Shower", "阵雨"), "SHOWER"),
		    new WeatherData(Utils.CSML("Snow", "雪"), "SNOW"),
			new WeatherData(Utils.CSML("Light Snow", "小雪"), "SNOWLIGHT"),
			new WeatherData(Utils.CSML("Snow Clearing", "雪转晴"), "SNOWCLEARING"),
			new WeatherData(Utils.CSML("Blizzard", "暴风雪"), "BLIZZARD"),
			new WeatherData(Utils.CSML("Ground Blizzard", "地表暴风雪"), "GROUNDBLIZZARD"),
			new WeatherData(Utils.CSML("Light Snow", "小雪"), "SNOWLIGHT"),
			new WeatherData(Utils.CSML("Hail", "冰雹"), "HAIL"),
			new WeatherData(Utils.CSML("Sleet", "雨夹雪"), "SLEET"),
			new WeatherData(Utils.CSML("Whiteout", "白昼"), "WHITEOUT"),
			new WeatherData(Utils.CSML("Sandstorm", "沙尘暴"), "SANDSTORM"),
		};
    }
}
