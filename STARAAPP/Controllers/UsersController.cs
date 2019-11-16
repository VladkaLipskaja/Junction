//-----------------------------------------------------------------------
// <copyright file="UsersController.cs" company="Space Rabbits">
//     Copyright (c) Space Rabbits. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STARAAPP.Models;
using STARAAPP.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace STARAAPP
{
    /// <summary>
    /// The users controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// The user service
        /// </summary>
        private IUserService _userService;

        /// <summary>
        /// The security service
        /// </summary>
        private ISecurityService _securityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController" /> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="securityService">The security service.</param>
        public UsersController(IUserService userService, ISecurityService securityService)
        {
            _userService = userService;
            _securityService = securityService;
        }

        // POST api/users/registration

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The method is void.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The request is null.
        /// </exception>
        [HttpPost("registration")]
        public async Task<JsonResult> RegisterUser([FromBody]RegisterUserRequest request)
        {
            Console.WriteLine($"POST: api/users/registration, login: {request.Login}, password: {request.Password}");

            if (request == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                UserDto user = new UserDto
                {
                    Latitude = request.Latitude,
                    Login = request.Login,
                    Longitude = request.Longitude,
                    RoleID = request.RoleID,
                    MobilePhone = request.MobilePhone,
                    Password = request.Password
                };

                await _userService.RegisterUserAsync(user);

                string token = await _userService.AuthenticateUserAsync(request.Login, request.Password);

                RegisterUserResponse response = new RegisterUserResponse
                {
                    Token = token,
                };

                return this.JsonApi(response);
            }
            catch (UserException exception)
            {
                return this.JsonApi(exception);
            }
        }

        // POST api/users/authentication

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// The token.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The request is null.
        /// </exception>
        [HttpPost("authentication")]
        public async Task<JsonResult> AuthenticateUserAsync([FromBody]AuthenticateUserRequest request)
        {
            Console.WriteLine($"POST: api/users/authentication, login: {request.Login}, password: {request.Password}");

            if (request == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                string token = await _userService.AuthenticateUserAsync(request.Login, request.Password);

                AuthenticateUserResponse response = new AuthenticateUserResponse
                {
                    Token = token,
                };

                return this.JsonApi(response);
            }
            catch (UserException exception)
            {
                return this.JsonApi(exception);
            }
        }
    }
}