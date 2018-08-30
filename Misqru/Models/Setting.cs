using Misqru.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misqru.Models
{
	public static class Meta
	{
		public const int SettingLatestVersion = 2;
	}

	public class Setting : JsonSerializable
	{
		public int _Version { get; set; } = Meta.SettingLatestVersion;

		public List<MisskeyInstance> Instances { get; set; } = new List<MisskeyInstance>();

		public List<MisskeyAccount> Accounts { get; set; } = new List<MisskeyAccount>();

		#region JsonSerializable

		/// <summary>
		/// setting.json から設定を読み込みます
		/// <para>setting.json が存在しないときは新規に生成します</para>
		/// </summary>
		public static async Task<Setting> LoadAsync()
		{
			var setting = await LoadAsync<Setting>("setting.json");

			return setting;
		}

		/// <summary>
		/// setting.json に設定を保存します
		/// </summary>
		public Task SaveAsync()
		{
			return SaveAsync("setting.json");
		}

		#endregion JsonSerializable
	}
}
