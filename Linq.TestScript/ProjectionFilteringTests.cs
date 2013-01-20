using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class ProjectionFilteringTests {
		[Test]
		public void TraverseBreadthFirstWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Make(1).TraverseBreadthFirst(x => new[] { x + x }).Take(5).ToArray(), new[] { 1, 2, 4, 8, 16 }, "Result should be correct");
		}

		[Test]
		public void TraverseBreadthFirstWithResultSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Make(1).TraverseBreadthFirst(x => new[] { x + x }, x => x * x).Take(5).ToArray(), new[] { 1, 4, 16, 64, 256 }, "Result should be correct");
		}

		[Test]
		public void TraverseBreadthFirstWithResultSelectorWithIndexArgWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Make(1).TraverseBreadthFirst(x => new[] { x + x }, (x, level) => new { x, level }).Take(5).ToArray(), new[] { new { x = 1, level = 0 }, new { x = 2, level = 1 }, new { x = 4, level = 2 }, new { x = 8, level = 3 }, new { x = 16, level = 4 } }, "Result should be correct");
		}

		[Test]
		public void TraverseBreadthFirstWorksForSaltarelleEnumerable() {
			var enumerable = new TestEnumerable(1, 1);
			Assert.AreEqual(enumerable.TraverseBreadthFirst(x => new[] { x + x }).Take(5).ToArray(), new[] { 1, 2, 4, 8, 16 }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}

		[Test]
		public void TraverseBreadthFirstWithResultSelectorWorksForSaltarelleEnumerable() {
			var enumerable = new TestEnumerable(1, 1);
			Assert.AreEqual(enumerable.TraverseBreadthFirst(x => new[] { x + x }, x => x * x).Take(5).ToArray(), new[] { 1, 4, 16, 64, 256 }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}

		[Test]
		public void TraverseBreadthFirstWithResultSelectorWithIndexArgWorksForSaltarelleEnumerable() {
			var enumerable = new TestEnumerable(1, 1);
			Assert.AreEqual(enumerable.TraverseBreadthFirst(x => new[] { x + x }, (x, level) => new { x, level }).Take(5).ToArray(), new[] { new { x = 1, level = 0 }, new { x = 2, level = 1 }, new { x = 4, level = 2 }, new { x = 8, level = 3 }, new { x = 16, level = 4 } }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}


		[Test]
		public void TraverseDepthFirstWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Make(1).TraverseDepthFirst(x => new[] { x + x }).Take(5).ToArray(), new[] { 1, 2, 4, 8, 16 }, "Result should be correct");
		}

		[Test]
		public void TraverseDepthFirstWithResultSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Make(1).TraverseDepthFirst(x => new[] { x + x }, x => x * x).Take(5).ToArray(), new[] { 1, 4, 16, 64, 256 }, "Result should be correct");
		}

		[Test]
		public void TraverseDepthFirstWithResultSelectorWithIndexArgWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Make(1).TraverseDepthFirst(x => new[] { x + x }, (x, level) => new { x, level }).Take(5).ToArray(), new[] { new { x = 1, level = 0 }, new { x = 2, level = 1 }, new { x = 4, level = 2 }, new { x = 8, level = 3 }, new { x = 16, level = 4 } }, "Result should be correct");
		}

		[Test]
		public void TraverseDepthFirstWorksForSaltarelleEnumerable() {
			var enumerable = new TestEnumerable(1, 1);
			Assert.AreEqual(enumerable.TraverseDepthFirst(x => new[] { x + x }).Take(5).ToArray(), new[] { 1, 2, 4, 8, 16 }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}

		[Test]
		public void TraverseDepthFirstWithResultSelectorWorksForSaltarelleEnumerable() {
			var enumerable = new TestEnumerable(1, 1);
			Assert.AreEqual(enumerable.TraverseDepthFirst(x => new[] { x + x }, x => x * x).Take(5).ToArray(), new[] { 1, 4, 16, 64, 256 }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}

		[Test]
		public void TraverseDepthFirstWithResultSelectorWithIndexArgWorksForSaltarelleEnumerable() {
			var enumerable = new TestEnumerable(1, 1);
			Assert.AreEqual(enumerable.TraverseDepthFirst(x => new[] { x + x }, (x, level) => new { x, level }).Take(5).ToArray(), new[] { new { x = 1, level = 0 }, new { x = 2, level = 1 }, new { x = 4, level = 2 }, new { x = 8, level = 3 }, new { x = 16, level = 4 } }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}
		
		
		[Test]
		public void FlattenWorksForSaltarelleEnumerable() {
			var arr = new object[] { 1, new object[] { 234, 2, new object[] { 62, 3 } }, new object[] { 234, 5 }, 3 };
			Assert.AreEqual(arr.Flatten().ToArray(), new[] { 1, 234, 2, 62, 3, 234, 5, 3 });
		}

		[Test]
		public void FlattenWorksForLinqJSEnumerable() {
			var arr = new object[] { 1, new object[] { 234, 2, new object[] { 62, 3 } }, new object[] { 234, 5 }, 3 };
			Assert.AreEqual(arr.Select(x => x).Flatten().ToArray(), new[] { 1, 234, 2, 62, 3, 234, 5, 3 });
		}

		
		[Test]
		public void PairwiseWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Pairwise((p, n) => p + n).ToArray(), new[] { 3, 5, 7, 9 });
		}

		[Test]
		public void PairwiseWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Select(x => x).Pairwise((p, n) => p + n).ToArray(), new[] { 3, 5, 7, 9 });
		}


		[Test]
		public void ScanWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Scan((a, b) => a + b).ToArray(), new[] { 1, 3, 6, 10, 15 });
		}

		[Test]
		public void ScanWithSeedWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Scan("", (a, b) => a + " " + b).ToArray(), new[] { "", " 1", " 1 2", " 1 2 3", " 1 2 3 4", " 1 2 3 4 5" });
		}

		[Test]
		public void ScanWithSeedAndResultSelectorWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Scan("", (a, b) => a + " " + b, s => s.Substr(1)).ToArray(), new[] { "", "1", "1 2", "1 2 3", "1 2 3 4", "1 2 3 4 5" });
		}

		[Test]
		public void ScanWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Select(x => x).Scan((a, b) => a + b).ToArray(), new[] { 1, 3, 6, 10, 15 });
		}

		[Test]
		public void ScanWithSeedWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Select(x => x).Scan("", (a, b) => a + " " + b).ToArray(), new[] { "", " 1", " 1 2", " 1 2 3", " 1 2 3 4", " 1 2 3 4 5" });
		}

		[Test]
		public void ScanWithSeedAndResultSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Select(x => x).Scan("", (a, b) => a + " " + b, s => s.Substr(1)).ToArray(), new[] { "", "1", "1 2", "1 2 3", "1 2 3 4", "1 2 3 4 5" });
		}


		[Test]
		public void SelectFromArrayWorks() {
			Assert.AreEqual(new[] { 1, 2, 3 }.Select(i => i * i).ToArray(), new[] { 1, 4, 9 });
		}

		[Test]
		public void SelectWithIndexFromArrayWorks() {
			Assert.AreEqual(new[] { 1, 2, 3 }.Select((i, n) => i * i + n).ToArray(), new[] { 1, 5, 11 });
		}

		[Test]
		public void SelectFromSaltarelleEnumerableWorks() {
			var enumerable = new TestEnumerable(1, 3);
			Assert.AreEqual(enumerable.Select(i => i * i).ToArray(), new[] { 1, 4, 9 }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}

		[Test]
		public void SelectWithIndexFromSaltarelleEnumerableWorks() {
			var enumerable = new TestEnumerable(1, 3);
			Assert.AreEqual(enumerable.Select((i, n) => i * i + n).ToArray(), new[] { 1, 5, 11 }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}

		[Test]
		public void ChainingSelectWorks() {
			Assert.AreEqual(new[] { 1, 2, 3 }.Select(i => i * i).Select(i => i * 2).ToArray(), new[] { 2, 8, 18 }, "Result should be correct");
		}

		[Test]
		public void ChainingSelectWithIndexWorks() {
			Assert.AreEqual(new[] { 1, 2, 3 }.Select(i => i * i).Select((i, idx) => i * 2 + idx).ToArray(), new[] { 2, 9, 20 }, "Result should be correct");
		}


		[Test]
		public void SelectManyWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3 }.SelectMany(i => Enumerable.Repeat('a' + i, i)).ToArray(), new[] { 'b', 'c', 'c', 'd', 'd', 'd' });
		}

		[Test]
		public void SelectManyWithIndexWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3 }.SelectMany((i, idx) => Enumerable.Repeat('a' + idx, i)).ToArray(), new[] { 'a', 'b', 'b', 'c', 'c', 'c' });
		}

		[Test]
		public void SelectManyWithResultSelectorWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3 }.SelectMany(i => Enumerable.Repeat('a' + i, i), (i, c) => new string((char)c, 1) + "x" + i).ToArray(), new[] { "bx1", "cx2", "cx2", "dx3", "dx3", "dx3" });
		}

		[Test]
		public void SelectManyWithIndexAndResultSelectorWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3 }.SelectMany((i, idx) => Enumerable.Repeat('a' + idx, i), (i, c) => new string((char)c, 1) + "x" + i).ToArray(), new[] { "ax1", "bx2", "bx2", "cx3", "cx3", "cx3" });
		}

		[Test]
		public void SelectManyWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 3).SelectMany(i => Enumerable.Repeat('a' + i, i)).ToArray(), new[] { 'b', 'c', 'c', 'd', 'd', 'd' });
		}

		[Test]
		public void SelectManyWithIndexWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 3).SelectMany((i, idx) => Enumerable.Repeat('a' + idx, i)).ToArray(), new[] { 'a', 'b', 'b', 'c', 'c', 'c' });
		}

		[Test]
		public void SelectManyWithResultSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 3).SelectMany(i => Enumerable.Repeat('a' + i, i), (i, c) => new string((char)c, 1) + "x" + i).ToArray(), new[] { "bx1", "cx2", "cx2", "dx3", "dx3", "dx3" });
		}

		[Test]
		public void SelectManyWithIndexAndResultSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 3).SelectMany((i, idx) => Enumerable.Repeat('a' + idx, i), (i, c) => new string((char)c, 1) + "x" + i).ToArray(), new[] { "ax1", "bx2", "bx2", "cx3", "cx3", "cx3" });
		}


		[Test]
		public void CastWorksForArray() {
			Assert.AreEqual(new object[] { "X", null, "Y" }.Cast<string>().ToArray(), new[] { "X", null, "Y" });
			Assert.Throws(() => new object[] { "X", 1, "Y" }.Cast<string>().ToArray(), "Invalid cast should throw");
		}

		[Test]
		public void CastWorksForLinqJSEnumerable() {
			Assert.AreEqual(new object[] { "X", null, "Y" }.Select(x => x).Cast<string>().ToArray(), new[] { "X", null, "Y" });
			Assert.Throws(() => new object[] { "X", 1, "Y" }.Select(x => x).Cast<string>().ToArray(), "Invalid cast should throw");
		}


		[Test]
		public void OfTypeWorksForArray() {
			Assert.AreEqual(new object[] { "X", null, 1, "Y" }.OfType<string>().ToArray(), new[] { "X", "Y" });
		}

		[Test]
		public void OfTypeWorksForLinqJSEnumerable() {
			Assert.AreEqual(new object[] { "X", null, 1, "Y" }.Select(x => x).OfType<string>().ToArray(), new[] { "X", "Y" });
		}


		[Test]
		public void ZipWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3 }.Zip(new[] { "a", "b", "c" }, (a, b) => a + b).ToArray(), new[] { "1a", "2b", "3c" });
		}

		[Test]
		public void ZipWithIndexWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3 }.Zip(new[] { "a", "b", "c" }, (a, b, i) => a + b + i).ToArray(), new[] { "1a0", "2b1", "3c2" });
		}

		[Test]
		public void ZipWorksForJSLinqEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 3).Zip(new[] { "a", "b", "c" }, (a, b) => a + b).ToArray(), new[] { "1a", "2b", "3c" });
		}

		[Test]
		public void ZipWithIndexWorksForJSLinqEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 3).Zip(new[] { "a", "b", "c" }, (a, b, i) => a + b + i).ToArray(), new[] { "1a0", "2b1", "3c2" });
		}


		[Test]
		public void WhereWithoutIndexWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Select(i => i).Where(i => i > 3).ToArray(), new[] { 4, 5 });
		}

		[Test]
		public void WhereWithoutIndexWorksForSaltarelleEnumerable() {
			var enumerable = new TestEnumerable(1, 5);
			Assert.AreEqual(enumerable.Where(i => i > 3).ToArray(), new[] { 4, 5 }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}

		[Test]
		public void WhereWithIndexWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Select(i => i).Where((i, idx) => idx > 2).ToArray(), new[] { 4, 5 });
		}

		[Test]
		public void WhereWithIndexWorksForSaltarelleEnumerable() {
			var enumerable = new TestEnumerable(1, 5);
			Assert.AreEqual(enumerable.Where((i, idx) => idx > 2).ToArray(), new[] { 4, 5 }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}
	}
}
