using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class ConvertTests {
		[Test]
		public void ToArrayWorksFromLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3 }.Select(i => i * i).ToArray(), new[] { 1, 4, 9 });
		}

		[Test]
		public void ToArrayWorksFromSatarelleEnumerable() {
			var enumerable = new TestEnumerable(1, 3);
			Assert.AreEqual(enumerable.ToArray(), new[] { 1, 2, 3 }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}


		[Test]
		public void ToListWorksFromLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3 }.Select(i => i * i).ToList(), new[] { 1, 4, 9 });
		}

		[Test]
		public void ToListWorksFromSatarelleEnumerable() {
			var enumerable = new TestEnumerable(1, 3);
			Assert.AreEqual(enumerable.ToList(), new[] { 1, 2, 3 }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}

		[Test]
		public void CanForeachOverLinqJSEnumerable() {
			var enumerable = new TestEnumerable(1, 3);
			var result = new List<int>();
			foreach (var i in enumerable.Select(i => i * i)) {
				result.Add(i);
			}
			Assert.AreEqual(result, new[] { 1, 4, 9 }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}


		[Test]
		public void ToLookupWithOnlyKeySelectorWorksForArray() {
			var lu = new[] { "temp.xls", "temp.pdf", "temp.jpg", "temp2.pdf" }.ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1]);
			Assert.AreEqual(lu.Count, 3);
			Assert.AreEqual(lu["xls"].ToArray(), new[] { "temp.xls" });
			Assert.AreEqual(lu["pdf"].ToArray(), new[] { "temp.pdf", "temp2.pdf" });
			Assert.AreEqual(lu["jpg"].ToArray(), new[] { "temp.jpg" });
		}

		[Test]
		public void ToLookupWithOnlyKeySelectorWorksForLinqJSEnumerable() {
			var lu = new[] { "temp.xls", "temp.pdf", "temp.jpg", "temp2.pdf" }.Select(x => x).ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1]);
			Assert.AreEqual(lu.Count, 3);
			Assert.AreEqual(lu["xls"].ToArray(), new[] { "temp.xls" });
			Assert.AreEqual(lu["pdf"].ToArray(), new[] { "temp.pdf", "temp2.pdf" });
			Assert.AreEqual(lu["jpg"].ToArray(), new[] { "temp.jpg" });
		}

		[Test]
		public void ToLookupWithKeyAndValueSelectorsWorksForArray() {
			var lu = new[] { "temp1.xls", "temp2.pdf", "temp3.jpg", "temp4.pdf" }.ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1], s => s.Match(new Regex("^(.+)\\."))[1]);
			Assert.AreEqual(lu.Count, 3);
			Assert.AreEqual(lu["xls"].ToArray(), new[] { "temp1" });
			Assert.AreEqual(lu["pdf"].ToArray(), new[] { "temp2", "temp4" });
			Assert.AreEqual(lu["jpg"].ToArray(), new[] { "temp3" });
		}

		[Test]
		public void ToLookupWithKeyAndValueSelectorsWorksForLinqJSEnumerable() {
			var lu = new[] { "temp1.xls", "temp2.pdf", "temp3.jpg", "temp4.pdf" }.Select(x => x).ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1], s => s.Match(new Regex("^(.+)\\."))[1]);
			Assert.AreEqual(lu.Count, 3);
			Assert.AreEqual(lu["xls"].ToArray(), new[] { "temp1" });
			Assert.AreEqual(lu["pdf"].ToArray(), new[] { "temp2", "temp4" });
			Assert.AreEqual(lu["jpg"].ToArray(), new[] { "temp3" });
		}

		[Test]
		public void ToLookupWithKeyAndValueAndCompareSelectorsWorksForArray() {
			var lu = new[] { "temp1.xls", "temp2.pdf", "temp3.jpg", "temp4.PDF" }.ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1], s => s.Substr(1), s => s.ToLower());
			Assert.AreEqual(lu.Count, 3);
			Assert.AreEqual(lu["xls"].ToArray(), new[] { "emp1.xls" });
			Assert.AreEqual(lu["pdf"].ToArray(), new[] { "emp2.pdf", "emp4.PDF" });
			Assert.AreEqual(lu["jpg"].ToArray(), new[] { "emp3.jpg" });
		}

		[Test]
		public void ToLookupWithKeyAndValueAndCompareSelectorsWorksForLinqJSEnumerable() {
			var lu = new[] { "temp1.xls", "temp2.pdf", "temp3.jpg", "temp4.PDF" }.Select(x => x).ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1], s => s.Substr(1), s => s.ToLower());
			Assert.AreEqual(lu.Count, 3);
			Assert.AreEqual(lu["xls"].ToArray(), new[] { "emp1.xls" });
			Assert.AreEqual(lu["pdf"].ToArray(), new[] { "emp2.pdf", "emp4.PDF" });
			Assert.AreEqual(lu["jpg"].ToArray(), new[] { "emp3.jpg" });
		}


		[Test]
		public void ToObjectWorksForArray() {
			Assert.AreEqual(Enumerable.Range(1, 5).Select((value, index) => new {id = "id_" + index, value}).ToArray().ToObject(item => item.id, item => item.value), new { id_0 = 1, id_1 = 2, id_2 = 3, id_3 = 4, id_4 = 5 });
		}

		[Test]
		public void ToObjectWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Select((value, index) => new {id = "id_" + index, value}).ToObject(item => item.id, item => item.value), new { id_0 = 1, id_1 = 2, id_2 = 3, id_3 = 4, id_4 = 5 });
		}


		[Test]
		public void ToDictionaryWithOnlyKeySelectorWorksForArray() {
			var d = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToArray().ToDictionary(item => item.id);
			Assert.AreEqual(d.Count, 5);
			Assert.AreEqual(d["id_0"], new { id = "id_0", value = 1 });
			Assert.AreEqual(d["id_1"], new { id = "id_1", value = 2 });
			Assert.AreEqual(d["id_2"], new { id = "id_2", value = 3 });
			Assert.AreEqual(d["id_3"], new { id = "id_3", value = 4 });
			Assert.AreEqual(d["id_4"], new { id = "id_4", value = 5 });
		}

		[Test]
		public void ToDictionaryWithOnlyKeySelectorWorksForLinqJSEnumerable() {
			var d = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id);
			Assert.AreEqual(d.Count, 5);
			Assert.AreEqual(d["id_0"], new { id = "id_0", value = 1 });
			Assert.AreEqual(d["id_1"], new { id = "id_1", value = 2 });
			Assert.AreEqual(d["id_2"], new { id = "id_2", value = 3 });
			Assert.AreEqual(d["id_3"], new { id = "id_3", value = 4 });
			Assert.AreEqual(d["id_4"], new { id = "id_4", value = 5 });
		}

		[Test]
		public void ToDictionaryWithKeyAndValueSelectorsWorksForArray() {
			var d = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToArray().ToDictionary(item => item.id, item => item.value);
			Assert.AreEqual(d.Count, 5);
			Assert.AreEqual(d["id_0"], 1);
			Assert.AreEqual(d["id_1"], 2);
			Assert.AreEqual(d["id_2"], 3);
			Assert.AreEqual(d["id_3"], 4);
			Assert.AreEqual(d["id_4"], 5);
		}

		[Test]
		public void ToDictionaryWithKeyAndValueSelectorsWorksForLinqJSEnumerable() {
			var d = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id, item => item.value);
			Assert.AreEqual(d.Count, 5);
			Assert.AreEqual(d["id_0"], 1);
			Assert.AreEqual(d["id_1"], 2);
			Assert.AreEqual(d["id_2"], 3);
			Assert.AreEqual(d["id_3"], 4);
			Assert.AreEqual(d["id_4"], 5);
		}

		[Test]
		public void ToDictionaryWithKeyAndValueAndCompareSelectorsWorksForArray() {
			var items = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToArray();
			var d = items.ToDictionary(item => item, item => item.value, item => item.id);
			Assert.AreEqual(d.ToArray(), items.Select(x => new { key = x, x.value }).ToArray());
		}

		[Test]
		public void ToDictionaryWithKeyAndValueAndCompareSelectorsWorksForLinqJSEnumerable() {
			var items = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value });
			var d = items.ToDictionary(item => item, item => item.value, item => item.id);
			Assert.AreEqual(d.ToArray(), items.Select(x => new { key = x, x.value }).ToArray());
		}


		[Test]
		public void ToJoinedStringWithoutArgumentsWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.ToJoinedString(), "12345");
		}

		[Test]
		public void ToJoinedStringWithSeparatorWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.ToJoinedString(","), "1,2,3,4,5");
		}

		[Test]
		public void ToJoinedStringWithSelectorAndSeparatorWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.ToJoinedString(",", i => (i + 1).ToString()), "2,3,4,5,6");
		}

		[Test]
		public void ToJoinedStringWithoutArgumentsWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).ToJoinedString(), "12345");
		}

		[Test]
		public void ToJoinedStringWithSeparatorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).ToJoinedString(","), "1,2,3,4,5");
		}

		[Test]
		public void ToJoinedStringWithSelectorAndSeparatorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).ToJoinedString(",", i => (i + 1).ToString()), "2,3,4,5,6");
		}
	}
}
