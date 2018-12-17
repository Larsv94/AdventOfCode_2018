using System.Collections.Generic;
using System.Linq;

namespace Day_8
{
    class TreeNode
    {
        public TreeNode[] Children;

        public int[] Metadata;

        public TreeNode(Queue<int> input)
        {
            Children = new TreeNode[input.Dequeue()];
            Metadata = new int[input.Dequeue()];
            CreateChildren(input);
            GetMetadata(input);
        }

        private void CreateChildren(Queue<int> input)
        {
            for (int i = 0; i < Children.Length; i++)
            {
                Children[i] = new TreeNode(input);
            }
        }

        private void GetMetadata(Queue<int> input)
        {
            for (int i = 0; i < Metadata.Length; i++)
            {
                Metadata[i] = input.Dequeue();
            }
        }

        public int SumMetadata()
        {
            int result = Metadata.Sum() + Children.Sum(child => child.SumMetadata());
            return result;
        }

        public int GetNodeValue()
        {
            int result = 0;

            if (!Children.Any())
            {
                result = Metadata.Sum();
            }
            else
            {
                foreach (var item in Metadata)
                {
                    result += (item - 1 >= Children.Length) ? 0 : Children[item - 1].GetNodeValue();
                }
            }

            return result;
        }
    }
}
