using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDotNet1
{
    class Scene : IScene
    {
        private readonly Random rnd = new Random();

        public SceneTypes SceneType { get; set; }
        public string Description { get; set; }
        public string SuccessPathDescription { get; set; }
        public string FailurePathDescription { get; set; }
        public bool IsRandom { get; set; }
        public double SuccessChance { get; set; }
        public IScene SuccessPath { get; set; }
        public IScene FailurePath { get; set; }

        public IScene GetNextScene(double modifier = 0.0)
        {
            if(SceneType == SceneTypes.Text)
            {
                return SuccessPath;
            }
            if (IsRandom)
            {
                return rnd.NextDouble() + modifier >= SuccessChance 
                    ? SuccessPath 
                    : FailurePath; 
            }
            return SuccessPath;
        }

        public bool IsEnding()
        {
            switch (SceneType)
            {
                case SceneTypes.GoodEnding:
                case SceneTypes.BadEnding:
                    return true;
                default:
                    return false;
            }
        }
    }
}
