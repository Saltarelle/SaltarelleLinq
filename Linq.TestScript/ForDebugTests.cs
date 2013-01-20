using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class ForDebugTests {
		[Test(ExpectedAssertionCount = 0)]
		public void TraceWithoutArgumentsWorksForArray() {
			new[] { 1, 2, 3, 4, 5 }.Trace().Force();
			// Writes to console.log, assume it works if we don't get errors.
		}

		[Test(ExpectedAssertionCount = 0)]
		public void TraceWithMessageWorksForArray() {
			new[] { 1, 2, 3, 4, 5 }.Trace("X").Force();
			// Writes to console.log, assume it works if we don't get errors.
		}

		[Test(ExpectedAssertionCount = 0)]
		public void TraceWithMessageAndSelectorWorksForArray() {
			new[] { 1, 2, 3, 4, 5 }.Trace("X", i => i.ToString()).Force();
			// Writes to console.log, assume it works if we don't get errors.
		}

		[Test(ExpectedAssertionCount = 0)]
		public void TraceWithoutArgumentsWorksForLinqJSEnumerable() {
			Enumerable.Range(1, 10).Trace().Force();
			// Writes to console.log, assume it works if we don't get errors.
		}

		[Test(ExpectedAssertionCount = 0)]
		public void TraceWithMessageWorksForLinqJSEnumerable() {
			Enumerable.Range(1, 10).Trace("X").Force();
			// Writes to console.log, assume it works if we don't get errors.
		}

		[Test(ExpectedAssertionCount = 0)]
		public void TraceWithMessageAndSelectorWorksForLinqJSEnumerable() {
			Enumerable.Range(1, 10).Trace("X", i => i.ToString()).Force();
			// Writes to console.log, assume it works if we don't get errors.
		}
	}
}
