using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misqru.Models
{
	public class MisskeyInstance
	{
		public MisskeyInstance(string host, string appSecret)
		{
			this.Host = host;
			this.AppSecret = appSecret;
		}

		public string Host { get; set; }

		public string AppSecret { get; set; }

		public static async Task<MisskeyInstance> Register(string host, string appName, string appDescription, IEnumerable<string> appPermissions)
		{
			var param = new Dictionary<string, object>();
			param.Add("name", appName);
			param.Add("description", appDescription);
			param.Add("permission", appPermissions);

			var res = await Misq.Core.Request($"https://{host}", "app/create", param);

			return new MisskeyInstance(host, res.secret.Value);
		}
	}
}
