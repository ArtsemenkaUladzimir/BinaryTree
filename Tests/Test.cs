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
			tree.Add (3);
			tree.Add (4);
		}

		[Test ()]
		public void CapasityTest ()
		{
			Assert.AreEqual (2, tree.Capasity);
		}
	}
}

