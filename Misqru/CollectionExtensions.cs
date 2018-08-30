using Misqru.Models;
using System.Collections.Generic;

namespace Misqru
{
	public static class CollectionExtensions
	{
		public static MisskeyInstance FindByHost(this List<MisskeyInstance> instances, string host)
		{
			return instances.Find(i => i.Host == host);
		}
	}
}
