using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misqru.Models
{
	public class MisskeyAccount
	{
		public MisskeyAccount(string host, string token, string username, string id)
		{
			this.Host = host;
			this.Token = token;
			this.Username = username;
			this.Id = id;
		}

		public string Host { get; set; }


		public string Token { get; set; }

		public string Username { get; set; }

		public string Id { get; set; }

		public async Task<dynamic> Request(string endpoint, Dictionary<string, object> ps)
		{
			ps.Add("i", this.Token);
			return await Misq.Core.Request($"https://{this.Host}", endpoint, ps);
		}

		public static async Task<MisskeyAccount> Authorize(MisskeyInstance instance)
		{
			var app = new Misq.App($"https://{instance.Host}", instance.AppSecret);
			var user = await app.Authorize();

			return new MisskeyAccount(instance.Host, user.Token, user.Username, user.ID);
		}
	}
}
