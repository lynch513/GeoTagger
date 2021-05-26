using GeoTagger.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace GeoTagger.Repositories.Test
{
    public class TagRepositorySimpleTests
    {
        private static AppDbContext CreateDbContext(string? dbName = default)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName ?? Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }

        private static Tag CreateTestItem() =>
            new() { Name = "TestTag" };

        private static TagRepository CreateSut(AppDbContext context) =>
            new(context);

        [SetUp]
        public void Setup()
        {
        }

        // Create
        [Test]
        public void Repository_Can_Add_Item()
        {
            var tag = CreateTestItem();
            using var context = CreateDbContext();
            var sut = CreateSut(context);

            Assert.Zero(context.Tags.Count());

            var result = sut.TryAdd(tag, out var message);

            Assert.True(result);
            Assert.Null(message);
            Assert.AreEqual(context.Tags.Count(), 1);
        }

        // Read
        [Test]
        public void Repository_Can_Get_Item()
        {
            var tag = CreateTestItem();
            using var context = CreateDbContext();
            var sut = CreateSut(context);

            sut.TryAdd(tag, out var _);
            var tagFromDb = sut.Get(tag.Id);

            Assert.NotNull(tagFromDb);
            Assert.AreEqual(tag.Name, tagFromDb?.Name);
        }

        [Test]
        public void Repository_Cant_Get_Non_Existent_Item()
        {
            var tag = CreateTestItem();
            using var context = CreateDbContext();
            var sut = CreateSut(context);

            var tagFromDb = sut.Get(tag.Id);
            Assert.Null(tagFromDb);
        }

        [Test]
        public void Repository_Can_Get_All_Items()
        {
            var tag = CreateTestItem();
            using var context = CreateDbContext();
            var sut = CreateSut(context);

            sut.TryAdd(tag, out var _);

            var tags = sut.GetAll();
            Assert.AreEqual(1, tags.Count());
            Assert.AreEqual(new Tag[] { tag }, tags);
        }

        [Test]
        public void Repository_Can_Get_Empty_Collection_Of_Items()
        {
            using var context = CreateDbContext();
            var sut = CreateSut(context);

            var tags = sut.GetAll();
            Assert.Zero(tags.Count());
        }

        [Test]
        public void Repository_Can_Search_Item_By_Name()
        {
            var tag = CreateTestItem();
            using var context = CreateDbContext();
            var sut = CreateSut(context);

            sut.TryAdd(tag, out var _);

            var tagFromDb = sut.GetByName(tag.Name);

            Assert.NotNull(tagFromDb);
            Assert.AreEqual(tag.Name, tagFromDb.Name);
        }

        [Test]
        public void Repository_Cant_Search_Non_Existen_Item_By_Name()
        {
            var tag = CreateTestItem();
            using var context = CreateDbContext();
            var sut = CreateSut(context);

            var tagFromDb = sut.GetByName(tag.Name);

            Assert.Null(tagFromDb);
        }

        // Update
        [Test]
        public void Repository_Can_Update_Item()
        {
            var tag = CreateTestItem();
            using var context = CreateDbContext();
            var sut = CreateSut(context);

            sut.TryAdd(tag, out var _);

            tag = sut.Get(tag.Id);

            Assert.NotNull(tag);
            Assert.AreEqual("TestTag", tag?.Name);

            tag!.Name = "NewTestTag";
            var result = sut.TryUpdate(tag, out var message);

            var tagFromDb = sut.Get(tag.Id);

            Assert.NotNull(tagFromDb);

            Assert.True(result);
            Assert.Null(message);
            Assert.AreEqual("NewTestTag", tagFromDb?.Name);
        }

        // Remove
        [Test]
        public void Repository_Can_Remove_Item()
        {
            var tag = CreateTestItem();
            using var context = CreateDbContext();
            var sut = CreateSut(context);

            var result = sut.TryAdd(tag, out var _);
            Assert.True(result);

            result = sut.TryRemove(tag, out var message);
            Assert.True(result);
            Assert.Null(message);

            var tags = sut.GetAll();
            Assert.Zero(tags.Count());
        }
    }
}