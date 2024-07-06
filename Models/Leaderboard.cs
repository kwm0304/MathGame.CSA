namespace MathGame.CSA.Models;

public class Leaderboard
{
  public List<LeaderboardEntry> Entries { get; private set; }
  public Leaderboard()
  {
    Entries = new List<LeaderboardEntry>();
  }
  public void AddEntry(LeaderboardEntry entry)
  {
    Entries.Add(entry);
  }

  public List<LeaderboardEntry> GetByHighScore()
  {
    return Entries.OrderByDescending(e => e.EntryScore).ToList();
  }
  public List<LeaderboardEntry> GetByMostRecent()
  {
    return Entries.OrderByDescending(e => e.EntryDate).ThenByDescending(e => e.EntryScore).ToList();
  }
}
