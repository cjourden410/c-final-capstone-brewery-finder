﻿using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    /// <summary>
    /// An interface for user data objects.
    /// </summary>
    public interface IUserDAO
    {
        /// <summary>
        /// Retrieves a user from the system by username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetUser(string username);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user"></param>
        void CreateUser(User user);

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(User user);

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="user"></param>
        void DeleteUser(User user);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        IList<User> GetUsers();

        /// <summary>
        /// Retrieves a user from the system by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserById(int id);

        /// <summary>
        /// Gets all users with the role of brewer.
        /// </summary>
        /// <returns></returns>
        IList<User> GetUserBrewers(string role);
    }
}
