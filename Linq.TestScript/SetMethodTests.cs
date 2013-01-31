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
			Assert.IsFalse(new[] { 1, 2, 3 }.Wrap().Contains(0));
			Assert.IsTrue (new[] { 1, 2, 3 }.Wrap().Contains(1));
			Assert.IsFalse(new[] { new C("1"), new C("2"), new C("3") }.Wrap().Contains(new C("0")));
			Assert.IsTrue (new[] { new C("1"), new C("2"), new C("3") }.Wrap().Contains(new C("1")));
		}

		[Test]
		public void ContainsWithCompareSelectorWorksForSaltarelleEnumerable() {
			Assert.IsFalse(new[] { new C("11"), new C("21"), new C("31") }.Wrap().Contains(new C("0"), new FirstLetterComparer()));
			Assert.IsTrue (new[] { new C("11"), new C("21"), new C("31") }.Wrap().Contains(new C("1"), new FirstLetterComparer()));
		}

		[Test]
		public void ContainsWorksForLinqJSEnumerable() {
			Assert.IsFalse(Enumerable.From(new[] { 1, 2, 3 }).Contains(0));
			Assert.IsTrue (Enumerable.From(new[] { 1, 2, 3 }).Contains(1));
			Assert.IsFalse(Enumerable.From(new[] { new C("1"), new C("2"), new C("3") }).Contains(new C("0")));
			Assert.IsTrue (Enumerable.From(new[] { new C("1"), new C("2"), new C("3") }).Contains(new C("1")));
		}

		[Test]
		public void ContainsWithComparerWorksForLinqJSEnumerable() {
			Assert.IsFalse(Enumerable.From(new[] { new C("11"), new C("21"), new C("31") }).Contains(new C("0"), new FirstLetterComparer()));
			Assert.IsTrue (Enumerable.From(new[] { new C("11"), new C("21"), new C("31") }).Contains(new C("1"), new FirstLetterComparer()));
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
			Assert.AreEqual(new[] { new C("1"), new C("4"), new C("1"), new C("3"), new C("7"), new C("1"), new C("4"), new C("3") }.Distinct().Select(x => x.S).ToArray(), new[] { "1", "4", "3", "7" });
		}

		[Test]
		public void DistinctWithComparerWorksForArray() {
			Assert.AreEqual(new[] { new C("1"), new C("4"), new C("1"), new C("3"), new C("7"), new C("14"), new C("41"), new C("32") }.Distinct(new FirstLetterComparer()).Select(x => x.S).ToArray(), new[] { "1", "4", "3", "7" });
		}

		[Test]
		public void DistinctWorksForSaltarelleEnumerableArray() {
			Assert.AreEqual(new[] { 1, 4, 1, 3, 7, 1, 4, 3 }.Wrap().Distinct().ToArray(), new[] { 1, 4, 3, 7 });
			Assert.AreEqual(new[] { new C("1"), new C("4"), new C("1"), new C("3"), new C("7"), new C("1"), new C("4"), new C("3") }.Wrap().Distinct().Select(x => x.S).ToArray(), new[] { "1", "4", "3", "7" });
		}

		[Test]
		public void DistinctWithComparerWorksForSaltarelleEnumerableArray() {
			Assert.AreEqual(new[] { new C("1"), new C("4"), new C("1"), new C("3"), new C("7"), new C("14"), new C("41"), new C("32") }.Wrap().Distinct(new FirstLetterComparer()).Select(x => x.S).ToArray(), new[] { "1", "4", "3", "7" });
		}

		[Test]
		public void DistinctWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 4, 1, 3, 7, 1, 4, 3 }).Distinct().ToArray(), new[] { 1, 4, 3, 7 });
			Assert.AreEqual(Enumerable.From(new[] { new C("1"), new C("4"), new C("1"), new C("3"), new C("7"), new C("1"), new C("4"), new C("3") }).Distinct().Select(x => x.S).ToArray(), new[] { "1", "4", "3", "7" });
		}

		[Test]
		public void DistinctWithCompareSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { new C("1"), new C("4"), new C("1"), new C("3"), new C("7"), new C("14"), new C("41"), new C("32") }).Distinct(new FirstLetterComparer()).Select(x => x.S).ToArray(), new[] { "1", "4", "3", "7" });
		}


		[Test]
		public void ExceptWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Except(new[] { 3, 4, 5, 6, 7 }).ToArray(), new[] { 1, 2 });
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }.Except(new[] { new C("3"), new C("4"), new C("5"), new C("6"), new C("7") }).ToArray(), new[] { new C("1"), new C("2") });
		}

		[Test]
		public void ExceptWithComparerWorksForArray() {
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }.Except(new[] { new C("31"), new C("41"), new C("51"), new C("61"), new C("71") }, new FirstLetterComparer()).ToArray(), new[] { new C("1"), new C("2") });
		}

		[Test]
		public void ExceptWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().Except(new[] { 3, 4, 5, 6, 7 }).ToArray(), new[] { 1, 2 });
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }.Wrap().Except(new[] { new C("3"), new C("4"), new C("5"), new C("6"), new C("7") }).ToArray(), new[] { new C("1"), new C("2") });
		}

		[Test]
		public void ExceptWithComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }.Wrap().Except(new[] { new C("31"), new C("41"), new C("51"), new C("61"), new C("71") }, new FirstLetterComparer()).ToArray(), new[] { new C("1"), new C("2") });
		}

		[Test]
		public void ExceptWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 5 }).Except(new[] { 3, 4, 5, 6, 7 }).ToArray(), new[] { 1, 2 });
			Assert.AreEqual(Enumerable.From(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }).Except(new[] { new C("3"), new C("4"), new C("5"), new C("6"), new C("7") }).ToArray(), new[] { new C("1"), new C("2") });
		}

		[Test]
		public void ExceptWithComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }).Except(new[] { new C("31"), new C("41"), new C("51"), new C("61"), new C("71") }, new FirstLetterComparer()).ToArray(), new[] { new C("1"), new C("2") });
		}


		[Test]
		public void IntersectWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Intersect(new[] { 3, 4, 5, 6, 7 }).ToArray(), new[] { 3, 4, 5 });
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }.Intersect(new[] { new C("3"), new C("4"), new C("5"), new C("6"), new C("7") }).ToArray(), new[] { new C("3"), new C("4"), new C("5") });
		}

		[Test]
		public void IntersectWithComparerWorksForArray() {
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }.Intersect(new[] { new C("31"), new C("41"), new C("51"), new C("61"), new C("71") }, new FirstLetterComparer()).ToArray(), new[] { new C("3"), new C("4"), new C("5") });
		}

		[Test]
		public void IntersectWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Wrap().Intersect(new[] { 3, 4, 5, 6, 7 }).ToArray(), new[] { 3, 4, 5 });
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }.Wrap().Intersect(new[] { new C("3"), new C("4"), new C("5"), new C("6"), new C("7") }).ToArray(), new[] { new C("3"), new C("4"), new C("5") });
		}

		[Test]
		public void IntersectWithComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }.Wrap().Intersect(new[] { new C("31"), new C("41"), new C("51"), new C("61"), new C("71") }, new FirstLetterComparer()).ToArray(), new[] { new C("3"), new C("4"), new C("5") });
		}

		[Test]
		public void IntersectWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 5 }).Intersect(new[] { 3, 4, 5, 6, 7 }).ToArray(), new[] { 3, 4, 5 });
			Assert.AreEqual(Enumerable.From(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }).Intersect(new[] { new C("3"), new C("4"), new C("5"), new C("6"), new C("7") }).ToArray(), new[] { new C("3"), new C("4"), new C("5") });
		}

		[Test]
		public void IntersectWithComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }).Intersect(new[] { new C("31"), new C("41"), new C("51"), new C("61"), new C("71") }, new FirstLetterComparer()).ToArray(), new[] { new C("3"), new C("4"), new C("5") });
		}


		[Test]
		public void SequenceEqualWorksForArray() {
			Assert.IsTrue (new[] { 1, 2, 3, 4, 5 }.SequenceEqual(new[] { 1, 2, 3, 4, 5 }));
			Assert.IsFalse(new[] { 1, 2, 3, 4, 5 }.SequenceEqual(new[] { 1, 2, 3, 4, 5, 6 }));
			Assert.IsTrue (new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }.SequenceEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }));
			Assert.IsFalse(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }.SequenceEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5"), new C("6") }));
		}

		[Test]
		public void SequenceEqualWithComparerWorksForArray() {
			Assert.IsTrue (new[] { new C("11"), new C("21"), new C("31"), new C("41"), new C("51") }.SequenceEqual(new[] { new C("12"), new C("22"), new C("32"), new C("42"), new C("52") }, new FirstLetterComparer()));
			Assert.IsFalse(new[] { new C("11"), new C("21"), new C("31"), new C("41"), new C("51") }.SequenceEqual(new[] { new C("12"), new C("22"), new C("32"), new C("42"), new C("52"), new C("6") }, new FirstLetterComparer()));
		}

		[Test]
		public void SequenceEqualWorksForSaltarelleEnumerable() {
			Assert.IsTrue (new[] { 1, 2, 3, 4, 5 }.Wrap().SequenceEqual(new[] { 1, 2, 3, 4, 5 }));
			Assert.IsFalse(new[] { 1, 2, 3, 4, 5 }.Wrap().SequenceEqual(new[] { 1, 2, 3, 4, 5, 6 }));
			Assert.IsTrue (new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }.Wrap().SequenceEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }));
			Assert.IsFalse(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }.Wrap().SequenceEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5"), new C("6") }));
		}

		[Test]
		public void SequenceEqualWithComparerWorksForSaltarelleEnumerable() {
			Assert.IsTrue (new[] { new C("11"), new C("21"), new C("31"), new C("41"), new C("51") }.Wrap().SequenceEqual(new[] { new C("12"), new C("22"), new C("32"), new C("42"), new C("52") }, new FirstLetterComparer()));
			Assert.IsFalse(new[] { new C("11"), new C("21"), new C("31"), new C("41"), new C("51") }.Wrap().SequenceEqual(new[] { new C("12"), new C("22"), new C("32"), new C("42"), new C("52"), new C("6") }, new FirstLetterComparer()));
		}

		[Test]
		public void SequenceEqualWorksForLinqJSEnumerable() {
			Assert.IsTrue (Enumerable.From(new[] { 1, 2, 3, 4, 5 }).SequenceEqual(new[] { 1, 2, 3, 4, 5 }));
			Assert.IsFalse(Enumerable.From(new[] { 1, 2, 3, 4, 5 }).SequenceEqual(new[] { 1, 2, 3, 4, 5, 6 }));
			Assert.IsTrue (Enumerable.From(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }).SequenceEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }));
			Assert.IsFalse(Enumerable.From(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") }).SequenceEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5"), new C("6") }));
		}

		[Test]
		public void SequenceEqualWithComparerWorksForLinqJSEnumerable() {
			Assert.IsTrue (Enumerable.From(new[] { new C("11"), new C("21"), new C("31"), new C("41"), new C("51") }).SequenceEqual(new[] { new C("12"), new C("22"), new C("32"), new C("42"), new C("52") }, new FirstLetterComparer()));
			Assert.IsFalse(Enumerable.From(new[] { new C("11"), new C("21"), new C("31"), new C("41"), new C("51") }).SequenceEqual(new[] { new C("12"), new C("22"), new C("32"), new C("42"), new C("52"), new C("6") }, new FirstLetterComparer()));
		}


		[Test]
		public void UnionWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4 }.Union(new[] { 2, 3, 4, 5 }).ToArray(), new[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4") }.Union(new[] { new C("2"), new C("3"), new C("4"), new C("5") }).ToArray(), new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") });
		}

		[Test]
		public void UnionWithComparerWorksForArray() {
			Assert.AreEqual(new[] { new C("11"), new C("21"), new C("31"), new C("41") }.Union(new[] { new C("22"), new C("32"), new C("42"), new C("52") }, new FirstLetterComparer()).ToArray(), new[] { new C("11"), new C("21"), new C("31"), new C("41"), new C("52") });
		}

		[Test]
		public void UnionWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4 }.Wrap().Union(new[] { 2, 3, 4, 5 }).ToArray(), new[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4") }.Wrap().Union(new[] { new C("2"), new C("3"), new C("4"), new C("5") }).ToArray(), new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") });
		}

		[Test]
		public void UnionWithComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { new C("11"), new C("21"), new C("31"), new C("41") }.Wrap().Union(new[] { new C("22"), new C("32"), new C("42"), new C("52") }, new FirstLetterComparer()).ToArray(), new[] { new C("11"), new C("21"), new C("31"), new C("41"), new C("52") });
		}

		[Test]
		public void UnionWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4 }).Union(new[] { 2, 3, 4, 5 }).ToArray(), new[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(Enumerable.From(new[] { new C("1"), new C("2"), new C("3"), new C("4") }).Union(new[] { new C("2"), new C("3"), new C("4"), new C("5") }).ToArray(), new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("5") });
		}

		[Test]
		public void UnionWithComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { new C("11"), new C("21"), new C("31"), new C("41") }).Union(new[] { new C("22"), new C("32"), new C("42"), new C("52") }, new FirstLetterComparer()).ToArray(), new[] { new C("11"), new C("21"), new C("31"), new C("41"), new C("52") });
		}
	}
}
