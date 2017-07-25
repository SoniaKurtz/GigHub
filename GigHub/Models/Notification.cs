using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
	public class Notification
	{
		public int Id { get; private set; }
		public DateTime DateTime { get; private set; }
		public NotificationType Type { get; private set; }
		public DateTime? OriginalDateTime { get; set; }
		public string OriginalVaneu { get; set; }

		[Required]
		public Gig Gig { get; private set; }

		protected Notification() {}

		public Notification(NotificationType type, Gig gig)
		{
			Type = type;
			Gig = gig ?? throw new ArgumentNullException("gig");
			DateTime = DateTime.Now;
		}
	}
}