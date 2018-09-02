using Misqru.Models;
using Misqru.Schemas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misqru
{
	public class ApiManager
	{
		public ApiManager(MisskeyAccount account = null)
		{
			this.Account = account;
		}

		public MisskeyAccount Account { get; set; }

		public async Task<UserSequence> GetFollowings(int limit = 100, string cursor = null)
		{
			if (this.Account == null)
				throw new InvalidOperationException();

			var param = new Dictionary<string, object>
			{
				["userId"] = this.Account.Id,
				["limit"] = limit
			};

			if (cursor != null)
				param.Add("cursor", cursor);

			var res = await this.Account.Request("users/following", param);

			return UserSequence.FromJObject(res);
		}

		public async Task<User> Follow(string userId)
		{
			if (this.Account == null)
				throw new InvalidOperationException();

			var param = new Dictionary<string, object>
			{
				["userId"] = userId
			};

			var res = await this.Account.Request("following/create", param);

			return User.FromJObject(res);
		}

		public async Task<User> Unfollow(string userId)
		{
			if (this.Account == null)
				throw new InvalidOperationException();

			var param = new Dictionary<string, object>
			{
				["userId"] = userId
			};

			var res = await this.Account.Request("following/delete", param);

			return User.FromJObject(res);
		}

		public async Task<User> CancelFollowRequest(string userId)
		{
			if (this.Account == null)
				throw new InvalidOperationException();

			var param = new Dictionary<string, object>
			{
				["userId"] = userId
			};

			var res = await this.Account.Request("following/requests/cancel", param);

			return User.FromJObject(res);
		}
	}
}
