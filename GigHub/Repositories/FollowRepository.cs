using GigHub.Models;
using System.Linq;

namespace GigHub.Repositories
{
	public class FollowRepository : IFollowRepository
	{
		private ApplicationDbContext _context;

		public FollowRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public Following GetFollowing(string followerId, string followeeId)
		{
			return _context.Followings
					.SingleOrDefault(f => f.FolloweeId == followeeId && f.FollowerId == followerId);
		}
	}
}