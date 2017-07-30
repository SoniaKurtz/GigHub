using System.Collections.Generic;
using System.Linq;
using GigHub.Core.Repositories;
using GigHub.Core.Models;

namespace GigHub.Persistence.Repositories
{
	public class UserNotificationRepository : IUserNotificationRepository
	{
		private readonly ApplicationDbContext _context;

		public UserNotificationRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<UserNotification> GetUserNotificationsFor(string userId)
		{
			return _context.UserNotifications
				.Where(un => un.UserId == userId && !un.IsRead)
				.ToList();
		}
	}
}