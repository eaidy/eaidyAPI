using System;
using eaidyAPI.DataAccess;
using eaidyAPI.DataAccess.Abstract;
using eaidyAPI.Entities;
using Microsoft.EntityFrameworkCore;
using eaidyAPI.Entities.Models;

namespace HotelFinder.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> CreateUser(User user)
        {
            using (var rnTrainingDbContext = new RNTrainingDbcontext())
            {
                await rnTrainingDbContext.Users.AddAsync(user);
                await rnTrainingDbContext.SaveChangesAsync();
                return user;
            }
        }

        public async Task DeleteUser(int id)
        {
            using (var rnTrainingDbContext = new RNTrainingDbcontext())
            {
                var deletedUser = await GetUserById(id);
                rnTrainingDbContext.Users.Remove(deletedUser);
                await rnTrainingDbContext.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserById(int id)
        {
            using (var rnTrainingDbContext = new RNTrainingDbcontext())
            {
                return await rnTrainingDbContext.Users.FindAsync(id);
            }
        }

        public async Task<User> GetUserByFirstname(string firstname)
        {
            using (var rnTrainingDbContext = new RNTrainingDbcontext())
            {
                return await rnTrainingDbContext.Users.FirstOrDefaultAsync(User => User.Firstname.ToLower() == firstname.ToLower());
            }
        }

        public async Task<User> UpdateUser(User User)
        {
            using (var rnTrainingDbContext = new RNTrainingDbcontext())
            {
                rnTrainingDbContext.Users.Update(User);
                await rnTrainingDbContext.SaveChangesAsync();
                return User;
            }
        }

        public async Task<User> LoginHandler(string username, string password)
        {
            using (var rnTrainingDbContext = new RNTrainingDbcontext())
            {
                return await rnTrainingDbContext.Users.FirstOrDefaultAsync(c => c.Username == username && c.Password == password);

            }
        }

        public async Task<CCFeedback> CheckCredentials(User user)
        {
            using (var rnTrainingDbContext = new RNTrainingDbcontext())
            {
                CCFeedback feedback;

                var entityUsernameCheck = await rnTrainingDbContext.Users
                    .FirstOrDefaultAsync(entity => entity.Username == user.Username);
                var entityPhoneCheck = await rnTrainingDbContext.Users
                    .FirstOrDefaultAsync(entity => entity.Phone == user.Phone);

                if((entityUsernameCheck != null) && (entityPhoneCheck != null))
                {
                    feedback = new CCFeedback {
                        property = "UP",
                        isValid = false
                    };
                    return feedback;
                } else if ((entityUsernameCheck != null))
                {
                    feedback = new CCFeedback {
                        property = "UO",
                        isValid = false
                    };
                    return feedback;
                } else if ((entityPhoneCheck != null))
                {
                    feedback = new CCFeedback {
                        property = "PO",
                        isValid = false
                    };
                    return feedback;
                } else
                {
                    feedback = new CCFeedback {
                        property = null,
                        isValid = true
                    };
                    return feedback;
                }
            }
        }
    }
}

