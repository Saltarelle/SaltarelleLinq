using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Linq;

namespace Linq.Tests {
	public abstract class TestBase {
		public class QUnitTest {
			public string module;
			public string name;
			public int failed;
			public int passed;
			public int total;
		}

		public class QUnitFailure {
			public string module;
			public string test;
			public dynamic expected;
			public dynamic actual;
			public string message;
			public string source;
		}

		public class QUnitOutput {
			public List<QUnitTest> tests;
			public List<QUnitFailure> failures;
		}

		protected virtual string TestClassName {
			get { return "Linq.TestScript." + GetType().Name; }
		}

		//[Test, Ignore("Not a real test")]
		public void WriteThePage() {
			var html =
@"<html>
	<head>
		<title>Test</title>
		<link rel=""stylesheet"" href=""file://" + Path.GetFullPath("qunit.css").Replace("\\", "/") + @"""/>
	</head>
	<body>
		<script type=""text/javascript"" src=""file://" + Path.GetFullPath("mscorlib.js").Replace("\\", "/") + @"""></script>
		<script type=""text/javascript"" src=""file://" + Path.GetFullPath("qunit.js").Replace("\\", "/") + @"""></script>
		<script type=""text/javascript"" src=""file://" + Path.GetFullPath("Linq.TestScript.js").Replace("\\", "/") + @"""></script>
		<script type=""text/javascript"" src=""file://" + Path.GetFullPath("linq.js").Replace("\\", "/") + @"""></script>
		<div id=""qunit""></div>
		<script type=""text/javascript"">(new " + TestClassName + @"()).runTests();</script>
	</body>
</html>
";
			Console.Write(html);
		}

		[TestCaseSource("PerformTest")]
		public void Outcome(bool pass, string errorMessage) {
			if (!pass)
				Assert.Fail(errorMessage);
		}

		public IEnumerable<TestCaseData> PerformTest() {
			string filename = Path.Combine(Environment.CurrentDirectory, Guid.NewGuid().ToString("N") + ".js");
			try {
				File.WriteAllText(filename, "(new " + TestClassName + @"()).runTests();");
				var p = Process.Start(new ProcessStartInfo { FileName = Path.GetFullPath("runner/node.exe"), Arguments = "run-tests.js \"" + filename + "\"", WorkingDirectory = Path.GetFullPath("runner"), RedirectStandardOutput = true, UseShellExecute = false, CreateNoWindow = true });
				var output = JsonConvert.DeserializeObject<QUnitOutput>(p.StandardOutput.ReadToEnd());
				var result = new List<TestCaseData>();
				foreach (var t in output.tests) {
					TestCaseData d;
					if (t.failed == 0) {
						d = new TestCaseData(true, null);
					}
					else {
						var failures = output.failures.Where(f => f.module == t.module && f.test == t.name).ToList();
						string errorMessage = string.Join("\n", failures.Select(f => f.message + (f.expected != null ? ", expected: " + f.expected.ToString() : "") + (f.actual != null ? ", actual: " + f.actual.ToString() : "")));
						if (errorMessage == "")
							errorMessage = "Failed";
						d = new TestCaseData(false, errorMessage);
					}
					d.SetName((t.module != "Linq.TestScript" ? t.module + ": " : "") + t.name);
					result.Add(d);
				}
				p.Close();
				return result;
			}
			catch (Exception ex) {
				return new[] { new TestCaseData(false, ex.Message).SetName(ex.Message) };
			}
			finally {
				try { File.Delete(filename); } catch {}
			}
		}
	}
}

/*

using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using com.gargoylesoftware.htmlunit;
using com.gargoylesoftware.htmlunit.html;

namespace Linq.Tests {
	public abstract class TestBase {
		private static readonly Lazy<string> _mscorlibScriptLazy = new Lazy<string>(() => File.ReadAllText("mscorlib.js"));
		internal static string MscorlibScript { get { return _mscorlibScriptLazy.Value; } }

		private static readonly Lazy<string> _qunitCss = new Lazy<string>(() => File.ReadAllText("qunit.css"));
		internal static string QUnitCss { get { return _qunitCss.Value; } }

		private static readonly Lazy<string> _qunitScript = new Lazy<string>(() => File.ReadAllText("qunit.js"));
		internal static string QUnitScript { get { return _qunitScript.Value; } }

		private static readonly Lazy<string> _testScript = new Lazy<string>(() => File.ReadAllText("Linq.TestScript.js"));
		internal static string TestScript { get { return _testScript.Value; } }

		private static readonly Lazy<string> _linqScript = new Lazy<string>(() => File.ReadAllText("linq.js"));
		internal static string LinqScript { get { return _linqScript.Value; } }

		private IEnumerable<string> ScriptSources {
			get { return new[] { MscorlibScript, LinqScript, TestScript }; }
		}

		private string TestClassName {
			get { return "Linq.TestScript." + GetType().Name; }
		}

		protected HtmlPage GeneratePage(bool print = false) {
			var client = new WebClient();
			try {
				var html =
@"<html>
	<head>
		<title>Test</title>
		<style>" + QUnitCss + @"</style>
	</head>
	<body>
		<script type=""text/javascript"">" + Environment.NewLine + MscorlibScript + @"</script>
		<script type=""text/javascript"">" + Environment.NewLine + QUnitScript + @"</script>";

				foreach (var src in ScriptSources)
					html += Environment.NewLine + "<script type=\"text/javascript\">" + Environment.NewLine + src + "</script>";
		html += @"
		<div id=""qunit""></div>
		<script type=""text/javascript"">(new " + TestClassName + @"()).runTests();</script>
	</body>
</html>
";
				if (print)
					Console.Write(html);

				var tempFile = Path.Combine(Environment.CurrentDirectory, Guid.NewGuid().ToString("N") + ".htm");
				try {
					File.WriteAllText(tempFile, html);
					var result = (HtmlPage)client.getPage("file://" + tempFile.Replace("\\", "/"));
					DateTime startTime = DateTime.Now;
					while (!result.getElementById("qunit-testresult").getTextContent().Contains("completed")) {
						System.Threading.Thread.Sleep(100);
						if ((DateTime.Now - startTime).Seconds > 3600)
							throw new Exception("Tests timed out");
					}
					return result;
				}
				finally {
					try { File.Delete(tempFile); } catch {}
				}
			}
			finally {
				client.closeAllWindows();
			}
		}

		//[Test, Ignore("Not a real test")]
		public void WriteThePage() {
			GeneratePage(true);
		}

		[TestCaseSource("PerformTest")]
		public void Outcome(bool pass, string errorMessage) {
			if (!pass)
				Assert.Fail(errorMessage);
		}

		public IEnumerable<TestCaseData> PerformTest() {
			try {
				var result = new List<TestCaseData>();
				var page = GeneratePage();
				var elems = page.querySelectorAll("#qunit-tests > li");
				for (int i = 0; i < elems.getLength(); i++) {
					var elem = (HtmlElement)elems.get(i);
					bool pass = (" " + elem.getAttribute("class") + " ").Contains(" pass ");
					var categoryElem = page.querySelector("#" + elem.getId() + " .module-name");
					string category = (categoryElem != null ? categoryElem.getTextContent() : null);
					string testName = page.querySelector("#" + elem.getId() + " .test-name").getTextContent();
					string errorMessage;
					if (pass) {
						errorMessage = null;
					}
					else {
						errorMessage = "";
						var allFailures = page.querySelectorAll("#" + elem.getId() + " .fail");
						for (int j = 0, n = allFailures.getLength(); j < n; j++) {
							var failure = (HtmlElement)allFailures.get(j);

							failure.setId("__current");

							errorMessage += (errorMessage != "" ? Environment.NewLine + Environment.NewLine : "") + page.querySelector("#__current .test-message").getTextContent();
							var expected = page.querySelector("#__current .test-expected");
							if (expected != null) {
								var expectedText = expected.getTextContent();
								errorMessage += "," + (expectedText.Contains("\n") ? Environment.NewLine : " ") + expectedText;
							}
							var actual = page.querySelector("#__current .test-actual");
							if (actual != null) {
								var actualText = actual.getTextContent();
								errorMessage += "," + (actualText.Contains("\n") ? Environment.NewLine : " ") + actualText;
							}

							failure.setId("");
						}
					}
					result.Add(new TestCaseData(pass, errorMessage).SetName((category != null ? category + ": " : "") + testName));
				}
				return result;
			}
			catch (Exception ex) {
				return new[] { new TestCaseData(false, ex.Message).SetName(ex.Message) };
			}
		}
	}
}
*/