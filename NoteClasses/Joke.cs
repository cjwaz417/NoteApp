using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Drawing;

namespace NoteClasses
{
    public class Joke
    {
        private readonly HttpClient _httpClient;

        public Joke()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
            

            
           
            
            
        }

        

    }
}
