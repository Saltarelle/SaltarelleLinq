using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class GeneratorTests {
		[Test]
		public void ChoiceWorks() {
			var enm = Enumerable.Choice("a", "b", "c", "d");
			int count = 0;
			foreach (var x in enm) {
				Assert.IsTrue(x == "a" || x == "b" || x == "c" || x == "d", "Value should be one of the choices");
				if (count++ > 10)
					break;
			}
		}

		[Test]
		public void CycleWorks() {
			var enm = Enumerable.Cycle("a", "b", "c");
			var result = new List<string>();
			foreach (var x in enm) {
				result.Add(x);
				if (result.Count >= 10)
					break;
			}
			Assert.AreEqual(result, new[] { "a", "b", "c", "a", "b", "c", "a", "b", "c", "a" });
		}

		[Test(ExpectedAssertionCount = 0)]
		public void EmptyWorks() {
			foreach (var x in Enumerable.Empty<int>()) {
				Assert.Fail("Enumerator should be empty");
			}
		}

		[Test]
		public void FromWorksForArray() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 5 }).ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void FromWorksForSaltarelleEnumerable() {
			Assert.AreEqual(Enumerable.From(new TestEnumerable(1, 5)).ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void FromWorksForArrayLikeObject() {
			var d = new JsDictionary<string, object>();
			d["length"] = 5;
			d["0"] = "A";
			d["1"] = "B";
			d["2"] = "C";
			d["3"] = "D";
			d["4"] = "E";
			Assert.AreEqual(Enumerable.From(d).ToArray(), new[] { "A", "B", "C", "D", "E" });
		}

		[Test]
		public void FromWorksForString() {
			var result = new List<string>();
			foreach (var s in Enumerable.From("12345"))
				result.Add(s);
			Assert.AreEqual(result, new[] { "1", "2", "3", "4", "5" });
		}

		[Test]
		public void MakeWorks() {
			Assert.AreEqual(Enumerable.Make(123).ToArray(), new[] { 123 });
		}

		[Test]
		public void MatchesWithRegexArgWorks() {
			Assert.AreEqual(Enumerable.Matches("xbcyBCzbc", new Regex("(.)bc", "i")).Select(m => new { index = m.Index, all = m[0], capture = m[1] }).ToArray(), new[] { new { index = 0, all = "xbc", capture = "x" }, new { index = 3, all = "yBC", capture = "y" }, new { index = 6, all = "zbc", capture = "z" } });
		}

		[Test]
		public void MatchesWithStringArgWorks() {
			Assert.AreEqual(Enumerable.Matches("xbcyBCzbc", "(.)bc").Select(m => new { index = m.Index, all = m[0], capture = m[1] }).ToArray(), new[] { new { index = 0, all = "xbc", capture = "x" }, new { index = 6, all = "zbc", capture = "z" } });
		}

		[Test]
		public void MatchesWithStringAndFlagsArgWorks() {
			Assert.AreEqual(Enumerable.Matches("xbcyBCzbc", "(.)bc", "i").Select(m => new { index = m.Index, all = m[0], capture = m[1] }).ToArray(), new[] { new { index = 0, all = "xbc", capture = "x" }, new { index = 3, all = "yBC", capture = "y" }, new { index = 6, all = "zbc", capture = "z" } });
		}

		[Test]
		public void RangeWorks() {
			Assert.AreEqual(Enumerable.Range(4, 3).ToArray(), new[] { 4, 5, 6 });
		}

		[Test]
		public void RangeWithStepWorks() {
			Assert.AreEqual(Enumerable.Range(4, 3, 2).ToArray(), new[] { 4, 6, 8 });
		}

		[Test]
		public void RangeDownWorks() {
			Assert.AreEqual(Enumerable.RangeDown(10, 5).ToArray(), new[] { 10, 9, 8, 7, 6 });
		}

		[Test]
		public void RangeDownWithStepWorks() {
			Assert.AreEqual(Enumerable.RangeDown(10, 5, 3).ToArray(), new[] { 10, 7, 4, 1, -2 });
		}

		[Test]
		public void RangeToWorks() {
			Assert.AreEqual(Enumerable.RangeTo(10, 13).ToArray(), new[] { 10, 11, 12, 13 });
		}

		[Test]
		public void RangeToWithStepWorks() {
			Assert.AreEqual(Enumerable.RangeTo(1, 9, 3).ToArray(), new[] { 1, 4, 7 });
		}

		[Test]
		public void RepeatWorks() {
			var result = new List<string>();
			foreach (var enm in Enumerable.Repeat("x")) {
				result.Add(enm);
				if (result.Count == 3)
					break;
			}
			Assert.AreEqual(result, new[] { "x", "x", "x" });
		}

		[Test]
		public void RepeatWithCountWorks() {
			Assert.AreEqual(Enumerable.Repeat("foo", 3).ToArray(), new[] { "foo", "foo", "foo" });
		}

		[Test]
		public void RepeatWithFinalizeWorks() {
			bool finalized = false;
			var enm = Enumerable.RepeatWithFinalize(() => "foo", s => { Assert.AreEqual(s, "foo", "The correct arg should be passed to finalizer"); finalized = true; });
			var result = new List<string>();
			foreach (var s in enm) {
				result.Add(s);
				if (result.Count == 3)
					break;
			}
			Assert.AreEqual(result, new[] { "foo", "foo", "foo" }, "Result should be correct");
			Assert.IsTrue(finalized, "Finalizer should have been called");
		}

		[Test]
		public void GenerateWorks() {
			int i = 1;
			var result = new List<int>();
			foreach (var enm in Enumerable.Generate(() => i *= 2)) {
				result.Add(enm);
				if (result.Count == 3)
					break;
			}
			Assert.AreEqual(result, new[] { 2, 4, 8 });
		}

		[Test]
		public void GenerateWithCountWorks() {
			int i = 1;
			Assert.AreEqual(Enumerable.Generate(() => i *= 2, 4).ToArray(), new[] { 2, 4, 8, 16 });
		}

		[Test]
		public void ToInfinityWorks() {
			Assert.AreEqual(Enumerable.ToInfinity().Take(5).ToArray(), new[] { 0, 1, 2, 3, 4 });
		}

		[Test]
		public void ToInfinityWithStartWorks() {
			Assert.AreEqual(Enumerable.ToInfinity(10).Take(5).ToArray(), new[] { 10, 11, 12, 13, 14 });
		}

		[Test]
		public void ToInfinityWithStartAndStepWorks() {
			Assert.AreEqual(Enumerable.ToInfinity(10, 2).Take(5).ToArray(), new[] { 10, 12, 14, 16, 18 });
		}

		[Test]
		public void ToNegativeInfinityWorks() {
			Assert.AreEqual(Enumerable.ToNegativeInfinity().Take(5).ToArray(), new[] { 0, -1, -2, -3, -4 });
		}

		[Test]
		public void ToNegativeInfinityWithStartWorks() {
			Assert.AreEqual(Enumerable.ToNegativeInfinity(10).Take(5).ToArray(), new[] { 10, 9, 8, 7, 6 });
		}

		[Test]
		public void ToNegativeInfinityWithStartAndStepWorks() {
			Assert.AreEqual(Enumerable.ToNegativeInfinity(10, 2).Take(5).ToArray(), new[] { 10, 8, 6, 4, 2 });
		}
	}
}
