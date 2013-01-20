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
		}

		[Test]
		public void JoinWithCompareSelectorWorksForArray() {
			Assert.AreEqual(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3"), Tuple.Create(4, "Outer 4"), Tuple.Create(5, "Outer 5") }.Join(Enumerable.Range(3, 5).Select(i => Tuple.Create("Inner " + i, i)), x => x.Item1, x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Item1, a => a % 3).ToArray(), new[] { "Outer 1:Inner 4", "Outer 1:Inner 7", "Outer 2:Inner 5", "Outer 3:Inner 3", "Outer 3:Inner 6", "Outer 4:Inner 4", "Outer 4:Inner 7", "Outer 5:Inner 5" });
		}

		[Test]
		public void JoinWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => Tuple.Create(i, "Outer " + i)).Join(Enumerable.Range(3, 5).Select(i => Tuple.Create("Inner " + i, i)), x => x.Item1, x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Item1).ToArray(), new[] { "Outer 3:Inner 3", "Outer 4:Inner 4", "Outer 5:Inner 5" });
		}

		[Test]
		public void JoinWithCompareSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => Tuple.Create(i, "Outer " + i)).Join(Enumerable.Range(3, 5).Select(i => Tuple.Create("Inner " + i, i)), x => x.Item1, x => x.Item2, (t1, t2) => t1.Item2 + ":" + t2.Item1, a => a % 3).ToArray(), new[] { "Outer 1:Inner 4", "Outer 1:Inner 7", "Outer 2:Inner 5", "Outer 3:Inner 3", "Outer 3:Inner 6", "Outer 4:Inner 4", "Outer 4:Inner 7", "Outer 5:Inner 5" });
		}


		[Test]
		public void GroupJoinWorksForArray() {
			Assert.AreEqual(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3") }.GroupJoin(Enumerable.Range(1, 5).Select(i => Tuple.Create("Inner " + i, i)), x => x.Item1 % 2, x => x.Item2 % 3, (t1, t2) => t1.Item2 + ":" + t2.Select(x => x.Item1).ToArray()).ToArray(), new[] { "Outer 1:Inner 1,Inner 4", "Outer 2:Inner 3", "Outer 3:Inner 1,Inner 4" });
		}

		[Test]
		public void GroupJoinWithCompareSelectorWorksForArray() {
			Assert.AreEqual(new[] { Tuple.Create(1, "Outer 1"), Tuple.Create(2, "Outer 2"), Tuple.Create(3, "Outer 3") }.GroupJoin(Enumerable.Range(1, 5).Select(i => Tuple.Create("Inner " + i, i)), x => x.Item1 % 2, x => x.Item2 % 3, (t1, t2) => t1.Item2 + ":" + t2.Select(x => x.Item1).ToArray(), a => a % 2).ToArray(), new[] { "Outer 1:Inner 1,Inner 4", "Outer 2:Inner 2,Inner 3,Inner 5", "Outer 3:Inner 1,Inner 4" });
		}


		[Test]
		public void GroupJoinWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 3).Select(i => Tuple.Create(i, "Outer " + i)).GroupJoin(Enumerable.Range(1, 5).Select(i => Tuple.Create("Inner " + i, i)), x => x.Item1 % 2, x => x.Item2 % 3, (t1, t2) => t1.Item2 + ":" + t2.Select(x => x.Item1).ToArray()).ToArray(), new[] { "Outer 1:Inner 1,Inner 4", "Outer 2:Inner 3", "Outer 3:Inner 1,Inner 4" });
		}

		[Test]
		public void GroupJoinWithCompareSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 3).Select(i => Tuple.Create(i, "Outer " + i)).GroupJoin(Enumerable.Range(1, 5).Select(i => Tuple.Create("Inner " + i, i)), x => x.Item1 % 2, x => x.Item2 % 3, (t1, t2) => t1.Item2 + ":" + t2.Select(x => x.Item1).ToArray(), a => a % 2).ToArray(), new[] { "Outer 1:Inner 1,Inner 4", "Outer 2:Inner 2,Inner 3,Inner 5", "Outer 3:Inner 1,Inner 4" });
		}
	}
}
