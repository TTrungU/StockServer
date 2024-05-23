using Application.Models.Notification;
using Application.Models.StockInforModel;
using Application.Models.Transaciton;
using Application.Models.User;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User,UserResponse>().ReverseMap();
            CreateMap<User,CreateUserRequest>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();
            CreateMap<Notification, NotificationResponse>().ReverseMap();
            CreateMap<Notification,CreateNotificationRequest>().ReverseMap();
            CreateMap<StockTransaction, CreateTransactionRequest>().ReverseMap();
            CreateMap<StockInforResponse, StockInfor>().ReverseMap();
            CreateMap<StockDataDto,StockData>().ReverseMap();
            
        }
    }
}
