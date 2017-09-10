using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Persistence;
using System.Linq;

namespace GigHub.Persistence.Repositories
{
	public class FollowRepository : IFollowRepository
	{
		private IApplicationDbContext _context;

		public FollowRepository(IApplicationDbContext context)
		{
			_context = context;
		}

		public void Add(Following following)
		{
			_context.Followings.Add(following);
		}

		public Following GetFollowing(string followerId, string followeeId)
		{
			return _context.Followings
					.SingleOrDefault(f => f.FolloweeId == followeeId && f.FollowerId == followerId);
		}

		public void Remove(Following following)
		{
			_context.Followings.Remove(following);
		}
	}
}