namespace MathGame.CSA.Models;

public class Leaderboard
{
  public static List<LeaderboardEntry> Entries { get; private set; }
  public Leaderboard()
  {
    Entries = new List<LeaderboardEntry>();
  }
  public void AddEntry(LeaderboardEntry entry)
  {
    Entries.Add(entry);
  }

  public static List<LeaderboardEntry> GetByHighScore()
  {
    return Entries.OrderByDescending(e => e.EntryScore).ToList();
  }
  public static List<LeaderboardEntry> GetByMostRecent()
  {
    return Entries.OrderByDescending(e => e.EntryDate).ThenByDescending(e => e.EntryScore).ToList();
  }
}
