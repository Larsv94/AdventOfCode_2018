using System;
using System.Text;

namespace Day_9
{
    class CircularList<T>
    {
        public DoubleLinkedNode<T> Head { get; private set; }
        public DoubleLinkedNode<T> Current { get; private set; }

        public CircularList(T val)
        {
            Head = Current = new DoubleLinkedNode<T>(val);
        }

        public void Rotate(int amount)
        {
            if (amount == 0)
            {
                return;
            }
            for (int i = 0; i < Math.Abs(amount); i++)
            {
                if (amount>0)
                {
                    Current = Current.Next;
                }
                else
                {
                    Current = Current.Previous;
                }
            }
        }

        public T Pop()
        {
            var val = Current.Value;

            Current.Previous.Next = Current.Next;
            Current.Next.Previous = Current.Previous;
            Current = Current.Next;

            return val;
        }

        public void Add(T value)
        {
            Current = new DoubleLinkedNode<T>(Current.Previous, Current, value);
        }

        public void AddAt(T value,int stepFromCurrent)
        {
            Rotate(stepFromCurrent);
            Current = new DoubleLinkedNode<T>(Current.Previous, Current, value);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            var node = Head;
            do
            {
                builder.Append($" {node.Value}");
                node = node.Next;
            } while (node!= Head);
            return builder.ToString();
        }
    }
}
