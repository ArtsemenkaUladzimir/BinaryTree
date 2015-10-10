using System;
using Entity;

namespace VisualTree
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var tree = new BinaryTree<int> ();
			tree.Add (10);
			tree.Add (8);
			tree.Add (12);
			tree.Add (20);
			tree.Add (11);
			tree.Add (19);
			tree.InsertRoot (7);
			tree.PreOrderTraversal (Console.Write);
		}
	}
}
