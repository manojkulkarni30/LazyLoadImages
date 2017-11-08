using LazyLoadWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LazyLoadWebApp.Services
{
    public interface IFeedService
    {
        Task<IEnumerable<FeedContent>> ReadFeedAsync();
    }
}
