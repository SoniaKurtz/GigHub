using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
	public interface IFollowRepository
	{
		Following GetFollowing(string followerId, string followeeId);
		void Add(Following following);
		void Remove(Following following);
	}
}