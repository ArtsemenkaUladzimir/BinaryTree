using System;

namespace Entity
{
	public class BinaryTree<T> where T : IComparable
	{
		#region BinaryTreeNode

		public class BinaryTreeNode : IComparable
		{
			public T data { get; set; }
			public BinaryTreeNode left { get; set; }
			public BinaryTreeNode right { get; set; }

			public BinaryTreeNode (T data)
			{
				this.data = data;
			}

			#region IComparable implementation

			public int CompareTo (object obj)
			{
				if (obj == null)
					return -1;

				var objBinaryTreeNode = obj as BinaryTreeNode;
				return this.data.CompareTo (objBinaryTreeNode.data);
			}

			#endregion
		}

		#endregion

		public BinaryTreeNode head { get; private set; }
		public int Capasity { get; private set; }

		public void Add(T value) 
		{
			var item = new BinaryTreeNode (value);
			if (item == null)
				return;

			item.left = null;
			item.right = null;
			
			if (head == null) {
				head = item;
				return;
			}

			var tmp = head;
			while (tmp == null) {
				if (tmp.CompareTo (item) < 0) {
					if (tmp.left == null) {
						tmp.left = item;
						Capasity++;
						return;
					}
					tmp = tmp.left;
					continue;
				} else {
					if (tmp.right == null) {
						tmp.right = item;
						Capasity++;
						return;
					}
					tmp = tmp.right;
				}
			}
		}
	}
}

