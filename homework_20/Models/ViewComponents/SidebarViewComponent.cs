using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace homework_20.Models.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;

        public SidebarViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {          
            string url = "https://news.yandex.ru/index.rss";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            List<RSSField> rss = new List<RSSField>();
            int newscount = 5;
            feed.Items = feed.Items.Take(newscount);
            foreach (SyndicationItem album in feed.Items)
            {
                rss.Add(new RSSField() { tittle = album.Title.Text, url = album.Id });

            }

            return Task.FromResult((IViewComponentResult)View("Default", rss));
        }

    }
    public class RSSField
    {
        public string url { get; set; }

        public string tittle { get; set; }

    }
}
