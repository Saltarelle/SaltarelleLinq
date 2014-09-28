using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Linq {
	[Imported]
	public class OrderedLinqJSEnumerable<TElement> : LinqJSEnumerable<TElement>, IOrderedEnumerable<TElement> {
		internal OrderedLinqJSEnumerable() {}

		IOrderedEnumerable<TElement> IOrderedEnumerable<TElement>.ThenBy<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer) { return null; }
		IOrderedEnumerable<TElement> IOrderedEnumerable<TElement>.ThenByDescending<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer) { return null; }

		public OrderedLinqJSEnumerable<TElement> ThenBy<TKey>(Func<TElement, TKey> keySelector) { return null; }
		public OrderedLinqJSEnumerable<TElement> ThenBy<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer) { return null; }
		public OrderedLinqJSEnumerable<TElement> ThenByDescending<TKey>(Func<TElement, TKey> keySelector) { return null; }
		public OrderedLinqJSEnumerable<TElement> ThenByDescending<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer) { return null; }
	}
}