namespace MathGame.CSA.Models;

public class Game
{
  public int Score { get; set; }
  public TimeSpan TimeTaken { get; set; }
  public GameSettings Settings { get; set; }
  public Game(TimeSpan timeTaken, GameSettings settings)
  {
    Score = 0;
    TimeTaken = timeTaken;
    Settings = settings;
  }
}
