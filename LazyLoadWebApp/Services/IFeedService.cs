using LazyLoadWebApp.Models;
using System.Collections.Generic;

namespace LazyLoadWebApp.Services
{
    public interface IFeedService
    {
        IEnumerable<FeedContent> ReadFeed();
    }
}
