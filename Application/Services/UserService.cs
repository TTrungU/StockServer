﻿using Application.Abtraction.IServices;
using Application.Models.User;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories; 
using Application.Exceptions;


namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task CreateUserAsync(CreateUserRequest user)
        {
            if(await _userRepository.IsEmailExist(user.Email))
                throw new EmailExistExceptions(user.Email);

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _userRepository.Create(_mapper.Map<User>(user));

            await _userRepository.SaveAsync();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserResponse>> GetAllUserAsync()
        {
            var user = await _userRepository.GetAllUserAsync();
            return _mapper.Map<IEnumerable<UserResponse>>(user);
        }

        public async Task<UserResponse> GetUserByIdsAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new UserNotFoundException(id);
            return _mapper.Map<UserResponse>(user);
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
