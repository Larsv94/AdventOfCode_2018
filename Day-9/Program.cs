using System;

namespace Day_9
{
    class Program
    {
        static void Main(string[] args)
        {

            var Game = new MarbleGame(447, 71510);
            Game.Play();
            Console.WriteLine(Game.GetHighScore());

            var Game1 = new MarbleGame(447, 71510 * 100);
            Game1.Play();
            Console.WriteLine(Game1.GetHighScore());


            Console.Read();
        }
    }
}
