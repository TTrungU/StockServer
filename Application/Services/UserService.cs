using Application.Abtraction.IServices;
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
        public async Task CreateUserAsync(CreateUserRequest request)
        {
            if(await _userRepository.IsEmailExist(request.Email))
                throw new EmailExistExceptions(request.Email);

            request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            _userRepository.Create(_mapper.Map<User>(request));

            await _userRepository.SaveAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user =  await _userRepository.GetByIdAsync(id);

            if (user == null)
                throw new UserNotFoundException(id);
            _userRepository.Delete(user);

            await _userRepository.SaveAsync();
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

        public async Task UpdateUserAsync(UpdateUserRequest request)
        {      
            if(!await _userRepository.IsExist(u => u.Id == request.Id))
                throw new UserNotFoundException(request.Id);     
            
            if(request.Email != null 
                && await _userRepository.IsExist(u => u.Id != request.Id && u.Email ==request.Email))
                throw new EmailExistExceptions(request.Email);

            _userRepository.Update(_mapper.Map<User>(request));

            await _userRepository.SaveAsync();
        }
    }
}
