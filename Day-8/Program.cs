using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_8
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode firstNode = new TreeNode(ReadInput("input.txt"));

            var answer1 = firstNode.SumMetadata();
            Console.WriteLine(answer1);

            var answer2 = firstNode.GetNodeValue();
            Console.WriteLine(answer2);

            Console.Read();
        }

        static Queue<int> ReadInput(string filename)
        {
            string[] lines = File.ReadAllLines("../../" + filename);
            return new Queue<int>(lines[0].Split(new char[] { ' ' }).Select(x => int.Parse(x)).ToArray());
        }
    }
}
