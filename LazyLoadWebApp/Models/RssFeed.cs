using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace LazyLoadWebApp.Models
{
    public static class RssFeed
    {
        public static List<FeedContent> Load(XmlReader reader)
        {
            try
            {
                var document = XDocument.Load(reader);

                var channel = document.Root?.Element("channel");

                if (channel == null)
                    return null;

                var items = new List<FeedContent>();
                foreach (var item in channel.Elements("item"))
                {
                    string pictureUrl = string.Empty;
                    var description = item.Element("description")?.Value;
                    if(!string.IsNullOrWhiteSpace(description))
                    {
                        var split = description.Split('\"');
                        if(split?.Any()==true)
                        {
                            pictureUrl = split
                                .FirstOrDefault(c => c.EndsWith(".jpg") 
                                || c.EndsWith(".jpeg") 
                                || c.EndsWith(".png"));
                        }
                    }

                    if (string.IsNullOrWhiteSpace(pictureUrl))
                        continue;

                    items.Add(new FeedContent
                    {
                        Title= item.Element("title")?.Value ?? string.Empty,
                        PictureUrl= pictureUrl,
                        Link= item.Element("link")?.Value ?? string.Empty,
                    });
                }
                return items;

            }
            catch
            {
                return null;
            }
        }
    }
}
