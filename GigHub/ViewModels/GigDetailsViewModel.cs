﻿using GigHub.Models;

namespace GigHub.ViewModels
{
	public class GigDetailsViewModel
	{
		public Gig Gig { get;  set; }
		public bool IsAttenting { get; internal set; }
		public bool IsFollowing { get; internal set; }
	}
}