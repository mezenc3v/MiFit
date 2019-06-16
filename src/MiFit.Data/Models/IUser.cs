namespace MiFit.Data.Models
{
	public interface IUser
	{
		string UserId { get; }
		string Gender { get; }
		string Height { get; }
		string Weight { get; }
		string NickName { get; }
		string Avatar { get; }
		string Birthday { get; }
	}
}