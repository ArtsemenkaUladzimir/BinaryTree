using System;
using System.Collections.Generic;

namespace Entity
{
	public class BinaryTree<T> : IEnumerable<T> where T : IComparable
	{
		public BinaryTreeNode head { get; private set; }
		public int Capacity { get; private set; }

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

			public int CompareTo (T obj)
			{
				return data.CompareTo (obj);
			}

			#endregion
		}

		#endregion

		public void Add(T value) 
		{
			var item = new BinaryTreeNode (value);

			if (head == null) {
				head = item;
				Capacity++;
				return;
			}

			var cur = head;
			while (cur != null) {
				if (cur.CompareTo (item) < 0) {
					if (cur.right == null) {
						cur.right = item;
						Capacity++;
						return;
					}
					cur = cur.right;
					continue;
				} else {
					if (cur.left == null) {
						cur.left = item;
						Capacity++;
						return;
					}
					cur = cur.left;
				}
			}
		}

		public bool Contains(T value)
		{
			BinaryTreeNode parent;
			return FindWithParent (value, out parent) != null;
		}

		public bool Remove(T value) 
		{
			BinaryTreeNode parent, cur, tmp, tmpParent;

			cur = FindWithParent (value, out parent);

			if (cur == null)
				return false;
			Capacity--;

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
					return ReplaceChild (parent, cur, tmp);
				}
			}
		}

		public void Clear() 
		{
			head = null;
			Capacity = 0;
		}

		public void PreOrderTraversal(Action<BinaryTreeNode> action)
		{
			PreOrderTraversal (action, head);
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

		#region private function

		private BinaryTreeNode FindWithParent(T value, out BinaryTreeNode parent)
		{
			BinaryTreeNode cur = head;
			parent = null;

			while (cur != null) {
				if (cur.CompareTo (value) < 0) {
					parent = cur;
					cur = cur.right;
					continue;
				}
				if (cur.CompareTo (value) > 0) {
					parent = cur;
					cur = cur.left;
					continue;
				}
				return cur;
			}

			return cur;
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

		private void PreOrderTraversal(Action<BinaryTreeNode> action, BinaryTreeNode node)
		{
			if (node != null) {
				action (node);
				PreOrderTraversal (action, node.left);
				PreOrderTraversal (action, node.right);
			}
		}

		#endregion
	}
}

