/*
CHALLENGES
- Levels of difficulty
- Timer
- User option to pick number of questions
- Randomize option
*/
using MathGame.CSA;

namespace MathGame.CSA;
class Program
{
  static void Main(string[] args)
  {
    Console.Clear();
    while (true)
    {
      GameLoop.DisplayMainMenu();
    }
  }
}