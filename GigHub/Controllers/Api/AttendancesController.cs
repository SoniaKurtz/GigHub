﻿using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
	[Authorize]
    public class AttendancesController : ApiController
    {
		private ApplicationDbContext _context;

		public AttendancesController()
		{
			_context = new ApplicationDbContext();
		}

		[HttpPost]
		public IHttpActionResult Attend(AttendanceDto dto)
		{
			var userId = User.Identity.GetUserId();

			if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
				return BadRequest("The attendance already exists.");

			var attadance = new Attendance
			{
				GigId = dto.GigId,
				AttendeeId = userId
			};

			_context.Attendances.Add(attadance);
			_context.SaveChanges();

			return Ok();
		}
    }
}