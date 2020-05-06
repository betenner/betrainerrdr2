///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using RDR2.Math;
using RDR2.Native;

namespace BETrainerRdr2.Vehicle
{
    /// <summary>
    /// Vehicle data
    /// </summary>
    public class VehicleData
    {
        public enum VehicleType
        {
            Boat,
            Train,
            Wagon,
            Cannon,
            Misc,
        }

        public struct VehicleInfo
        {
            public VehicleType Type;
            public Vector3 SpawnCoordOffset;
            public float SpawnHeadingOffset;
        }

        public static VehicleInfo GetVehicleInfo(string modelName) 
        {
            VehicleInfo result;
            int model = Function.Call<int>(Hash.GET_HASH_KEY, modelName);
            result.SpawnCoordOffset = new Vector3(1f, 5f, 0f);
            result.SpawnHeadingOffset = 90f;
            result.Type = VehicleType.Wagon;
            if (Function.Call<bool>(Hash.IS_THIS_MODEL_A_BOAT, model))
            {
                result.SpawnCoordOffset = new Vector3(0f, 10f, 0f);
                result.Type = VehicleType.Boat;
            }
            else if (Function.Call<bool>(Hash.IS_THIS_MODEL_A_TRAIN, model))
            {
                result.SpawnCoordOffset = new Vector3(0f, 5f, -1f);
                result.Type = VehicleType.Train;
            }
            else if (modelName == "gatling_gun" || modelName == "gatlingMaxim02" || modelName == "hotchkiss_cannon" || modelName == "breach_cannon")
            {
                result.SpawnCoordOffset = new Vector3(0f, 3f, 0f);
                result.SpawnHeadingOffset = 0f;
                result.Type = VehicleType.Cannon;
            }
            else if (modelName == "hotAirBalloon01")
            {
                result.SpawnCoordOffset = new Vector3(0f, 5f, 0f);
                result.SpawnHeadingOffset = 0f;
                result.Type = VehicleType.Misc;
            }
            return result;
        }

        /// <summary>
        /// Name of the vehicle
        /// </summary>
        public string Name = null;

        /// <summary>
        /// Internal value of the vehicle
        /// </summary>
        public string InternalValue = null;

        public VehicleInfo Info;
        public bool WagonOnly = false;

        /// <summary>
        /// Creates a vehicle data
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="internalValue">Internal value</param>
        public VehicleData(string name, string internalValue = null)
        {
            Name = name;
            InternalValue = internalValue ?? name;
        }
    }
}
