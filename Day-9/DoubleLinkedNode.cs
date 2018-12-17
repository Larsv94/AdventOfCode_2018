
namespace Day_9
{
    class DoubleLinkedNode<T>
    {
        public DoubleLinkedNode<T> Previous;
        public DoubleLinkedNode<T> Next;
        public T Value { get; set; }

        public DoubleLinkedNode(DoubleLinkedNode<T> previous, DoubleLinkedNode<T> next,T value)
        {
            Value = value;
            Previous = previous;
            Next = next;
            previous.Next = this;
            next.Previous = this;
        }

        public DoubleLinkedNode(T value)
        {
            Value = value;
            Previous = this;
            Next = this;
        }

        public override string ToString()
        {
            return $"{Previous.Value.ToString()} >> {Value.ToString()} << {Next.Value.ToString()}";
        }
    }
}
