using GeoTagger.Models;
using System;
using System.Collections.Generic;

namespace GeoTagger.Repositories
{
    public interface ITagRepository
    {
        Tag? Get(Guid id);
        IEnumerable<Tag> GetAll();
        Tag? GetByName(string name);
        bool TryAdd(Tag item, out string? message);
        bool TryRemove(Tag item, out string? message);
        bool TryUpdate(Tag item, out string? message);
    }
}