using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class ErrorHandlingTests {
		[Test]
		public void CatchErrorWorksSaltarelleEnumerable() {
			string errorMessage = null;
			var enumerable = new TestEnumerable(1, 10) { ThrowOnIndex = 4 };
			var result = enumerable.CatchError(ex => errorMessage = ex.Message).ToArray();
			Assert.AreEqual(result, new[] { 1, 2, 3, 4, });
			Assert.AreEqual(errorMessage, "error");
		}

		[Test]
		public void CatchErrorWorksForLinqJSEnumerable() {
			string errorMessage = null;
			var result = Enumerable.Range(1, 10).Select(i => { if (i == 5) throw new Exception("enumerable_error"); return i; }).CatchError(ex => errorMessage = ex.Message).ToArray();
			Assert.AreEqual(result, new[] { 1, 2, 3, 4, });
			Assert.AreEqual(errorMessage, "enumerable_error");
		}

		[Test]
		public void FinallyActionWorksForArray() {
			bool finallyRun = false;
			new[] { 1, 2, 3, 4, 5 }.FinallyAction(() => finallyRun = true).Force();
			Assert.IsTrue(finallyRun);
		}

		[Test]
		public void FinallyActionWorksForLinqJSEnumerable() {
			bool finallyRun = false;
			Enumerable.Range(1, 10).FinallyAction(() => finallyRun = true).Force();
			Assert.IsTrue(finallyRun);
		}
	}
}
