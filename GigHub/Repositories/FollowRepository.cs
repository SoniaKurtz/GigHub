using GigHub.Models;
using System.Linq;

namespace GigHub.Repositories
{
	public class FollowRepository
	{
		private ApplicationDbContext _context;

		public FollowRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		internal object GetFollowing(string followerId, string followeeId)
		{
			return _context.Followings
					.SingleOrDefault(f => f.FolloweeId == followeeId && f.FollowerId == followerId);
		}
	}
}