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

			var lu2 = new[] { new { s = "1", i = 100 }, new { s = "3", i = 101 }, new { s = "1", i = 102 }, new { s = "2", i = 103 }, new { s = "3", i = 104 } }.ToLookup(x => new C(x.s));
			Assert.AreEqual(lu2.Select(x => x.Key.S).ToArray(), new[] { "1", "3", "2" });
			Assert.AreEqual(lu2[new C("1")].Select(x => x.i).ToArray(), new[] { 100, 102 });
			Assert.AreEqual(lu2[new C("2")].Select(x => x.i).ToArray(), new[] { 103 });
			Assert.AreEqual(lu2[new C("3")].Select(x => x.i).ToArray(), new[] { 101, 104 });
		}

		[Test]
		public void ToLookupWithOnlyKeySelectorWorksForSaltarelleEnumerable() {
			var lu = new[] { "temp.xls", "temp.pdf", "temp.jpg", "temp2.pdf" }.Wrap().ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1]);
			Assert.AreEqual(lu.Count, 3);
			Assert.AreEqual(lu["xls"].ToArray(), new[] { "temp.xls" });
			Assert.AreEqual(lu["pdf"].ToArray(), new[] { "temp.pdf", "temp2.pdf" });
			Assert.AreEqual(lu["jpg"].ToArray(), new[] { "temp.jpg" });

			var lu2 = new[] { new { s = "1", i = 100 }, new { s = "3", i = 101 }, new { s = "1", i = 102 }, new { s = "2", i = 103 }, new { s = "3", i = 104 } }.Wrap().ToLookup(x => new C(x.s));
			Assert.AreEqual(lu2.Select(x => x.Key.S).ToArray(), new[] { "1", "3", "2" });
			Assert.AreEqual(lu2[new C("1")].Select(x => x.i).ToArray(), new[] { 100, 102 });
			Assert.AreEqual(lu2[new C("2")].Select(x => x.i).ToArray(), new[] { 103 });
			Assert.AreEqual(lu2[new C("3")].Select(x => x.i).ToArray(), new[] { 101, 104 });
		}

		[Test]
		public void ToLookupWithOnlyKeySelectorWorksForLinqJSEnumerable() {
			var lu = Enumerable.From(new[] { "temp.xls", "temp.pdf", "temp.jpg", "temp2.pdf" }).ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1]);
			Assert.AreEqual(lu.Count, 3);
			Assert.AreEqual(lu["xls"].ToArray(), new[] { "temp.xls" });
			Assert.AreEqual(lu["pdf"].ToArray(), new[] { "temp.pdf", "temp2.pdf" });
			Assert.AreEqual(lu["jpg"].ToArray(), new[] { "temp.jpg" });

			var lu2 = Enumerable.From(new[] { new { s = "1", i = 100 }, new { s = "3", i = 101 }, new { s = "1", i = 102 }, new { s = "2", i = 103 }, new { s = "3", i = 104 } }).ToLookup(x => new C(x.s));
			Assert.AreEqual(lu2.Select(x => x.Key.S).ToArray(), new[] { "1", "3", "2" });
			Assert.AreEqual(lu2[new C("1")].Select(x => x.i).ToArray(), new[] { 100, 102 });
			Assert.AreEqual(lu2[new C("2")].Select(x => x.i).ToArray(), new[] { 103 });
			Assert.AreEqual(lu2[new C("3")].Select(x => x.i).ToArray(), new[] { 101, 104 });
		}

		[Test]
		public void ToLookupWithKeySelectorAndComparerWorksForArray() {
			var lu2 = new[] { new { s = "11", i = 100 }, new { s = "31", i = 101 }, new { s = "12", i = 102 }, new { s = "22", i = 103 }, new { s = "32", i = 104 } }.ToLookup(x => new C(x.s), new FirstLetterComparer());
			Assert.AreEqual(lu2.Select(x => x.Key.S).ToArray(), new[] { "11", "31", "22" });
			Assert.AreEqual(lu2[new C("1")].Select(x => x.i).ToArray(), new[] { 100, 102 });
			Assert.AreEqual(lu2[new C("2")].Select(x => x.i).ToArray(), new[] { 103 });
			Assert.AreEqual(lu2[new C("3")].Select(x => x.i).ToArray(), new[] { 101, 104 });
		}

		[Test]
		public void ToLookupWithKeySelectorAndComparerWorksForSaltarelleEnumerable() {
			var lu2 = new[] { new { s = "11", i = 100 }, new { s = "31", i = 101 }, new { s = "12", i = 102 }, new { s = "22", i = 103 }, new { s = "32", i = 104 } }.Wrap().ToLookup(x => new C(x.s), new FirstLetterComparer());
			Assert.AreEqual(lu2.Select(x => x.Key.S).ToArray(), new[] { "11", "31", "22" });
			Assert.AreEqual(lu2[new C("1")].Select(x => x.i).ToArray(), new[] { 100, 102 });
			Assert.AreEqual(lu2[new C("2")].Select(x => x.i).ToArray(), new[] { 103 });
			Assert.AreEqual(lu2[new C("3")].Select(x => x.i).ToArray(), new[] { 101, 104 });
		}

		[Test]
		public void ToLookupWithKeySelectorAndComparerWorksForLinqJSEnumerable() {
			var lu2 = Enumerable.From(new[] { new { s = "11", i = 100 }, new { s = "31", i = 101 }, new { s = "12", i = 102 }, new { s = "22", i = 103 }, new { s = "32", i = 104 } }).ToLookup(x => new C(x.s), new FirstLetterComparer());
			Assert.AreEqual(lu2.Select(x => x.Key.S).ToArray(), new[] { "11", "31", "22" });
			Assert.AreEqual(lu2[new C("1")].Select(x => x.i).ToArray(), new[] { 100, 102 });
			Assert.AreEqual(lu2[new C("2")].Select(x => x.i).ToArray(), new[] { 103 });
			Assert.AreEqual(lu2[new C("3")].Select(x => x.i).ToArray(), new[] { 101, 104 });
		}

		[Test]
		public void ToLookupWithKeyAndValueSelectorsWorksForArray() {
			var lu = new[] { "temp1.xls", "temp2.pdf", "temp3.jpg", "temp4.pdf" }.ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1], s => s.Match(new Regex("^(.+)\\."))[1]);
			Assert.AreEqual(lu.Count, 3);
			Assert.AreEqual(lu["xls"].ToArray(), new[] { "temp1" });
			Assert.AreEqual(lu["pdf"].ToArray(), new[] { "temp2", "temp4" });
			Assert.AreEqual(lu["jpg"].ToArray(), new[] { "temp3" });

			var lu2 = new[] { new { s = "1", i = 100 }, new { s = "3", i = 101 }, new { s = "1", i = 102 }, new { s = "2", i = 103 }, new { s = "3", i = 104 } }.ToLookup(x => new C(x.s), x => x.i);
			Assert.AreEqual(lu2.Select(x => x.Key.S).ToArray(), new[] { "1", "3", "2" });
			Assert.AreEqual(lu2[new C("1")].ToArray(), new[] { 100, 102 });
			Assert.AreEqual(lu2[new C("2")].ToArray(), new[] { 103 });
			Assert.AreEqual(lu2[new C("3")].ToArray(), new[] { 101, 104 });
		}

		[Test]
		public void ToLookupWithKeyAndValueSelectorsWorksForSaltarelleEnumerable() {
			var lu = new[] { "temp1.xls", "temp2.pdf", "temp3.jpg", "temp4.pdf" }.Wrap().ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1], s => s.Match(new Regex("^(.+)\\."))[1]);
			Assert.AreEqual(lu.Count, 3);
			Assert.AreEqual(lu["xls"].ToArray(), new[] { "temp1" });
			Assert.AreEqual(lu["pdf"].ToArray(), new[] { "temp2", "temp4" });
			Assert.AreEqual(lu["jpg"].ToArray(), new[] { "temp3" });

			var lu2 = new[] { new { s = "1", i = 100 }, new { s = "3", i = 101 }, new { s = "1", i = 102 }, new { s = "2", i = 103 }, new { s = "3", i = 104 } }.Wrap().ToLookup(x => new C(x.s), x => x.i);
			Assert.AreEqual(lu2.Select(x => x.Key.S).ToArray(), new[] { "1", "3", "2" });
			Assert.AreEqual(lu2[new C("1")].ToArray(), new[] { 100, 102 });
			Assert.AreEqual(lu2[new C("2")].ToArray(), new[] { 103 });
			Assert.AreEqual(lu2[new C("3")].ToArray(), new[] { 101, 104 });
		}

		[Test]
		public void ToLookupWithKeyAndValueSelectorsWorksForLinqJSEnumerable() {
			var lu = Enumerable.From(new[] { "temp1.xls", "temp2.pdf", "temp3.jpg", "temp4.pdf" }).ToLookup(s => s.Match(new Regex("\\.(.+$)"))[1], s => s.Match(new Regex("^(.+)\\."))[1]);
			Assert.AreEqual(lu.Count, 3);
			Assert.AreEqual(lu["xls"].ToArray(), new[] { "temp1" });
			Assert.AreEqual(lu["pdf"].ToArray(), new[] { "temp2", "temp4" });
			Assert.AreEqual(lu["jpg"].ToArray(), new[] { "temp3" });

			var lu2 = Enumerable.From(new[] { new { s = "1", i = 100 }, new { s = "3", i = 101 }, new { s = "1", i = 102 }, new { s = "2", i = 103 }, new { s = "3", i = 104 } }).ToLookup(x => new C(x.s), x => x.i);
			Assert.AreEqual(lu2.Select(x => x.Key.S).ToArray(), new[] { "1", "3", "2" });
			Assert.AreEqual(lu2[new C("1")].ToArray(), new[] { 100, 102 });
			Assert.AreEqual(lu2[new C("2")].ToArray(), new[] { 103 });
			Assert.AreEqual(lu2[new C("3")].ToArray(), new[] { 101, 104 });
		}

		[Test]
		public void ToLookupWithKeyAndValueSelectorsAndComparerWorksForArray() {
			var lu = new[] { new { s = "11", i = 100 }, new { s = "31", i = 101 }, new { s = "12", i = 102 }, new { s = "22", i = 103 }, new { s = "32", i = 104 } }.ToLookup(x => new C(x.s), x => x.i, new FirstLetterComparer());
			Assert.AreEqual(lu.Select(x => x.Key.S).ToArray(), new[] { "11", "31", "22" });
			Assert.AreEqual(lu[new C("11")].ToArray(), new[] { 100, 102 });
			Assert.AreEqual(lu[new C("22")].ToArray(), new[] { 103 });
			Assert.AreEqual(lu[new C("31")].ToArray(), new[] { 101, 104 });
		}

		[Test]
		public void ToLookupWithKeyAndValueSelectorsAndComparerWorksForSaltarelleEnumerable() {
			var lu = new[] { new { s = "11", i = 100 }, new { s = "31", i = 101 }, new { s = "12", i = 102 }, new { s = "22", i = 103 }, new { s = "32", i = 104 } }.Wrap().ToLookup(x => new C(x.s), x => x.i, new FirstLetterComparer());
			Assert.AreEqual(lu.Select(x => x.Key.S).ToArray(), new[] { "11", "31", "22" });
			Assert.AreEqual(lu[new C("12")].ToArray(), new[] { 100, 102 });
			Assert.AreEqual(lu[new C("22")].ToArray(), new[] { 103 });
			Assert.AreEqual(lu[new C("31")].ToArray(), new[] { 101, 104 });
		}

		[Test]
		public void ToLookupWithKeyAndValueSelectorsAndComparerWorksForLinqJSEnumerable() {
			var lu = Enumerable.From(new[] { new { s = "11", i = 100 }, new { s = "31", i = 101 }, new { s = "12", i = 102 }, new { s = "22", i = 103 }, new { s = "32", i = 104 } }).ToLookup(x => new C(x.s), x => x.i, new FirstLetterComparer());
			Assert.AreEqual(lu.Select(x => x.Key.S).ToArray(), new[] { "11", "31", "22" });
			Assert.AreEqual(lu[new C("11")].ToArray(), new[] { 100, 102 });
			Assert.AreEqual(lu[new C("22")].ToArray(), new[] { 103 });
			Assert.AreEqual(lu[new C("31")].ToArray(), new[] { 101, 104 });
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

			var d2 = Enumerable.Range(1, 5).Select((value, index) => new { id = new C(index.ToString()), value }).ToArray().ToDictionary(item => item.id);
			Assert.AreEqual(d2.Count, 5);
			Assert.AreEqual(d2[new C("0")].value, 1);
			Assert.AreEqual(d2[new C("1")].value, 2);
			Assert.AreEqual(d2[new C("2")].value, 3);
			Assert.AreEqual(d2[new C("3")].value, 4);
			Assert.AreEqual(d2[new C("4")].value, 5);
		}

		[Test]
		public void ToDictionaryWithOnlyKeySelectorWorksForSaltarelleEnumerable() {
			var d = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).Wrap().ToDictionary(item => item.id);
			Assert.AreEqual(d.Count, 5);
			Assert.AreEqual(d["id_0"], new { id = "id_0", value = 1 });
			Assert.AreEqual(d["id_1"], new { id = "id_1", value = 2 });
			Assert.AreEqual(d["id_2"], new { id = "id_2", value = 3 });
			Assert.AreEqual(d["id_3"], new { id = "id_3", value = 4 });
			Assert.AreEqual(d["id_4"], new { id = "id_4", value = 5 });

			var d2 = Enumerable.Range(1, 5).Select((value, index) => new { id = new C(index.ToString()), index, value }).Wrap().ToDictionary(item => item.id);
			Assert.AreEqual(d2.Count, 5);
			Assert.AreEqual(d2[new C("0")].value, 1);
			Assert.AreEqual(d2[new C("1")].value, 2);
			Assert.AreEqual(d2[new C("2")].value, 3);
			Assert.AreEqual(d2[new C("3")].value, 4);
			Assert.AreEqual(d2[new C("4")].value, 5);
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

			var d2 = Enumerable.Range(1, 5).Select((value, index) => new { id = new C(index.ToString()), index, value }).ToDictionary(item => item.id);
			Assert.AreEqual(d2.Count, 5);
			Assert.AreEqual(d2[new C("0")].value, 1);
			Assert.AreEqual(d2[new C("1")].value, 2);
			Assert.AreEqual(d2[new C("2")].value, 3);
			Assert.AreEqual(d2[new C("3")].value, 4);
			Assert.AreEqual(d2[new C("4")].value, 5);
		}

		[Test]
		public void ToDictionaryWithKeySelectorAndComparerWorksForArray() {
			var d2 = Enumerable.Range(1, 5).Select((value, index) => new { id = new C(index.ToString()), value }).ToArray().ToDictionary(item => item.id, new FirstLetterComparer());
			Assert.AreEqual(d2.Count, 5);
			Assert.AreEqual(d2[new C("02")].value, 1);
			Assert.AreEqual(d2[new C("12")].value, 2);
			Assert.AreEqual(d2[new C("22")].value, 3);
			Assert.AreEqual(d2[new C("32")].value, 4);
			Assert.AreEqual(d2[new C("42")].value, 5);
		}

		[Test]
		public void ToDictionaryWithKeySelectorAndComparerWorksForSaltarelleEnumerable() {
			var d2 = Enumerable.Range(1, 5).Select((value, index) => new { id = new C(index.ToString()), value }).Wrap().ToDictionary(item => item.id, new FirstLetterComparer());
			Assert.AreEqual(d2.Count, 5);
			Assert.AreEqual(d2[new C("02")].value, 1);
			Assert.AreEqual(d2[new C("12")].value, 2);
			Assert.AreEqual(d2[new C("22")].value, 3);
			Assert.AreEqual(d2[new C("32")].value, 4);
			Assert.AreEqual(d2[new C("42")].value, 5);
		}

		[Test]
		public void ToDictionaryWithKeySelectorAndComparerWorksForLinqJSEnumerable() {
			var d2 = Enumerable.Range(1, 5).Select((value, index) => new { id = new C(index.ToString()), value }).ToDictionary(item => item.id, new FirstLetterComparer());
			Assert.AreEqual(d2.Count, 5);
			Assert.AreEqual(d2[new C("02")].value, 1);
			Assert.AreEqual(d2[new C("12")].value, 2);
			Assert.AreEqual(d2[new C("22")].value, 3);
			Assert.AreEqual(d2[new C("32")].value, 4);
			Assert.AreEqual(d2[new C("42")].value, 5);
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

			var d2 = Enumerable.Range(1, 5).Select((value, index) => new { id = new C(index.ToString()), value }).ToArray().ToDictionary(item => item.id, item => item.value);
			Assert.AreEqual(d2.Count, 5);
			Assert.AreEqual(d2[new C("0")], 1);
			Assert.AreEqual(d2[new C("1")], 2);
			Assert.AreEqual(d2[new C("2")], 3);
			Assert.AreEqual(d2[new C("3")], 4);
			Assert.AreEqual(d2[new C("4")], 5);
		}

		[Test]
		public void ToDictionaryWithKeyAndValueSelectorsWorksForSaltarelleEnumerable() {
			var d = Enumerable.Range(1, 5).Select((value, index) => new { id = "id_" + index, value }).Wrap().ToDictionary(item => item.id, item => item.value);
			Assert.AreEqual(d.Count, 5);
			Assert.AreEqual(d["id_0"], 1);
			Assert.AreEqual(d["id_1"], 2);
			Assert.AreEqual(d["id_2"], 3);
			Assert.AreEqual(d["id_3"], 4);
			Assert.AreEqual(d["id_4"], 5);

			var d2 = Enumerable.Range(1, 5).Select((value, index) => new { id = new C(index.ToString()), value }).Wrap().ToDictionary(item => item.id, item => item.value);
			Assert.AreEqual(d2.Count, 5);
			Assert.AreEqual(d2[new C("0")], 1);
			Assert.AreEqual(d2[new C("1")], 2);
			Assert.AreEqual(d2[new C("2")], 3);
			Assert.AreEqual(d2[new C("3")], 4);
			Assert.AreEqual(d2[new C("4")], 5);
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

			var d2 = Enumerable.Range(1, 5).Select((value, index) => new { id = new C(index.ToString()), value }).ToDictionary(item => item.id, item => item.value);
			Assert.AreEqual(d2.Count, 5);
			Assert.AreEqual(d2[new C("0")], 1);
			Assert.AreEqual(d2[new C("1")], 2);
			Assert.AreEqual(d2[new C("2")], 3);
			Assert.AreEqual(d2[new C("3")], 4);
			Assert.AreEqual(d2[new C("4")], 5);
		}

		[Test]
		public void ToDictionaryWithKeyAndValueSelectorsAndComparerWorksForArray() {
			var d2 = Enumerable.Range(1, 5).Select((value, index) => new { id = new C(index.ToString()), value }).ToArray().ToDictionary(item => item.id, item => item.value, new FirstLetterComparer());
			Assert.AreEqual(d2.Count, 5);
			Assert.AreEqual(d2[new C("02")], 1);
			Assert.AreEqual(d2[new C("12")], 2);
			Assert.AreEqual(d2[new C("22")], 3);
			Assert.AreEqual(d2[new C("32")], 4);
			Assert.AreEqual(d2[new C("42")], 5);
		}

		[Test]
		public void ToDictionaryWithKeyAndValueSelectorsAndComparerWorksForSaltarelleEnumerable() {
			var d2 = Enumerable.Range(1, 5).Select((value, index) => new { id = new C(index.ToString()), value }).Wrap().ToDictionary(item => item.id, item => item.value, new FirstLetterComparer());
			Assert.AreEqual(d2.Count, 5);
			Assert.AreEqual(d2[new C("02")], 1);
			Assert.AreEqual(d2[new C("12")], 2);
			Assert.AreEqual(d2[new C("22")], 3);
			Assert.AreEqual(d2[new C("32")], 4);
			Assert.AreEqual(d2[new C("42")], 5);
		}

		[Test]
		public void ToDictionaryWithKeyAndValueSelectorsAndComparerWorksForLinqJSEnumerable() {
			var d2 = Enumerable.Range(1, 5).Select((value, index) => new { id = new C(index.ToString()), value }).ToDictionary(item => item.id, item => item.value, new FirstLetterComparer());
			Assert.AreEqual(d2.Count, 5);
			Assert.AreEqual(d2[new C("02")], 1);
			Assert.AreEqual(d2[new C("12")], 2);
			Assert.AreEqual(d2[new C("22")], 3);
			Assert.AreEqual(d2[new C("32")], 4);
			Assert.AreEqual(d2[new C("42")], 5);
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
