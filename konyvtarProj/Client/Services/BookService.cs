using konyvtarProj.Shared.Models;
using System.Text;
using System.Text.Json;

namespace konyvtarProj.Client.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Books?> AddBook(Books book)
        {
            try 
            {
                var itemJson = new StringContent(JsonSerializer.Serialize(book), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/Books", itemJson);
                if(response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();
                    var newbook =  await JsonSerializer.DeserializeAsync<Books>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
                    return newbook;
                }
                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:  {ex.Message}");
                throw ex;
            }
        }

        public async Task<IEnumerable<Books>?> All()
        {
            try 
            {
                var apiResponse = await _httpClient.GetStreamAsync("api/Books");
                var book = await JsonSerializer
                    .DeserializeAsync<IEnumerable<Books>>(apiResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
                return book;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:  {ex.Message}");
                throw ex;
            }
        }

        public async Task<bool> DeleteBook(int LibNumber)
        {
            try 
            {
                var resp = await _httpClient.DeleteAsync($"api/Books/{LibNumber}");
                return resp.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:  {ex.Message}");
                throw ex;
            }
        }

        public async Task<Books?> GetBook(int LibNumber)
        {
            try 
            {
                var apiresp = await _httpClient.GetStreamAsync($"api/Books/{LibNumber}");
                var book = await JsonSerializer.DeserializeAsync<Books>(apiresp, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return book;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:  {ex.Message}");
                throw ex;
            }
        }

        public async Task<bool> UpdateBook(Books book)
        {
            try 
            {
                var itemJson = new StringContent(JsonSerializer.Serialize(book), Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"api/Books/{book.LibNumber}", itemJson);
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:  {ex.Message}");
                throw ex;
            }
        }
    }
}
