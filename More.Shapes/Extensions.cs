using System.Collections.Generic;

namespace More.Shapes
{
	static class Extensions
	{
		public static void Add<T>(this ICollection<T> collection, T x, T y)
		{
			collection.Add(x);
			collection.Add(y);
		}

		public static void Add<T>(this ICollection<T> collection, T x, T y, T z)
		{
			collection.Add(x);
			collection.Add(y);
			collection.Add(z);
		}
	}
}
