﻿using Hangfire.SqlServer;
using Hangfire.Tags.Storage;

namespace Hangfire.Tags.SqlServer
{
    /// <summary>
    /// Provides extension methods to setup Hangfire.Tags
    /// </summary>
    public static class GlobalConfigurationExtensions
    {
        /// <summary>
        /// Configures Hangfire to use Tags.
        /// </summary>
        /// <param name="configuration">Global configuration</param>
        /// <param name="options">Options for tags</param>
        /// <param name="sqlOptions">Options for sql storage</param>
        /// <returns></returns>
        public static IGlobalConfiguration UseTagsWithSql(this IGlobalConfiguration configuration, TagsOptions options = null, SqlServerStorageOptions sqlOptions = null)
        {
            options = options ?? new TagsOptions();
            sqlOptions = sqlOptions ?? new SqlServerStorageOptions();

            options.Storage = new SqlTagsServiceStorage(sqlOptions);

            TagsServiceStorage.Current = options.Storage;

            var config = configuration.UseTags(options);
            return config;
        }
    }
}
