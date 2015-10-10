using System;
using Entity;
using NUnit.Framework;

namespace Tests
{
	[TestFixture ()]
	public class Test
	{
		BinaryTree<int> tree;

		[SetUp]
		public void Init()
		{
			tree = new BinaryTree<int> ();
			tree.Add (9);
			tree.Add (4);
			tree.Add (12);
			tree.Add (34);
		}

		[Test ()]
		public void CapacityTest ()
		{
			Assert.AreEqual (4, tree.Capacity);
		}

		[Test ()]
		public void RemoveTest1 ()
		{
			tree.Remove (4);
			tree.Remove (4);
			Assert.AreEqual (3, tree.Capacity);
		}

		[Test ()]
		public void RemoveTest2 ()
		{
			tree.Remove (34);
			tree.Remove (12);
			Assert.AreEqual (2, tree.Capacity);
		}

		[Test]
		public void RemoveHead()
		{
			tree.Remove (9);
			Assert.AreEqual (3, tree.Capacity);
		}
	}
}

