using GigHub.Core.Repositories;

namespace GigHub.Core
{
	public interface IUnitOfWork
	{
		IAttendanceRepository Attendances { get; }
		IFollowRepository Followings { get; }
		IGenreRepository Genres { get; }
		IGigRepository Gigs { get; }
		IApplicationUserRepository Users { get; }
		INotificationsRepository Notifications { get; }
		IUserNotificationRepository UserNotifications { get; }

		void Complete();
	}
}