using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class JoinTests {
		[Test]
		public void JoinWorksForArray() {
			Assert.AreEqual(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3"), Tuple.Create(4, "Outer 4"), Tuple.Create(5, "Outer 5") }.Join(Enumerable.Range(3, 5).Select(i => Tuple.Create("Inner " + i, i)), x => x.Item1, x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Item1).ToArray(), new[] { "Outer 3:Inner 3", "Outer 4:Inner 4", "Outer 5:Inner 5" });
			Assert.AreEqual(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3"), Tuple.Create(4, "Outer 4"), Tuple.Create(5, "Outer 5") }.Join(Enumerable.Range(3, 5).Select(i => Tuple.Create("Inner " + i, new C(i.ToString()))), x => new C(x.Item1.ToString()), x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Item1).ToArray(), new[] { "Outer 3:Inner 3", "Outer 4:Inner 4", "Outer 5:Inner 5" });
		}

		[Test]
		public void JoinWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3"), Tuple.Create(4, "Outer 4"), Tuple.Create(5, "Outer 5") }.Wrap().Join(Enumerable.Range(3, 5).Select(i => Tuple.Create("Inner " + i, i)), x => x.Item1, x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Item1).ToArray(), new[] { "Outer 3:Inner 3", "Outer 4:Inner 4", "Outer 5:Inner 5" });
			Assert.AreEqual(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3"), Tuple.Create(4, "Outer 4"), Tuple.Create(5, "Outer 5") }.Wrap().Join(Enumerable.Range(3, 5).Select(i => Tuple.Create("Inner " + i, new C(i.ToString()))), x => new C(x.Item1.ToString()), x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Item1).ToArray(), new[] { "Outer 3:Inner 3", "Outer 4:Inner 4", "Outer 5:Inner 5" });
		}

		[Test]
		public void JoinWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3"), Tuple.Create(4, "Outer 4"), Tuple.Create(5, "Outer 5") }).Join(Enumerable.Range(3, 5).Select(i => Tuple.Create("Inner " + i, i)), x => x.Item1, x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Item1).ToArray(), new[] { "Outer 3:Inner 3", "Outer 4:Inner 4", "Outer 5:Inner 5" });
			Assert.AreEqual(Enumerable.From(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3"), Tuple.Create(4, "Outer 4"), Tuple.Create(5, "Outer 5") }).Join(Enumerable.Range(3, 5).Select(i => Tuple.Create("Inner " + i, new C(i.ToString()))), x => new C(x.Item1.ToString()), x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Item1).ToArray(), new[] { "Outer 3:Inner 3", "Outer 4:Inner 4", "Outer 5:Inner 5" });
		}

		[Test]
		public void JoinWithComparerWorksForArray() {
			Assert.AreEqual(new[] { Tuple.Create(new C("1"), "Outer 1"), Tuple.Create(new C("2"), "Outer 2"), Tuple.Create(new C("3"), "Outer 3"), Tuple.Create(new C("4"), "Outer 4"), Tuple.Create(new C("5"), "Outer 5") }.Join(Enumerable.Range(3, 5).Select(i => Tuple.Create("Inner " + i, new C(i.ToString() + "X"))), x => x.Item1, x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Item1, new FirstLetterComparer()).ToArray(), new[] { "Outer 3:Inner 3", "Outer 4:Inner 4", "Outer 5:Inner 5" });
		}

		[Test]
		public void JoinWithComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { Tuple.Create(new C("1"), "Outer 1"), Tuple.Create(new C("2"), "Outer 2"), Tuple.Create(new C("3"), "Outer 3"), Tuple.Create(new C("4"), "Outer 4"), Tuple.Create(new C("5"), "Outer 5") }.Wrap().Join(Enumerable.Range(3, 5).Select(i => Tuple.Create("Inner " + i, new C(i.ToString() + "X"))), x => x.Item1, x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Item1, new FirstLetterComparer()).ToArray(), new[] { "Outer 3:Inner 3", "Outer 4:Inner 4", "Outer 5:Inner 5" });
		}

		[Test]
		public void JoinWithComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { Tuple.Create(new C("1"), "Outer 1"), Tuple.Create(new C("2"), "Outer 2"), Tuple.Create(new C("3"), "Outer 3"), Tuple.Create(new C("4"), "Outer 4"), Tuple.Create(new C("5"), "Outer 5") }).Join(Enumerable.Range(3, 5).Select(i => Tuple.Create("Inner " + i, new C(i.ToString() + "X"))), x => x.Item1, x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Item1, new FirstLetterComparer()).ToArray(), new[] { "Outer 3:Inner 3", "Outer 4:Inner 4", "Outer 5:Inner 5" });
		}


		[Test]
		public void GroupJoinWorksForArray() {
			Assert.AreEqual(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3") }.GroupJoin(Enumerable.Range(1, 5).Select(i => Tuple.Create("Inner " + i, i)), x => x.Item1 % 2, x => x.Item2 % 3, (t1, t2) => t1.Item2 + ":" + t2.Select(x => x.Item1).ToArray()).ToArray(), new[] { "Outer 1:Inner 1,Inner 4", "Outer 2:Inner 3", "Outer 3:Inner 1,Inner 4" });
			Assert.AreEqual(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3") }.GroupJoin(Enumerable.Range(1, 5).Select(i => Tuple.Create("Inner " + i, new C((i % 3).ToString()))), x => new C((x.Item1 % 2).ToString()), x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Select(x => x.Item1).ToArray()).ToArray(), new[] { "Outer 1:Inner 1,Inner 4", "Outer 2:Inner 3", "Outer 3:Inner 1,Inner 4" });
		}

		[Test]
		public void GroupJoinWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3") }.Wrap().GroupJoin(Enumerable.Range(1, 5).Select(i => Tuple.Create("Inner " + i, i)), x => x.Item1 % 2, x => x.Item2 % 3, (t1, t2) => t1.Item2 + ":" + t2.Select(x => x.Item1).ToArray()).ToArray(), new[] { "Outer 1:Inner 1,Inner 4", "Outer 2:Inner 3", "Outer 3:Inner 1,Inner 4" });
			Assert.AreEqual(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3") }.Wrap().GroupJoin(Enumerable.Range(1, 5).Select(i => Tuple.Create("Inner " + i, new C((i % 3).ToString()))), x => new C((x.Item1 % 2).ToString()), x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Select(x => x.Item1).ToArray()).ToArray(), new[] { "Outer 1:Inner 1,Inner 4", "Outer 2:Inner 3", "Outer 3:Inner 1,Inner 4" });
		}

		[Test]
		public void GroupJoinWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3") }).GroupJoin(Enumerable.Range(1, 5).Select(i => Tuple.Create("Inner " + i, i)), x => x.Item1 % 2, x => x.Item2 % 3, (t1, t2) => t1.Item2 + ":" + t2.Select(x => x.Item1).ToArray()).ToArray(), new[] { "Outer 1:Inner 1,Inner 4", "Outer 2:Inner 3", "Outer 3:Inner 1,Inner 4" });
			Assert.AreEqual(Enumerable.From(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3") }).GroupJoin(Enumerable.Range(1, 5).Select(i => Tuple.Create("Inner " + i, new C((i % 3).ToString()))), x => new C((x.Item1 % 2).ToString()), x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Select(x => x.Item1).ToArray()).ToArray(), new[] { "Outer 1:Inner 1,Inner 4", "Outer 2:Inner 3", "Outer 3:Inner 1,Inner 4" });
		}

		[Test]
		public void GroupJoinWithCompareSelectorWorksForArray() {
			Assert.AreEqual(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3") }.GroupJoin(Enumerable.Range(1, 5).Select(i => Tuple.Create("Inner " + i, new C((i % 3).ToString() + "X"))), x => new C((x.Item1 % 2).ToString()), x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Select(x => x.Item1).ToArray(), new FirstLetterComparer()).ToArray(), new[] { "Outer 1:Inner 1,Inner 4", "Outer 2:Inner 3", "Outer 3:Inner 1,Inner 4" });
		}

		[Test]
		public void GroupJoinWithCompareSelectorWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3") }.Wrap().GroupJoin(Enumerable.Range(1, 5).Select(i => Tuple.Create("Inner " + i, new C((i % 3).ToString() + "X"))), x => new C((x.Item1 % 2).ToString()), x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Select(x => x.Item1).ToArray(), new FirstLetterComparer()).ToArray(), new[] { "Outer 1:Inner 1,Inner 4", "Outer 2:Inner 3", "Outer 3:Inner 1,Inner 4" });
		}

		[Test]
		public void GroupJoinWithCompareSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3") }).GroupJoin(Enumerable.Range(1, 5).Select(i => Tuple.Create("Inner " + i, new C((i % 3).ToString() + "X"))), x => new C((x.Item1 % 2).ToString()), x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Select(x => x.Item1).ToArray(), new FirstLetterComparer()).ToArray(), new[] { "Outer 1:Inner 1,Inner 4", "Outer 2:Inner 3", "Outer 3:Inner 1,Inner 4" });
		}
	}
}
