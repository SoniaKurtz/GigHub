using GigHub.Models;

namespace GigHub.Repositories
{
	public interface IFollowRepository
	{
		Following GetFollowing(string followerId, string followeeId);
	}
}