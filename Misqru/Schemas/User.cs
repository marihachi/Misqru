using Newtonsoft.Json.Linq;

namespace Misqru.Schemas
{
	public class User
	{
		public string Id { get; set; }

		public string Username { get; set; }

		public string Host { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public bool IsFollowing { get; set; }

		public bool IsFollowed { get; set; }

		public bool IsLocked { get; set; }

		public bool HasPendingFollowRequestFromYou { get; set; }

		public static User FromJObject(JObject data) => data.ToObject<User>();
	}
}
