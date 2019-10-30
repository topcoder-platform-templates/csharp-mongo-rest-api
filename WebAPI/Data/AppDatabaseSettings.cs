/*
 * Copyright (c) 2019, TopCoder, Inc. All rights reserved.
 */

namespace WebAPI.Data
{
    /// <summary>
    /// The Mongo DB settings.
    /// </summary>
    public class AppDatabaseSettings : IAppDatabaseSettings
    {
        /// <summary>
        /// Gets or sets the name of the users collection.
        /// </summary>
        /// <value>
        /// The name of the users collection.
        /// </value>
        public string UsersCollectionName { get; set; }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        /// <value>
        /// The name of the database.
        /// </value>
        public string DatabaseName { get; set; }
    }
}
