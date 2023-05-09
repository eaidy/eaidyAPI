using System;
using eaidyAPI.Entities;
using eaidyAPI.Entities.Models;

namespace eaidyAPI.Business.Abstract
{
	public interface IUserService
	{
        Task<User> GetUserById(int id);

        Task<User> GetUserByFirstname(string name);

        Task<CUFeedback> CreateUser(User User);

        Task<User> UpdateUser(User User);

        Task<User> LoginHandler(string username, string password);

        Task DeleteUser(int id);
	}
}

