using MathGame.CSA.Enums;
using Spectre.Console;

namespace MathGame.CSA;

public class Printer
{
  //will print all console statements
  //need to make enums lists into lists of their values before writing then link after choice is made
  public static void PrintHeader()
  {
    Console.WriteLine();
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
  public static void PrintNumberOfQuestionsPrompt()
  {
    Console.WriteLine("How many questions do you want the game to be?");
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
      .AddChoices(["[blue]Play", "Leaderboard[/]"])
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
    Console.WriteLine();
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
}
