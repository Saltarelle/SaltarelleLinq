using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class ActionTests {
		[Test]
		public void DoActionWorksForArray() {
			var result = new List<int>();
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.DoAction(x => result.Add(x)).ToArray(), new[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(result, new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void DoActionWithIndexWorksForArray() {
			var result = new List<int>();
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.DoAction((x, idx) => { result.Add(x); result.Add(idx); }).ToArray(), new[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(result, new[] { 1, 0, 2, 1, 3, 2, 4, 3, 5, 4 });
		}

		[Test]
		public void DoActionWorksForLinqJSEnumerable() {
			var result = new List<int>();
			Assert.AreEqual(Enumerable.Range(1, 5).DoAction(x => result.Add(x)).ToArray(), new[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(result, new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void DoActionWithIndexWorksForLinqJSEnumerable() {
			var result = new List<int>();
			Assert.AreEqual(Enumerable.Range(1, 5).DoAction((x, idx) => { result.Add(x); result.Add(idx); }).ToArray(), new[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(result, new[] { 1, 0, 2, 1, 3, 2, 4, 3, 5, 4 });
		}


		[Test]
		public void ForEachWithSingleParameterWithoutReturnValueWorksForSaltarelleEnumerable() {
			var result = new List<int>();
			new TestEnumerable(1, 5).ForEach(i => result.Add(i));
			Assert.AreEqual(result, new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void ForEachWithSingleParameterWithReturnValueWorksForSaltarelleEnumerable() {
			var result = new List<int>();
			new TestEnumerable(1, 5).ForEach(i => { result.Add(i); return i < 3; });
			Assert.AreEqual(result, new[] { 1, 2, 3 });
		}

		[Test]
		public void ForEachWithTwoParametersWithoutReturnValueWorksForSaltarelleEnumerable() {
			var result = new List<int>();
			new TestEnumerable(1, 5).ForEach((i, idx) => { result.Add(i); result.Add(idx); });
			Assert.AreEqual(result, new[] { 1, 0, 2, 1, 3, 2, 4, 3, 5, 4 });
		}

		[Test]
		public void ForEachWithTwoParametersWithReturnValueWorksForSaltarelleEnumerable() {
			var result = new List<int>();
			new TestEnumerable(1, 5).ForEach((i, idx) => { result.Add(i); result.Add(idx); return i < 3; });
			Assert.AreEqual(result, new[] { 1, 0, 2, 1, 3, 2 });
		}

		[Test]
		public void ForEachWithSingleParameterWithoutReturnValueWorksForLinqJSEnumerable() {
			var result = new List<int>();
			Enumerable.Range(1, 5).ForEach(i => result.Add(i));
			Assert.AreEqual(result, new[] { 1, 2, 3, 4, 5 });
		}

		[Test]
		public void ForEachWithSingleParameterWithReturnValueWorksForLinqJSEnumerable() {
			var result = new List<int>();
			Enumerable.Range(1, 5).ForEach(i => { result.Add(i); return i < 3; });
			Assert.AreEqual(result, new[] { 1, 2, 3 });
		}

		[Test]
		public void ForEachWithTwoParametersWithoutReturnValueWorksForLinqJSEnumerable() {
			var result = new List<int>();
			Enumerable.Range(1, 5).ForEach((i, idx) => { result.Add(i); result.Add(idx); });
			Assert.AreEqual(result, new[] { 1, 0, 2, 1, 3, 2, 4, 3, 5, 4 });
		}

		[Test]
		public void ForEachWithTwoParametersWithReturnValueWorksForLinqJSEnumerable() {
			var result = new List<int>();
			Enumerable.Range(1, 5).ForEach((i, idx) => { result.Add(i); result.Add(idx); return i < 3; });
			Assert.AreEqual(result, new[] { 1, 0, 2, 1, 3, 2 });
		}


		[Test]
		public void ForceWorksForSaltarelleEnumerable() {
			var enm = new TestEnumerable(1, 5);
			enm.Force();
			Assert.AreEqual(enm.LastReturnedValue, 5);
		}

		[Test]
		public void ForceWorksForLinqJSEnumerable() {
			var result = new List<int>();
			Enumerable.Range(1, 5).DoAction(x => result.Add(x)).Force();
			Assert.AreEqual(result, new[] { 1, 2, 3, 4, 5 });
		}
	}
}
