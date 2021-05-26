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

        public Tag? GetByName(string name) =>
            context.Tags.Where(i => i.Name == name).FirstOrDefault();

        public IEnumerable<Tag> GetAll() =>
            context.Tags;

        // Update
        public bool TryUpdate(Tag item, out string? message)
        {
            try
            {
                //var local = context
                //    .Tags
                //    .Local
                //    .FirstOrDefault(e => e.Id == item.Id);

                //if (local != null)
                //{
                //    context.Entry(local).State = EntityState.Detached;
                //}

                //context.Entry(item).State = EntityState.Modified;
                context.Tags.Update(item);

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

        // Delete
        public bool TryRemove(Tag item, out string? message)
        {
            try
            {
                context.Remove(item);
                context.SaveChanges();

                message = default;
                return true;
            }
            catch (InvalidOperationException ex)
            {
                message = ex.Message;
                return false;
            }
            catch (DbUpdateException ex)
            {
                message = ex.Message;
                return false;
            }
        }
    }
}
