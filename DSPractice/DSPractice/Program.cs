using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph();
            //search();
            //sort();
            //GetHastTable();


        }

        static void Graph()
        {
            var treeNode = new BinaryTreeNode();
            treeNode.Data = 14;
            treeNode.Left = new BinaryTreeNode { Data = 19, Left = new BinaryTreeNode { Data = 33 }, Right = new BinaryTreeNode { Data = 35 } };
            treeNode.Right = new BinaryTreeNode { Data = 27, Left = new BinaryTreeNode { Data = 42 }, Right = new BinaryTreeNode { Data = 50 } };

            var q = new Queue();
            q.Enqueue(treeNode);
            var _current = new BinaryTreeNode();
            _current = treeNode;
            try
            {
                while (q.Count != 0)
                {
                    _current = (BinaryTreeNode)q.Dequeue();
                    Console.Write(_current.Data + " ");
                    q.Enqueue(_current.Left);
                    q.Enqueue(_current.Right);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
            }


            Console.Write("Enter no to search: ");
            var o = new BreadthFirstSearch(treeNode);
            o.Search(int.Parse(Console.ReadLine()));
            Console.ReadLine();

        }

        static void search()
        {
            int[] i = { 14, 33, 27, 10, 35, 19, 42, 44 };
            foreach (var item in i)
                Console.Write(item + ",");
            Console.WriteLine("");
            var o = new QuickSort();
            i = o.sort(i);
            foreach (var item in i)
                Console.Write(item + ",");
            Console.ReadLine();
        }

        static void sort()
        {
            int[] i = { 10, 17, 22, 36, 46, 52, 64, 77, 81, 90 };
            foreach (var item in i)
                Console.Write(item + ",");
            Console.WriteLine("");
            var ls = new BinarySearch();
            Console.Write("Enter no to search: ");
            int n = int.Parse(Console.ReadLine());
            int pos = ls.SearchMyNo(n, i);
            if (pos > -1)
                Console.WriteLine("Number:{0} found at position:{1}", n, pos);
            else
                Console.WriteLine("Number:{0} not found", n);


            Console.ReadLine();
        }

        static Hashtable SetHashtable()
        {
            // Create and return new Hashtable.
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Area", 1000);
            hashtable.Add("Perimeter", 55);
            hashtable.Add("Mortgage", 540);
            return hashtable;
        }

        static void GetHastTable()
        {
            Hashtable hashtable = SetHashtable();
            // See if the Hashtable contains this key.
            Console.WriteLine(hashtable.ContainsKey("Perimeter"));
            // Test the Contains method. It works the same way.
            Console.WriteLine(hashtable.Contains("Area"));
            // Get value of Area with indexer.
            int value = (int)hashtable["Area"];
            // Write the value of Area.
            Console.WriteLine(value);
        }
    }
}
