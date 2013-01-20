using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class SetMethodTests {
		[Test]
		public void AllWorksForArray() {
			Assert.IsTrue(new[] { 1, 2, 3 }.All(x => x > 0));
			Assert.IsFalse(new[] { 0, 1, 2 }.All(x => x > 0));
		}

		[Test]
		public void AllWorksForLinqJSEnumerable() {
			Assert.IsTrue(Enumerable.Repeat(1, 3).All(x => x > 0));
			Assert.IsFalse(Enumerable.Repeat(0, 3).All(x => x > 0));
		}


		[Test]
		public void AnyWorksForArray() {
			Assert.IsFalse(new int[0].Any());
			Assert.IsTrue(new[] { 1 }.Any());
		}

		[Test]
		public void AnyWorksForLinqJSEnumerable() {
			Assert.IsTrue(Enumerable.Repeat(0, 3).Any());
			Assert.IsFalse(Enumerable.Empty<int>().Any());
		}

		[Test]
		public void AnyWithPredicateWorksForArray() {
			Assert.IsTrue(new[] { 0, 1, 2 }.Any(x => x == 0));
			Assert.IsFalse(new[] { 1, 2, 3 }.Any(x => x == 0));
		}

		[Test]
		public void AnyWithPredicateWorksForLinqJSEnumerable() {
			Assert.IsTrue(Enumerable.Repeat(0, 3).Any(x => x == 0));
			Assert.IsFalse(Enumerable.Repeat(1, 3).Any(x => x == 0));
		}


		[Test]
		public void ConcatWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new TestEnumerable(1, 3).Concat(new[] { 4, 5, 6 }).ToArray(), new[] { 1, 2, 3, 4, 5, 6 });
		}

		[Test]
		public void ConcatWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 3).Concat(new[] { 4, 5, 6 }).ToArray(), new[] { 1, 2, 3, 4, 5, 6 });
		}


		[Test]
		public void InsertWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new TestEnumerable(1, 3).Insert(1, new[] { 4, 5, 6 }).ToArray(), new[] { 1, 4, 5, 6, 2, 3 });
		}

		[Test]
		public void InsertWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 3).Insert(1, new[] { 4, 5, 6 }).ToArray(), new[] { 1, 4, 5, 6, 2, 3 });
		}


		[Test]
		public void AlternateWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new TestEnumerable(1, 5).Alternate(-1).ToArray(), new[] { 1, -1, 2, -1, 3, -1, 4, -1, 5 });
		}

		[Test]
		public void AlternateWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Alternate(-1).ToArray(), new[] { 1, -1, 2, -1, 3, -1, 4, -1, 5 });
		}


		[Test]
		public void ContainsWorksForSaltarelleEnumerable() {
			Assert.IsFalse(new TestEnumerable(1, 3).Contains(0));
			Assert.IsTrue(new TestEnumerable(1, 3).Contains(1));
		}

		[Test]
		public void ContainsWithCompareSelectorWorksForSaltarelleEnumerable() {
			Assert.IsFalse(new TestEnumerable(10, 3).Contains(4, i => i % 5));
			Assert.IsTrue(new TestEnumerable(10, 3).Contains(2, i => i % 5));
		}

		[Test]
		public void ContainsWorksForLinqJSEnumerable() {
			Assert.IsFalse(Enumerable.Range(1, 3).Contains(0));
			Assert.IsTrue(Enumerable.Range(1, 3).Contains(1));
		}

		[Test]
		public void ContainsWithCompareSelectorWorksForLinqJSEnumerable() {
			Assert.IsFalse(Enumerable.Range(10, 3).Contains(4, i => i % 5));
			Assert.IsTrue(Enumerable.Range(10, 3).Contains(2, i => i % 5));
		}


		[Test]
		public void DefaultIfEmptyWithoutArgumentWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new TestEnumerable(1, 3).DefaultIfEmpty().ToArray(), new[] { 1, 2, 3 });
			Assert.AreEqual(new TestEnumerable(1, 0).DefaultIfEmpty().ToArray(), new[] { 0 });
		}

		[Test]
		public void DefaultIfEmptyWithArgumentWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new TestEnumerable(1, 3).DefaultIfEmpty(8).ToArray(), new[] { 1, 2, 3 });
			Assert.AreEqual(new TestEnumerable(1, 0).DefaultIfEmpty(8).ToArray(), new[] { 8 });
		}

		[Test]
		public void DefaultIfEmptyWithoutArgumentWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 3).DefaultIfEmpty().ToArray(), new[] { 1, 2, 3 });
			Assert.AreEqual(Enumerable.Range(1, 0).DefaultIfEmpty().ToArray(), new[] { 0 });
		}

		[Test]
		public void DefaultIfEmptyWithArgumentWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 3).DefaultIfEmpty(8).ToArray(), new[] { 1, 2, 3 });
			Assert.AreEqual(Enumerable.Range(1, 0).DefaultIfEmpty(8).ToArray(), new[] { 8 });
		}


		[Test]
		public void DistinctWorksForArray() {
			Assert.AreEqual(new[] { 1, 4, 1, 3, 7, 1, 4, 3 }.Distinct().ToArray(), new[] { 1, 4, 3, 7 });
		}

		[Test]
		public void DistinctWithCompareSelectorWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Distinct(i => i % 3).ToArray(), new[] { 1, 2, 3 });
		}

		[Test]
		public void DistinctWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 4, 1, 3, 7, 1, 4, 3 }.Select(x => x).Distinct().ToArray(), new[] { 1, 4, 3, 7 });
		}

		[Test]
		public void DistinctWithCompareSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 10).Distinct(i => i % 3).ToArray(), new[] { 1, 2, 3 });
		}


		[Test]
		public void ExceptWorksForArray() {
			Assert.AreEqual(Enumerable.Range(1, 5).Except(Enumerable.Range(3, 7)).ToArray(), new[] { 1, 2 });
		}

		[Test]
		public void ExceptWithCompareSelectorWorksForArray() {
			Assert.AreEqual(new[] { new { i = 1 }, new { i = 2}, new { i = 3 }, new { i = 4 }, new { i = 5 } }.Except(new[] { new { i = 3 }, new { i = 4 }, new { i = 5 }, new { i = 6 }, new { i = 7 } }, x => x.i).ToArray(), new[] { new { i = 1 }, new { i = 2 } });
		}

		[Test]
		public void ExceptWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Except(Enumerable.Range(3, 7)).ToArray(), new[] { 1, 2 });
		}

		[Test]
		public void ExceptWithCompareSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i }).Except(Enumerable.Range(3, 7).Select(i => new { i }), x => x.i).ToArray(), new[] { new { i = 1 }, new { i = 2 } });
		}

		
		[Test]
		public void SequenceEqualWorksForArray() {
			Assert.IsTrue(new[] { 1, 2, 3, 4, 5 }.SequenceEqual(new[] { 1, 2, 3, 4, 5 }));
			Assert.IsFalse(new[] { 1, 2, 3, 4, 5 }.SequenceEqual(new[] { 1, 2, 3, 4, 5, 6 }));
		}

		[Test]
		public void SequenceEqualWithCompareSelectorWorksForArray() {
			Assert.IsTrue(new[] { new { i = 1 }, new { i = 2 }, new { i = 3 }, new { i = 4 }, new { i = 5 } }.SequenceEqual(new[] { new { i = 1 }, new { i = 2 }, new { i = 3 }, new { i = 4 }, new { i = 5 } }, x => x.i));
			Assert.IsFalse(new[] { new { i = 1 }, new { i = 2 }, new { i = 3 }, new { i = 4 }, new { i = 5 } }.SequenceEqual(new[] { new { i = 1 }, new { i = 2 }, new { i = 3 }, new { i = 4 }, new { i = 5 }, new { i = 6 } }, x => x.i));
		}

		[Test]
		public void SequenceEqualWorksForLinqJSEnumerable() {
			Assert.IsTrue(Enumerable.Range(1, 5).SequenceEqual(Enumerable.Range(1, 5)));
			Assert.IsFalse(Enumerable.Range(1, 5).SequenceEqual(Enumerable.Range(1, 6)));
		}

		[Test]
		public void SequenceEqualWithCompareSelectorWorksForLinqJSEnumerable() {
			Assert.IsTrue(Enumerable.Range(1, 5).Select(i => new { i }).SequenceEqual(Enumerable.Range(1, 5).Select(i => new { i }), x => x.i));
			Assert.IsFalse(Enumerable.Range(1, 5).Select(i => new { i }).SequenceEqual(Enumerable.Range(1, 6).Select(i => new { i }), x => x.i));
		}


		[Test]
		public void UnionWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4 }.Union(new[] { 2, 3, 4, 5 }).ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void UnionWithCompareSelectorWorksForArray() {
			Assert.AreEqual(new[] { new { i = 1 }, new { i = 2 }, new { i = 3 }, new {i = 4 } }.Union(new[] { new { i = 2 }, new { i = 3 }, new {i = 4 },  new { i = 5 } }, x => x.i).ToArray(), new[] { new { i = 1 }, new { i = 2 }, new { i = 3 }, new {i = 4 }, new { i = 5 } });
		}

		[Test]
		public void UnionWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 4).Union(Enumerable.Range(2, 4)).ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void UnionWithCompareSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 4).Select(i => new { i }).Union(Enumerable.Range(2, 4).Select(i => new { i }), x => x.i).ToArray(), new[] { new { i = 1 }, new { i = 2 }, new { i = 3 }, new { i = 4 }, new { i = 5 } });
		}
	}
}
