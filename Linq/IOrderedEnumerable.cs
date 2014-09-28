using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Linq {
	[Imported]
	public interface IOrderedEnumerable<out TElement> : IEnumerable<TElement> {
		[OmitUnspecifiedArgumentsFrom(1)]
		IOrderedEnumerable<TElement> ThenBy<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer = null);
		[OmitUnspecifiedArgumentsFrom(1)]
		IOrderedEnumerable<TElement> ThenByDescending<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey> comparer = null);
	}
}