using Application.Abtraction.IServices;
using Application.Exceptions;
using Application.Models.Notification;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.IRepositories;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly IUserRepository _userRepository;

        public NotificationService(IMapper mapper, INotificationRepository notificationRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            _userRepository = userRepository;
        }

        public async Task CreateNotificationAsync(CreateNotificationRequest request)
        {
            if (await _userRepository.IsExist(u => u.Id == request.UserId))
                throw new UserNotFoundException(request.UserId);

            _notificationRepository.Create(_mapper.Map<Notification>(request));

            await _notificationRepository.SaveAsync();

        }

        public async Task DeleteNotificationAsync(int id)
        {
            var noti =await _notificationRepository.FindByCondition(n => n.Id == n.Id).FirstOrDefaultAsync();

            if (noti == null) 
            {
                throw new NotificationNotFoundExceptions(id);
            }

            _notificationRepository.Delete(noti);
            await _notificationRepository.SaveAsync();

        }

        public async Task<IEnumerable<NotificationResponse>> GetNotificationsAsync(int userId)
        {
            var noti = await _notificationRepository.GetNotificationsByUserIdAsync(userId);

           return _mapper.Map<IEnumerable<NotificationResponse>>(noti);
        }
    }
}
