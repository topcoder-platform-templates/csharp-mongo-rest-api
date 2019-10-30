/*
 * Copyright (c) 2019, TopCoder, Inc. All rights reserved.
 */
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using WebAPI.Data.Entities;

namespace WebAPI.Data.Repositories.Impl
{
    /// <summary>
    /// The user repository.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The users collection.
        /// </summary>
        private readonly IMongoCollection<User> _users;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository" /> class.
        /// </summary>
        /// <param name="settings">The DB settings.</param>
        public UserRepository(IAppDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        /// <summary>
        /// Gets the User by handle.
        /// </summary>
        /// <param name="handle">The user handle.</param>
        /// <returns>Found user or null.</returns>
        public User GetByHandle(string handle)
        {
            var user = _users.Find(x => x.Handle == handle).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Gets the User by Id.
        /// </summary>
        /// <param name="id">The user Id.</param>
        /// <returns>Found user or null.</returns>
        public User GetById(int id)
        {
            var user = _users.Find(x => x.Id == id).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>All users.</returns>
        public IList<User> GetAll()
        {
            return _users.Find(x => true).ToList();
        }

        /// <summary>
        /// Creates the given user.
        /// </summary>
        /// <param name="entity">The user entity.</param>
        /// <returns>Created user entity.</returns>
        public User Create(User entity)
        {
            var allUsers = GetAll();
            entity.Id = allUsers.Count == 0 ? 1 : GetAll().Max(x => x.Id) + 1;
            _users.InsertOne(entity);
            return entity;
        }

        /// <summary>
        /// Updates given user.
        /// </summary>
        /// <param name="entity">The user entity.</param>
        public void Update(User entity)
        {
            _users.ReplaceOne(book => book.Id == entity.Id, entity);
        }

        /// <summary>
        /// Deletes user with given Id.
        /// </summary>
        /// <param name="id">The user Id.</param>
        public void Delete(int id)
        {
            _users.DeleteOne(book => book.Id == id);
        }
    }
}
