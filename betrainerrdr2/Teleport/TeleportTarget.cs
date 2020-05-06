﻿///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

namespace BETrainerRdr2.Teleport
{
    /// <summary>
    /// Teleport target
    /// </summary>
    public class TeleportTarget
    {
        private RDR2.Math.Vector3 _coords;
        private string[] _requiredIPLs = null;
        private string[] _removeIPLs = null;

        /// <summary>
        /// Name of the target
        /// </summary>
        public MLString Name { get; } = null;

        /// <summary>
        /// Coordinate of the target
        /// </summary>
        public RDR2.Math.Vector3 Coords
        {
            get
            {
                return new RDR2.Math.Vector3(_coords.X, _coords.Y, _coords.Z);
            }
        }

        /// <summary>
        /// Gets the count of required IPLs
        /// </summary>
        public int RequiredIPLsCount
        {
            get
            {
                if (_requiredIPLs == null) return 0;
                return _requiredIPLs.Length;
            }
        }

        /// <summary>
        /// Gets the specified required IPL
        /// </summary>
        /// <param name="index">Index of the IPL</param>
        /// <returns></returns>
        public string GetRequiredIPL(int index)
        {
            return _requiredIPLs[index];
        }

        /// <summary>
        /// Gets the count of remove IPLs
        /// </summary>
        public int RemoveIPLsCount
        {
            get
            {
                if (_removeIPLs == null) return 0;
                return _removeIPLs.Length;
            }
        }

        /// <summary>
        /// Gets the specified remove IPL
        /// </summary>
        /// <param name="index">Index of the IPL</param>
        /// <returns></returns>
        public string GetRemoveIPL(int index)
        {
            return _removeIPLs[index];
        }

        /// <summary>
        /// Creates a teleport target instance
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <param name="requiredIPLs">Required IPLs to load</param>
        /// <param name="removeIPLs">Required IPLs to remove</param>
        /// <param name="isLoaded">Is loaded</param>
        public TeleportTarget(MLString name, float x, float y, float z, string[] requiredIPLs = null, string[] removeIPLs = null)
        {
            Name = name;
            _coords = new RDR2.Math.Vector3(x, y, z);
            _requiredIPLs = requiredIPLs;
            _removeIPLs = removeIPLs;
        }
    }
}
