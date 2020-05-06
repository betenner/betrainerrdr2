///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using BETrainerRdr2.Menu;

namespace BETrainerRdr2.Teleport
{
    /// <summary>
    /// Teleport targets storage
    /// </summary>
    public static class TeleportTargetStorage
    {
        /// <summary>
        /// Map locations
        /// </summary>
        public static readonly TeleportTarget[] MAPLOCATIONS =
        {
            new TeleportTarget ( "SOUTH MAP",      -5311.2583f,  -4612.00f,   -10.63389f ),
            new TeleportTarget ( "SOUTH GUAMA",    1315.66381f,  -6815.48f,   42.377101f ),
            new TeleportTarget ( "ANNESBURG",      2898.593994f, 1239.85253f, 44.073299f ),
            new TeleportTarget ( "STRAWBERRY",       -1725.22143f, -418.11560f, 153.55740f ),
            new TeleportTarget ( "VALENTINE",     -213.152496f, 691.802979f, 112.37100f ),
            new TeleportTarget ( "RHODES",           1282.707520f, -1275.7485f, 74.945099f ),
            new TeleportTarget ( "SAINT DENIS",    2336.584961f, -1106.2358f, 44.737598f ),
            new TeleportTarget ( "WAPITI",           538.738525f,  2217.46557f, 240.23280f ),
            new TeleportTarget ( "BUTCHERCREEK",   2552.203613f, 835.510010f, 81.183098f ),
            new TeleportTarget ( "BLACKWATER",       -798.338379f, -1238.9395f, 43.537899f ),
            new TeleportTarget ( "BEECHERS",       -1653.19738f, -1448.8156f, 82.503502f ),
            new TeleportTarget ( "CALIGA HALL",    1705.509888f, -1386.3237f, 42.884998f ),
            new TeleportTarget ( "BRAITHWAITE",    1011.190674f, -1661.6768f, 45.918301f ),
            new TeleportTarget ( "VANHORN",         2982.234863f, 445.724915f, 51.491501f ),
            new TeleportTarget ( "CORNWALL",       437.7247920f, 494.582092f, 107.67649f ),
            new TeleportTarget ( "COLTER",           -1371.6590f,  2388.5073f,  307.7218f ),
            new TeleportTarget ( "EMERALD RANCH",  1332.332642f, 300.425110f, 86.306297f ),
            new TeleportTarget ( "PRONGHORN",     -2616.57714f, 519.256775f, 144.10809f ),
            new TeleportTarget ( "MANZANITA POST", -1977.98754f, -1545.6749f, 112.87020f ),
            new TeleportTarget ( "LAGRAS",           2111.099121f, -662.25317f, 41.259899f ),
            new TeleportTarget ( "ARMADILLO",     -3622.65527f, -2586.5795f, -15.36900f ),
            new TeleportTarget ( "TUMBLEWEED",       -5382.39453f, -2940.1596f, 1.582700f ),
            new TeleportTarget ( "MACFARLANES RANCH",  -2296.26318f, -2454.4101f, 60.969898f ),
            new TeleportTarget ( "BENEDICT POINT", -5269.60400f, -3411.0588f, -23.15930f ),
        };

        /// <summary>
        /// Teleport categories
        /// </summary>
        public static readonly TeleportCategory[] CATEGORIES =
        {
            new TeleportCategory(MenuText.Location.LocationTeleporter.MAP_LOCATIONS, MAPLOCATIONS),
        };

    }
}
