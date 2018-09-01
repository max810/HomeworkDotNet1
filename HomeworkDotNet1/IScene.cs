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
        double SuccessChance { get; set; }

        IScene SuccessPath { get; }
        IScene FailurePath { get; }

        IScene GetNextScene(double modifier = 0.0);
       
        //change success/fail to left/right
    }
}