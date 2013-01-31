using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Linq {
	[Imported]
	public class LinqJSEnumerable<TSource> : IEnumerable<TSource> {
		internal LinqJSEnumerable() {}

		public IEnumerator<TSource> GetEnumerator() { return null; }

		IEnumerator IEnumerable.GetEnumerator() { return null; }

		#region Projection / filtering

		public LinqJSEnumerable<TSource> CascadeBreadthFirst(Func<TSource, IEnumerable<TSource>> func) { return null; }

		public LinqJSEnumerable<TResult> CascadeBreadthFirst<TResult>(Func<TSource, IEnumerable<TSource>> func, Func<TSource, TResult> resultSelector) { return null; }

		public LinqJSEnumerable<TResult> CascadeBreadthFirst<TResult>(Func<TSource, IEnumerable<TSource>> func, Func<TSource, int, TResult> resultSelector) { return null; }


		public LinqJSEnumerable<TSource> CascadeDepthFirst(Func<TSource, IEnumerable<TSource>> func) { return null; }

		public LinqJSEnumerable<TResult> CascadeDepthFirst<TResult>(Func<TSource, IEnumerable<TSource>> func, Func<TSource, TResult> resultSelector) { return null; }

		public LinqJSEnumerable<TResult> CascadeDepthFirst<TResult>(Func<TSource, IEnumerable<TSource>> func, Func<TSource, int, TResult> resultSelector) { return null; }


		public LinqJSEnumerable<object> Flatten() { return null; }


		public LinqJSEnumerable<TResult> Pairwise<TResult>(Func<TSource, TSource, TResult> selector) { return null; }


		public static LinqJSEnumerable<T> Scan<T>(Func<T, T, T> func) { return null; }

		public LinqJSEnumerable<TAccumulate> Scan<TAccumulate>(TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) { return null; }


		public LinqJSEnumerable<TResult> Select<TResult>(Func<TSource, TResult> selector) { return null; }

		public LinqJSEnumerable<TResult> Select<TResult>(Func<TSource, int, TResult> selector) { return null; }


		public LinqJSEnumerable<TResult> SelectMany<TResult>(Func<TSource, IEnumerable<TResult>> selector) { return null; }

		public LinqJSEnumerable<TResult> SelectMany<TResult>(Func<TSource, int, IEnumerable<TResult>> selector) { return null; }

		public LinqJSEnumerable<TResult> SelectMany<TCollection, TResult>(Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) { return null; }

		public LinqJSEnumerable<TResult> SelectMany<TCollection, TResult>(Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) { return null; }


		[InlineCode("{this}.select(function(x) {{ return {$System.Script}.cast(x, {TResult}); }})")]
		public LinqJSEnumerable<TResult> Cast<TResult>() { return null; }


		[InlineCode("{this}.ofType({TResult})")]
		public LinqJSEnumerable<TResult> OfType<TResult>() { return null; }


		public LinqJSEnumerable<TResult> Zip<TOther, TResult>(IEnumerable<TOther> other, Func<TSource, TOther, TResult> selector) { return null; }

		public LinqJSEnumerable<TResult> Zip<TOther, TResult>(IEnumerable<TOther> other, Func<TSource, TOther, int, TResult> selector) { return null; }


		public LinqJSEnumerable<TSource> Where(Func<TSource, bool> predicate) { return null; }

		public LinqJSEnumerable<TSource> Where(Func<TSource, int, bool> predicate) { return null; }

		#endregion

		#region Join

		public LinqJSEnumerable<TResult> Join<TInner, TKey, TResult>(IEnumerable<TInner> inner, Func<TSource, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TSource, TInner, TResult> resultSelector) { return null; }

		public LinqJSEnumerable<TResult> Join<TInner, TKey, TResult>(IEnumerable<TInner> inner, Func<TSource, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TSource, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer) { return null; }


		public LinqJSEnumerable<TResult> GroupJoin<TInner, TKey, TResult>(IEnumerable<TInner> inner, Func<TSource, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TSource, IEnumerable<TInner>, TResult> resultSelector) { return null; }

		public LinqJSEnumerable<TResult> GroupJoin<TInner, TKey, TResult>(IEnumerable<TInner> inner, Func<TSource, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TSource, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer) { return null; }

		#endregion

		#region Set methods

		public bool All(Func<TSource, bool> predicate) { return false; }


		public bool Any() { return false; }

		public bool Any(Func<TSource, bool> predicate) { return false; }


		public LinqJSEnumerable<TSource> Concat(IEnumerable<TSource> other) { return null; }


		public LinqJSEnumerable<TSource> Insert(int index, IEnumerable<TSource> other) { return null; }


		public LinqJSEnumerable<TSource> Alternate(TSource value) { return null; }


		public bool Contains(TSource value) { return false; }

		public bool Contains(TSource value, IEqualityComparer<TSource> comparer) { return false; }

		[InlineCode("{this}.defaultIfEmpty(ss.getDefaultValue({TSource}))")]
		public LinqJSEnumerable<TSource> DefaultIfEmpty() { return null; }

		public LinqJSEnumerable<TSource> DefaultIfEmpty(TSource defaultValue) { return null; }


		public LinqJSEnumerable<TSource> Distinct() { return null; }

		public LinqJSEnumerable<TSource> Distinct(IEqualityComparer<TSource> comparer) { return null; }


		public LinqJSEnumerable<TSource> Except(IEnumerable<TSource> other) { return null; }

		public LinqJSEnumerable<TSource> Except(IEnumerable<TSource> other, IEqualityComparer<TSource> comparer) { return null; }


		public bool SequenceEqual(IEnumerable<TSource> other) { return false; }

		public bool SequenceEqual<TKey>(IEnumerable<TSource> other, Func<TSource, TKey> compareSelector) { return false; }


		public LinqJSEnumerable<TSource> Union(IEnumerable<TSource> other) { return null; }

		public LinqJSEnumerable<TSource> Union(IEnumerable<TSource> other, IEqualityComparer<TSource> comparer) { return null; }

		#endregion

		#region Ordering

		public OrderedLinqJSEnumerable<TSource> OrderBy() { return null; }

		public OrderedLinqJSEnumerable<TSource> OrderBy<TKey>(Func<TSource, TKey> keySelector) { return null; }

		public OrderedLinqJSEnumerable<TSource> OrderByDescending() { return null; }

		public OrderedLinqJSEnumerable<TSource> OrderByDescending<TKey>(Func<TSource, TKey> keySelector) { return null; }

		public LinqJSEnumerable<TSource> Reverse() { return null; }

		public LinqJSEnumerable<TSource> Shuffle() { return null; }

		#endregion

		#region Grouping

		public LinqJSEnumerable<Grouping<TKey, TSource>> GroupBy<TKey>(Func<TSource, TKey> keySelector) { return null; }

		[InlineCode("{this}.groupBy({keySelector}, null, null, {comparer})")]
		public LinqJSEnumerable<Grouping<TKey, TSource>> GroupBy<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) { return null; }

		public LinqJSEnumerable<Grouping<TKey, TElement>> GroupBy<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) { return null; }

		[InlineCode("{this}.groupBy({keySelector}, null, {resultSelector})")]
		public LinqJSEnumerable<TResult> GroupBy<TKey, TResult>(Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector) { return null; }

		[InlineCode("{this}.groupBy({keySelector}, {elementSelector}, null, {comparer})")]
		public LinqJSEnumerable<Grouping<TKey, TElement>> GroupBy<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) { return null; }

		public LinqJSEnumerable<TResult> GroupBy<TKey, TElement, TResult>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector) { return null; }

		[InlineCode("{this}.groupBy({keySelector}, null, {resultSelector}, {comparer})")]
		public LinqJSEnumerable<TResult> GroupBy<TKey, TResult>(Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer) { return null; }

		public LinqJSEnumerable<TResult> GroupBy<TKey, TElement, TResult>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comperer) { return null; }


		public LinqJSEnumerable<Grouping<TKey, TSource>> PartitionBy<TKey>(Func<TSource, TKey> keySelector) { return null; }

		[InlineCode("{this}.partitionBy({keySelector}, null, null, {comparer})")]
		public LinqJSEnumerable<Grouping<TKey, TSource>> PartitionBy<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) { return null; }

		public LinqJSEnumerable<Grouping<TKey, TElement>> PartitionBy<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) { return null; }

		[InlineCode("{this}.partitionBy({keySelector}, null, {resultSelector})")]
		public LinqJSEnumerable<TResult> PartitionBy<TKey, TResult>(Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector) { return null; }

		[InlineCode("{this}.partitionBy({keySelector}, {elementSelector}, null, {comparer})")]
		public LinqJSEnumerable<Grouping<TKey, TElement>> PartitionBy<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) { return null; }

		public LinqJSEnumerable<TResult> PartitionBy<TKey, TElement, TResult>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector) { return null; }

		[InlineCode("{this}.partitionBy({keySelector}, null, {resultSelector}, {comparer})")]
		public LinqJSEnumerable<TResult> PartitionBy<TKey, TResult>(Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer) { return null; }

		public LinqJSEnumerable<TResult> PartitionBy<TKey, TElement, TResult>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comperer) { return null; }


		public LinqJSEnumerable<TSource[]> Buffer(int count) { return null; }

		#endregion

		#region Aggregate

		public TSource Aggregate(Func<TSource, TSource, TSource> func) { return default(TSource); }

		public TAccumulate Aggregate<TAccumulate>(TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) { return default(TAccumulate); }

		public TResult Aggregate<TAccumulate, TResult>(TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector) { return default(TResult); }


		public double Average(Func<TSource, int> selector) { return 0; }

		public double Average(Func<TSource, long> selector) { return 0; }

		public float Average(Func<TSource, float> selector) { return 0; }

		public double Average(Func<TSource, double> selector) { return 0; }

		public decimal Average(Func<TSource, decimal> selector) { return 0; }


		public int Count() { return 0; }

		public int Count(Func<TSource, bool> predicate) { return 0; }


		public int Max(Func<TSource, int> selector) { return 0; }

		public long Max(Func<TSource, long> selector) { return 0; }

		public float Max(Func<TSource, float> selector) { return 0; }

		public double Max(Func<TSource, double> selector) { return 0; }

		public decimal Max(Func<TSource, decimal> selector) { return 0; }


		public int Min(Func<TSource, int> selector) { return 0; }

		public long Min(Func<TSource, long> selector) { return 0; }

		public float Min(Func<TSource, float> selector) { return 0; }

		public double Min(Func<TSource, double> selector) { return 0; }

		public decimal Min(Func<TSource, decimal> selector) { return 0; }


		public TSource MaxBy(Func<TSource, int> selector) { return default(TSource); }

		public TSource MaxBy(Func<TSource, long> selector) { return default(TSource); }

		public TSource MaxBy(Func<TSource, float> selector) { return default(TSource); }

		public TSource MaxBy(Func<TSource, double> selector) { return default(TSource); }

		public TSource MaxBy(Func<TSource, decimal> selector) { return default(TSource); }


		public TSource MinBy(Func<TSource, int> selector) { return default(TSource); }

		public TSource MinBy(Func<TSource, long> selector) { return default(TSource); }

		public TSource MinBy(Func<TSource, float> selector) { return default(TSource); }

		public TSource MinBy(Func<TSource, double> selector) { return default(TSource); }

		public TSource MinBy(Func<TSource, decimal> selector) { return default(TSource); }


		public int Sum(Func<TSource, int> selector) { return 0; }

		public long Sum(Func<TSource, long> selector) { return 0; }

		public float Sum(Func<TSource, float> selector) { return 0; }

		public double Sum(Func<TSource, double> selector) { return 0; }

		public decimal Sum(Func<TSource, decimal> selector) { return 0; }

		#endregion

		#region Paging

		public TSource ElementAt(int index) { return default(TSource); }


		[InlineCode("{this}.elementAtOrDefault({index}, ss.getDefaultValue({TSource}))")]
		public TSource ElementAtOrDefault(int index) { return default(TSource); }


		public TSource ElementAtOrDefault(int index, TSource defaultValue) { return default(TSource); }


		public TSource First() { return default(TSource); }

		public TSource First(Func<TSource, bool> predicate) { return default(TSource); }


		[InlineCode("{this}.firstOrDefault(null, ss.getDefaultValue({TSource}))")]
		public TSource FirstOrDefault() { return default(TSource); }

		[InlineCode("{this}.firstOrDefault(null, {defaultValue})")]
		public TSource FirstOrDefault(TSource defaultValue) { return default(TSource); }

		[InlineCode("{this}.firstOrDefault({predicate}, ss.getDefaultValue({TSource}))")]
		public TSource FirstOrDefault(Func<TSource, bool> predicate) { return default(TSource); }

		[InlineCode("{this}.firstOrDefault({predicate}, {defaultValue})")]
		public TSource FirstOrDefault(Func<TSource, bool> predicate, TSource defaultValue) { return default(TSource); }


		public TSource Last() { return default(TSource); }

		public TSource Last(Func<TSource, bool> predicate) { return default(TSource); }


		[InlineCode("{this}.lastOrDefault(null, ss.getDefaultValue({TSource}))")]
		public TSource LastOrDefault() { return default(TSource); }

		[InlineCode("{this}.lastOrDefault(null, {defaultValue})")]
		public TSource LastOrDefault(TSource defaultValue) { return default(TSource); }

		[InlineCode("{this}.lastOrDefault({predicate}, ss.getDefaultValue({TSource}))")]
		public TSource LastOrDefault(Func<TSource, bool> predicate) { return default(TSource); }

		[InlineCode("{this}.lastOrDefault({predicate}, {defaultValue})")]
		public TSource LastOrDefault(Func<TSource, bool> predicate, TSource defaultValue) { return default(TSource); }


		public TSource Single() { return default(TSource); }

		public TSource Single(Func<TSource, bool> predicate) { return default(TSource); }


		[InlineCode("{this}.singleOrDefault(null, ss.getDefaultValue({TSource}))")]
		public TSource SingleOrDefault() { return default(TSource); }

		[InlineCode("{this}.singleOrDefault(null, {defaultValue})")]
		public TSource SingleOrDefault(TSource defaultValue) { return default(TSource); }

		[InlineCode("{this}.singleOrDefault({predicate}, ss.getDefaultValue({TSource}))")]
		public TSource SingleOrDefault(Func<TSource, bool> predicate) { return default(TSource); }

		[InlineCode("{this}.singleOrDefault({predicate}, {defaultValue})")]
		public TSource SingleOrDefault(Func<TSource, bool> predicate, TSource defaultValue) { return default(TSource); }


		public LinqJSEnumerable<TSource> Skip(int count) { return null; }


		public LinqJSEnumerable<TSource> SkipWhile(Func<TSource, bool> predicate) { return null; }

		public LinqJSEnumerable<TSource> SkipWhile(Func<TSource, int, bool> predicate) { return null; }


		public LinqJSEnumerable<TSource> Take(int count) { return null; }


		public LinqJSEnumerable<TSource> TakeWhile(Func<TSource, bool> predicate) { return null; }

		public LinqJSEnumerable<TSource> TakeWhile(Func<TSource, int, bool> predicate) { return null; }


		public LinqJSEnumerable<TSource> TakeExceptLast() { return null; }

		public LinqJSEnumerable<TSource> TakeExceptLast(int count) { return null; }


		public LinqJSEnumerable<TSource> TakeFromLast(int count) { return null; }


		public int IndexOf(TSource item) { return 0; }

		public int IndexOf(TSource item, Func<TSource, bool> predicate) { return 0; }

		public int IndexOf(TSource item, IEqualityComparer<TSource> comparer) { return 0; }


		public int LastIndexOf(TSource item) { return 0; }

		public int LastIndexOf(TSource item, Func<TSource, bool> predicate) { return 0; }

		public int LastIndexOf(TSource item, IEqualityComparer<TSource> comparer) { return 0; }

		#endregion

		#region Convert
		
		public TSource[] ToArray() { return null; }


		[ScriptName("toArray")]
		public List<TSource> ToList() { return null; }


		public Lookup<TKey, TSource> ToLookup<TKey>(Func<TSource, TKey> keySelector) { return null; }

		[InlineCode("{this}.toLookup({keySelector}, null, {comparer})")]
		public Lookup<TKey, TSource> ToLookup<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) { return null; }

		public Lookup<TKey, TElement> ToLookup<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) { return null; }

		public Lookup<TKey, TElement> ToLookup<TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) { return null; }


		public JsDictionary<TKey, TValue> ToObject<TKey, TValue>(Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector) { return null; }


		[InlineCode("{this}.toDictionary({keySelector}, null, {TKey}, {TSource})")]
		public IDictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector) { return null; }

		[InlineCode("{this}.toDictionary({keySelector}, null, {TKey}, {TSource}, {comparer})")]
		public IDictionary<TKey, TSource> ToDictionary<TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) { return null; }

		[InlineCode("{this}.toDictionary({keySelector}, {elementSelector}, {TKey}, {TValue})")]
		public IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector) { return null; }

		[InlineCode("{this}.toDictionary({keySelector}, {elementSelector}, {TKey}, {TValue}, {comparer})")]
		public IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector, IEqualityComparer<TKey> comparer) { return null; }


		public string ToJoinedString() { return null; }

		public string ToJoinedString(string separator) { return null; }

		public string ToJoinedString(string separator, Func<TSource, string> selector) { return null; }

		#endregion

		#region Action

		public LinqJSEnumerable<TSource> DoAction(Action<TSource> action) { return null; }

		public LinqJSEnumerable<TSource> DoAction(Action<TSource, int> action) { return null; }


		public void ForEach(Action<TSource> action) {}

		public void ForEach(Func<TSource, bool> action) {}

		public void ForEach(Action<TSource, int> action) {}

		public void ForEach(Func<TSource, int, bool> action) {}


		public void Force() {}

		#endregion

		#region Functional

		public LinqJSEnumerable<TResult> LetBind<TResult>(Func<IEnumerable<TSource>, IEnumerable<TResult>> func) { return null; }

		public LinqJSEnumerable<TSource> Share() { return null; }

		public LinqJSEnumerable<TSource> Memoize() { return null; }

		#endregion

		#region Error handling

		public LinqJSEnumerable<TSource> CatchError(Action<Exception> action) { return null; }

		public LinqJSEnumerable<TSource> FinallyAction(Action action) { return null; }

		#endregion

		#region For debug

		public LinqJSEnumerable<TSource> Trace() { return null; }

		public LinqJSEnumerable<TSource> Trace(string message) { return null; }

		public LinqJSEnumerable<TSource> Trace(string message, Func<TSource, string> selector) { return null; }

		#endregion
	}
}