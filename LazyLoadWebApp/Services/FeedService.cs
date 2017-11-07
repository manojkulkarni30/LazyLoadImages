using LazyLoadWebApp.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
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

        public IEnumerable<FeedContent> ReadFeed()
        {
            try
            {
                var request = WebRequest.Create("https://www.pinterest.com/Signaturethings/brass-hooks.rss");
                request.Timeout = 5000;
                using (var response = request.GetResponse())
                using (var reader = XmlReader.Create(response.GetResponseStream()))
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
