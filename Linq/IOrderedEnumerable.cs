using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Linq {
	[Imported]
	public interface IOrderedEnumerable<out TElement> : IEnumerable<TElement> {
		IOrderedEnumerable<TElement> ThenBy<TKey>(Func<TElement, TKey> keySelector);
		IOrderedEnumerable<TElement> ThenBy<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer);
		IOrderedEnumerable<TElement> ThenByDescending<TKey>(Func<TElement, TKey> keySelector);
		IOrderedEnumerable<TElement> ThenByDescending<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer);
	}
}