using MathGame.CSA.Enums;

namespace MathGame.CSA.Models;

public class GameSettings
{
  //initialized after collecting user choices
  private int Score { get; set; }
  private Operation InitialOperation { get; set; }
  private Difficulty DifficultySetting { get; set; }
  private bool IsRandom { get; set; }
  private int NumberOfQuestions { get; set; }
  public GameSettings(
    Operation initialOperation, Difficulty difficultySetting,
    bool isRandom, int numberOfQuetsions)
  {
    Score = 0;
    InitialOperation = !isRandom ? initialOperation : ChooseRandomOperation();
    DifficultySetting = difficultySetting;
    IsRandom = isRandom;
    NumberOfQuestions = numberOfQuetsions;
  }

  private Operation ChooseRandomOperation()
  {
    throw new NotImplementedException();
  }

}