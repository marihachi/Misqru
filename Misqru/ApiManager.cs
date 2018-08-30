using Misqru.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misqru
{
	public class ApiManager
	{
		public ApiManager(MisskeyAccount account)
		{
			this.Account = account;
		}

		public MisskeyAccount Account { get; set; }

		public async Task<User> Follow(string userId)
		{
			var obj = (JObject)await this.Account.Request("following/create", new Dictionary<string, object>
			{
				["userId"] = userId
			});
			return User.FromJObject(obj);
		}

		public async Task<User> Unfollow(string userId)
		{
			var obj = (JObject)await this.Account.Request("following/delete", new Dictionary<string, object>
			{
				["userId"] = userId
			});
			return User.FromJObject(obj);
		}

		public async Task<User> CancelFollowRequest(string userId)
		{
			var obj = (JObject)await this.Account.Request("following/requests/cancel", new Dictionary<string, object>
			{
				["userId"] = userId
			});
			return User.FromJObject(obj);
		}
	}
}
