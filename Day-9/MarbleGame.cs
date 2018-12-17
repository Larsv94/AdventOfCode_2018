
using System.Linq;

namespace Day_9
{
    class MarbleGame
    {
        int Players { get; set; }
        int Marbles { get; set; }
        long[] ScoreList { get; set; }

        CircularList<long> MarbleCircle = new CircularList<long>(0);

        public MarbleGame(int players, int marbles)
        {
            Players = players;
            Marbles = marbles;
            ScoreList = new long[players];
        }

        public void Play()
        {
            int currentplayer;
            for (int i = 1; i <= Marbles; i++)
            {
                if (i % 23 == 0)
                {
                    currentplayer = i % Players;
                    ScoreList[currentplayer] += i;
                    MarbleCircle.Rotate(-7);
                    ScoreList[currentplayer] += MarbleCircle.Pop();
                }
                else
                {
                    MarbleCircle.AddAt(i, 2);
                }

                //Console.WriteLine(MarbleCircle.ToString());
            }
        }

        public long GetHighScore()
        {
            return ScoreList.Max();
        }
    }
}
