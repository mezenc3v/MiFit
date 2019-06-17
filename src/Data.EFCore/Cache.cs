using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Data.EFCore
{
	internal class Cache<TKey, TValue> : ConcurrentDictionary<TKey, TValue>
	{
		internal Cache(IEnumerable<KeyValuePair<TKey, TValue>> collection) : base(collection)
		{
		}

		internal TValue AddOrUpdate(TKey id, TValue entity)
		{
			return AddOrUpdate(id, entity, UpdateCache);
		}

		internal TValue UpdateCache(TKey id, TValue entity)
		{
			if (!TryGetValue(id, out var old)) return default;
			return TryUpdate(id, entity, old) ? entity : default;
		}
	}
}