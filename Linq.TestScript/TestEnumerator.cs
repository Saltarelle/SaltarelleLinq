using System;
using System.Collections;
using System.Collections.Generic;

namespace Linq.TestScript {
	public class TestEnumerator : IEnumerator<int> {
		private int _from, _count, _current;
		private TestEnumerable _enumerable;

		public TestEnumerator(TestEnumerable enumerable, int from, int count) {
			_enumerable = enumerable;
			_from  = from;
			_count = count;
		}

		public int Current { get; private set; }
		object IEnumerator.Current { get { return Current; } }

		public bool MoveNext() {
			if (_current == _enumerable.ThrowOnIndex)
				throw new Exception("error");

			if (_current < _count) {
				Current = _from + _current++;
				_enumerable.LastReturnedValue = Current;
				_enumerable.NumMoveNextCalls++;
				return true;
			}
			else {
				return false;
			}
		}

		public void Reset() {
			_current = 0;
		}

		public void Dispose() {
			_enumerable.EnumeratorDisposed = true;
		}
	}
}
