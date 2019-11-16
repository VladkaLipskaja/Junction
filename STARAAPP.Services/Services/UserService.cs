//-----------------------------------------------------------------------
// <copyright file="UserService.cs" company="Space Rabbits">
//     Copyright (c) Space Rabbits. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using STARAAPP.Entities;
using STARAAPP.Models;
using System.Linq;
using System.Threading.Tasks;

namespace STARAAPP.Services
{
    /// <summary>
    /// User service
    /// </summary>
    /// <seealso cref="SkeletonKey.Services.IUserService" />
    public class UserService : IUserService
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IRepository<User> _userRepository;

        /// <summary>
        /// The hashing service
        /// </summary>
        private readonly ISecurityService _securityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService" /> class.
        /// </summary>
        /// <param name="hashingService">The hashing service.</param>
        /// <param name="userRepository">The user repository.</param>
        public UserService(ISecurityService hashingService, IRepository<User> userRepository)
        {
            _userRepository = userRepository;
            _securityService = hashingService;
        }

        /// <summary>
        /// Registers the user asynchronously.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// The method is void.
        /// </returns>
        /// <exception cref="UserException">
        /// Existing login.
        /// </exception>
        public async Task RegisterUserAsync(UserDto user)
        {
            var existingUser = (await _userRepository.GetAsync(u => u.Email == user.Login)).FirstOrDefault();

            if (existingUser != null)
            {
                throw new UserException(UserErrorCode.ExistingLogin);
            }

            string hashedPassword = _securityService.GetHash(user.Password);

            User newUser = new User
            {
                Email = user.Login,
                Password = hashedPassword,
                MobilePhone = user.MobilePhone,
                RoleId = user.RoleID,
                Latitude = user.Latitude,
                Longitude = user.Longitude
            };

            await _userRepository.AddAsync(newUser);
        }

        /// <summary>
        /// Authenticates the user asynchronously.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The token.
        /// </returns>
        /// <exception cref="UserException">
        /// Invalid credentials.
        /// </exception>
        public async Task<UserLoginDto> AuthenticateUserAsync(string username, string password)
        {
            User user = (await _userRepository.GetAsync(u => u.Email == username)).FirstOrDefault();

            if (user == null)
            {
                throw new UserException(UserErrorCode.InvalidLogin);
            }

            string hashedPassword = _securityService.GetHash(password);

            if (user.Password != hashedPassword)
            {
                throw new UserException(UserErrorCode.InvalidPassword);
            }

            string token = _securityService.GetToken(user.ID);

            var info = new UserLoginDto
            {
                Token = token,
                RoleId = user.RoleId
            };

            return info;
        }

        /// <summary>
        /// Gets the user data asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The user data.
        /// </returns>
        /// <exception cref="UserException">
        /// Invalid user id.
        /// </exception>
        public async Task<User> GetUserDataAsync(int id)
        {
            User user = (await _userRepository.GetAsync(u => u.ID == id)).FirstOrDefault();

            if (user == null)
            {
                throw new UserException(UserErrorCode.NoSuchUser);
            }

            return user;
        }
    }
}
