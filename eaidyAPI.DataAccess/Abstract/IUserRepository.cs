using System;
using eaidyAPI.Entities;
using eaidyAPI.Entities.Models;

namespace eaidyAPI.DataAccess.Abstract
{
    public interface IUserRepository
    {
        // CRUD Methods
        Task<User> GetUserById(int id);

        Task<User> GetUserByFirstname(string name);

        Task<User> CreateUser(User User);

        Task<User> UpdateUser(User User);

        Task DeleteUser(int id);

        // Auxillary Methods
        Task<User> LoginHandler(string username, string password);

        Task<CCFeedback> CheckCredentials(User user);
    }
}

