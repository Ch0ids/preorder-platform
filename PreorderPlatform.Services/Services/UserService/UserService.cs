using AutoMapper;
using PreorderPlatform.Entity.Entities;
using PreorderPlatform.Entity.Repositories.UserRepository;
using PreorderPlatform.Services.Exceptions;
using PreorderPlatform.Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreorderPlatform.Services.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserViewModel>> GetUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return _mapper.Map<List<UserViewModel>>(users);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while fetching users.", ex);
            }
        }

        public async Task<UserViewModel> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);

                if (user == null)
                {
                    throw new NotFoundException($"User with ID {id} was not found.");
                }

                return _mapper.Map<UserViewModel>(user);
            }
            catch (NotFoundException)
            {
                // Rethrow NotFoundException to be handled by the caller
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while fetching user with ID {id}.", ex);
            }
        }

        public async Task CreateUserAsync(UserCreateViewModel model)
        {
            try
            {
                var user = _mapper.Map<User>(model);
                await _userRepository.CreateAsync(user);
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occurred while creating the user.", ex);
            }
        }

        public async Task UpdateUserAsync(UserUpdateViewModel model)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(model.Id);
                user = _mapper.Map(model, user);
                await _userRepository.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while updating user with ID {model.Id}.", ex);
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                await _userRepository.DeleteAsync(user);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while deleting user with ID {id}.", ex);
            }
        }
    }
}