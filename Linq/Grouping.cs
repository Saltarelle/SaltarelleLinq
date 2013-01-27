using System.Runtime.CompilerServices;

namespace System.Linq {
	[Imported]
	public class Grouping<TKey, TElement> : LinqJSEnumerable<TElement>, IGrouping<TKey, TElement> {
		internal Grouping() {}

		public TKey Key { get { return default(TKey); } }
	}
}