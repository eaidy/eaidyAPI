using System;
using eaidyAPI.Business.Abstract;
using eaidyAPI.DataAccess.Abstract;
using eaidyAPI.Entities;
using eaidyAPI.Entities.Models;

namespace eaidyAPI.Business.Concrete
{
	public class UserManager : IUserService
	{
        private IUserRepository _UserRepository;

        public UserManager(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<CUFeedback> CreateUser(User user)
        {
            CUFeedback createUserFeedback = new CUFeedback();

            createUserFeedback.feedback = await _UserRepository.CheckCredentials(user);

            if (createUserFeedback.feedback.isValid)
            {
                createUserFeedback.user = await _UserRepository.CreateUser(user);
                return createUserFeedback;
            } else
            {
                createUserFeedback.user = null;
                return createUserFeedback;
            }
        }

        public async Task DeleteUser(int id)
        {
            await _UserRepository.DeleteUser(id);
        }

        public async Task<User> GetUserByFirstname(string firstname)
        {
            return await _UserRepository.GetUserByFirstname(firstname);
        }

        public async Task<User> GetUserById(int id)
        {
            if (1 <= id)
            {
                return await _UserRepository.GetUserById(id);
            }
            throw new Exception("Id must be greater than 1");
        }

        public async Task<User> LoginHandler(string username, string password)
        {
            User User = await _UserRepository.LoginHandler(username, password);
            return User;
        }

        public async Task<User> UpdateUser(User user)
        {
            if (await _UserRepository.GetUserById(user.id) != null)
            {
                return await _UserRepository.UpdateUser(user);
            }
            throw new Exception("No such User to update!");
        }
    }
}

