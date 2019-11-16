//-----------------------------------------------------------------------
// <copyright file="IUserService.cs" company="Space Rabbits">
//     Copyright (c) Space Rabbits. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using STARAAPP.Entities;
using STARAAPP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace STARAAPP.Services
{
    /// <summary>
    /// User interface
    /// </summary>
    public interface IUserService
    {
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
        Task RegisterUserAsync(UserDto user);

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
        Task<UserLoginDto> AuthenticateUserAsync(string username, string password);

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
        Task<User> GetUserDataAsync(int id);

        Task<List<User>> GetWorkersAsync();
    }
}
