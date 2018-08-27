using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misqru.Models
{
	public class MisskeyInstance
	{
		public MisskeyInstance(string host, string appSecret, string appId = null)
		{
			Set(host, appSecret, appId);
		}

		public void Set(string host, string appSecret, string appId = null)
		{
			this.Host = host;
			this.AppSecret = appSecret;
			this.AppId = appId;
		}

		public string Host { get; set; }
		public string AppSecret { get; set; }
		public string AppId { get; set; }

		[JsonIgnore]
		public string HostAndAppId { get => $"{this.AppId}@{this.Host}"; }

		public static async Task<MisskeyInstance> Register(string host, string appName, string appDescription, IEnumerable<string> appPermissions)
		{
			var param = new Dictionary<string, object>();
			param.Add("name", appName);
			param.Add("description", appDescription);
			param.Add("permission", appPermissions);

			var res = await Misq.Core.Request($"https://{host}", "app/create", param);

			return new MisskeyInstance(host, res.secret.Value, res.id.Value);
		}
	}
}
