using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class PagingTests {
		[Test]
		public void ElementAtWorksForLinqArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.ElementAt(2), 3);
		}

		[Test]
		public void ElementAtWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).ElementAt(2), 3);
		}


		[Test]
		public void ElementAtOrDefaultWithoutDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.ElementAtOrDefault(2), 3);
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.ElementAtOrDefault(10), 0);
		}

		[Test]
		public void ElementAtOrDefaultWithDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.ElementAtOrDefault(2, -1), 3);
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.ElementAtOrDefault(10, -1), -1);
		}

		[Test]
		public void ElementAtOrDefaultWithoutDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).ElementAtOrDefault(2), 3);
			Assert.AreEqual(Enumerable.Range(1, 5).ElementAtOrDefault(10), 0);
		}

		[Test]
		public void ElementAtOrDefaultWithDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).ElementAtOrDefault(2, -1), 3);
			Assert.AreEqual(Enumerable.Range(1, 5).ElementAtOrDefault(10, -1), -1);
		}


		[Test]
		public void FirstWithoutPredicateWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.First(), 1);
		}

		[Test]
		public void FirstWithPredicateWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.First(i => i > 2), 3);
		}

		[Test]
		public void FirstWithoutPredicateWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).First(), 1);
		}

		[Test]
		public void FirstWithPredicateWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).First(i => i > 2), 3);
		}


		[Test]
		public void FirstOrDefaultWithoutPredicateOrDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.FirstOrDefault(), 1);
			Assert.AreEqual(new int[0].FirstOrDefault(), 0);
		}

		[Test]
		public void FirstOrDefaultWithoutPredicateWithDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.FirstOrDefault(-1), 1);
			Assert.AreEqual(new int[0].FirstOrDefault(-1), -1);
		}

		[Test]
		public void FirstOrDefaultWithPredicateWithoutDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.FirstOrDefault(i => i > 2), 3);
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.FirstOrDefault(i => i > 5), 0);
		}

		[Test]
		public void FirstOrDefaultWithPredicateAndDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.FirstOrDefault(i => i > 2, -1), 3);
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.FirstOrDefault(i => i > 5, -1), -1);
		}

		[Test]
		public void FirstOrDefaultWithoutPredicateOrDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).FirstOrDefault(), 1);
			Assert.AreEqual(Enumerable.Range(1, 0).FirstOrDefault(), 0);
		}

		[Test]
		public void FirstOrDefaultWithoutPredicateWithDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).FirstOrDefault(-1), 1);
			Assert.AreEqual(Enumerable.Range(1, 0).FirstOrDefault(-1), -1);
		}

		[Test]
		public void FirstOrDefaultWithPredicateWithoutDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).FirstOrDefault(i => i > 2), 3);
			Assert.AreEqual(Enumerable.Range(1, 2).FirstOrDefault(i => i > 2), 0);
		}

		[Test]
		public void FirstOrDefaultWithPredicateAndDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).FirstOrDefault(i => i > 2, -1), 3);
			Assert.AreEqual(Enumerable.Range(1, 2).FirstOrDefault(i => i > 2, -1), -1);
		}


		[Test]
		public void LastWithoutPredicateWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Last(), 5);
		}

		[Test]
		public void LastWithPredicateWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Last(i => i < 3), 2);
		}

		[Test]
		public void LastWithoutPredicateWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Last(), 5);
		}

		[Test]
		public void LastWithPredicateWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Last(i => i < 3), 2);
		}


		[Test]
		public void LastOrDefaultWithoutPredicateOrDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.LastOrDefault(), 5);
			Assert.AreEqual(new int[0].LastOrDefault(), 0);
		}

		[Test]
		public void LastOrDefaultWithoutPredicateWithDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.LastOrDefault(-1), 5);
			Assert.AreEqual(new int[0].LastOrDefault(-1), -1);
		}

		[Test]
		public void LastOrDefaultWithPredicateWithoutDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.LastOrDefault(i => i < 3), 2);
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.LastOrDefault(i => i < 0), 0);
		}

		[Test]
		public void LastOrDefaultWithPredicateAndDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.LastOrDefault(i => i < 3, -1), 2);
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.LastOrDefault(i => i < 0, -1), -1);
		}

		[Test]
		public void LastOrDefaultWithoutPredicateOrDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).LastOrDefault(), 5);
			Assert.AreEqual(Enumerable.Range(1, 0).LastOrDefault(), 0);
		}

		[Test]
		public void LastOrDefaultWithoutPredicateWithDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).LastOrDefault(-1), 5);
			Assert.AreEqual(Enumerable.Range(1, 0).LastOrDefault(-1), -1);
		}

		[Test]
		public void LastOrDefaultWithPredicateWithoutDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).LastOrDefault(i => i < 3), 2);
			Assert.AreEqual(Enumerable.Range(1, 2).LastOrDefault(i => i < 0), 0);
		}

		[Test]
		public void LastOrDefaultWithPredicateAndDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).LastOrDefault(i => i < 3, -1), 2);
			Assert.AreEqual(Enumerable.Range(1, 2).LastOrDefault(i => i < 0, -1), -1);
		}


		[Test]
		public void SingleWithoutPredicateWorksForArray() {
			Assert.AreEqual(new[] { 2 }.Single(), 2);
		}

		[Test]
		public void SingleWithPredicateWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Single(i => i == 3), 3);
		}

		[Test]
		public void SingleWithoutPredicateWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(2, 1).Single(), 2);
		}

		[Test]
		public void SingleWithPredicateWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Single(i => i == 3), 3);
		}


		[Test]
		public void SingleOrDefaultWithoutPredicateOrDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 2 }.SingleOrDefault(), 2);
			Assert.AreEqual(new int[0].SingleOrDefault(), 0);
		}

		[Test]
		public void SingleOrDefaultWithoutPredicateWithDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 2 }.SingleOrDefault(-1), 2);
			Assert.AreEqual(new int[0].SingleOrDefault(-1), -1);
		}

		[Test]
		public void SingleOrDefaultWithPredicateWithoutDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.SingleOrDefault(i => i == 3), 3);
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.SingleOrDefault(i => i == 9), 0);
		}

		[Test]
		public void SingleOrDefaultWithPredicateAndDefaultValueWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.SingleOrDefault(i => i == 3, -1), 3);
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.SingleOrDefault(i => i == 9, -1), -1);
		}

		[Test]
		public void SingleOrDefaultWithoutPredicateOrDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(2, 1).SingleOrDefault(), 2);
			Assert.AreEqual(Enumerable.Range(1, 0).SingleOrDefault(), 0);
		}

		[Test]
		public void SingleOrDefaultWithoutPredicateWithDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(2, 1).SingleOrDefault(-1), 2);
			Assert.AreEqual(Enumerable.Range(1, 0).SingleOrDefault(-1), -1);
		}

		[Test]
		public void SingleOrDefaultWithPredicateWithoutDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).SingleOrDefault(i => i == 3), 3);
			Assert.AreEqual(Enumerable.Range(1, 5).SingleOrDefault(i => i == 9), 0);
		}

		[Test]
		public void SingleOrDefaultWithPredicateAndDefaultValueWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).SingleOrDefault(i => i == 3, -1), 3);
			Assert.AreEqual(Enumerable.Range(1, 2).SingleOrDefault(i => i == 9, -1), -1);
		}


		[Test]
		public void SkipWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Skip(2).ToArray(), new[] { 3, 4, 5 });
		}

		[Test]
		public void SkipWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Skip(2).ToArray(), new[] { 3, 4, 5 });
		}


		[Test]
		public void SkipWhileWithoutIndexWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.SkipWhile(i => i <= 2).ToArray(), new[] { 3, 4, 5 });
		}

		[Test]
		public void SkipWhileWithIndexWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.SkipWhile((i, idx) => (i + idx) <= 3).ToArray(), new[] { 3, 4, 5 });
		}

		[Test]
		public void SkipWhileWithoutIndexWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).SkipWhile(i => i <= 2).ToArray(), new[] { 3, 4, 5 });
		}

		[Test]
		public void SkipWhileWithIndexWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).SkipWhile((i, idx) => (i + idx) <= 3).ToArray(), new[] { 3, 4, 5 });
		}


		[Test]
		public void TakeWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 1000).Take(3).ToArray(), new[] { 1, 2, 3 }, "Result should be correct");
		}

		[Test]
		public void TakeWorksForSaltarelleEnumerable() {
			var enumerable = new TestEnumerable(1, 1000);
			Assert.AreEqual(enumerable.Take(3).ToArray(), new[] { 1, 2, 3 }, "Result should be correct");
			Assert.IsTrue(enumerable.EnumeratorDisposed, "Enumerator should be disposed");
		}


		[Test]
		public void TakeWhileWithoutIndexWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.TakeWhile(i => i <= 2).ToArray(), new[] { 1, 2 });
		}

		[Test]
		public void TakeWhileWithIndexWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.TakeWhile((i, idx) => (i + idx) <= 3).ToArray(), new[] { 1, 2 });
		}

		[Test]
		public void TakeWhileWithoutIndexWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).TakeWhile(i => i <= 2).ToArray(), new[] { 1, 2 });
		}

		[Test]
		public void TakeWhileWithIndexWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).TakeWhile((i, idx) => (i + idx) <= 3).ToArray(), new[] { 1, 2 });
		}


		[Test]
		public void TakeExceptLastWithoutArgumentWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.TakeExceptLast().ToArray(), new[] { 1, 2, 3, 4 });
		}

		[Test]
		public void TakeExceptLastWithArgumentWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.TakeExceptLast(2).ToArray(), new[] { 1, 2, 3 });
		}

		[Test]
		public void TakeExceptLastWithoutArgumentWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).TakeExceptLast().ToArray(), new[] { 1, 2, 3, 4 });
		}

		[Test]
		public void TakeExceptLastWithArgumentWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).TakeExceptLast(2).ToArray(), new[] { 1, 2, 3 });
		}


		[Test]
		public void TakeFromLastWithoutArgumentWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.TakeFromLast(2).ToArray(), new[] { 4, 5 });
		}

		[Test]
		public void TakeFromLastWithoutArgumentWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).TakeFromLast(2).ToArray(), new[] { 4, 5 });
		}


		[Test]
		public void IndexOfWorksForArray() {
			Assert.AreEqual(((IEnumerable<int>)new[] { 1, 2, 3, 4, 3, 2, 1 }).IndexOf(3), 2);
			Assert.AreEqual(((IEnumerable<C>)new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("3"), new C("2"), new C("1") }).IndexOf(new C("3")), 2);
		}

		[Test]
		public void IndexOfWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 3, 2, 1 }.Wrap().IndexOf(3), 2);
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("3"), new C("2"), new C("1") }.Wrap().IndexOf(new C("3")), 2);
		}

		[Test]
		public void IndexOfWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 3, 2, 1 }).IndexOf(3), 2);
			Assert.AreEqual(Enumerable.From(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("3"), new C("2"), new C("1") }).IndexOf(new C("3")), 2);
		}

		[Test]
		public void IndexOfWithPredicateWorksForArray() {
			Assert.AreEqual(((IEnumerable<int>)new[] { 1, 2, 3, 4, 3, 2, 1 }).IndexOf(x => x == 3), 2);
		}

		[Test]
		public void IndexOfWithPredicateWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 3, 2, 1 }.Wrap().IndexOf(x => x == 3), 2);
		}

		[Test]
		public void IndexOfWithPredicateWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { 1, 2, 3, 4, 3, 2, 1 }).IndexOf(x => x == 3), 2);
		}

		[Test]
		public void IndexOfWithComparerWorksForArray() {
			Assert.AreEqual(((IEnumerable<C>)new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("3"), new C("2"), new C("1") }).IndexOf(new C("3X"), new FirstLetterComparer()), 2);
		}

		[Test]
		public void IndexOfWithComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("3"), new C("2"), new C("1") }.Wrap().IndexOf(new C("3X"), new FirstLetterComparer()), 2);
		}

		[Test]
		public void IndexOfWithComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("3"), new C("2"), new C("1") }).IndexOf(new C("3X"), new FirstLetterComparer()), 2);
		}


		[Test]
		public void LastIndexOfWorksForArray() {
			Assert.AreEqual(((IEnumerable<int>)new[] { 1, 2, 3, 4, 3, 2, 1 }).LastIndexOf(3), 4);
			Assert.AreEqual(((IEnumerable<C>)new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("3"), new C("2"), new C("1") }).LastIndexOf(new C("3")), 4);
		}

		[Test]
		public void LastIndexOfWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 3, 2, 1 }.Wrap().LastIndexOf(3), 4);
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("3"), new C("2"), new C("1") }.Wrap().LastIndexOf(new C("3")), 4);
		}

		[Test]
		public void LastIndexOfWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 3, 2, 1 }.Wrap().LastIndexOf(3), 4);
			Assert.AreEqual(Enumerable.From(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("3"), new C("2"), new C("1") }).LastIndexOf(new C("3")), 4);
		}

		[Test]
		public void LastIndexOfWithPredicateWorksForArray() {
			Assert.AreEqual(((IEnumerable<int>)new[] { 1, 2, 3, 4, 3, 2, 1 }).LastIndexOf(x => x == 3), 4);
		}

		[Test]
		public void LastIndexOfWithPredicateWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 3, 2, 1 }.Wrap().LastIndexOf(x => x == 3), 4);
		}

		[Test]
		public void LastIndexOfWithPredicateWorksForLinqJSEnumerable() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 3, 2, 1 }.Wrap().LastIndexOf(x => x == 3), 4);
		}

		[Test]
		public void LastIndexOfWithComparerWorksForArray() {
			Assert.AreEqual(((IEnumerable<C>)new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("3"), new C("2"), new C("1") }).LastIndexOf(new C("3X"), new FirstLetterComparer()), 4);
		}

		[Test]
		public void LastIndexOfWithComparerWorksForSaltarelleEnumerable() {
			Assert.AreEqual(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("3"), new C("2"), new C("1") }.Wrap().LastIndexOf(new C("3X"), new FirstLetterComparer()), 4);
		}

		[Test]
		public void LastIndexOfWithComparerWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.From(new[] { new C("1"), new C("2"), new C("3"), new C("4"), new C("3"), new C("2"), new C("1") }).LastIndexOf(new C("3X"), new FirstLetterComparer()), 4);
		}
	}
}
