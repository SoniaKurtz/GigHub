using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Core.Models
{
	public class UserNotification
	{
		public string UserId { get; private set; }
		public int NotificationId { get; private set; }
		public ApplicationUser User { get; private set; }
		public Notification Notification { get; private set; }
		public bool IsRead { get; private set; }
		protected UserNotification() {}

		public UserNotification(ApplicationUser user, Notification notification)
		{
			Notification = notification ?? throw new ArgumentNullException("notification");
			User = user ?? throw new ArgumentNullException("user");
		}

		public void Read()
		{
			IsRead = true;
		}
	}
}