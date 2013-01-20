using System;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	[TestFixture]
	public class AggregateTests {
		[Test]
		public void AggregateWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5}.Aggregate((a, b) => a * b), 120);
		}

		[Test]
		public void AggregateWithSeedWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5}.Aggregate("", (a, b) => a + b), "12345");
		}

		[Test]
		public void AggregateWithSeedAndResultSelectorWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5}.Aggregate("", (a, b) => a + b, s => s + "X"), "12345X");
		}

		[Test]
		public void AggregateWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Aggregate((a, b) => a * b), 120);
		}

		[Test]
		public void AggregateWithSeedWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Aggregate("", (a, b) => a + b), "12345");
		}

		[Test]
		public void AggregateWithSeedAndResultSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Aggregate("", (a, b) => a + b, s => s + "X"), "12345X");
		}


		[Test]
		public void AverageWorksForArray() {
			Assert.AreEqual(new int[]     { 1, 2, 3, 4, 5 }.Average(), 3);
			Assert.AreEqual(new long[]    { 1, 2, 3, 4, 5 }.Average(), 3);
			Assert.AreEqual(new double[]  { 1, 2, 3, 4, 5 }.Average(), 3);
			Assert.AreEqual(new float[]   { 1, 2, 3, 4, 5 }.Average(), 3);
			Assert.AreEqual(new decimal[] { 1, 2, 3, 4, 5 }.Average(), 3);
		}

		[Test]
		public void AverageWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Average(), 3);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i =>    (long)i).Average(), 3);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i =>   (float)i).Average(), 3);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i =>  (double)i).Average(), 3);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => (decimal)i).Average(), 3);
		}

		[Test]
		public void AverageWithSelectorWorksForArray() {
			Assert.AreEqual(new[] { new { i =     (int)1 }, new { i =     (int)2 }, new { i =     (int)3 }, new { i =     (int)4 }, new { i =     (int)5 } }.Average(x => x.i), 3);
			Assert.AreEqual(new[] { new { i =    (long)1 }, new { i =    (long)2 }, new { i =    (long)3 }, new { i =    (long)4 }, new { i =    (long)5 } }.Average(x => x.i), 3);
			Assert.AreEqual(new[] { new { i =   (float)1 }, new { i =   (float)2 }, new { i =   (float)3 }, new { i =   (float)4 }, new { i =   (float)5 } }.Average(x => x.i), 3);
			Assert.AreEqual(new[] { new { i =  (double)1 }, new { i =  (double)2 }, new { i =  (double)3 }, new { i =  (double)4 }, new { i =  (double)5 } }.Average(x => x.i), 3);
			Assert.AreEqual(new[] { new { i = (decimal)1 }, new { i = (decimal)2 }, new { i = (decimal)3 }, new { i = (decimal)4 }, new { i = (decimal)5 } }.Average(x => x.i), 3);
		}

		[Test]
		public void AverageWithSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =     (int)i }).Average(x => x.i), 3);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =    (long)i }).Average(x => x.i), 3);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =   (float)i }).Average(x => x.i), 3);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =  (double)i }).Average(x => x.i), 3);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i = (decimal)i }).Average(x => x.i), 3);
		}


		[Test]
		public void CountWithoutPredicateWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Count(), 5);
		}

		[Test]
		public void CountWithPredicateWorksForArray() {
			Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }.Count(i => i > 3), 2);
		}

		[Test]
		public void CountWithoutPredicateWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Count(), 5);
		}

		[Test]
		public void CountWithPredicateWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Count(i => i > 3), 2);
		}
		

		[Test]
		public void MaxWorksForArray() {
			Assert.AreEqual(new int[]     { 1, 2, 3, 4, 5 }.Max(), 5);
			Assert.AreEqual(new long[]    { 1, 2, 3, 4, 5 }.Max(), 5);
			Assert.AreEqual(new double[]  { 1, 2, 3, 4, 5 }.Max(), 5);
			Assert.AreEqual(new float[]   { 1, 2, 3, 4, 5 }.Max(), 5);
			Assert.AreEqual(new decimal[] { 1, 2, 3, 4, 5 }.Max(), 5);
		}

		[Test]
		public void MaxWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Max(), 5);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i =>    (long)i).Max(), 5);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i =>   (float)i).Max(), 5);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i =>  (double)i).Max(), 5);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => (decimal)i).Max(), 5);
		}

		[Test]
		public void MaxWithSelectorWorksForArray() {
			Assert.AreEqual(new[] { new { i =     (int)1 }, new { i =     (int)2 }, new { i =     (int)3 }, new { i =     (int)4 }, new { i =     (int)5 } }.Max(x => x.i), 5);
			Assert.AreEqual(new[] { new { i =    (long)1 }, new { i =    (long)2 }, new { i =    (long)3 }, new { i =    (long)4 }, new { i =    (long)5 } }.Max(x => x.i), 5);
			Assert.AreEqual(new[] { new { i =   (float)1 }, new { i =   (float)2 }, new { i =   (float)3 }, new { i =   (float)4 }, new { i =   (float)5 } }.Max(x => x.i), 5);
			Assert.AreEqual(new[] { new { i =  (double)1 }, new { i =  (double)2 }, new { i =  (double)3 }, new { i =  (double)4 }, new { i =  (double)5 } }.Max(x => x.i), 5);
			Assert.AreEqual(new[] { new { i = (decimal)1 }, new { i = (decimal)2 }, new { i = (decimal)3 }, new { i = (decimal)4 }, new { i = (decimal)5 } }.Max(x => x.i), 5);
		}

		[Test]
		public void MaxWithSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =     (int)i }).Max(x => x.i), 5);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =    (long)i }).Max(x => x.i), 5);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =   (float)i }).Max(x => x.i), 5);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =  (double)i }).Max(x => x.i), 5);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i = (decimal)i }).Max(x => x.i), 5);
		}


		[Test]
		public void MinWorksForArray() {
			Assert.AreEqual(new int[]     { 1, 2, 3, 4, 5 }.Min(), 1);
			Assert.AreEqual(new long[]    { 1, 2, 3, 4, 5 }.Min(), 1);
			Assert.AreEqual(new double[]  { 1, 2, 3, 4, 5 }.Min(), 1);
			Assert.AreEqual(new float[]   { 1, 2, 3, 4, 5 }.Min(), 1);
			Assert.AreEqual(new decimal[] { 1, 2, 3, 4, 5 }.Min(), 1);
		}

		[Test]
		public void MinWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Min(), 1);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i =>    (long)i).Min(), 1);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i =>   (float)i).Min(), 1);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i =>  (double)i).Min(), 1);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => (decimal)i).Min(), 1);
		}

		[Test]
		public void MinWithSelectorWorksForArray() {
			Assert.AreEqual(new[] { new { i =     (int)1 }, new { i =     (int)2 }, new { i =     (int)3 }, new { i =     (int)4 }, new { i =     (int)5 } }.Min(x => x.i), 1);
			Assert.AreEqual(new[] { new { i =    (long)1 }, new { i =    (long)2 }, new { i =    (long)3 }, new { i =    (long)4 }, new { i =    (long)5 } }.Min(x => x.i), 1);
			Assert.AreEqual(new[] { new { i =   (float)1 }, new { i =   (float)2 }, new { i =   (float)3 }, new { i =   (float)4 }, new { i =   (float)5 } }.Min(x => x.i), 1);
			Assert.AreEqual(new[] { new { i =  (double)1 }, new { i =  (double)2 }, new { i =  (double)3 }, new { i =  (double)4 }, new { i =  (double)5 } }.Min(x => x.i), 1);
			Assert.AreEqual(new[] { new { i = (decimal)1 }, new { i = (decimal)2 }, new { i = (decimal)3 }, new { i = (decimal)4 }, new { i = (decimal)5 } }.Min(x => x.i), 1);
		}

		[Test]
		public void MinWithSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =     (int)i }).Min(x => x.i), 1);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =    (long)i }).Min(x => x.i), 1);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =   (float)i }).Min(x => x.i), 1);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =  (double)i }).Min(x => x.i), 1);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i = (decimal)i }).Min(x => x.i), 1);
		}


		[Test]
		public void MaxByWorksForArray() {
			Assert.AreEqual(new[] { new { i =     (int)1 }, new { i =     (int)2 }, new { i =     (int)3 }, new { i =     (int)4 }, new { i =     (int)5 } }.MaxBy(x => x.i), new { i = 5 });
			Assert.AreEqual(new[] { new { i =    (long)1 }, new { i =    (long)2 }, new { i =    (long)3 }, new { i =    (long)4 }, new { i =    (long)5 } }.MaxBy(x => x.i), new { i = 5 });
			Assert.AreEqual(new[] { new { i =   (float)1 }, new { i =   (float)2 }, new { i =   (float)3 }, new { i =   (float)4 }, new { i =   (float)5 } }.MaxBy(x => x.i), new { i = 5 });
			Assert.AreEqual(new[] { new { i =  (double)1 }, new { i =  (double)2 }, new { i =  (double)3 }, new { i =  (double)4 }, new { i =  (double)5 } }.MaxBy(x => x.i), new { i = 5 });
			Assert.AreEqual(new[] { new { i = (decimal)1 }, new { i = (decimal)2 }, new { i = (decimal)3 }, new { i = (decimal)4 }, new { i = (decimal)5 } }.MaxBy(x => x.i), new { i = 5 });
		}

		[Test]
		public void MaxByWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =     (int)i }).MaxBy(x => x.i), new { i = 5 });
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =    (long)i }).MaxBy(x => x.i), new { i = 5 });
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =   (float)i }).MaxBy(x => x.i), new { i = 5 });
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =  (double)i }).MaxBy(x => x.i), new { i = 5 });
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i = (decimal)i }).MaxBy(x => x.i), new { i = 5 });
		}


		[Test]
		public void MinByWorksForArray() {
			Assert.AreEqual(new[] { new { i =     (int)1 }, new { i =     (int)2 }, new { i =     (int)3 }, new { i =     (int)4 }, new { i =     (int)5 } }.MinBy(x => x.i), new { i = 1 });
			Assert.AreEqual(new[] { new { i =    (long)1 }, new { i =    (long)2 }, new { i =    (long)3 }, new { i =    (long)4 }, new { i =    (long)5 } }.MinBy(x => x.i), new { i = 1 });
			Assert.AreEqual(new[] { new { i =   (float)1 }, new { i =   (float)2 }, new { i =   (float)3 }, new { i =   (float)4 }, new { i =   (float)5 } }.MinBy(x => x.i), new { i = 1 });
			Assert.AreEqual(new[] { new { i =  (double)1 }, new { i =  (double)2 }, new { i =  (double)3 }, new { i =  (double)4 }, new { i =  (double)5 } }.MinBy(x => x.i), new { i = 1 });
			Assert.AreEqual(new[] { new { i = (decimal)1 }, new { i = (decimal)2 }, new { i = (decimal)3 }, new { i = (decimal)4 }, new { i = (decimal)5 } }.MinBy(x => x.i), new { i = 1 });
		}

		[Test]
		public void MinByWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =     (int)i }).MinBy(x => x.i), new { i = 1 });
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =    (long)i }).MinBy(x => x.i), new { i = 1 });
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =   (float)i }).MinBy(x => x.i), new { i = 1 });
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =  (double)i }).MinBy(x => x.i), new { i = 1 });
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i = (decimal)i }).MinBy(x => x.i), new { i = 1 });
		}


		[Test]
		public void SumWorksForArray() {
			Assert.AreEqual(new int[]     { 1, 2, 3, 4, 5 }.Sum(), 15);
			Assert.AreEqual(new long[]    { 1, 2, 3, 4, 5 }.Sum(), 15);
			Assert.AreEqual(new double[]  { 1, 2, 3, 4, 5 }.Sum(), 15);
			Assert.AreEqual(new float[]   { 1, 2, 3, 4, 5 }.Sum(), 15);
			Assert.AreEqual(new decimal[] { 1, 2, 3, 4, 5 }.Sum(), 15);
		}

		[Test]
		public void SumWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Sum(), 15);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i =>    (long)i).Sum(), 15);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i =>   (float)i).Sum(), 15);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i =>  (double)i).Sum(), 15);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => (decimal)i).Sum(), 15);
		}

		[Test]
		public void SumWithSelectorWorksForArray() {
			Assert.AreEqual(new[] { new { i =     (int)1 }, new { i =     (int)2 }, new { i =     (int)3 }, new { i =     (int)4 }, new { i =     (int)5 } }.Sum(x => x.i), 15);
			Assert.AreEqual(new[] { new { i =    (long)1 }, new { i =    (long)2 }, new { i =    (long)3 }, new { i =    (long)4 }, new { i =    (long)5 } }.Sum(x => x.i), 15);
			Assert.AreEqual(new[] { new { i =   (float)1 }, new { i =   (float)2 }, new { i =   (float)3 }, new { i =   (float)4 }, new { i =   (float)5 } }.Sum(x => x.i), 15);
			Assert.AreEqual(new[] { new { i =  (double)1 }, new { i =  (double)2 }, new { i =  (double)3 }, new { i =  (double)4 }, new { i =  (double)5 } }.Sum(x => x.i), 15);
			Assert.AreEqual(new[] { new { i = (decimal)1 }, new { i = (decimal)2 }, new { i = (decimal)3 }, new { i = (decimal)4 }, new { i = (decimal)5 } }.Sum(x => x.i), 15);
		}

		[Test]
		public void SumWithSelectorWorksForLinqJSEnumerable() {
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =     (int)i }).Sum(x => x.i), 15);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =    (long)i }).Sum(x => x.i), 15);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =   (float)i }).Sum(x => x.i), 15);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i =  (double)i }).Sum(x => x.i), 15);
			Assert.AreEqual(Enumerable.Range(1, 5).Select(i => new { i = (decimal)i }).Sum(x => x.i), 15);
		}
	}
}
