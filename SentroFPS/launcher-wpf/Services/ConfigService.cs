using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SentroFPS.Launcher.Models;


namespace SentroFPS.Launcher.Services;


public class ConfigService
{
private static readonly HttpClient _http = new();


public async Task<RemoteConfig> FetchAsync(string url)
{
var json = await _http.GetStringAsync(url);
var cfg = JsonSerializer.Deserialize<RemoteConfig>(json, new JsonSerializerOptions
{
PropertyNameCaseInsensitive = true
})!;
return cfg;
}
}