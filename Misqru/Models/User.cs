namespace Misqru.Models
{
	public class User
	{
		public User() { }

		public User(string id, string username, string name, string description)
		{
			Set(id, username, name, description);
		}

		public void Set(string id, string username, string name, string description)
		{
			this.Id = id;
			this.Username = username;
			this.Name = name;
			this.Description = description;
		}

		public string Id { get; set; }

		public string Username { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
	}
}
