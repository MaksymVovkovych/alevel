namespace DataStructure.DoublyLinkedList
{
    public class Node<T>
    {
        public T value { get; set; }
        public Node<T>? Prev { get; set; }
        public Node<T>? Next { get; set; }
        public Node(T value)
        {
            this.value = value;
            Prev = null;
            Next = null;
        }
    }
}
