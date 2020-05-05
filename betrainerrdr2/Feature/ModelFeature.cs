///////////////////////////////////////////////
//   BE Trainer.NET for Red Dead Redemption 2
//               by BE.Tenner
//        Copyright (c) BE Group 2020
//                Thanks to
//   ScriptHookRdr2 & ScriptHookRdr2DotNet
//             Native Trainer
///////////////////////////////////////////////

using BETrainerRdr2.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDR2;
using RDR2.Native;
using BETrainerRdr2.Model;
using RDR2.Math;

namespace BETrainerRdr2
{
    public static partial class Feature
    {
        /// <summary>
        /// Model features
        /// </summary>
        public static class Model
        {
            /// <summary>
            /// Spawn model
            /// </summary>
            /// <param name="sender">MenuItem</param>
            public static unsafe void Spawn(MenuItem sender)
            {
                ModelData md = sender.Data as ModelData;
                int model = Function.Call<int>(Hash.GET_HASH_KEY, md.ModelName);
                if (Function.Call<bool>(Hash.IS_MODEL_IN_CDIMAGE, model) && Function.Call<bool>(Hash.IS_MODEL_VALID, model))
                {
                    Function.Call(Hash.REQUEST_MODEL, model, false);
                    while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, model)) Script.Wait(0);
                    Vector3 coords = Function.Call<Vector3>(Hash.GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS, Game.Player.Character.Handle, 0f, 3f, -0.3f);
                    float playerHeading = Function.Call<float>(Hash.GET_ENTITY_HEADING, Game.Player.Character.Handle);
                    int ped = Function.Call<int>(Hash.CREATE_PED, model, coords.X, coords.Y, coords.Z, playerHeading + 180, 0, 0, 0, 0);
                    Function.Call((Hash)GlobalConst.CustomHash.SET_PED_VISIBLE, ped, true);
                    Function.Call(Hash.SET_PED_AS_NO_LONGER_NEEDED, &ped);
                    Function.Call(Hash.SET_MODEL_AS_NO_LONGER_NEEDED, model);
                    Utils.ShowNotification(Utils.FormatML(GlobalConst.Message.MODEL_SPAWNED, md.Name));
                }
            }
        }
    }
}
