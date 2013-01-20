using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class GroupingTests {
		[Test]
		public void GroupByWithOnlyKeySelectorWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => i % 2).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 1, 3, 5 } }, new { key = 0, value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithOnlyKeySelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1,5).GroupBy(i => i % 2).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 1, 3, 5 } }, new { key = 0, value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementSelectorsWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => i % 2, i => i * 10).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10, 30, 50 } }, new { key = 0, value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementSelectorsForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1,5).GroupBy(i => i % 2, i => i * 10).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10, 30, 50 } }, new { key = 0, value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementAndResultSelectorsWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => i % 2, i => i * 10, (key, value) => new { key, value = value.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10, 30, 50 } }, new { key = 0, value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementAndResultSelectorsWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1,5).GroupBy(i => i % 2, i => i * 10, (key, value) => new { key, value = value.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10, 30, 50 } }, new { key = 0, value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementAndResultAndCompareSelectorsWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => i, i => i * 10, (key, value) => new { key, value = value.ToArray() }, i => i % 2).ToArray(), new[] { new { key = 1, value = new[] { 10, 30, 50 } }, new { key = 2, value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementAndResultAndCompareSelectorsWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1,5).GroupBy(i => i, i => i * 10, (key, value) => new { key, value = value.ToArray() }, i => i % 2).ToArray(), new[] { new { key = 1, value = new[] { 10, 30, 50 } }, new { key = 2, value = new[] { 20, 40 } } });
		}

		[Test]
		public void PartitionByWithOnlyKeySelectorWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 2, 3, 3, 2, 1, 1 }.PartitionBy(i => i).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 1 } }, new { key = 2, value = new[] { 2, 2 } }, new { key = 3, value = new[] { 3, 3 } }, new { key = 2, value = new[] { 2 } }, new { key = 1, value = new[] { 1, 1 } } });
		}

		[Test]
		public void PartitionByWithOnlyKeySelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 2, 3, 3, 2, 1, 1 }.Select(x => x).PartitionBy(i => i).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 1 } }, new { key = 2, value = new[] { 2, 2 } }, new { key = 3, value = new[] { 3, 3 } }, new { key = 2, value = new[] { 2 } }, new { key = 1, value = new[] { 1, 1 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementSelectorsWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 2, 3, 3, 2, 1, 1 }.PartitionBy(i => i, i => i * 10).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 20 } }, new { key = 3, value = new[] { 30, 30 } }, new { key = 2, value = new[] { 20 } }, new { key = 1, value = new[] { 10, 10 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementSelectorsWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 2, 3, 3, 2, 1, 1 }.Select(x => x).PartitionBy(i => i, i => i * 10).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 20 } }, new { key = 3, value = new[] { 30, 30 } }, new { key = 2, value = new[] { 20 } }, new { key = 1, value = new[] { 10, 10 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementAndResultSelectorsWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 2, 3, 3, 2, 1, 1 }.PartitionBy(i => i, i => i * 10, (key, value) => new { key, value = value.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 20 } }, new { key = 3, value = new[] { 30, 30 } }, new { key = 2, value = new[] { 20 } }, new { key = 1, value = new[] { 10, 10 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementAndResultSelectorsWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 2, 3, 3, 2, 1, 1 }.Select(x => x).PartitionBy(i => i, i => i * 10, (key, value) => new { key, value = value.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 20 } }, new { key = 3, value = new[] { 30, 30 } }, new { key = 2, value = new[] { 20 } }, new { key = 1, value = new[] { 10, 10 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementAndResultAndCompareSelectorsWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 2, 3, 3, 2, 1, 1 }.PartitionBy(i => i, i => i * 10, (key, value) => new { key, value = value.ToArray() }, i => Math.Min(i, 2)).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 20, 30, 30, 20 } }, new { key = 1, value = new[] { 10, 10 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementAndResultAndCompareSelectorsWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 2, 3, 3, 2, 1, 1 }.Select(x => x).PartitionBy(i => i, i => i * 10, (key, value) => new { key, value = value.ToArray() }, i => Math.Min(i, 2)).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 20, 30, 30, 20 } }, new { key = 1, value = new[] { 10, 10 } } });
		}


		[Test]
		public void BufferWithCountWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Buffer(4).ToArray(), new[] { new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 }, new[] { 9, 10 } });
		}

		[Test]
		public void BufferWithCountWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 10).Buffer(4).ToArray(), new[] { new[] { 1, 2, 3, 4 }, new[] { 5, 6, 7, 8 }, new[] { 9, 10 } });
		}
	}
}
