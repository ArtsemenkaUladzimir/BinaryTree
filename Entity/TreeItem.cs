using System;

namespace Entity
{
	public class TreeItem<T> : IComparable where T : IComparable
	{
		public T data { get; set; }
		public TreeItem<T> left { get; set; }
		public TreeItem<T> right { get; set; }

		public TreeItem (T data)
		{
			this.data = data;
		}

		#region IComparable implementation

		public int CompareTo (object obj)
		{
			if (obj == null)
				return -1;

			var objTreeItem = obj as TreeItem<T>;
			return this.data.CompareTo (objTreeItem.data);
		}

		#endregion
	}
}

