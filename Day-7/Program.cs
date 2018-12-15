using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    class Program
    {
        static void Main(string[] args)
        {
            SleighKit guide = new SleighKit("input.txt");
            DirectionalGraph graph = new DirectionalGraph();
            foreach ((string curr,string next) in guide.ReadManual())
            {
                graph.AddStep(curr,next);
            }

            var Answer1 = new GraphReader(graph).GetSteps();
            Console.WriteLine(Answer1);

            graph.Reset();
            var Answer2 = new GraphReader(graph).GetDurationWithWorkersAndTime(5,60);
            Console.WriteLine(Answer2);


            Console.Read();
        }
        
    }
}
