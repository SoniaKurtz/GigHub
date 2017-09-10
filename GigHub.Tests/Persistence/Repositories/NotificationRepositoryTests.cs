using Microsoft.VisualStudio.TestTools.UnitTesting;
using GigHub.Core.Models;
using GigHub.Persistence.Repositories;
using System.Data.Entity;
using FluentAssertions;
using Moq;
using GigHub.Persistence;
using GigHub.Tests.Extensions;
using System.Linq;

namespace GigHub.Tests.Persistence.Repositories
{
	[TestClass]
	public class NotificationRepositoryTests
	{
		private NotificationRepository _repository;
		private Mock<DbSet<UserNotification>> _mockNotifications;
		private Mock<IApplicationDbContext> _mockContext;

		[TestInitialize]
		public void TestInitialize()
		{
			_mockNotifications = new Mock<DbSet<UserNotification>>();

			_mockContext = new Mock<IApplicationDbContext>();

			_mockContext.SetupGet(c => c.UserNotifications).Returns(_mockNotifications.Object);

			_repository = new NotificationRepository(_mockContext.Object);
		}


		[TestMethod]
		public void GetNewNotificationsFor_NotificationIsRead_ShouldNotBeReturned()
		{
			var notification = Notification.GigCanceled(new Gig());
			var user = new ApplicationUser { Id = "1" };
			var userNotification = new UserNotification(user, notification);
			userNotification.Read();

			_mockNotifications.SetSource(new[] { userNotification });

			var notifications = _repository.GetNewNotificationsFor(user.Id);

			notifications.Should().BeEmpty();
		}

		[TestMethod]
		public void GetNewNotificationsFor_NotificationIsForADifferentUser_ShouldNotBeReturned()
		{
			var notification = Notification.GigCanceled(new Gig());
			var user = new ApplicationUser { Id = "1" };
			var userNotification = new UserNotification(user, notification);

			_mockNotifications.SetSource(new[] { userNotification });

			var notifications = _repository.GetNewNotificationsFor(user.Id + "-");

			notifications.Should().BeEmpty();
		}

		[TestMethod]
		public void GetNewNotificationsFor_NewNotificationForTheGivenUser_ShouldBeReturned()
		{
			var notification = Notification.GigCanceled(new Gig());
			var user = new ApplicationUser { Id = "1" };
			var userNotification = new UserNotification(user, notification);

			_mockNotifications.SetSource(new[] { userNotification });

			_mockContext.SetupGet(c => c.UserNotifications).Returns(_mockNotifications.Object);

			var notifications = _repository.GetNewNotificationsFor(user.Id);

			notifications.Should().HaveCount(1);
			notifications.First().Should().Be(notification);
		}
	}
}

