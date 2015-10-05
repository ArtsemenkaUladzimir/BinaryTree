using System;

namespace Entity
{
	public class BinaryTree<T> where T : IComparable
	{
		private TreeItem<T> head { get; set; }

		public void Add(TreeItem<T> item) 
		{
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
				if (tmp.CompareTo (item) < 0 && tmp.left == null) {
					tmp.left = item;
					return;
				} else {
					tmp = tmp.left;
				}
				if (tmp.CompareTo (item) >= 0 && tmp.right == null) {
					tmp.right = item;
					return;
				} else {
					tmp = tmp.right;
				}
			}
		}
	}
}

