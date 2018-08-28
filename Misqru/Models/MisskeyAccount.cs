using System.Threading.Tasks;

namespace Misqru.Models
{
	public class MisskeyAccount
	{
		public MisskeyAccount(string hostAndAppId, string userToken, string username, string id)
		{
			Set(hostAndAppId, userToken, username, id);
		}

		public void Set(string hostAndAppId, string userToken, string username, string id)
		{
			this.HostAndAppId = hostAndAppId;
			this.UserToken = userToken;
			this.Username = username;
			this.Id = id;
		}

		public string HostAndAppId { get; set; }
		public string UserToken { get; set; }
		public string Username { get; set; }
		public string Id { get; set; }

		public MisskeyInstance FindInstance(Setting setting)
		{
			return setting.Instances.Find(i => i.HostAndAppId == this.HostAndAppId);
		}

		public static async Task<MisskeyAccount> Authorize(MisskeyInstance instance)
		{
			var app = new Misq.App($"https://{instance.Host}", instance.AppSecret);
			var user = await app.Authorize();

			return new MisskeyAccount(instance.HostAndAppId, user.UserToken, user.Username, user.ID);
		}
	}
}
