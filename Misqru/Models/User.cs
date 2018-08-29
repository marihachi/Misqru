using Newtonsoft.Json.Linq;

namespace Misqru.Models
{
	public class User
	{
		public static User FromJObject(JObject data)
		{
			return data.ToObject<User>();
		}

		public string Id { get; set; }

		public string Username { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
	}
}
