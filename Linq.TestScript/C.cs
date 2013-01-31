using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QUnit;
using System.Text.RegularExpressions;

namespace Linq.TestScript {
	public class C {
		public string S { get; private set; }

		public C(string s) {
			S = s;
		}

		public override bool Equals(object o) {
			return S == ((C)o).S;
		}

		public override int GetHashCode() {
			return S.GetHashCode();
		}
	}

	public class FirstLetterComparer : IEqualityComparer<C> {
		bool IEqualityComparer.Equals(object x, object y) { throw new Exception(); }
		int IEqualityComparer.GetHashCode(object obj) { throw new Exception(); }

		public bool Equals(C x, C y) {
			return x.S[0] == y.S[0];
		}

		public int GetHashCode(C obj) {
			return obj.S[0].GetHashCode();
		}
	}
}
