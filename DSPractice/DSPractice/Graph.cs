using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPractice
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }
        public int Data { get; set; }
    }

    public class BreadthFirstSearch
    {
        private Queue _searchQueue;
        private BinaryTreeNode _root;
        public BreadthFirstSearch(BinaryTreeNode rootNode)
        {
            _searchQueue = new Queue();
            _root = rootNode;
        }
        public bool Search(int data)
        {
            BinaryTreeNode _current = _root;
            _searchQueue.Enqueue(_root);
            while (_searchQueue.Count != 0)
            {
                _current = (BinaryTreeNode)_searchQueue.Dequeue();
                Console.Write(_current.Data + " ");
                if (_current.Data == data)
                {
                    Console.Write(" Data Found");
                    return true;
                }
                else
                {
                    _searchQueue.Enqueue(_current.Left);
                    _searchQueue.Enqueue(_current.Right);
                }
            }
            return false;
        }
    }


}
