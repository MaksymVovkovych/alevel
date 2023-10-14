using System.Collections;

namespace DataStructure.Tree
{
    public class BinaryTree<T> : IEnumerable<T>
    {

        private TreeNode<T> _root = null;
        private int _count;

        public int Count => _count;

        private TreeNode<T> Remove(TreeNode<T> node, T value)
        {
            if (node == null)
            {
                return node;
            }
            int comparison = Comparer<T>.Default.Compare(value, node.value);

            if (comparison < 0)
            {
                node.left = Remove(node.left, value);
            }
            else if (comparison > 0)
            {
                node.right = Remove(node.right, value);
            }
            else
            {
                if (node.left == null)
                {
                    return node.right;
                }
                else if (node.right == null)
                {
                    return node.left;
                }
                node.value = FindMinValue(node.right);
                node.right = Remove(node.right, node.value);
            }

            return node;
        }

        private T FindMinValue(TreeNode<T> node)
        {
            T minValue = node.value;
            while (node.left != null)
            {
                minValue = node.left.value;
                node = node.left;
            }
            return minValue;
        }


        public void Add(T value)
        {
            _root = Insert(_root, value);
            _count++;
        }

        public void Remove(T value)
        {
            _root = Remove(_root, value);
        }


        public TreeNode<T> Insert(TreeNode<T> treeNode, T value)
        {
            if (treeNode == null)
            {
                return new TreeNode<T>(value);
            }
            if (Comparer<T>.Default.Compare(value, treeNode.value) < 0)
            {
                treeNode.left = Insert(treeNode.left, value);
            }
            else
            {
                treeNode.right = Insert(treeNode.right, value);
            }
            return treeNode;
        }
        public IEnumerable<T> InOrderTraversal()
        {
            return InOrderTraversal(_root);
        }
        public IEnumerable<T> InOrderTraversal(TreeNode<T>? treeNode)
        {
            if(treeNode!= null)
            {
                foreach(var left in InOrderTraversal(treeNode.left))
                {
                    yield return left;
                }
                yield return treeNode.value;
                foreach (var right in InOrderTraversal(treeNode.right))
                {
                    yield return right;
                }
            }
        }
        public IEnumerable<T> PreOrderTraversal()
        {
            return PreOrderTraversal(_root);
        }
        public IEnumerable<T> PreOrderTraversal(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                yield return treeNode.value;
                foreach (var left in PreOrderTraversal(treeNode.left))
                {
                    yield return left;
                }
                foreach (var right in PreOrderTraversal(treeNode.right))
                {
                    yield return right;
                }
            }
        }
        public IEnumerable<T> PostOrderTraversal()
        {
           return PostOrderTraversal(_root);
        }
        public IEnumerable<T> PostOrderTraversal(TreeNode<T>? treeNode)
        {
            if (treeNode != null)
            {
                foreach (var left in PostOrderTraversal(treeNode.left))
                {
                    yield return left;
                }
                foreach (var right in PostOrderTraversal(treeNode.right))
                {
                    yield return right;
                }
                yield return treeNode.value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal(_root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
