using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
	public interface IGigRepository
	{
		Gig GetGig(int gigId);
		IEnumerable<Gig> GetGigsUserAttending(string userId);
		Gig GetGigWithAttendees(int gigId);
		IEnumerable<Gig> GetUpcomingGigsByArtist(string artistId);
		void Add(Gig gig);
		IEnumerable<Gig> GetUpcomingGigs(string searchTerm = null);
	}
}