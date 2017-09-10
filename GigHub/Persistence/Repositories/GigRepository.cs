﻿using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Persistence;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace GigHub.Persistence.Repositories
{
	public class GigRepository : IGigRepository
	{
		private IApplicationDbContext _context;

		public GigRepository(IApplicationDbContext context)
		{
			_context = context;
		}

		public Gig GetGigWithAttendees(int gigId)
		{
			return _context.Gigs
				.Include(g => g.Attendances.Select(a => a.Attendee))
				.SingleOrDefault(g => g.Id == gigId);
		}

		public IEnumerable<Gig> GetGigsUserAttending(string userId)
		{
			return _context.Attendances
								.Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
								.Select(a => a.Gig)
								.Include(g => g.Artist)
								.Include(g => g.Genre)
								.ToList();
		}

		public Gig GetGig(int gigId)
		{
			return _context.Gigs
				.Include(g => g.Artist)
				.Include(g => g.Genre)
				.SingleOrDefault(g => g.Id == gigId);
		}

		public IEnumerable<Gig> GetUpcomingGigsByArtist(string artistId)
		{
			return _context.Gigs
							.Where(g =>
								g.ArtistId == artistId &&
								g.DateTime > DateTime.Now &&
								!g.IsCanceled)
							.Include(g => g.Genre)
							.ToList();
		}

		public void Add(Gig gig)
		{
			_context.Gigs.Add(gig);
		}

		public IEnumerable<Gig> GetUpcomingGigs(string searchTerm = null)
		{
			var upComingGigs = _context.Gigs
				.Include(g => g.Artist)
				.Include(g => g.Genre)
				.Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);

			if(!String.IsNullOrWhiteSpace(searchTerm))
			{
				upComingGigs = upComingGigs
					.Where(g => g.Artist.Name.Contains(searchTerm) ||
								g.Genre.Name.Contains(searchTerm) ||
								g.Venue.Contains(searchTerm));
			}

			return upComingGigs.ToList();
		}
	}
}