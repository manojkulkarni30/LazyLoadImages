using LazyLoadWebApp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;

namespace LazyLoadWebApp.Services
{
    public class FeedService : IFeedService
    {
        public IEnumerable<FeedContent> ReadFeed()
        {
            try
            {
                //specify timeout (5 secs)
                var request = WebRequest.Create("https://www.pinterest.com/Signaturethings/brass-hooks.rss");
                request.Timeout = 5000;
                using (var response = request.GetResponse())
                using (var reader = XmlReader.Create(response.GetResponseStream()))
                {
                    return RssFeed.Load(reader);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
