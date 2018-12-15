using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    class DirectionalGraph
    {
        public List<Step> Nodes { get; private set; } = new List<Step>();

        public void AddStep(string step, string before)
        {
            Step curr = Nodes.FirstOrDefault(n => n.Value.Equals(step)) ?? CreateNode(step);
            Step next = Nodes.FirstOrDefault(n => n.Value.Equals(before)) ?? CreateNode(before);
            curr.Next.Add(next);
            next.Previous.Add(curr);
        }

        private Step CreateNode(string val)
        {
            Step newNode = new Step(val);
            Nodes.Add(newNode);
            return newNode;
        }

        /// <summary>
        /// Reset the all the work for the current graph
        /// </summary>
        public void Reset()
        {
            foreach (var node in Nodes)
            {
                node.IsCompleted = false;
                node.InProgress = false;
            }
        }
        
    }
}
