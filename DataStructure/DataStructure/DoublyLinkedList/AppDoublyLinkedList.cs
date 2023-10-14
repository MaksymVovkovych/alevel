namespace DataStructure.DoublyLinkedList
{
    public class AppDoublyLinkedList
    {
        public static void AppDLL()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddFront(0);
            list.AddLast(3);
            list.PopFront();
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);
            list.AddFront(8);

            Console.WriteLine("Using foreach loop:");
            foreach (int value in list)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();

            list.PopBack();
            list.Earse(7);
            list.Insert(1, 10);
            foreach (int value in list)
            {
                Console.Write(value + " ");
            }


        }
    }
}
