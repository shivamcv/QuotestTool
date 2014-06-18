using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
namespace Sample
{
  public  class Parser
    {

      public Parser()
      {

      }

      public string parse()
      {
          WebClient client = new WebClient();
         var url = new Uri("https://www.google.com/finance?q=NSE%3ARELCAPITAL&ei=aFOhU-G_CsmekAWCkYCgDg");
          string html = client.DownloadString(url);

          HtmlDocument doc = new HtmlDocument();
          //doc.Load(url.AbsolutePath);
          doc.LoadHtml(html);
          var temp = doc.GetElementbyId("price-panel");
        var t=   temp.ChildNodes[1].ChildNodes[1].ChildNodes[1];

        return t.InnerHtml;
          
      }


    }
}
