using GigHub.App_Start;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebGrease.Css.Extensions;

namespace GigHub.Controllers.Api
{
	[Authorize]
	public class NotificationsController : ApiController
	{
		private IUnitOfWork _unitOfWork;

		public NotificationsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IEnumerable<NotificationDto> GetNewNotifications()
		{
			var userId = User.Identity.GetUserId();
			var notifications = _unitOfWork.Notifications.GetNewNotificationsFor(userId);

			var mapper = AutoMapperNotification.GetMapper();

			return notifications.Select(mapper.Map<Notification, NotificationDto>);
		}

		[HttpPost]
		public IHttpActionResult MarkAsRead()
		{
			var userId = User.Identity.GetUserId();
			var notification = _unitOfWork.UserNotifications.GetUserNotificationsFor(userId);

			notification.ForEach(n => n.Read());

			_unitOfWork.Complete();

			return Ok();
		}
    }
}
