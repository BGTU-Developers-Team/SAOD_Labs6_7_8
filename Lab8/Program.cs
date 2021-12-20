using System;
using System.Data;

namespace Lab8
{
    class Node
    {
        public int Height => _height;
        public int Key => _key;

        private int _key;
        private int _height;
        public Node Left;
        public Node Right;

        public Node(int key)
        {
            _key    = key;
            _height = 1;
            Left    = Right = null;
        }

        public void UpdateHeight()
        {
            int leftHeight = Left?.Height ?? 0;
            int rightHeight = Right?.Height ?? 0;
            _height = (leftHeight > rightHeight ? leftHeight : rightHeight) + 1;
        }

        public int BFactor()
        {
            int leftHeight  = Left?.Height ?? 0;
            int rightHeight = Right?.Height ?? 0;
            return rightHeight - leftHeight;
        }
    }


    class Program
    {
        static Node RotateRight(Node rotationOriginNode)
        {
            var newOrigin = rotationOriginNode.Left;

            rotationOriginNode.Left = newOrigin.Right;
            newOrigin.Right         = rotationOriginNode;

            rotationOriginNode.UpdateHeight();
            newOrigin.UpdateHeight();

            return newOrigin;
        }

        static Node RotateLeft(Node rotationOriginNode)
        {
            var newOrigin = rotationOriginNode.Right;

            rotationOriginNode.Right = newOrigin?.Left;
            newOrigin.Left           = rotationOriginNode;

            rotationOriginNode.UpdateHeight();
            newOrigin.UpdateHeight();

            return newOrigin;
        }

        static Node Balance(Node root)
        {
            root.UpdateHeight();

            if (root.BFactor() == 2)
            {
                if (root.Right?.BFactor() < 0)
                {
                    root.Right = RotateRight(root.Right);
                }

                return RotateLeft(root);
            }
            else if (root.BFactor() == -2)
            {
                if (root.Left?.BFactor() > 0)
                {
                    root.Left = RotateLeft(root.Left);
                }

                return RotateRight(root);
            }

            return root;
        }

        static Node Insert(Node root, int key)
        {
            if (root is null) return new Node(key);

            if (key < root.Key)
            {
                root.Left = Insert(root.Left, key);
            }
            else
            {
                root.Right = Insert(root.Right, key);
            }

            return Balance(root);
        }

        static void Main(string[] args)
        {
            var root = Insert(null, 15);
            root = Insert(root, 1);
            root = Insert(root, -2);
            root = Insert(root, 55);
            root = Insert(root, 55);
            root = Insert(root, 5);

            Console.WriteLine();
        }
    }
}