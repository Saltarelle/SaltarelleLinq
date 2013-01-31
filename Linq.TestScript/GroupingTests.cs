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
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => new C((i % 2).ToString())).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 1, 3, 5 } }, new { key = "0", value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithOnlyKeySelectorWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => i % 2).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 1, 3, 5 } }, new { key = 0, value = new[] { 2, 4 } } });
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => new C((i % 2).ToString())).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 1, 3, 5 } }, new { key = "0", value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithOnlyKeySelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => i % 2).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 1, 3, 5 } }, new { key = 0, value = new[] { 2, 4 } } });
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => new C((i % 2).ToString())).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 1, 3, 5 } }, new { key = "0", value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithKeySelectorAndComparerWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => new C((i % 2).ToString() + (i + 1)), new FirstLetterComparer()).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "12", value = new[] { 1, 3, 5 } }, new { key = "03", value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithKeySelectorAndComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => new C((i % 2).ToString() + (i + 1)), new FirstLetterComparer()).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "12", value = new[] { 1, 3, 5 } }, new { key = "03", value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithKeySelectorAndComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 5 }).GroupBy(i => new C((i % 2).ToString() + (i + 1)), new FirstLetterComparer()).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "12", value = new[] { 1, 3, 5 } }, new { key = "03", value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementSelectorsWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => i % 2, i => i * 10).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10, 30, 50 } }, new { key = 0, value = new[] { 20, 40 } } });
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => new C((i % 2).ToString()), i => i * 10).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10, 30, 50 } }, new { key = "0", value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementSelectorsWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => i % 2, i => i * 10).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10, 30, 50 } }, new { key = 0, value = new[] { 20, 40 } } });
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => new C((i % 2).ToString()), i => i * 10).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10, 30, 50 } }, new { key = "0", value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementSelectorsWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 5 }).GroupBy(i => i % 2, i => i * 10).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10, 30, 50 } }, new { key = 0, value = new[] { 20, 40 } } });
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 5 }).GroupBy(i => new C((i % 2).ToString()), i => i * 10).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10, 30, 50 } }, new { key = "0", value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndResultSelectorsWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => i % 2, (key, g) => new { key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 1, 3, 5 } }, new { key = 0, value = new[] { 2, 4 } } });
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => new C((i % 2).ToString()), (key, g) => new { key = key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 1, 3, 5 } }, new { key = "0", value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithKeyAndResultSelectorsWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => i % 2, (key, g) => new { key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 1, 3, 5 } }, new { key = 0, value = new[] { 2, 4 } } });
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => new C((i % 2).ToString()), (key, g) => new { key = key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 1, 3, 5 } }, new { key = "0", value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithKeyAndResultSelectorsWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 5 }).GroupBy(i => i % 2, (key, g) => new { key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 1, 3, 5 } }, new { key = 0, value = new[] { 2, 4 } } });
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 5 }).GroupBy(i => new C((i % 2).ToString()), (key, g) => new { key = key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 1, 3, 5 } }, new { key = "0", value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementSelectorsAndComparerWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => new C((i % 2).ToString() + (i + 1)), i => i * 10, new FirstLetterComparer()).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "12", value = new[] { 10, 30, 50 } }, new { key = "03", value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementSelectorsAndComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => new C((i % 2).ToString() + (i + 1)), i => i * 10, new FirstLetterComparer()).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "12", value = new[] { 10, 30, 50 } }, new { key = "03", value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementSelectorsAndComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 5 }).GroupBy(i => new C((i % 2).ToString() + (i + 1)), i => i * 10, new FirstLetterComparer()).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "12", value = new[] { 10, 30, 50 } }, new { key = "03", value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementAndResultSelectorsWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => i % 2, i => i * 10, (key, g) => new { key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10, 30, 50 } }, new { key = 0, value = new[] { 20, 40 } } });
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => new C((i % 2).ToString()), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10, 30, 50 } }, new { key = "0", value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementAndResultSelectorsWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => i % 2, i => i * 10, (key, g) => new { key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10, 30, 50 } }, new { key = 0, value = new[] { 20, 40 } } });
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => new C((i % 2).ToString()), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10, 30, 50 } }, new { key = "0", value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementAndResultSelectorsWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 5 }).GroupBy(i => i % 2, i => i * 10, (key, g) => new { key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10, 30, 50 } }, new { key = 0, value = new[] { 20, 40 } } });
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 5 }).GroupBy(i => new C((i % 2).ToString()), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10, 30, 50 } }, new { key = "0", value = new[] { 20, 40 } } });
		}


		[Test]
		public void GroupByWithKeyAndResultSelectorsAndComparerWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => new C((i % 2).ToString() + (i + 1)), (key, g) => new { key = key.S, value = g.ToArray() }, new FirstLetterComparer()).ToArray(), new[] { new { key = "12", value = new[] { 1, 3, 5 } }, new { key = "03", value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithKeyAndResultSelectorsAndComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => new C((i % 2).ToString() + (i + 1)), (key, g) => new { key = key.S, value = g.ToArray() }, new FirstLetterComparer()).ToArray(), new[] { new { key = "12", value = new[] { 1, 3, 5 } }, new { key = "03", value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithKeyAndResultSelectorsAndComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 5 }).GroupBy(i => new C((i % 2).ToString() + (i + 1)), (key, g) => new { key = key.S, value = g.ToArray() }, new FirstLetterComparer()).ToArray(), new[] { new { key = "12", value = new[] { 1, 3, 5 } }, new { key = "03", value = new[] { 2, 4 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementAndResultSelectorsAndComparerWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => new C((i % 2).ToString() + (i + 1)), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }, new FirstLetterComparer()).ToArray(), new[] { new { key = "12", value = new[] { 10, 30, 50 } }, new { key = "03", value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementAndResultSelectorsAndComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().GroupBy(i => new C((i % 2).ToString() + (i + 1)), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }, new FirstLetterComparer()).ToArray(), new[] { new { key = "12", value = new[] { 10, 30, 50 } }, new { key = "03", value = new[] { 20, 40 } } });
		}

		[Test]
		public void GroupByWithKeyAndElementAndResultSelectorsAndComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.GroupBy(i => new C((i % 2).ToString() + (i + 1)), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }, new FirstLetterComparer()).ToArray(), new[] { new { key = "12", value = new[] { 10, 30, 50 } }, new { key = "03", value = new[] { 20, 40 } } });
		}


		[Test]
		public void PartitionByWithOnlyKeySelectorWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.PartitionBy(i => i % 4).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 1 } }, new { key = 2, value = new[] { 2, 6 } }, new { key = 3, value = new[] { 7, 11 } }, new { key = 2, value = new[] { 10 } }, new { key = 1, value = new[] { 5, 9 } } });
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.PartitionBy(i => new C((i % 4).ToString())).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 1 } }, new { key = "2", value = new[] { 2, 6 } }, new { key = "3", value = new[] { 7, 11 } }, new { key = "2", value = new[] { 10 } }, new { key = "1", value = new[] { 5, 9 } } });
		}

		[Test]
		public void PartitionByWithOnlyKeySelectorWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.Wrap().PartitionBy(i => i % 4).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 1 } }, new { key = 2, value = new[] { 2, 6 } }, new { key = 3, value = new[] { 7, 11 } }, new { key = 2, value = new[] { 10 } }, new { key = 1, value = new[] { 5, 9 } } });
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.Wrap().PartitionBy(i => new C((i % 4).ToString())).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 1 } }, new { key = "2", value = new[] { 2, 6 } }, new { key = "3", value = new[] { 7, 11 } }, new { key = "2", value = new[] { 10 } }, new { key = "1", value = new[] { 5, 9 } } });
		}

		[Test]
		public void PartitionByWithOnlyKeySelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }).PartitionBy(i => i % 4).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 1 } }, new { key = 2, value = new[] { 2, 6 } }, new { key = 3, value = new[] { 7, 11 } }, new { key = 2, value = new[] { 10 } }, new { key = 1, value = new[] { 5, 9 } } });
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }).PartitionBy(i => new C((i % 4).ToString())).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 1 } }, new { key = "2", value = new[] { 2, 6 } }, new { key = "3", value = new[] { 7, 11 } }, new { key = "2", value = new[] { 10 } }, new { key = "1", value = new[] { 5, 9 } } });
		}

		[Test]
		public void PartitionByWithKeySelectorAndComparerWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.PartitionBy(i => new C((i % 4).ToString() + i.ToString()), new FirstLetterComparer()).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "11", value = new[] { 1 } }, new { key = "22", value = new[] { 2, 6 } }, new { key = "37", value = new[] { 7, 11 } }, new { key = "210", value = new[] { 10 } }, new { key = "15", value = new[] { 5, 9 } } });
		}

		[Test]
		public void PartitionByWithKeySelectorAndComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.Wrap().PartitionBy(i => new C((i % 4).ToString() + i.ToString()), new FirstLetterComparer()).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "11", value = new[] { 1 } }, new { key = "22", value = new[] { 2, 6 } }, new { key = "37", value = new[] { 7, 11 } }, new { key = "210", value = new[] { 10 } }, new { key = "15", value = new[] { 5, 9 } } });
		}

		[Test]
		public void PartitionByWithKeySelectorAndComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }).PartitionBy(i => new C((i % 4).ToString() + i.ToString()), new FirstLetterComparer()).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "11", value = new[] { 1 } }, new { key = "22", value = new[] { 2, 6 } }, new { key = "37", value = new[] { 7, 11 } }, new { key = "210", value = new[] { 10 } }, new { key = "15", value = new[] { 5, 9 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementSelectorsWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.PartitionBy(i => i % 4, i => i * 10).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 60 } }, new { key = 3, value = new[] { 70, 110 } }, new { key = 2, value = new[] { 100 } }, new { key = 1, value = new[] { 50, 90 } } });
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.PartitionBy(i => new C((i % 4).ToString()), i => i * 10).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10 } }, new { key = "2", value = new[] { 20, 60 } }, new { key = "3", value = new[] { 70, 110 } }, new { key = "2", value = new[] { 100 } }, new { key = "1", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementSelectorsWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.Wrap().PartitionBy(i => i % 4, i => i * 10).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 60 } }, new { key = 3, value = new[] { 70, 110 } }, new { key = 2, value = new[] { 100 } }, new { key = 1, value = new[] { 50, 90 } } });
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.Wrap().PartitionBy(i => new C((i % 4).ToString()), i => i * 10).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10 } }, new { key = "2", value = new[] { 20, 60 } }, new { key = "3", value = new[] { 70, 110 } }, new { key = "2", value = new[] { 100 } }, new { key = "1", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementSelectorsWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }).PartitionBy(i => i % 4, i => i * 10).Select(g => new { key = g.Key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 60 } }, new { key = 3, value = new[] { 70, 110 } }, new { key = 2, value = new[] { 100 } }, new { key = 1, value = new[] { 50, 90 } } });
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }).PartitionBy(i => new C((i % 4).ToString()), i => i * 10).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10 } }, new { key = "2", value = new[] { 20, 60 } }, new { key = "3", value = new[] { 70, 110 } }, new { key = "2", value = new[] { 100 } }, new { key = "1", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndResultSelectorsWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.PartitionBy(i => i % 4, i => i * 10, (key, g) => new { key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 60 } }, new { key = 3, value = new[] { 70, 110 } }, new { key = 2, value = new[] { 100 } }, new { key = 1, value = new[] { 50, 90 } } });
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.PartitionBy(i => new C((i % 4).ToString()), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10 } }, new { key = "2", value = new[] { 20, 60 } }, new { key = "3", value = new[] { 70, 110 } }, new { key = "2", value = new[] { 100 } }, new { key = "1", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndResultSelectorsWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.Wrap().PartitionBy(i => i % 4, i => i * 10, (key, g) => new { key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 60 } }, new { key = 3, value = new[] { 70, 110 } }, new { key = 2, value = new[] { 100 } }, new { key = 1, value = new[] { 50, 90 } } });
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.Wrap().PartitionBy(i => new C((i % 4).ToString()), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10 } }, new { key = "2", value = new[] { 20, 60 } }, new { key = "3", value = new[] { 70, 110 } }, new { key = "2", value = new[] { 100 } }, new { key = "1", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndResultSelectorsWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }).PartitionBy(i => i % 4, i => i * 10, (key, g) => new { key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 60 } }, new { key = 3, value = new[] { 70, 110 } }, new { key = 2, value = new[] { 100 } }, new { key = 1, value = new[] { 50, 90 } } });
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }).PartitionBy(i => new C((i % 4).ToString()), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10 } }, new { key = "2", value = new[] { 20, 60 } }, new { key = "3", value = new[] { 70, 110 } }, new { key = "2", value = new[] { 100 } }, new { key = "1", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementSelectorsAndComparerWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.PartitionBy(i => new C((i % 4).ToString() + i.ToString()), i => i * 10, new FirstLetterComparer()).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "11", value = new[] { 10 } }, new { key = "22", value = new[] { 20, 60 } }, new { key = "37", value = new[] { 70, 110 } }, new { key = "210", value = new[] { 100 } }, new { key = "15", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementSelectorsAndComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.Wrap().PartitionBy(i => new C((i % 4).ToString() + i.ToString()), i => i * 10, new FirstLetterComparer()).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "11", value = new[] { 10 } }, new { key = "22", value = new[] { 20, 60 } }, new { key = "37", value = new[] { 70, 110 } }, new { key = "210", value = new[] { 100 } }, new { key = "15", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementSelectorsAndComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }).PartitionBy(i => new C((i % 4).ToString() + i.ToString()), i => i * 10, new FirstLetterComparer()).Select(g => new { key = g.Key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "11", value = new[] { 10 } }, new { key = "22", value = new[] { 20, 60 } }, new { key = "37", value = new[] { 70, 110 } }, new { key = "210", value = new[] { 100 } }, new { key = "15", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementAndResultSelectorsWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.PartitionBy(i => i % 4, i => i * 10, (key, g) => new { key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 60 } }, new { key = 3, value = new[] { 70, 110 } }, new { key = 2, value = new[] { 100 } }, new { key = 1, value = new[] { 50, 90 } } });
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.PartitionBy(i => new C((i % 4).ToString()), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10 } }, new { key = "2", value = new[] { 20, 60 } }, new { key = "3", value = new[] { 70, 110 } }, new { key = "2", value = new[] { 100 } }, new { key = "1", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementAndResultSelectorsWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.Wrap().PartitionBy(i => i % 4, i => i * 10, (key, g) => new { key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 60 } }, new { key = 3, value = new[] { 70, 110 } }, new { key = 2, value = new[] { 100 } }, new { key = 1, value = new[] { 50, 90 } } });
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.Wrap().PartitionBy(i => new C((i % 4).ToString()), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10 } }, new { key = "2", value = new[] { 20, 60 } }, new { key = "3", value = new[] { 70, 110 } }, new { key = "2", value = new[] { 100 } }, new { key = "1", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementAndResultSelectorsWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }).PartitionBy(i => i % 4, i => i * 10, (key, g) => new { key, value = g.ToArray() }).ToArray(), new[] { new { key = 1, value = new[] { 10 } }, new { key = 2, value = new[] { 20, 60 } }, new { key = 3, value = new[] { 70, 110 } }, new { key = 2, value = new[] { 100 } }, new { key = 1, value = new[] { 50, 90 } } });
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }).PartitionBy(i => new C((i % 4).ToString()), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }).ToArray(), new[] { new { key = "1", value = new[] { 10 } }, new { key = "2", value = new[] { 20, 60 } }, new { key = "3", value = new[] { 70, 110 } }, new { key = "2", value = new[] { 100 } }, new { key = "1", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndResultSelectorsAndComparerWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.PartitionBy(i => new C((i % 4).ToString() + i.ToString()), (key, g) => new { key = key.S, value = g.ToArray() }, new FirstLetterComparer()).ToArray(), new[] { new { key = "11", value = new[] { 1 } }, new { key = "22", value = new[] { 2, 6 } }, new { key = "37", value = new[] { 7, 11 } }, new { key = "210", value = new[] { 10 } }, new { key = "15", value = new[] { 5, 9 } } });
		}

		[Test]
		public void PartitionByWithKeyAndResultSelectorsAndComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.Wrap().PartitionBy(i => new C((i % 4).ToString() + i.ToString()), (key, g) => new { key = key.S, value = g.ToArray() }, new FirstLetterComparer()).ToArray(), new[] { new { key = "11", value = new[] { 1 } }, new { key = "22", value = new[] { 2, 6 } }, new { key = "37", value = new[] { 7, 11 } }, new { key = "210", value = new[] { 10 } }, new { key = "15", value = new[] { 5, 9 } } });
		}

		[Test]
		public void PartitionByWithKeyAndResultSelectorsAndComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }).PartitionBy(i => new C((i % 4).ToString() + i.ToString()), (key, g) => new { key = key.S, value = g.ToArray() }, new FirstLetterComparer()).ToArray(), new[] { new { key = "11", value = new[] { 1 } }, new { key = "22", value = new[] { 2, 6 } }, new { key = "37", value = new[] { 7, 11 } }, new { key = "210", value = new[] { 10 } }, new { key = "15", value = new[] { 5, 9 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementAndResultSelectorsAndComparerWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.PartitionBy(i => new C((i % 4).ToString() + i.ToString()), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }, new FirstLetterComparer()).ToArray(), new[] { new { key = "11", value = new[] { 10 } }, new { key = "22", value = new[] { 20, 60 } }, new { key = "37", value = new[] { 70, 110 } }, new { key = "210", value = new[] { 100 } }, new { key = "15", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementAndResultSelectorsAndComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }.Wrap().PartitionBy(i => new C((i % 4).ToString() + i.ToString()), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }, new FirstLetterComparer()).ToArray(), new[] { new { key = "11", value = new[] { 10 } }, new { key = "22", value = new[] { 20, 60 } }, new { key = "37", value = new[] { 70, 110 } }, new { key = "210", value = new[] { 100 } }, new { key = "15", value = new[] { 50, 90 } } });
		}

		[Test]
		public void PartitionByWithKeyAndElementAndResultSelectorsAndComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 6, 7, 11, 10, 5, 9 }).PartitionBy(i => new C((i % 4).ToString() + i.ToString()), i => i * 10, (key, g) => new { key = key.S, value = g.ToArray() }, new FirstLetterComparer()).ToArray(), new[] { new { key = "11", value = new[] { 10 } }, new { key = "22", value = new[] { 20, 60 } }, new { key = "37", value = new[] { 70, 110 } }, new { key = "210", value = new[] { 100 } }, new { key = "15", value = new[] { 50, 90 } } });
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
