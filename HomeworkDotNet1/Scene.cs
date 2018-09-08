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

        public SceneType SceneType { get; set; }
        public string Description { get; set; }
        public string SuccessPathDescription { get; set; }
        public string FailurePathDescription { get; set; }
        public IScene SuccessPathScene { get; set; }
        public IScene FailurePathScene { get; set; }

        public IScene GetNextScene(bool isSuccess)
        {
            if (IsEnding(this))
            {
                throw new SceneException("Ending scene!");
            }

            return isSuccess ? SuccessPathScene : FailurePathScene;
        }

        public IScene GetNextSceneRandom(double modifier = 0)
        {
            return rnd.NextDouble() + modifier >= 0.5
                    ? SuccessPathScene
                    : FailurePathScene;
        }

        public static bool IsEnding(SceneType sceneType)
        {
            switch (sceneType)
            {
                case SceneType.GoodEnding:
                case SceneType.BadEnding:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsEnding(IScene scene)
        {
            return IsEnding(scene.SceneType);
        }
    }
}
