using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Misqru.Schemas
{
	public class UserSequence
	{
		public List<User> Users { get; set; }

		[JsonProperty("next")]
		public string NextCursor { get; set; }

		public static UserSequence FromJObject(JObject data) => data.ToObject<UserSequence>();
	}
}
