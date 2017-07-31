using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Persistance.Repositories
{
	public class GenreRepository : IGenreRepository
	{
		private IApplicationDbContext _context;

		public GenreRepository(IApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Genre> GetGenres()
		{
			return _context.Genres.ToList();
		}
	}
}