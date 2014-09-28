using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class MiscTests {
		[Test]
		public void QueryExpressionsWork() {
			string[] data = new[] { "4", "5", "7" };
			var result = (from a in data let b = int.Parse(a) let c = b + 1 select a + b.ToString() + c.ToString()).ToArray();

			Assert.AreEqual(result, new[] { "445", "556", "778" });
		}

		[Test]
		public void EnumeratorIsIDisposable() {
			var enm = Enumerable.Range(1, 5).GetEnumerator();
			Assert.IsTrue(enm is IDisposable);
		}

		[Test]
		public void EnumerableIsIEnumerable() {
			var enm = Enumerable.Range(1, 5);
			Assert.IsTrue(enm is IEnumerable<int>);
		}

		[Test]
		public void CanForeachOverEnumerable() {
			var result = "";
			foreach (var i in Enumerable.From(new[] { 1, 3, 5 }))
				result += i;
			Assert.AreEqual(result, "135");
		}

		[Test]
		public void CanSelectFromGrouping() {
			var grp = new[] { 1, 2, 3, 4, 5 }.GroupBy(i => i % 2, i => i.ToString()).First();
			Assert.AreEqual(grp.Select(x => x).ToArray(), new[] { "1", "3", "5" });
		}

		[Test]
		public void GroupingIsIEnumerable() {
			var grp = new[] { 1, 2, 3, 4, 5 }.GroupBy(i => i % 2, i => i.ToString()).First();
			Assert.IsTrue(grp is IEnumerable<string>);
		}

		[Test]
		public void CanForeachOverGrouping() {
			var grp = new[] { 1, 2, 3, 4, 5 }.GroupBy(i => i % 2, i => i.ToString()).First();
			var result = "";
			foreach (var x in grp)
				result += x;
			Assert.AreEqual(result, "135");
		}

		[Test]
		public void CanReadGroupingKey() {
			var grp = new[] { 1, 2, 3, 4, 5 }.GroupBy(i => i % 2, i => i.ToString()).First();
			Assert.AreEqual(grp.Key, 1);
		}

		[Test]
		public void CanSelectFromLookup() {
			var actual = new[] { "temp1.xls", "temp2.pdf", "temp3.jpg", "temp4.pdf" }.ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1], s => s.Match(new Regex("^(.+)\\."))[1]).Select(x => x.Key + " : " + x.ToArray());
			Assert.AreEqual(actual.ToArray(), new[] { "xls : temp1", "pdf : temp2,temp4", "jpg : temp3" });
		}

		[Test]
		public void CanForeachOverLookup() {
			var actual = new[] { "temp1.xls", "temp2.pdf", "temp3.jpg", "temp4.pdf" }.ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1], s => s.Match(new Regex("^(.+)\\."))[1]);
			string result = "";
			foreach (var x in actual)
				result += x.Key + " : " + x.ToArray() + "\n";
			Assert.AreEqual(result, "xls : temp1\npdf : temp2,temp4\njpg : temp3\n");
		}

		[Test]
		public void LookupImplementsIEnumerableOfGrouping() {
			var lu = new[] { "temp1.xls", "temp2.pdf", "temp3.jpg", "temp4.pdf" }.ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1], s => s.Match(new Regex("^(.+)\\."))[1]);
			Assert.IsTrue(lu is IEnumerable<Grouping<string, string>>);
		}

		[Test]
		public void LookupCountMemberWorks() {
			var lu = new[] { "temp1.xls", "temp2.pdf", "temp3.jpg", "temp4.pdf" }.ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1], s => s.Match(new Regex("^(.+)\\."))[1]);
			Assert.AreEqual(lu.Count, 3);
		}

		[Test]
		public void LookupContainsMemberWorks() {
			var lu = new[] { "temp1.xls", "temp2.pdf", "temp3.jpg", "temp4.pdf" }.ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1], s => s.Match(new Regex("^(.+)\\."))[1]);
			Assert.IsTrue(lu.Contains("xls"));
			Assert.IsFalse(lu.Contains("XLS"));
		}

		[Test]
		public void LookupIndexingWorks() {
			var lu = new[] { "temp1.xls", "temp2.pdf", "temp3.jpg", "temp4.pdf" }.ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1], s => s.Match(new Regex("^(.+)\\."))[1]);
			Assert.AreEqual(lu["pdf"].ToArray(), new[] { "temp2", "temp4" });
		}


		[Test]
		public void CanSelectFromDictionary() {
			var actual = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id, item => item.value).Select(x => new { x.Key, x.Value });
			Assert.AreEqual(actual.ToArray(), new[] { new { Key = "id_0", Value = 1 },  new { Key = "id_1", Value = 2 },  new { Key = "id_2", Value = 3 },  new { Key = "id_3", Value = 4 },  new { Key = "id_4", Value = 5 } });
		}

		[Test]
		public void CanForeachOverDictionary() {
			string result = "";
			foreach (var kvp in Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id, item => item.value)) {
				result += kvp.Key + "=" + kvp.Value + " ";
			}
			Assert.AreEqual(result, "id_0=1 id_1=2 id_2=3 id_3=4 id_4=5 ");
		}

		[Test]
		public void DictionaryImplementsIEnumerableOfKeyValuePair() {
			var d = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id, item => item.value);
			Assert.IsTrue(d is IEnumerable<KeyValuePair<string, int>>);
		}

		[Test]
		public void CanGetDictionaryElement() {
			var actual = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id, item => item.value);
			Assert.AreEqual(actual["id_0"], 1);
			Assert.Throws(() => { int i = actual["x"]; });
		}

		[Test]
		public void CanSetDictionaryElementWithIndexer() {
			var actual = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id, item => item.value);
			actual["id_0"] = 98;
			actual["x"] = 99;
			Assert.AreEqual(actual["id_0"], 98);
			Assert.AreEqual(actual["x"], 99);
		}

		[Test]
		public void CanAddDictionaryElement() {
			var actual = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id, item => item.value);
			actual.Add("x", 99);
			Assert.AreEqual(actual["x"], 99);
			Assert.Throws(() => actual.Add("id_0", 1));
		}

		[Test]
		public void CanGetDictionaryCount() {
			var actual = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id, item => item.value);
			Assert.AreEqual(actual.Count, 5);
		}

		[Test]
		public void DictionaryContainsKeyWorks() {
			var actual = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id, item => item.value);
			Assert.IsTrue(actual.ContainsKey("id_0"));
			Assert.IsFalse(actual.ContainsKey("x"));
		}

		[Test]
		public void DictionaryKeysWorks() {
			var actual = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id, item => item.value).Keys;
			Assert.AreEqual(actual.OrderBy().ToArray(), new[] { "id_0", "id_1", "id_2", "id_3", "id_4" });
		}

		[Test]
		public void DictionaryValuesWorks() {
			var actual = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id, item => item.value).Values;
			Assert.AreEqual(actual.OrderBy().ToArray(), new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void DictionaryRemoveWorks() {
			var actual = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id, item => item.value);
			Assert.IsTrue(actual.Remove("id_0"), "Remove id_0 should return true");
			Assert.IsFalse(actual.Remove("x"), "Remove x should return false");
			Assert.AreEqual(actual.Values.OrderBy().ToArray(), new[] { 2, 3, 4, 5 });
		}

		[Test]
		public void DictionaryTryGetValueWorks() {
			var actual = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).ToDictionary(item => item.id, item => item.value);
			int i;
			Assert.IsTrue(actual.TryGetValue("id_0", out i), "TryGetValue id_0 should return true");
			Assert.AreEqual(i, 1, "id_0 should be 1");
			Assert.IsFalse(actual.TryGetValue("x", out i), "TryGetValue x should return false");
			Assert.AreEqual(i, 0, "x should be 0");
		}

		[Test]
		public void EnumerableCanBeEvaluatedInMultipleContexts()
		{
			// Refers to https://github.com/erik-kallen/SaltarelleLinq/issues/4

			var actual = Enumerable.From(new int[] { 1, 2, 3 });

			Assert.IsTrue(actual.SequenceEqual(actual), "Enumerable should be sequenceEqual to itself");
			Assert.IsTrue(actual.SelectMany(x => actual).SequenceEqual(new int[] { 1, 2, 3, 1, 2, 3, 1, 2, 3 }), "SelectMany result should match");
		}
	}
}
