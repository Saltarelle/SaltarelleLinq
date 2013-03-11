using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class ForDebugTests {
		[ExpandParams] delegate void ConsoleLogDelegate(params object[] messages);

		[ScriptAlias("console.log"), IntrinsicProperty]
		static ConsoleLogDelegate ConsoleLog { get; set; }

		private string WithRedirectedConsoleLog(Action a) {
			var old = ConsoleLog;
			try {
				var sb = new StringBuilder();
				ConsoleLog = args => sb.Append(args.Join(",") + "|");
				a();
				return sb.ToString();
			}
			finally {
				ConsoleLog = old;
			}
		}

		[Test]
		public void TraceWithoutArgumentsWorksForArray() {
			string s = WithRedirectedConsoleLog(() => new[] { 1, 2, 3, 4, 5 }.Trace().Force());
			Assert.AreEqual(s, "Trace,1|Trace,2|Trace,3|Trace,4|Trace,5|");
		}

		[Test]
		public void TraceWithMessageWorksForArray() {
			string s = WithRedirectedConsoleLog(() => new[] { 1, 2, 3, 4, 5 }.Trace("X").Force());
			Assert.AreEqual(s, "X,1|X,2|X,3|X,4|X,5|");
		}

		[Test]
		public void TraceWithMessageAndSelectorWorksForArray() {
			string s = WithRedirectedConsoleLog(() => new[] { 1, 2, 3, 4, 5 }.Trace("X", i => (i * 2).ToString()).Force());
			Assert.AreEqual(s, "X,2|X,4|X,6|X,8|X,10|");
		}

		[Test]
		public void TraceWithoutArgumentsWorksForLinqJSEnumerable() {
			string s = WithRedirectedConsoleLog(() => Enumerable.Range(1, 10).Trace().Force());
			Assert.AreEqual(s, "Trace,1|Trace,2|Trace,3|Trace,4|Trace,5|Trace,6|Trace,7|Trace,8|Trace,9|Trace,10|");
		}

		[Test]
		public void TraceWithMessageWorksForLinqJSEnumerable() {
			string s = WithRedirectedConsoleLog(() => Enumerable.Range(1, 10).Trace("X").Force());
			Assert.AreEqual(s, "X,1|X,2|X,3|X,4|X,5|X,6|X,7|X,8|X,9|X,10|");
		}

		[Test]
		public void TraceWithMessageAndSelectorWorksForLinqJSEnumerable() {
			string s = WithRedirectedConsoleLog(() => Enumerable.Range(1, 10).Trace("X", i => (i * 2).ToString()).Force());
			Assert.AreEqual(s, "X,2|X,4|X,6|X,8|X,10|X,12|X,14|X,16|X,18|X,20|");
		}
	}
}
