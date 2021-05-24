using GeoTagger.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeoTagger.Repositories.Test
{
    public class TagRepositoryTests
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

        [SetUp]
        public void Setup()
        {
        }

        // Create
        [Test]
        public void Repository_Can_Add_Item()
        {
            var tag = new Tag() { Name = "TestTag" };

            using var context = CreateDbContext();
            var sut = new TagRepository(context);

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
            var tag = new Tag() { Name = "TestTag" };

            using var context = CreateDbContext();
            var sut = new TagRepository(context);

            sut.TryAdd(tag, out var _);
            var tagFromDb = sut.Get(tag.Id);

            Assert.NotNull(tagFromDb);
            Assert.AreEqual(tag.Name, tagFromDb?.Name);
        }

        [Test]
        public void Repository_Cant_Get_Nonexistent_Item()
        {
            var tag = new Tag() { Name = "TestTag" };

            using var context = CreateDbContext();
            var sut = new TagRepository(context);

            var tagFromDb = sut.Get(tag.Id);
            Assert.Null(tagFromDb);
        }

        [Test]
        public void Repository_Can_Get_All_Items()
        {
            var tag = new Tag() { Name = "TestTag" };

            using var context = CreateDbContext();
            var sut = new TagRepository(context);

            sut.TryAdd(tag, out var _);

            var tags = sut.GetAll();
            Assert.AreEqual(1, tags.Count());
            Assert.AreEqual(new Tag[] { tag }, tags);
        }

        [Test]
        public void Repository_Can_Get_Empty_Collection_Of_Items()
        {
            var tag = new Tag() { Name = "TestTag" };

            using var context = CreateDbContext();
            var sut = new TagRepository(context);

            var tags = sut.GetAll();
            Assert.Zero(tags.Count());
        }


    }
}