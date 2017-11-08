using LazyLoadWebApp.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace LazyLoadWebApp.Services
{
    public class FeedService : IFeedService
    {
        private readonly ILogger<FeedService> _logger;

        public FeedService(ILogger<FeedService> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<FeedContent>> ReadFeedAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                using (var response = await httpClient.GetStreamAsync("https://www.pinterest.com/Signaturethings/brass-hooks.rss"))
                using (var reader = XmlReader.Create(response))
                {
                    return RssFeed.Load(reader);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }
    }
}
