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
				if (tmp.CompareTo (item) < 0) {
					if (tmp.left == null) {
						tmp.left = item;
						return;
					}
					tmp = tmp.left;
					continue;
				} else {
					if (tmp.right == null) {
						tmp.right = item;
						return;
					}
					tmp = tmp.right;
				}
			}
		}
	}
}

