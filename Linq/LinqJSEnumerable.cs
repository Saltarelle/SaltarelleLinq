using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Linq {
	[Imported]
	public class LinqJSEnumerable<TElement> : IEnumerable<TElement> {
		internal LinqJSEnumerable() {}

		public IEnumerator<TElement> GetEnumerator() { return null; }

		IEnumerator IEnumerable.GetEnumerator() { return null; }

		#region Projection / filtering

		public LinqJSEnumerable<TElement> CascadeBreadthFirst(Func<TElement, IEnumerable<TElement>> func) { return null; }

		public LinqJSEnumerable<TResult> CascadeBreadthFirst<TResult>(Func<TElement, IEnumerable<TElement>> func, Func<TElement, TResult> resultSelector) { return null; }

		public LinqJSEnumerable<TResult> CascadeBreadthFirst<TResult>(Func<TElement, IEnumerable<TElement>> func, Func<TElement, int, TResult> resultSelector) { return null; }


		public LinqJSEnumerable<TElement> CascadeDepthFirst(Func<TElement, IEnumerable<TElement>> func) { return null; }

		public LinqJSEnumerable<TResult> CascadeDepthFirst<TResult>(Func<TElement, IEnumerable<TElement>> func, Func<TElement, TResult> resultSelector) { return null; }

		public LinqJSEnumerable<TResult> CascadeDepthFirst<TResult>(Func<TElement, IEnumerable<TElement>> func, Func<TElement, int, TResult> resultSelector) { return null; }


		public LinqJSEnumerable<object> Flatten() { return null; }


		public LinqJSEnumerable<TResult> Pairwise<TResult>(Func<TElement, TElement, TResult> selector) { return null; }


		public static LinqJSEnumerable<T> Scan<T>(Func<T, T, T> func) { return null; }

		public LinqJSEnumerable<TAccumulate> Scan<TAccumulate>(TAccumulate seed, Func<TAccumulate, TElement, TAccumulate> func) { return null; }


		public LinqJSEnumerable<TResult> Select<TResult>(Func<TElement, TResult> selector) { return null; }

		public LinqJSEnumerable<TResult> Select<TResult>(Func<TElement, int, TResult> selector) { return null; }


		public LinqJSEnumerable<TResult> SelectMany<TResult>(Func<TElement, IEnumerable<TResult>> selector) { return null; }

		public LinqJSEnumerable<TResult> SelectMany<TResult>(Func<TElement, int, IEnumerable<TResult>> selector) { return null; }

		public LinqJSEnumerable<TResult> SelectMany<TCollection, TResult>(Func<TElement, IEnumerable<TCollection>> collectionSelector, Func<TElement, TCollection, TResult> resultSelector) { return null; }

		public LinqJSEnumerable<TResult> SelectMany<TCollection, TResult>(Func<TElement, int, IEnumerable<TCollection>> collectionSelector, Func<TElement, TCollection, TResult> resultSelector) { return null; }


		[InlineCode("{this}.select(function(x) {{ return {$System.Script}.cast(x, {TResult}); }})")]
		public LinqJSEnumerable<TResult> Cast<TResult>() { return null; }


		[InlineCode("{this}.ofType({TResult})")]
		public LinqJSEnumerable<TResult> OfType<TResult>() { return null; }


		public LinqJSEnumerable<TResult> Zip<TOther, TResult>(IEnumerable<TOther> other, Func<TElement, TOther, TResult> selector) { return null; }

		public LinqJSEnumerable<TResult> Zip<TOther, TResult>(IEnumerable<TOther> other, Func<TElement, TOther, int, TResult> selector) { return null; }


		public LinqJSEnumerable<TElement> Where(Func<TElement, bool> predicate) { return null; }

		public LinqJSEnumerable<TElement> Where(Func<TElement, int, bool> predicate) { return null; }

		#endregion

		#region Join

		public LinqJSEnumerable<TResult> Join<TInner, TKey, TResult>(IEnumerable<TInner> inner, Func<TElement, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TElement, TInner, TResult> resultSelector) { return null; }

		public LinqJSEnumerable<TResult> Join<TInner, TKey, TResult>(IEnumerable<TInner> inner, Func<TElement, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TElement, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer) { return null; }


		public LinqJSEnumerable<TResult> GroupJoin<TInner, TKey, TResult>(IEnumerable<TInner> inner, Func<TElement, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TElement, IEnumerable<TInner>, TResult> resultSelector) { return null; }

		public LinqJSEnumerable<TResult> GroupJoin<TInner, TKey, TResult>(IEnumerable<TInner> inner, Func<TElement, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TElement, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer) { return null; }

		#endregion

		#region Set methods

		public bool All(Func<TElement, bool> predicate) { return false; }


		public bool Any() { return false; }

		public bool Any(Func<TElement, bool> predicate) { return false; }


		public LinqJSEnumerable<TElement> Concat(IEnumerable<TElement> other) { return null; }


		public LinqJSEnumerable<TElement> Insert(int index, IEnumerable<TElement> other) { return null; }


		public LinqJSEnumerable<TElement> Alternate(TElement value) { return null; }


		public bool Contains(TElement value) { return false; }

		public bool Contains(TElement value, IEqualityComparer<TElement> comparer) { return false; }

		[InlineCode("{this}.defaultIfEmpty(ss.getDefaultValue({TElement}))")]
		public LinqJSEnumerable<TElement> DefaultIfEmpty() { return null; }

		public LinqJSEnumerable<TElement> DefaultIfEmpty(TElement defaultValue) { return null; }


		public LinqJSEnumerable<TElement> Distinct() { return null; }

		public LinqJSEnumerable<TElement> Distinct(IEqualityComparer<TElement> comparer) { return null; }


		public LinqJSEnumerable<TElement> Except(IEnumerable<TElement> other) { return null; }

		public LinqJSEnumerable<TElement> Except(IEnumerable<TElement> other, IEqualityComparer<TElement> comparer) { return null; }


		public bool SequenceEqual(IEnumerable<TElement> other) { return false; }

		public bool SequenceEqual<TKey>(IEnumerable<TElement> other, Func<TElement, TKey> compareSelector) { return false; }


		public LinqJSEnumerable<TElement> Union(IEnumerable<TElement> other) { return null; }

		public LinqJSEnumerable<TElement> Union(IEnumerable<TElement> other, IEqualityComparer<TElement> comparer) { return null; }

		#endregion

		#region Ordering

		public OrderedLinqJSEnumerable<TElement> OrderBy() { return null; }

		public OrderedLinqJSEnumerable<TElement> OrderBy<TKey>(Func<TElement, TKey> keySelector) { return null; }

		public OrderedLinqJSEnumerable<TElement> OrderBy<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer) { return null; }


		public OrderedLinqJSEnumerable<TElement> OrderByDescending() { return null; }

		public OrderedLinqJSEnumerable<TElement> OrderByDescending<TKey>(Func<TElement, TKey> keySelector) { return null; }

		public OrderedLinqJSEnumerable<TElement> OrderByDescending<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer) { return null; }


		public LinqJSEnumerable<TElement> Reverse() { return null; }


		public LinqJSEnumerable<TElement> Shuffle() { return null; }

		#endregion

		#region Grouping

		public LinqJSEnumerable<Grouping<TKey, TElement>> GroupBy<TKey>(Func<TElement, TKey> keySelector) { return null; }

		[InlineCode("{this}.groupBy({keySelector}, null, null, {comparer})")]
		public LinqJSEnumerable<Grouping<TKey, TElement>> GroupBy<TKey>(Func<TElement, TKey> keySelector, IEqualityComparer<TKey> comparer) { return null; }

		public LinqJSEnumerable<Grouping<TKey, TElement>> GroupBy<TKey, TElement>(Func<TElement, TKey> keySelector, Func<TElement, TElement> elementSelector) { return null; }

		[InlineCode("{this}.groupBy({keySelector}, null, {resultSelector})")]
		public LinqJSEnumerable<TResult> GroupBy<TKey, TResult>(Func<TElement, TKey> keySelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector) { return null; }

		[InlineCode("{this}.groupBy({keySelector}, {elementSelector}, null, {comparer})")]
		public LinqJSEnumerable<Grouping<TKey, TElement>> GroupBy<TKey, TElement>(Func<TElement, TKey> keySelector, Func<TElement, TElement> elementSelector, IEqualityComparer<TKey> comparer) { return null; }

		public LinqJSEnumerable<TResult> GroupBy<TKey, TElement, TResult>(Func<TElement, TKey> keySelector, Func<TElement, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector) { return null; }

		[InlineCode("{this}.groupBy({keySelector}, null, {resultSelector}, {comparer})")]
		public LinqJSEnumerable<TResult> GroupBy<TKey, TResult>(Func<TElement, TKey> keySelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer) { return null; }

		public LinqJSEnumerable<TResult> GroupBy<TKey, TElement, TResult>(Func<TElement, TKey> keySelector, Func<TElement, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comperer) { return null; }


		public LinqJSEnumerable<Grouping<TKey, TElement>> PartitionBy<TKey>(Func<TElement, TKey> keySelector) { return null; }

		[InlineCode("{this}.partitionBy({keySelector}, null, null, {comparer})")]
		public LinqJSEnumerable<Grouping<TKey, TElement>> PartitionBy<TKey>(Func<TElement, TKey> keySelector, IEqualityComparer<TKey> comparer) { return null; }

		public LinqJSEnumerable<Grouping<TKey, TElement>> PartitionBy<TKey, TElement>(Func<TElement, TKey> keySelector, Func<TElement, TElement> elementSelector) { return null; }

		[InlineCode("{this}.partitionBy({keySelector}, null, {resultSelector})")]
		public LinqJSEnumerable<TResult> PartitionBy<TKey, TResult>(Func<TElement, TKey> keySelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector) { return null; }

		[InlineCode("{this}.partitionBy({keySelector}, {elementSelector}, null, {comparer})")]
		public LinqJSEnumerable<Grouping<TKey, TElement>> PartitionBy<TKey, TElement>(Func<TElement, TKey> keySelector, Func<TElement, TElement> elementSelector, IEqualityComparer<TKey> comparer) { return null; }

		public LinqJSEnumerable<TResult> PartitionBy<TKey, TElement, TResult>(Func<TElement, TKey> keySelector, Func<TElement, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector) { return null; }

		[InlineCode("{this}.partitionBy({keySelector}, null, {resultSelector}, {comparer})")]
		public LinqJSEnumerable<TResult> PartitionBy<TKey, TResult>(Func<TElement, TKey> keySelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer) { return null; }

		public LinqJSEnumerable<TResult> PartitionBy<TKey, TElement, TResult>(Func<TElement, TKey> keySelector, Func<TElement, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comperer) { return null; }


		public LinqJSEnumerable<TElement[]> Buffer(int count) { return null; }

		#endregion

		#region Aggregate

		public TElement Aggregate(Func<TElement, TElement, TElement> func) { return default(TElement); }

		public TAccumulate Aggregate<TAccumulate>(TAccumulate seed, Func<TAccumulate, TElement, TAccumulate> func) { return default(TAccumulate); }

		public TResult Aggregate<TAccumulate, TResult>(TAccumulate seed, Func<TAccumulate, TElement, TAccumulate> func, Func<TAccumulate, TResult> resultSelector) { return default(TResult); }


		public double Average(Func<TElement, int> selector) { return 0; }

		public double Average(Func<TElement, long> selector) { return 0; }

		public float Average(Func<TElement, float> selector) { return 0; }

		public double Average(Func<TElement, double> selector) { return 0; }

		public decimal Average(Func<TElement, decimal> selector) { return 0; }


		public int Count() { return 0; }

		public int Count(Func<TElement, bool> predicate) { return 0; }


		public int Max(Func<TElement, int> selector) { return 0; }

		public long Max(Func<TElement, long> selector) { return 0; }

		public float Max(Func<TElement, float> selector) { return 0; }

		public double Max(Func<TElement, double> selector) { return 0; }

		public decimal Max(Func<TElement, decimal> selector) { return 0; }


		public int Min(Func<TElement, int> selector) { return 0; }

		public long Min(Func<TElement, long> selector) { return 0; }

		public float Min(Func<TElement, float> selector) { return 0; }

		public double Min(Func<TElement, double> selector) { return 0; }

		public decimal Min(Func<TElement, decimal> selector) { return 0; }


		public TElement MaxBy(Func<TElement, int> selector) { return default(TElement); }

		public TElement MaxBy(Func<TElement, long> selector) { return default(TElement); }

		public TElement MaxBy(Func<TElement, float> selector) { return default(TElement); }

		public TElement MaxBy(Func<TElement, double> selector) { return default(TElement); }

		public TElement MaxBy(Func<TElement, decimal> selector) { return default(TElement); }


		public TElement MinBy(Func<TElement, int> selector) { return default(TElement); }

		public TElement MinBy(Func<TElement, long> selector) { return default(TElement); }

		public TElement MinBy(Func<TElement, float> selector) { return default(TElement); }

		public TElement MinBy(Func<TElement, double> selector) { return default(TElement); }

		public TElement MinBy(Func<TElement, decimal> selector) { return default(TElement); }


		public int Sum(Func<TElement, int> selector) { return 0; }

		public long Sum(Func<TElement, long> selector) { return 0; }

		public float Sum(Func<TElement, float> selector) { return 0; }

		public double Sum(Func<TElement, double> selector) { return 0; }

		public decimal Sum(Func<TElement, decimal> selector) { return 0; }

		#endregion

		#region Paging

		public TElement ElementAt(int index) { return default(TElement); }


		[InlineCode("{this}.elementAtOrDefault({index}, ss.getDefaultValue({TElement}))")]
		public TElement ElementAtOrDefault(int index) { return default(TElement); }


		public TElement ElementAtOrDefault(int index, TElement defaultValue) { return default(TElement); }


		public TElement First() { return default(TElement); }

		public TElement First(Func<TElement, bool> predicate) { return default(TElement); }


		[InlineCode("{this}.firstOrDefault(null, ss.getDefaultValue({TElement}))")]
		public TElement FirstOrDefault() { return default(TElement); }

		[InlineCode("{this}.firstOrDefault(null, {defaultValue})")]
		public TElement FirstOrDefault(TElement defaultValue) { return default(TElement); }

		[InlineCode("{this}.firstOrDefault({predicate}, ss.getDefaultValue({TElement}))")]
		public TElement FirstOrDefault(Func<TElement, bool> predicate) { return default(TElement); }

		[InlineCode("{this}.firstOrDefault({predicate}, {defaultValue})")]
		public TElement FirstOrDefault(Func<TElement, bool> predicate, TElement defaultValue) { return default(TElement); }


		public TElement Last() { return default(TElement); }

		public TElement Last(Func<TElement, bool> predicate) { return default(TElement); }


		[InlineCode("{this}.lastOrDefault(null, ss.getDefaultValue({TElement}))")]
		public TElement LastOrDefault() { return default(TElement); }

		[InlineCode("{this}.lastOrDefault(null, {defaultValue})")]
		public TElement LastOrDefault(TElement defaultValue) { return default(TElement); }

		[InlineCode("{this}.lastOrDefault({predicate}, ss.getDefaultValue({TElement}))")]
		public TElement LastOrDefault(Func<TElement, bool> predicate) { return default(TElement); }

		[InlineCode("{this}.lastOrDefault({predicate}, {defaultValue})")]
		public TElement LastOrDefault(Func<TElement, bool> predicate, TElement defaultValue) { return default(TElement); }


		public TElement Single() { return default(TElement); }

		public TElement Single(Func<TElement, bool> predicate) { return default(TElement); }


		[InlineCode("{this}.singleOrDefault(null, ss.getDefaultValue({TElement}))")]
		public TElement SingleOrDefault() { return default(TElement); }

		[InlineCode("{this}.singleOrDefault(null, {defaultValue})")]
		public TElement SingleOrDefault(TElement defaultValue) { return default(TElement); }

		[InlineCode("{this}.singleOrDefault({predicate}, ss.getDefaultValue({TElement}))")]
		public TElement SingleOrDefault(Func<TElement, bool> predicate) { return default(TElement); }

		[InlineCode("{this}.singleOrDefault({predicate}, {defaultValue})")]
		public TElement SingleOrDefault(Func<TElement, bool> predicate, TElement defaultValue) { return default(TElement); }


		public LinqJSEnumerable<TElement> Skip(int count) { return null; }


		public LinqJSEnumerable<TElement> SkipWhile(Func<TElement, bool> predicate) { return null; }

		public LinqJSEnumerable<TElement> SkipWhile(Func<TElement, int, bool> predicate) { return null; }


		public LinqJSEnumerable<TElement> Take(int count) { return null; }


		public LinqJSEnumerable<TElement> TakeWhile(Func<TElement, bool> predicate) { return null; }

		public LinqJSEnumerable<TElement> TakeWhile(Func<TElement, int, bool> predicate) { return null; }


		public LinqJSEnumerable<TElement> TakeExceptLast() { return null; }

		public LinqJSEnumerable<TElement> TakeExceptLast(int count) { return null; }


		public LinqJSEnumerable<TElement> TakeFromLast(int count) { return null; }


		public int IndexOf(TElement item) { return 0; }

		public int IndexOf(TElement item, Func<TElement, bool> predicate) { return 0; }

		public int IndexOf(TElement item, IEqualityComparer<TElement> comparer) { return 0; }


		public int LastIndexOf(TElement item) { return 0; }

		public int LastIndexOf(TElement item, Func<TElement, bool> predicate) { return 0; }

		public int LastIndexOf(TElement item, IEqualityComparer<TElement> comparer) { return 0; }

		#endregion

		#region Convert
		
		public TElement[] ToArray() { return null; }


		[ScriptName("toArray")]
		public List<TElement> ToList() { return null; }


		public Lookup<TKey, TElement> ToLookup<TKey>(Func<TElement, TKey> keySelector) { return null; }

		[InlineCode("{this}.toLookup({keySelector}, null, {comparer})")]
		public Lookup<TKey, TElement> ToLookup<TKey>(Func<TElement, TKey> keySelector, IEqualityComparer<TKey> comparer) { return null; }

		public Lookup<TKey, TElement> ToLookup<TKey, TElement>(Func<TElement, TKey> keySelector, Func<TElement, TElement> elementSelector) { return null; }

		public Lookup<TKey, TElement> ToLookup<TKey, TElement>(Func<TElement, TKey> keySelector, Func<TElement, TElement> elementSelector, IEqualityComparer<TKey> comparer) { return null; }


		public JsDictionary<TKey, TValue> ToObject<TKey, TValue>(Func<TElement, TKey> keySelector, Func<TElement, TValue> valueSelector) { return null; }


		[InlineCode("{this}.toDictionary({keySelector}, null, {TKey}, {TElement})")]
		public IDictionary<TKey, TElement> ToDictionary<TKey>(Func<TElement, TKey> keySelector) { return null; }

		[InlineCode("{this}.toDictionary({keySelector}, null, {TKey}, {TElement}, {comparer})")]
		public IDictionary<TKey, TElement> ToDictionary<TKey>(Func<TElement, TKey> keySelector, IEqualityComparer<TKey> comparer) { return null; }

		[InlineCode("{this}.toDictionary({keySelector}, {elementSelector}, {TKey}, {TValue})")]
		public IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(Func<TElement, TKey> keySelector, Func<TElement, TValue> elementSelector) { return null; }

		[InlineCode("{this}.toDictionary({keySelector}, {elementSelector}, {TKey}, {TValue}, {comparer})")]
		public IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(Func<TElement, TKey> keySelector, Func<TElement, TValue> elementSelector, IEqualityComparer<TKey> comparer) { return null; }


		public string ToJoinedString() { return null; }

		public string ToJoinedString(string separator) { return null; }

		public string ToJoinedString(string separator, Func<TElement, string> selector) { return null; }

		#endregion

		#region Action

		public LinqJSEnumerable<TElement> DoAction(Action<TElement> action) { return null; }

		public LinqJSEnumerable<TElement> DoAction(Action<TElement, int> action) { return null; }


		public void ForEach(Action<TElement> action) {}

		public void ForEach(Func<TElement, bool> action) {}

		public void ForEach(Action<TElement, int> action) {}

		public void ForEach(Func<TElement, int, bool> action) {}


		public void Force() {}

		#endregion

		#region Functional

		public LinqJSEnumerable<TResult> LetBind<TResult>(Func<IEnumerable<TElement>, IEnumerable<TResult>> func) { return null; }

		public LinqJSEnumerable<TElement> Share() { return null; }

		public LinqJSEnumerable<TElement> Memoize() { return null; }

		#endregion

		#region Error handling

		public LinqJSEnumerable<TElement> CatchError(Action<Exception> action) { return null; }

		public LinqJSEnumerable<TElement> FinallyAction(Action action) { return null; }

		#endregion

		#region For debug

		public LinqJSEnumerable<TElement> Trace() { return null; }

		public LinqJSEnumerable<TElement> Trace(string message) { return null; }

		public LinqJSEnumerable<TElement> Trace(string message, Func<TElement, string> selector) { return null; }

		#endregion
	}
}