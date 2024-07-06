using MathGame.CSA.Enums;

namespace MathGame.CSA.Models;

public class GameSettings
{
  //initialized after collecting user choices
  private Operation InitialOperation { get; set; }
  private Difficulty DifficultySetting { get; set; }
  private bool IsRandom { get; set; }
  private int NumberOfQuestions { get; set; }
  public int QuestionsAnswered { get; private set; } = 0;
  public GameSettings(
    Operation initialOperation, Difficulty difficultySetting,
    bool isRandom, int numberOfQuetsions)
  {
    InitialOperation = initialOperation;
    DifficultySetting = difficultySetting;
    IsRandom = isRandom;
    NumberOfQuestions = numberOfQuetsions;
  }
  public GameSettings(Difficulty difficultySetting, bool isRandom, int numberOfQuetsions)
  {
    InitialOperation = ChooseRandomOperation();
    DifficultySetting = difficultySetting;
    IsRandom = isRandom;
    NumberOfQuestions = numberOfQuetsions;
  }

  private Operation ChooseRandomOperation()
  {
    int operationIndex = GlobalConfig.random.Next(GlobalConfig.OperationsList.Count);
    return GlobalConfig.OperationsList[operationIndex];
  }
  public void Increment()
  {
    QuestionsAnswered++;
  }

}
