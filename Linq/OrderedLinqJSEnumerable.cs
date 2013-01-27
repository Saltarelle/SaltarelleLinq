using System.Runtime.CompilerServices;

namespace System.Linq {
	[Imported]
	public class OrderedLinqJSEnumerable<TSource> : LinqJSEnumerable<TSource> {
		internal OrderedLinqJSEnumerable() {}

		public OrderedLinqJSEnumerable<TSource> ThenBy<TKey>(Func<TSource, TKey> keySelector) { return null; }

		public OrderedLinqJSEnumerable<TSource> ThenByDescending<TKey>(Func<TSource, TKey> keySelector) { return null; }
	}
}