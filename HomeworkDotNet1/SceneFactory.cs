using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDotNet1
{
    public static class SceneFactory
    {
        public static IScene CreateTextScene(string description)
        {
            Scene scene = new Scene()
            {
                Description = description,
                IsRandom = false,
                SuccessChance = 1,
                SceneType = SceneTypes.Text
            };

            return scene;
        }

        public static IScene CreateBadEndingScene(string description)
        {
            Scene scene = new Scene()
            {
                Description = description,
                IsRandom = false,
                SuccessChance = 1,
                SceneType = SceneTypes.BadEnding
            };

            return scene;
        }

        public static IScene CreateGoodEndingScene(string description)
        {
            Scene scene = new Scene()
            {
                Description = description,
                IsRandom = false,
                SuccessChance = 1,
                SceneType = SceneTypes.GoodEnding
            };

            return scene;
        }

        public static IScene LoadDefaultStory()
        {
            throw new NotImplementedException();
        }
    }
}
