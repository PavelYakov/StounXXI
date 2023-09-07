using StounXXI.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StounXXI.Services
{
    public class HhApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public HhApiService(string apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(apiBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        
        public async Task<List<Candidat>> GetAllCandidatesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("HhApiGetAllCandidates"); 
                var candidatesData = await response.Content.ReadAsAsync<List<Candidat>>(); 
                return candidatesData;
            }
            catch (HttpRequestException ex)
            {
                
                throw ex;
            }
        }
        
        public async Task<string> GetCandidateAsync(int candidateId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"candidates/{candidateId}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                
                throw ex;
            }
        }
             

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
