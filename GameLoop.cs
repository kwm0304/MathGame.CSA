using MathGame.CSA.Enums;
using MathGame.CSA.Models;

namespace MathGame.CSA;

public class GameLoop
{
  //StartGame 
  public static void DisplayMainMenu()
  {
    Printer.PrintHeader();
    string response = Printer.PrintMainMenuOptions();
    if (response == "Leaderboard")
    {
      Printer.PrintLeaderboard();
    }
    else
    {
      Run();
    }
  }
  public static void Run()
  {
    GetGameSettings();
  }
  public static void GetGameSettings()
  {
    Console.Clear();
    GameSettings settings;
    Difficulty gameDifficulty = Printer.PrintDifficultyPrompt();
    bool isGameRandom = Printer.PrintRandomPrompt();
    int numberOfQuestions = Printer.PrintNumberOfQuestionsPrompt();
    if (!isGameRandom)
    {
      Operation gameOperation = Printer.PrintOperationPrompt();
      settings = new GameSettings(gameOperation, gameDifficulty, isGameRandom, numberOfQuestions);
    }
    else
    {
      settings = new GameSettings(gameDifficulty, isGameRandom, numberOfQuestions);
    }
  }
  //  DisplayInitialPrompts - set GameSettings
  //  StartTimer
  //GenerateQuetsion
  //EndGame
  //  Create new LeaderboardEntry
  //  Leaderboard.AddEntry
}
