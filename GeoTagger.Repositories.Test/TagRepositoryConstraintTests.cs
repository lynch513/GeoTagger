using GeoTagger.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace GeoTagger.Repositories.Test
{
    class TagRepositoryConstraintTests
    {
        private const string InMemoryConnection = "Data Source=:memory:";
        private readonly SqliteConnection connection;
        private readonly AppDbContext context;

        public TagRepositoryConstraintTests()
        {
            connection = new SqliteConnection(InMemoryConnection);
            connection.Open();
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connection: connection)
                .Options;

            context = new AppDbContext(options);
            context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            connection.Close();
        }

        private static Tag CreateTestItem() =>
            new() { Name = "TestTag" };

        private static TagRepository CreateSut(AppDbContext context) =>
            new(context);

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Repository_Cant_Add_Item_With_Existing_Name()
        {
            var tag = CreateTestItem();
            var sut = CreateSut(context);

            sut.TryAdd(tag, out _);

            var newTag = CreateTestItem();
            var result = sut.TryAdd(newTag, out var message);

            Assert.False(result);
            Assert.NotNull(message);
            Assert.IsNotEmpty(message);
        }

    }
}
