namespace DataStructure.Tree
{
    public class App
    {

        public static void AppTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Add(50);
            tree.Add(30);
            tree.Add(70);
            tree.Add(20);
            tree.Add(40);
            tree.Add(60);
            tree.Add(80);

            foreach (var item in tree)
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine();
            foreach (var item in tree.PreOrderTraversal())
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine();
            foreach (var item in tree.PostOrderTraversal())
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine();

            tree.Remove(60);
            tree.Remove(70);
            tree.Remove(10);

            Console.WriteLine();
            foreach (var item in tree.InOrderTraversal())
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine();

        }
    }
}
