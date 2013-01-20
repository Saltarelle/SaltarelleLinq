using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class OrderingTests {
		[Test]
		public void OrderByWithoutSelectorWorksForArray() {
			Assert.AreEqual(new[] { 5, 4, 2, 1, 3 }.OrderBy().ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void OrderByWithSelectorWorksForArray() {
			Assert.AreEqual(new[] { new { i = 5 }, new { i = 4 }, new { i = 2 }, new { i = 1 }, new { i = 3 } }.OrderBy(x => x.i).ToArray(), new[] { new { i = 1 }, new { i = 2 }, new { i = 3 }, new { i = 4 }, new { i = 5 } });
		}

		[Test]
		public void OrderByWithoutSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 5, 4, 2, 1, 3 }.Select(x => x).OrderBy().ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void OrderByWithSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { new { i = 5 }, new { i = 4 }, new { i = 2 }, new { i = 1 }, new { i = 3 } }.Select(x => x).OrderBy(x => x.i).ToArray(), new[] { new { i = 1 }, new { i = 2 }, new { i = 3 }, new { i = 4 }, new { i = 5 } });
		}
		

		[Test]
		public void OrderByDescendingWithoutSelectorWorksForArray() {
			Assert.AreEqual(new[] { 5, 4, 2, 1, 3 }.OrderByDescending().ToArray(), new[] { 5, 4, 3, 2, 1 });
		}

		[Test]
		public void OrderByDescendningWithSelectorWorksForArray() {
			Assert.AreEqual(new[] { new { i = 5 }, new { i = 4 }, new { i = 2 }, new { i = 1 }, new { i = 3 } }.OrderByDescending(x => x.i).ToArray(), new[] { new { i = 5 }, new { i = 4 }, new { i = 3 }, new { i = 2 }, new { i = 1 } });
		}

		[Test]
		public void OrderByDescendingWithoutSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 5, 4, 2, 1, 3 }.Select(x => x).OrderByDescending().ToArray(), new[] { 5, 4, 3, 2, 1 });
		}

		[Test]
		public void OrderByDescendingWithSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { new { i = 5 }, new { i = 4 }, new { i = 2 }, new { i = 1 }, new { i = 3 } }.Select(x => x).OrderByDescending(x => x.i).ToArray(), new[] { new { i = 5 }, new { i = 4 }, new { i = 3 }, new { i = 2 }, new { i = 1 } });
		}


		[Test]
		public void ThenByWorks() {
			var arr = new[] { new { a = 2, b = 4, c = 1 }, new { a = 2, b = 3, c = 7 }, new { a = 2, b = 3, c = 3 }, new { a = 4, b = 7, c = 5 }, new { a = 7, b = 3, c = 2 }, new { a = 4, b = 1, c = 5 } };
			var result = arr.OrderBy(x => x.a).ThenBy(x => x.c).ThenBy(x => x.b).ToArray();
			Assert.AreEqual(result, new[] { new { a = 2, b = 4, c = 1 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 3, c = 7 }, new { a = 4, b = 1, c = 5 }, new { a = 4, b = 7, c = 5 }, new { a = 7, b = 3, c = 2 } });
		}


		[Test]
		public void ThenByDescendingWorks() {
			var arr = new[] { new { a = 2, b = 4, c = 1 }, new { a = 2, b = 3, c = 7 }, new { a = 2, b = 3, c = 3 }, new { a = 4, b = 7, c = 5 }, new { a = 7, b = 3, c = 2 }, new { a = 4, b = 1, c = 5 } };
			var result = arr.OrderBy(x => x.a).ThenByDescending(x => x.c).ThenByDescending(x => x.b).ToArray();
			Assert.AreEqual(result, new[] { new { a = 2, b = 3, c = 7 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 4, c = 1 }, new { a = 4, b = 7, c = 5 }, new { a = 4, b = 1, c = 5 }, new { a = 7, b = 3, c = 2 } });
		}


		[Test]
		public void ReverseWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new TestEnumerable(1, 5).Reverse().ToArray(), new[] { 5, 4, 3, 2, 1 });
		}

		[Test]
		public void ReverseWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Reverse().ToArray(), new[] { 5, 4, 3, 2, 1 });
		}


		[Test]
		public void ShuffleWorksForSaltarelleEnumerable() {
			var result = new TestEnumerable(1, 5).Shuffle().ToArray();
			Assert.IsTrue(result.Contains(1) && result.Contains(2) && result.Contains(3) && result.Contains(4) && result.Contains(5));
		}

		[Test]
		public void ShuffleWorksForLinqJSEnumerable() {
			var result = Enumerable.Range(1, 5).Shuffle().ToArray();
			Assert.IsTrue(result.Contains(1) && result.Contains(2) && result.Contains(3) && result.Contains(4) && result.Contains(5));
		}
	}
}
