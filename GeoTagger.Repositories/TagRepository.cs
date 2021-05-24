using GeoTagger.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTagger.Repositories
{
    public class TagRepository
    {
        protected readonly AppDbContext context;

        public TagRepository(AppDbContext context)
        {
            this.context = context;
        }

        // Create
        public bool TryAdd(Tag item, out string? message)
        {
            try
            {
                context.Add(item);
                context.SaveChanges();
                message = default;
                return true;
            }
            catch (DbUpdateException ex)
            {
                message = ex.Message;
                return false;
            }
        }

        // Read
        public Tag? Get(Guid id) =>
            context.Find<Tag>(id);

        public Tag? GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetAll() =>
            context.Tags;

        // Update
        public bool TryUpdate(Tag item, out string? message)
        {
            throw new NotImplementedException();
        }

        // Delete
        public bool TryRemove(Guid id, out string? message)
        {
            throw new NotImplementedException();
        }
    }
}
