using System.Text.Json;

namespace ProductObjects;

public class Products : List<Product>
{
    private readonly HttpClient _httpClient;

    public Products()
    {
        _httpClient = new HttpClient();
    }

    public async Task GetProductsFromApi(string apiUrl)
    {
        try
        {
            // Set Authorization header
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Basic dXNlcm5hbWU6cGFzc3dvcmQ=");

            // Send GET request to API
            var response = await _httpClient.GetStringAsync(apiUrl);

            // Deserialize response to List<Product>
            var productsFromApi = JsonSerializer.Deserialize<List<Product>>(response);

            // Add the products to the Products list
            foreach (var product in productsFromApi)
            {
                Add(product);
            }
        }
        catch (HttpRequestException e)
        {
            // Handle exception
            Console.WriteLine($"Request error: {e.Message}");
        }
    }
}