

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using QuienEsQuien.Models;

namespace QuienEsQuien.Services
{
    public class AzureMobileService
    {
        private readonly MobileServiceClient _client;

        public AzureMobileService()
        {
            _client = new MobileServiceClient("https://w-w.azure-mobile.net/",
                "PRDEWjvMXLFUSOFCqRkRWlxDpAXUdP72");
        }

        public async Task<string> IsQuestion(string questionId, int player)
        {
            var request = new Dictionary<string, string>
                {
                    {"QuestionId", questionId},
                    {"SimpsonId", player.ToString()}
                };
            var result = await _client.InvokeApiAsync<Answer>("simpson", System.Net.Http.HttpMethod.Get, request);

            return (result.Result) ? "SI" : "NO";

        }

    }
}
