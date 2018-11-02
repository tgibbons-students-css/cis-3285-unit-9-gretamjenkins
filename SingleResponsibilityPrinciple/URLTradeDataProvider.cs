using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    class URLTradeDataProvider : ITradeDataProvider
    {
        public URLTradeDataProvider(string URL)
        {
            this.URL = URL;
        }

        // Gets the trade data from an online file using a string URL
        public IEnumerable<string> GetTradeData()
        {
            var tradeData = new List<string>();
            // create new web client and use it to read the file stored at the given URL
            var client = new WebClient();
            using (var stream = client.OpenRead(URL))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }

        // URL to be used for data provision
        private readonly string URL;
    }

}
