using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public class Bob
{
	public bool Method(string source) => source.Length > 0;
	public bool Method(int[] source) => source.Length > 0;
	public bool Method(IReadOnlyList<int> source) => source.Count > 0;
	public bool Method(IReadOnlyCollection<int> source) => source.Count > 0;
	public bool Method(IList<int> source) => source.Count > 0;
	public bool Method(ICollection<int> source) => source.Count > 0;
	public bool Method(IEnumerable<int> source) => source.Any();

	public bool MethodA(int[] source) => source.Length > 0;
	public Expression<Func<int[], bool>> Query = source => source.Length > 0;

	public bool Method(ConcurrentQueue<int> source) => !source.IsEmpty;
	public bool Method(ConcurrentStack<int> source) => !source.IsEmpty;
	public bool Method(ConcurrentDictionary<int, int> source) => !source.IsEmpty;

	public bool? Method1(int[] source) => source?.Any(); // don't suggest as it will change the behavour.
	public bool Method2(ExplicitCollection<int> source) => source.Any(); // don't suggest if using the property would require casting.
	public bool Method3(UnknownCollection source) => source.Any(); // don't suggest if we don't recognise the type.
	public bool Method4(int[] source) => source.Any(x => x > 0); // don't suggest if a filter is provided.
}

public struct ExplicitCollection<T> : IReadOnlyCollection<T>
{
	public IEnumerator<T> GetEnumerator()
	{
		yield break;
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	int IReadOnlyCollection<T>.Count => 0;
}
