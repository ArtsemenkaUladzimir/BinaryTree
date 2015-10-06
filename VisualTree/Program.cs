using System;
using Entity;

namespace VisualTree
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var tree = new BinaryTree<int> ();
			tree.Add (9);
			tree.Add (4);
			tree.Add (12);
			tree.Add (34);
			tree.Add (5);
			tree.PreOrderTraversal (Console.Write);
		}
	}
}
