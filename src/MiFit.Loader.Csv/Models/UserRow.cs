using MiFit.Model;

namespace MiFit.Loader.Csv.Models
{
	public class UserRow : IUser
	{
		[CsvColumn("userId")]
		public string UserId { get; set; }
		[CsvColumn("gender")]
		public string Gender { get; set; }
		[CsvColumn("height")]
		public string Height { get; set; }
		[CsvColumn("weight")]
		public string Weight { get; set; }
		[CsvColumn("nickName")]
		public string NickName { get; set; }
		[CsvColumn("avatar")]
		public string Avatar { get; set; }
		[CsvColumn("birthday")]
		public string Birthday { get; set; }
	}
}