using System;
using System.Collections.Generic;

namespace Entity
{
	public class BinaryTree<T> : IEnumerable<T> where T : IComparable
	{
		public BinaryTreeNode head { get; private set; }
		public int Capasity { get; private set; }

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
				return data.CompareTo (objBinaryTreeNode.data);
			}

			#endregion
		}

		#endregion

		public void Add(T value) 
		{
			var item = new BinaryTreeNode (value);

			if (head == null) {
				head = item;
				Capasity++;
				return;
			}

			var cur = head;
			while (cur != null) {
				if (cur.CompareTo (item) < 0) {
					if (cur.left == null) {
						cur.left = item;
						Capasity++;
						return;
					}
					cur = cur.left;
					continue;
				} else {
					if (cur.right == null) {
						cur.right = item;
						Capasity++;
						return;
					}
					cur = cur.right;
				}
			}
		}

		public bool Contains(T value)
		{
			throw new NotImplementedException ();
		}

		public bool Remove(T value) 
		{
			BinaryTreeNode parent, cur, tmp, tmpParent;

			cur = FindWithParent (value, out parent);

			if (cur == null)
				return false;
			Capasity--;

			if (cur.right == null) {
				if (parent == null) {
					head = cur.left;
					return true;
				}
//				if (parent.CompareTo (cur) < 0)
//					parent.right = cur.left;
//				else
//					parent.left = cur.left;
//				return true;
				return ReplaceChild (parent, cur, cur.left);

			} else {
				if (cur.right.left == null) {
					cur.right.left = cur.left;
//					if (parent.CompareTo (cur) < 0)
//						parent.right = cur.right;
//					else
//						parent.left = cur.right;
//					return true;
					return ReplaceChild (parent, cur, cur.right);

				} else {
					tmp = FindMostLeftWithParent (cur.right, out tmpParent);
//					if (tmpParent.CompareTo (tmp) < 0)
//						tmpParent.right = tmp.right;
//					else
//						tmpParent.left = tmp.right;
					ReplaceChild (tmpParent, tmp, tmp.right);
					tmp.left = cur.left;
					tmp.right = cur.right;
					return ReplaceChild (parent, tmp, tmp);
				}
			}
		}

		#region IEnumerable implementation
		public IEnumerator<T> GetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			throw new NotImplementedException ();
		}
		#endregion

		public void Clear() 
		{
			throw new NotImplementedException ();
		}

		#region private function

		private BinaryTreeNode FindWithParent(T value, out BinaryTreeNode parent)
		{
			throw new NotImplementedException ();
		}

		private BinaryTreeNode FindMostLeftWithParent(BinaryTreeNode node, out BinaryTreeNode parent)
		{
			throw new NotImplementedException ();
		}

		private bool ReplaceChild(BinaryTreeNode parent, BinaryTreeNode oldChild, BinaryTreeNode newChild)
		{
			if (parent.CompareTo (oldChild) < 0)
				parent.right = newChild;
			else
				parent.left = newChild;
			return true;
		}

		#endregion
	}
}

