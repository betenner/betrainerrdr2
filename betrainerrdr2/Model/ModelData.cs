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

namespace BETrainerRdr2.Model
{
    /// <summary>
    /// Model data
    /// </summary>
    public class ModelData
    {
        /// <summary>
        /// Type of model
        /// </summary>
        public enum ModelType
        {
            None = 0,
            Animal = 1,
            Horse = 1 << 1,
            Dog = 1 << 2,
            Fish = 1 << 3,
            Male = 1 << 4,
            Female = 1 << 5,
            Young = 1 << 6,
            MiddleAged = 1 << 7,
            Old = 1 << 8,
            Cutscene = 1 << 9,
        }

        /// <summary>
        /// Name of model
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Internal name of model
        /// </summary>
        public string ModelName { get; private set; }

        public ModelType Type { get; private set; }

        /// <summary>
        /// Creates a model data
        /// </summary>
        /// <param name="name">Name of model</param>
        /// <param name="modelName">Internal name of model</param>
        /// <param name="type">Type of model</param>
        public ModelData(string name, string modelName, ModelType type)
        {
            Name = name;
            ModelName = modelName;
            Type = type;
        }

        public static ModelData Create(string modelName, string name, bool animal, bool horse, bool dog, bool fish, bool male, bool female, bool young, bool middleAged, bool old, bool cutscene)
        {
            ModelType type = 0;
            if (animal) type |= ModelType.Animal;
            if (horse) type |= ModelType.Horse;
            if (dog) type |= ModelType.Dog;
            if (fish) type |= ModelType.Fish;
            if (male) type |= ModelType.Male;
            if (female) type |= ModelType.Female;
            if (young) type |= ModelType.Young;
            if (middleAged) type |= ModelType.MiddleAged;
            if (old) type |= ModelType.Old;
            if (cutscene) type |= ModelType.Cutscene;
            return new ModelData(name, modelName, type);
        }
    }
}
