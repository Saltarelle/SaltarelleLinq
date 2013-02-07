using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class OrderingTests {
		class C : IComparable<C> {
			public int value;
			public C(int value) {
				this.value = value;
			}

			public int CompareTo(C other) {
				return value.CompareTo(other.value);
			}
		}

		class DescendingComparer : IComparer<C> {
			public int Compare(C x, C y) {
				return y.CompareTo(x);
			}
		}

		private IOrderedEnumerable<T> OrderBy<T, TKey>(IEnumerable<T> enm, Func<T, TKey> f) {
			return enm.OrderBy(f);
		}

		[Test]
		public void OrderByWithoutSelectorWorksForArray() {
			Assert.AreEqual(new[] { 5, 4, 2, 1, 3 }.OrderBy().ToArray(), new[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(new[] { new C(5), new C(4), new C(2), new C(1), new C(3) }.OrderBy().Select(x => x.value).ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void OrderByWithoutSelectorWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 5, 4, 2, 1, 3 }.Wrap().OrderBy().ToArray(), new[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(new[] { new C(5), new C(4), new C(2), new C(1), new C(3) }.Wrap().OrderBy().Select(x => x.value).ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void OrderByWithoutSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 5, 4, 2, 1, 3 }).OrderBy().ToArray(), new[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(Enumerable.From(new[] { new C(5), new C(4), new C(2), new C(1), new C(3) }).OrderBy().Select(x => x.value).ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void OrderByWithSelectorWorksForArray() {
			Assert.AreEqual(new[] { new { i = 5 }, new { i = 4 }, new { i = 2 }, new { i = 1 }, new { i = 3 } }.OrderBy(x => x.i).Select(x => x.i).ToArray(), new[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(new[] { new { i = new C(5) }, new { i = new C(4) }, new { i = new C(2) }, new { i = new C(1) }, new { i = new C(3) } }.OrderBy(x => x.i).Select(x => x.i.value).ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void OrderByWithSelectorWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { new { i = 5 }, new { i = 4 }, new { i = 2 }, new { i = 1 }, new { i = 3 } }.Wrap().OrderBy(x => x.i).Select(x => x.i).ToArray(), new[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(new[] { new { i = new C(5) }, new { i = new C(4) }, new { i = new C(2) }, new { i = new C(1) }, new { i = new C(3) } }.Wrap().OrderBy(x => x.i).Select(x => x.i.value).ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void OrderByWithSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { new { i = 5 }, new { i = 4 }, new { i = 2 }, new { i = 1 }, new { i = 3 } }).OrderBy(x => x.i).Select(x => x.i).ToArray(), new[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(Enumerable.From(new[] { new { i = new C(5) }, new { i = new C(4) }, new { i = new C(2) }, new { i = new C(1) }, new { i = new C(3) } }).OrderBy(x => x.i).Select(x => x.i.value).ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void OrderByWithSelectorAndComparerWorksForArray() {
			Assert.AreEqual(new[] { new { i = new C(3) }, new { i = new C(1) }, new { i = new C(2) }, new { i = new C(4) }, new { i = new C(5) } }.OrderBy(x => x.i, new DescendingComparer()).Select(x => x.i.value).ToArray(), new[] { 5, 4, 3, 2, 1 });
		}

		[Test]
		public void OrderByWithSelectorAndComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { new { i = new C(3) }, new { i = new C(1) }, new { i = new C(2) }, new { i = new C(4) }, new { i = new C(5) } }.Wrap().OrderBy(x => x.i, new DescendingComparer()).Select(x => x.i.value).ToArray(), new[] { 5, 4, 3, 2, 1 });
		}

		[Test]
		public void OrderByWithSelectorAndComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { new { i = new C(3) }, new { i = new C(1) }, new { i = new C(2) }, new { i = new C(4) }, new { i = new C(5) } }).OrderBy(x => x.i, new DescendingComparer()).Select(x => x.i.value).ToArray(), new[] { 5, 4, 3, 2, 1 });
		}


		[Test]
		public void OrderByDescendingWithoutSelectorWorksForArray() {
			Assert.AreEqual(new[] { 3, 1, 2, 4, 5 }.OrderByDescending().ToArray(), new[] { 5, 4, 3, 2, 1 });
			Assert.AreEqual(new[] { new C(3), new C(1), new C(2), new C(4), new C(5) }.OrderByDescending().Select(x => x.value).ToArray(), new[] { 5, 4, 3, 2, 1 });
		}

		[Test]
		public void OrderByDescendingWithoutSelectorWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 3, 1, 2, 4, 5 }.Wrap().OrderByDescending().ToArray(), new[] { 5, 4, 3, 2, 1 });
			Assert.AreEqual(new[] { new C(3), new C(1), new C(2), new C(4), new C(5) }.Wrap().OrderByDescending().Select(x => x.value).ToArray(), new[] { 5, 4, 3, 2, 1 });
		}

		[Test]
		public void OrderByDescendingWithoutSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 3, 1, 2, 4, 5 }).OrderByDescending().ToArray(), new[] { 5, 4, 3, 2, 1 });
			Assert.AreEqual(Enumerable.From(new[] { new C(3), new C(1), new C(2), new C(4), new C(5) }).OrderByDescending().Select(x => x.value).ToArray(), new[] { 5, 4, 3, 2, 1 });
		}

		[Test]
		public void OrderByDescendingWithSelectorWorksForArray() {
			Assert.AreEqual(new[] { new { i = 3 }, new { i = 1 }, new { i = 2 }, new { i = 4 }, new { i = 5 } }.OrderByDescending(x => x.i).Select(x => x.i).ToArray(), new[] { 5, 4, 3, 2, 1 });
			Assert.AreEqual(new[] { new { i = new C(3) }, new { i = new C(1) }, new { i = new C(2) }, new { i = new C(4) }, new { i = new C(5) } }.OrderByDescending(x => x.i).Select(x => x.i.value).ToArray(), new[] { 5, 4, 3, 2, 1 });
		}

		[Test]
		public void OrderByDescendingWithSelectorWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { new { i = 3 }, new { i = 1 }, new { i = 2 }, new { i = 4 }, new { i = 5 } }.Wrap().OrderByDescending(x => x.i).Select(x => x.i).ToArray(), new[] { 5, 4, 3, 2, 1 });
			Assert.AreEqual(new[] { new { i = new C(3) }, new { i = new C(1) }, new { i = new C(2) }, new { i = new C(4) }, new { i = new C(5) } }.Wrap().OrderByDescending(x => x.i).Select(x => x.i.value).ToArray(), new[] { 5, 4, 3, 2, 1 });
		}

		[Test]
		public void OrderByDescendingWithSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { new { i = 3 }, new { i = 1 }, new { i = 2 }, new { i = 4 }, new { i = 5 } }).OrderByDescending(x => x.i).Select(x => x.i).ToArray(), new[] { 5, 4, 3, 2, 1 });
			Assert.AreEqual(Enumerable.From(new[] { new { i = new C(3) }, new { i = new C(1) }, new { i = new C(2) }, new { i = new C(4) }, new { i = new C(5) } }).OrderByDescending(x => x.i).Select(x => x.i.value).ToArray(), new[] { 5, 4, 3, 2, 1 });
		}

		[Test]
		public void OrderByDescendingWithSelectorAndComparerWorksForArray() {
			Assert.AreEqual(new[] { new { i = new C(5) }, new { i = new C(4) }, new { i = new C(2) }, new { i = new C(1) }, new { i = new C(3) } }.OrderByDescending(x => x.i, new DescendingComparer()).Select(x => x.i.value).ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void OrderByDescendingWithSelectorAndComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { new { i = new C(5) }, new { i = new C(4) }, new { i = new C(2) }, new { i = new C(1) }, new { i = new C(3) } }.Wrap().OrderByDescending(x => x.i, new DescendingComparer()).Select(x => x.i.value).ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void OrderByDescendingWithSelectorAndComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { new { i = new C(5) }, new { i = new C(4) }, new { i = new C(2) }, new { i = new C(1) }, new { i = new C(3) } }).OrderByDescending(x => x.i, new DescendingComparer()).Select(x => x.i.value).ToArray(), new[] { 1, 2, 3, 4, 5 });
		}


		[Test]
		public void ThenByWithoutComparerWorksForLinqJSOrderedEnumerable() {
			var arr = new[] { new { a = 2, b = 4, c = 1 }, new { a = 2, b = 3, c = 7 }, new { a = 2, b = 3, c = 3 }, new { a = 4, b = 7, c = 5 }, new { a = 7, b = 3, c = 2 }, new { a = 4, b = 1, c = 5 } };
			var result = arr.OrderBy(x => x.a).ThenBy(x => x.c).ThenBy(x => x.b).ToArray();
			Assert.AreEqual(result, new[] { new { a = 2, b = 4, c = 1 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 3, c = 7 }, new { a = 4, b = 1, c = 5 }, new { a = 4, b = 7, c = 5 }, new { a = 7, b = 3, c = 2 } });

			var arr2 = new[] { new { a = new C(2), b = new C(4), c = new C(1) }, new { a = new C(2), b = new C(3), c = new C(7) }, new { a = new C(2), b = new C(3), c = new C(3) }, new { a = new C(4), b = new C(7), c = new C(5) }, new { a = new C(7), b = new C(3), c = new C(2) }, new { a = new C(4), b = new C(1), c = new C(5) } };
			var result2 = arr2.OrderBy(x => x.a).ThenBy(x => x.c).ThenBy(x => x.b).Select(x => new { a = x.a.value, b = x.b.value, c = x.c.value }).ToArray();
			Assert.AreEqual(result2, new[] { new { a = 2, b = 4, c = 1 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 3, c = 7 }, new { a = 4, b = 1, c = 5 }, new { a = 4, b = 7, c = 5 }, new { a = 7, b = 3, c = 2 } });
		}

		[Test]
		public void ThenByWithoutComparerWorksForIOrderedEnumerable() {
			var arr = new[] { new { a = 2, b = 4, c = 1 }, new { a = 2, b = 3, c = 7 }, new { a = 2, b = 3, c = 3 }, new { a = 4, b = 7, c = 5 }, new { a = 7, b = 3, c = 2 }, new { a = 4, b = 1, c = 5 } };
			var result = OrderBy(arr, x => x.a).ThenBy(x => x.c).ThenBy(x => x.b).ToArray();
			Assert.AreEqual(result, new[] { new { a = 2, b = 4, c = 1 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 3, c = 7 }, new { a = 4, b = 1, c = 5 }, new { a = 4, b = 7, c = 5 }, new { a = 7, b = 3, c = 2 } });

			var arr2 = new[] { new { a = new C(2), b = new C(4), c = new C(1) }, new { a = new C(2), b = new C(3), c = new C(7) }, new { a = new C(2), b = new C(3), c = new C(3) }, new { a = new C(4), b = new C(7), c = new C(5) }, new { a = new C(7), b = new C(3), c = new C(2) }, new { a = new C(4), b = new C(1), c = new C(5) } };
			var result2 = OrderBy(arr2, x => x.a).ThenBy(x => x.c).ThenBy(x => x.b).Select(x => new { a = x.a.value, b = x.b.value, c = x.c.value }).ToArray();
			Assert.AreEqual(result2, new[] { new { a = 2, b = 4, c = 1 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 3, c = 7 }, new { a = 4, b = 1, c = 5 }, new { a = 4, b = 7, c = 5 }, new { a = 7, b = 3, c = 2 } });
		}

		[Test]
		public void ThenByWithComparerWorksForLinqJSOrderedEnumerable() {
			var arr = new[] { new { a = new C(2), b = new C(4), c = new C(1) }, new { a = new C(2), b = new C(3), c = new C(7) }, new { a = new C(2), b = new C(3), c = new C(3) }, new { a = new C(4), b = new C(7), c = new C(5) }, new { a = new C(7), b = new C(3), c = new C(2) }, new { a = new C(4), b = new C(1), c = new C(5) } };
			var result = arr.OrderBy(x => x.a).ThenBy(x => x.c, new DescendingComparer()).ThenBy(x => x.b, new DescendingComparer()).Select(x => new { a = x.a.value, b = x.b.value, c = x.c.value }).ToArray();
			Assert.AreEqual(result, new[] { new { a = 2, b = 3, c = 7 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 4, c = 1 }, new { a = 4, b = 7, c = 5 }, new { a = 4, b = 1, c = 5 }, new { a = 7, b = 3, c = 2 } });
		}

		[Test]
		public void ThenByWithComparerWorksForIOrderedEnumerable() {
			var arr = new[] { new { a = new C(2), b = new C(4), c = new C(1) }, new { a = new C(2), b = new C(3), c = new C(7) }, new { a = new C(2), b = new C(3), c = new C(3) }, new { a = new C(4), b = new C(7), c = new C(5) }, new { a = new C(7), b = new C(3), c = new C(2) }, new { a = new C(4), b = new C(1), c = new C(5) } };
			var result = OrderBy(arr, x => x.a).ThenBy(x => x.c, new DescendingComparer()).ThenBy(x => x.b, new DescendingComparer()).Select(x => new { a = x.a.value, b = x.b.value, c = x.c.value }).ToArray();
			Assert.AreEqual(result, new[] { new { a = 2, b = 3, c = 7 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 4, c = 1 }, new { a = 4, b = 7, c = 5 }, new { a = 4, b = 1, c = 5 }, new { a = 7, b = 3, c = 2 } });
		}


		[Test]
		public void ThenByDescendingWithoutComparerWorksForLinqJSOrderedEnumerable() {
			var arr = new[] { new { a = 2, b = 4, c = 1 }, new { a = 2, b = 3, c = 7 }, new { a = 2, b = 3, c = 3 }, new { a = 4, b = 7, c = 5 }, new { a = 7, b = 3, c = 2 }, new { a = 4, b = 1, c = 5 } };
			var result = arr.OrderBy(x => x.a).ThenByDescending(x => x.c).ThenByDescending(x => x.b).ToArray();
			Assert.AreEqual(result, new[] { new { a = 2, b = 3, c = 7 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 4, c = 1 }, new { a = 4, b = 7, c = 5 }, new { a = 4, b = 1, c = 5 }, new { a = 7, b = 3, c = 2 } });

			var arr2 = new[] { new { a = new C(2), b = new C(4), c = new C(1) }, new { a = new C(2), b = new C(3), c = new C(7) }, new { a = new C(2), b = new C(3), c = new C(3) }, new { a = new C(4), b = new C(7), c = new C(5) }, new { a = new C(7), b = new C(3), c = new C(2) }, new { a = new C(4), b = new C(1), c = new C(5) } };
			var result2 = arr2.OrderBy(x => x.a).ThenByDescending(x => x.c).ThenByDescending(x => x.b).Select(x => new { a = x.a.value, b = x.b.value, c = x.c.value }).ToArray();
			Assert.AreEqual(result2, new[] { new { a = 2, b = 3, c = 7 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 4, c = 1 }, new { a = 4, b = 7, c = 5 }, new { a = 4, b = 1, c = 5 }, new { a = 7, b = 3, c = 2 } });
		}

		[Test]
		public void ThenByDescendingWithoutComparerWorksForIOrderedEnumerable() {
			var arr = new[] { new { a = 2, b = 4, c = 1 }, new { a = 2, b = 3, c = 7 }, new { a = 2, b = 3, c = 3 }, new { a = 4, b = 7, c = 5 }, new { a = 7, b = 3, c = 2 }, new { a = 4, b = 1, c = 5 } };
			var result = OrderBy(arr, x => x.a).ThenByDescending(x => x.c).ThenByDescending(x => x.b).ToArray();
			Assert.AreEqual(result, new[] { new { a = 2, b = 3, c = 7 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 4, c = 1 }, new { a = 4, b = 7, c = 5 }, new { a = 4, b = 1, c = 5 }, new { a = 7, b = 3, c = 2 } });

			var arr2 = new[] { new { a = new C(2), b = new C(4), c = new C(1) }, new { a = new C(2), b = new C(3), c = new C(7) }, new { a = new C(2), b = new C(3), c = new C(3) }, new { a = new C(4), b = new C(7), c = new C(5) }, new { a = new C(7), b = new C(3), c = new C(2) }, new { a = new C(4), b = new C(1), c = new C(5) } };
			var result2 = OrderBy(arr2, x => x.a).ThenByDescending(x => x.c).ThenByDescending(x => x.b).Select(x => new { a = x.a.value, b = x.b.value, c = x.c.value }).ToArray();
			Assert.AreEqual(result2, new[] { new { a = 2, b = 3, c = 7 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 4, c = 1 }, new { a = 4, b = 7, c = 5 }, new { a = 4, b = 1, c = 5 }, new { a = 7, b = 3, c = 2 } });
		}


		[Test]
		public void ThenByDescendingWithComparerWorksForLinqJSOrderedEnumerable() {
			var arr2 = new[] { new { a = new C(2), b = new C(4), c = new C(1) }, new { a = new C(2), b = new C(3), c = new C(7) }, new { a = new C(2), b = new C(3), c = new C(3) }, new { a = new C(4), b = new C(7), c = new C(5) }, new { a = new C(7), b = new C(3), c = new C(2) }, new { a = new C(4), b = new C(1), c = new C(5) } };
			var result2 = arr2.OrderBy(x => x.a).ThenByDescending(x => x.c, new DescendingComparer()).ThenByDescending(x => x.b, new DescendingComparer()).Select(x => new { a = x.a.value, b = x.b.value, c = x.c.value }).ToArray();
			Assert.AreEqual(result2, new[] { new { a = 2, b = 4, c = 1 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 3, c = 7 }, new { a = 4, b = 1, c = 5 }, new { a = 4, b = 7, c = 5 }, new { a = 7, b = 3, c = 2 } });
		}

		[Test]
		public void ThenByDescendingWithComparerWorksForIOrderedEnumerable() {
			var arr2 = new[] { new { a = new C(2), b = new C(4), c = new C(1) }, new { a = new C(2), b = new C(3), c = new C(7) }, new { a = new C(2), b = new C(3), c = new C(3) }, new { a = new C(4), b = new C(7), c = new C(5) }, new { a = new C(7), b = new C(3), c = new C(2) }, new { a = new C(4), b = new C(1), c = new C(5) } };
			var result2 = OrderBy(arr2, x => x.a).ThenByDescending(x => x.c, new DescendingComparer()).ThenByDescending(x => x.b, new DescendingComparer()).Select(x => new { a = x.a.value, b = x.b.value, c = x.c.value }).ToArray();
			Assert.AreEqual(result2, new[] { new { a = 2, b = 4, c = 1 }, new { a = 2, b = 3, c = 3 }, new { a = 2, b = 3, c = 7 }, new { a = 4, b = 1, c = 5 }, new { a = 4, b = 7, c = 5 }, new { a = 7, b = 3, c = 2 } });
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
