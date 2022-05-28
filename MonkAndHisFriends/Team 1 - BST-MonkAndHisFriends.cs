using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.hackerearth.com/practice/data-structures/trees/binary-search-tree/practice-problems/algorithm/monk-and-his-friends/
namespace MonkAndHisFriends {
    internal class Program {
        static void Main(string[] args) {
            BinarySearchTree bst;

            int int_T = int.Parse(Console.ReadLine()); // Get number of test cases

            for (int t = 1; t <= int_T; t++) {

                bst = new BinarySearchTree();

                string NM = Console.ReadLine();  
                string[] NM1 = NM.Split(' ');
                    
                string raw_input = Console.ReadLine(); // Get values for array

                string[] user_inputs = raw_input.Split(' ');

                long temp;
                bool check_insert;

                int N = int.Parse(NM1[0]);
                int M = int.Parse(NM1[1]);

                for (int i = 0; i < N; i++) {
                    bst.Insert(new BST_Node(long.Parse(user_inputs[i])));
                }


                for (int i = N; i < N + M; i++) {
                    temp = long.Parse(user_inputs[i]);

                    check_insert = bst.Insert(new BST_Node(temp));

                    if (check_insert == false) {
                        Console.WriteLine("YES");
                    } else {
                        Console.WriteLine("NO");
                    }
                }
            }
        }
    }

    // Define BinarySearchTree_Node data structure
    public class BST_Node {
        // This will contain the key value
        public long Key { get; set; }

        // Left node pointer
        public BST_Node Left { get; set; }

        // Right node pointer
        public BST_Node Right { get; set; }

        // Constructor
        public BST_Node(long key_m) {
            Key = key_m;
            Left = null;
            Right = null;
        }
    }


    // Define a BinarySearchTree class to parse the tree
    public class BinarySearchTree {
        // Root node for the tree
        private BST_Node root;

        // Constructor
        public BinarySearchTree() {
            root = null;
        }

        // Insert new node to the tree
        public bool Insert(BST_Node my_node) {
            if (my_node == null)
                return false;

            if (root == null) {
                root = my_node;
                //Console.WriteLine("Head Node inserted, value:{0}", my_node.Key);
            } else {
                BST_Node current_node = root;

                while (true) {
                    // New node is smaller then current node, go left
                    if (my_node.Key < current_node.Key) {
                        // There is no node on left, insert our new node there
                        if (current_node.Left == null) {
                            current_node.Left = my_node;
                           // Console.WriteLine("LNode inserted, value:{0}", my_node.Key);


                            break;
                        }
                        // There is a node, go left
                        else {
                            current_node = current_node.Left;
                        }
                    }
                    // New node is larger then current node, go right
                    else if (my_node.Key > current_node.Key) {
                        // There is no node on right, insert our new node there
                        if (current_node.Right == null) {
                            current_node.Right = my_node;
                          //  Console.WriteLine("RNode inserted, value:{0}", my_node.Key);
                            break;
                        }
                        // There is a node, go right
                        else {
                            current_node = current_node.Right;
                        }
                    }
                    // New node is same size as current node, increment existing node counter
                    else {
                        // This already exists in the array
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
