using System.IO;
using Microsoft.Extensions.Configuration;
using RestSharp;
using Jsn = Newtonsoft.Json;
using models = QuoteRetriever.Models;

namespace QuoteRetriever
{
    public class QuoteManager
    {
        private IConfigurationRoot _config = null;

        private IConfigurationRoot config
        {
            get
            {
                if (_config == null)
                {
                    _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                }

                return _config;
            }
        }

        private IRestClient _restClient = null;
        private IRestClient restClient
        {
            get
            {
                if (_restClient == null)
                    _restClient = new RestClient(config["baseURL"]);
                return _restClient;
            }
        }

        public models.Stock GetQuotes(string symbol)
        {
            var request = new RestRequest($"?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval=60min&apikey={config["apiKEY"]}", Method.GET);
            var response = restClient.Execute(request);
            return Jsn.JsonConvert.DeserializeObject<models.Stock>(response.Content);
        }
    }
}
