namespace HomeworkDotNet1
{
    public interface IScene
    {
        // remove sets
        SceneType SceneType { get; set; }
        string Description { get; set; }
        string SuccessPathDescription { get; set; }
        string FailurePathDescription { get; set; }

        IScene SuccessPathScene { get; set; }
        IScene FailurePathScene { get; set; }

        // user input
        IScene GetNextScene(bool isSuccess);
        IScene GetNextSceneRandom(double modifier = 0.0);
       
        // ? change success/fail to left/right
    }
}