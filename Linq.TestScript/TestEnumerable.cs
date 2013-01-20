using System;
using System.Collections;
using System.Collections.Generic;

namespace Linq.TestScript {
	public class TestEnumerable : IEnumerable<int> {
		private int _from, _count;
		public bool EnumeratorDisposed { get; set; }
		public int LastReturnedValue { get; set; }
		public int NumMoveNextCalls { get; set; }
		public int ThrowOnIndex { get; set; }

		public TestEnumerable(int from, int count) {
			_from  = from;
			_count = count;
			ThrowOnIndex = -1;
		}

		public IEnumerator<int> GetEnumerator() {
			return new TestEnumerator(this, _from, _count);
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return null;
		}
	}
}
