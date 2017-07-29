using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;

namespace GigHub.App_Start
{
	public static class AutoMapperNotification
	{
		private static IMapper Mapper;

		public static IMapper GetMapper()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Genre, GenreDto>();
				cfg.CreateMap<Gig, GigDto>();
				cfg.CreateMap<ApplicationUser, UserDto>();
				cfg.CreateMap<Notification, NotificationDto>();
			});

			Mapper = config.CreateMapper();
			return Mapper;
		}
	}
}