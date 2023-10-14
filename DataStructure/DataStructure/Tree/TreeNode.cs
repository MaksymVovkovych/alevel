namespace DataStructure.Tree
{
    public class TreeNode<T>
    {
        public T value { get; set; }
        public TreeNode<T>? left { get; set; }
        public TreeNode<T>? right { get; set; }
        public TreeNode(T value)
        {
            this.value = value;
            left = null;
            right = null;
        }
    }
}
