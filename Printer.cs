using MathGame.CSA.Enums;
using MathGame.CSA.Models;
using Spectre.Console;

namespace MathGame.CSA;

public class Printer
{
  //will print all console statements, if using ansi will return value
  //need to make enums lists into lists of their values before writing then link after choice is made
  public static void PrintHeader()
  {
    AnsiConsole.WriteLine(@"
.___  ___.      ___   .___________. __    __       _______      ___      .___  ___.  _______ 
|   \/   |     /   \  |           ||  |  |  |     /  _____|    /   \     |   \/   | |   ____|
|  \  /  |    /  ^  \ `---|  |----`|  |__|  |    |  |  __     /  ^  \    |  \  /  | |  |__   
|  |\/|  |   /  /_\  \    |  |     |   __   |    |  | |_ |   /  /_\  \   |  |\/|  | |   __|  
|  |  |  |  /  _____  \   |  |     |  |  |  |    |  |__| |  /  _____  \  |  |  |  | |  |____ 
|__|  |__| /__/     \__\  |__|     |__|  |__|     \______| /__/     \__\ |__|  |__| |_______|
                                                                                             
");
  }
  public static bool PrintRandomPrompt()
  {
    string isRandom = AnsiConsole.Prompt(
      new SelectionPrompt<string>()
      .Title("[yellow]Do you want to randomize operations throughout the game?[/]")
      .AddChoices("Yes", "No")
    );
    return isRandom == "Yes";
  }
  public static int PrintNumberOfQuestionsPrompt()
  {
    int numberOfQuestions = AnsiConsole.Prompt(
      new TextPrompt<int>("[green]How many questions do you want the game to be?[/]")
      .Validate(input =>
      {
        return input > 0
        ? ValidationResult.Success()
        : ValidationResult.Error("[red]Input must be a number[/]");
      })
    );
    return numberOfQuestions;
    //read and validate where called
  }
  public static void PrintProgressBar(int numQuestions, int currentScore)
  {
    var chart = new BarChart()
    .Width(60)
    .Label("[green]Math Game[/]")
    .CenterLabel()
    .WithMaxValue(numQuestions)
    .AddItem("Level", currentScore, Color.Green);
    AnsiConsole.Write(chart);
  }

  public static string PrintMainMenuOptions()
  {
    string option = AnsiConsole.Prompt(
      new SelectionPrompt<string>()
      .AddChoices("Play", "Leaderboard")
    );
    return option;
  }
  public static Operation PrintOperationPrompt()
  {
    Operation operation = AnsiConsole.Prompt(
      new SelectionPrompt<Operation>()
      .Title("[green]Choose an operation for the game:[/]")
      .AddChoices(GlobalConfig.OperationsList)
    );
    return operation;
  }
  public static Difficulty PrintDifficultyPrompt()
  {
    Difficulty difficulty = AnsiConsole.Prompt(
      new SelectionPrompt<Difficulty>()
      .Title("[blue]Choose a difficulty level:[/]")
      .AddChoices(GlobalConfig.DifficultyList)
    );
    return difficulty;
  }

  public static void PrintQuestion(string questionText)
  {
    Console.WriteLine(questionText);
  }
  public static void PrintGameOver()
  {
    AnsiConsole.WriteLine(@"
  _______      ___      .___  ___.  _______      ______   ____    ____  _______ .______      
 /  _____|    /   \     |   \/   | |   ____|    /  __  \  \   \  /   / |   ____||   _  \     
|  |  __     /  ^  \    |  \  /  | |  |__      |  |  |  |  \   \/   /  |  |__   |  |_)  |    
|  | |_ |   /  /_\  \   |  |\/|  | |   __|     |  |  |  |   \      /   |   __|  |      /     
|  |__| |  /  _____  \  |  |  |  | |  |____    |  `--'  |    \    /    |  |____ |  |\  \----.
 \______| /__/     \__\ |__|  |__| |_______|    \______/      \__/     |_______|| _| `._____|
                                                                                             
");
  }
  public string PrintInitialsPrompt()
  {
    string response = AnsiConsole.Prompt(
      new TextPrompt<string>("[green]Enter your initials[/]")
    .Validate(initials =>
    {
      return initials.Length != 3
      ? ValidationResult.Error("[red]Initials must be 3 letters.")
      : ValidationResult.Success();
    }
    ));
    return response;
  }

  public static void PrintLeaderboard()
  {
    AnsiConsole.WriteLine("**Press any key to return home**");
    List<LeaderboardEntry> leaderboard = Leaderboard.GetByHighScore();
    if (leaderboard != null && leaderboard.Count != 0)
    {
      var table = new Table();
      table.Title("Leaderboard").Centered();
      table.Border(TableBorder.Rounded);
      table.Expand();
      table.Centered();
      table.AddColumns("Score", "Player", "Date").Centered();
      foreach (LeaderboardEntry entry in leaderboard)
      {
        table.AddRow(entry.EntryScore.ToString(), entry.Initials, entry.EntryDate.ToString());
      }
      AnsiConsole.Write(table);
    }
    else
    {
      AnsiConsole.WriteLine("No entries to display");
    }
    Thread.Sleep(1000);
    Console.Clear();
  }
}
