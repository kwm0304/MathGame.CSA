using MathGame.CSA.Enums;
using Spectre.Console;

namespace MathGame.CSA;

public class Printer
{
  //will print all console statements
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
  public static string PrintInitialsPrompt()
  {
    Console.WriteLine("Enter your initials: ");
    return Console.ReadLine(); //validate where this gets called
  }
}
