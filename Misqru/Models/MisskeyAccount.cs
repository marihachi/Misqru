using System.Threading.Tasks;

namespace Misqru.Models
{
	public class MisskeyAccount
	{
		public MisskeyAccount(string hostAndAppId, string userToken, string username)
		{
			Set(hostAndAppId, userToken, username);
		}

		public void Set(string hostAndAppId, string userToken, string username)
		{
			this.HostAndAppId = hostAndAppId;
			this.UserToken = userToken;
			this.Username = username;
		}

		public string HostAndAppId { get; set; }
		public string UserToken { get; set; }
		public string Username { get; set; }

		public static async Task<MisskeyAccount> Authorize(MisskeyInstance instance)
		{
			var app = new Misq.App($"https://{instance.Host}", instance.AppSecret);
			var user = await app.Authorize();

			return new MisskeyAccount(instance.HostAndAppId, user.UserToken, user.Username);
		}
	}
}
