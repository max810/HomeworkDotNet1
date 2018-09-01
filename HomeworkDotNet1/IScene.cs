namespace HomeworkDotNet1
{
    public interface IScene
    {
        // remove sets
        SceneTypes SceneType { get; set; }
        string Description { get; set; }
        string SuccessPathDescription { get; set; }
        string FailurePathDescription { get; set; }
        bool IsRandom { get; set; }
        double LuckNeeded { get; set; }

        IScene SuccessPath { get; set; }
        IScene FailurePath { get; set; }

        bool IsEnding();
        IScene GetNextScene(double luckModifier = 0.0);
       
        // ? change success/fail to left/right
    }
}