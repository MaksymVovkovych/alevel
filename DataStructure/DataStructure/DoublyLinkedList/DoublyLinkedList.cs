using System.Collections;

namespace DataStructure.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private Node<T>? head;
        private Node<T>? tail;
        private int _count;

        public int Count => _count;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }
        ~DoublyLinkedList()
        {
            while (this.head != null)
            {
                PopFront();
            }
        }
        public void AddFront(T value)
        {
            var node = new Node<T>(value);
            node.Next = head;
            if (head != null)
                head.Prev = node;

            if (tail == null)
                tail = node;

            head = node;
            _count++;
        }
        public void AddLast(T value)
        {
            var node = new Node<T>(value);
            node.Prev = tail;
            if (tail != null)
                tail.Next = node;

            if (head == null)
                head = node;

            tail = node;
            _count++;
        }

        public void PopFront()
        {
            if (head == null) return;

            Node<T>? node = head.Next;
            if (node != null)
                node.Prev = null;
            else
                tail = null;

            head = node;
            _count--;
        }
        public void PopBack()
        {
            if (tail == null) return;

            Node<T>? node = tail.Prev;
            if (node != null)
                node.Next = null;
            else
                head = null;
            tail = null;
            tail = node;
            _count--;
        }
        public Node<T>? GetAt(int index)
        {
            Node<T>? node = head;
            int n = 0;
            while (n != index)
            {
                if (node == null) return null;
                node = node.Next;
                n++;
            }
            return node;
        }

        public void Insert(int index, T data)
        {
            Node<T>? rightNode = GetAt(index);
            if (rightNode == null)
            {
                AddLast(data);
                return;
            }
            Node<T>? leftNode = rightNode.Prev;
            if (leftNode == null)
            {
                AddFront(data);
                return;
            }

            Node<T> node = new Node<T>(data);
            node.Prev = leftNode;
            node.Next = rightNode;
            leftNode.Next = node;
            rightNode.Prev = node;
            _count++;
        }

        public void Earse(int index)
        {
            Node<T>? node = GetAt(index);
            if (node == null) return;
            if (node.Prev == null)
            {
                PopFront();
                return;
            }
            if (node.Next == null)
            {
                PopBack();
                return;
            }
            Node<T> leftNode = node.Prev;
            Node<T> rightNode = node.Next;
            leftNode.Next = rightNode;
            rightNode.Prev = leftNode;

            node = null;
            _count--;

        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? node = tail;
            while (node != null)
            {
                yield return node.value;
                node = node.Prev;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
