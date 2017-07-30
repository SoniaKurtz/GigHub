using GigHub.Repositories;

namespace GigHub.Persistence
{
	public interface IUnitOfWork
	{
		IAttendanceRepository Attendances { get; }
		IFollowRepository Followings { get; }
		IGenreRepository Genres { get; }
		IGigRepository Gigs { get; }

		void Complete();
	}
}