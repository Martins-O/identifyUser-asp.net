using IdentityUserCustom.Datas;

namespace IdentityUserCustom.Services
{
    public class VerifyMeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://vapi.verifyme.ng/v1/verifications/identities";

        public VerifyMeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_apiBaseUrl);
        }

        public async Task<bool> VerifyIdentity(string reference)
        {
            // Set your API key in the headers
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer your_api_key");

            // Make the API request and handle the response
            HttpResponseMessage response = await _httpClient.GetAsync($"/vin/{reference}");
            response.EnsureSuccessStatusCode(); // Throw an exception for non-success status codes

            // Assuming the response is a JSON object with a property 'status'
            var result = await response.Content.ReadFromJsonAsync<VerifyMeResponse>();

            // Check the verification result
            return result?.Status == "success";
        }
    }
}
