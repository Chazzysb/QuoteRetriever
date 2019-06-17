using System;
using models = QuoteRetriever.Models;

namespace QuoteRetriever
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = new QuoteManager().GetQuotes("MSFT");

            var s = string.Empty;
        }
    }
}
