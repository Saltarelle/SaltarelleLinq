using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class FunctionalTests {
//		This test fails due to what seems like a bug in linq.js
//		[Test]
		public void LetBindWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.LetBind(a => a.Zip(a.Skip(1), (x, y) => x + ":" + y)).ToArray(), new[] { "1:2", "2:3", "3:4", "4:5" });
		}

		[Test]
		public void LetBindWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1,5).LetBind(a => a.Zip(a.Skip(1), (x, y) => x + ":" + y)).ToArray(), new[] { "1:2", "2:3", "3:4", "4:5" });
		}


		[Test]
		public void ShareWorksForArray() {
			var result = new List<int>();
			var enm = new[] { 1, 2, 3, 4, 5 }.Share();
			enm.Take(3).ForEach(i => result.Add(i));
			result.Add(-1);
			enm.ForEach(i => result.Add(i));
			Assert.AreEqual(result, new[] { 1, 2, 3, -1, 4, 5 });
		}

		[Test]
		public void ShareWorksForLinqJSEnumerable() {
			var result = new List<int>();
			var enm = Enumerable.Range(1, 5).Share();
			enm.Take(3).ForEach(i => result.Add(i));
			result.Add(-1);
			enm.ForEach(i => result.Add(i));
			Assert.AreEqual(result, new[] { 1, 2, 3, -1, 4, 5 });
		}


		[Test]
		public void MemoizeWorksForSaltarelleEnumerable() {
			var enumerable = new TestEnumerable(1, 5);
			var enm = enumerable.Memoize();
			enm.Where(i => i % 2 == 0).Force();
			enm.Where(i => i % 2 == 0).Force();
			Assert.AreEqual(5, enumerable.NumMoveNextCalls);
		}

		[Test]
		public void MemoizeWorksForLinqJSEnumerable() {
			var result = new List<string>();
			var enm = Enumerable.Range(1, 5).DoAction(i => result.Add("--->" + i)).Memoize();
			enm.Where(i => i % 2 == 0).ForEach(i => result.Add(i.ToString()));
			result.Add("---");
			enm.Where(i => i % 2 == 0).ForEach(i => result.Add(i.ToString()));
			Assert.AreEqual(result, new[] { "--->1", "--->2", "2", "--->3", "--->4", "4", "--->5", "---" , "2", "4" });
		}
	}
}
