﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Shuttle.Recall.Tests;

namespace Shuttle.Recall.EFCore.SqlServer.Storage.Tests;

public class StorageFixture : RecallFixture
{
    [Test]
    public async Task Should_be_able_to_exercise_event_store_async()
    {
        var services = SqlConfiguration.GetServiceCollection();

        var serviceProvider = services.BuildServiceProvider();

        var dbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<StorageDbContext>>();
        var options = serviceProvider.GetRequiredService<IOptions<SqlServerStorageOptions>>().Value;

        await using (var dbContext = await dbContextFactory.CreateDbContextAsync())
        {
#pragma warning disable EF1002
            await dbContext.Database.ExecuteSqlRawAsync($"DELETE FROM [{options.Schema}].[PrimitiveEvent] WHERE Id IN ('{OrderId}', '{OrderProcessId}')");
            await dbContext.Database.ExecuteSqlRawAsync($"DELETE FROM [{options.Schema}].[PrimitiveEventJournal] WHERE Id IN ('{OrderId}', '{OrderProcessId}')");
#pragma warning restore EF1002
        }

        await ExerciseStorageAsync(services);
    }
}