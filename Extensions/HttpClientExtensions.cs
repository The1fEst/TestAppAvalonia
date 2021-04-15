using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestApp.Extensions {
  public enum HttpMethods {
    Get,
    Post,
    Put,
    Delete,
  }

  public static class HttpClientExtensions {
    private static readonly JsonSerializerOptions DeserializationOptions = new() {
      PropertyNameCaseInsensitive = true,
    };

    // static HttpClientExtensions() {
    //   DeserializationOptions.Converters.Add(new DateFormatConverter());
    //   DeserializationOptions.Converters.Add(new NullableDateFormatConverter());
    //   DeserializationOptions.Converters.Add(new NormalizeFormatConverter());
    //   DeserializationOptions.Converters.Add(new NullableNormalizeFormatConverter());
    // }

    private static async Task<T> RunRequest<T>(Task<HttpResponseMessage> requestTask) where T : notnull {
      string json = await RunRequestAsString(requestTask);
      return JsonSerializer.Deserialize<T>(json, DeserializationOptions)!;
    }

    private static async Task<string> RunRequestAsString(Task<HttpResponseMessage> requestTask) {
      using var response = await requestTask;
      response.EnsureSuccessStatusCode();
      return await response.Content.ReadAsStringAsync();
    }

    private static Task<HttpResponseMessage> GetRequestTask(HttpClient client, string url, HttpMethods method,
                                                            object? body, params (string, string)[] headers) {
      try {
        foreach (var (name, value) in headers) {
          client.DefaultRequestHeaders.Add(name, value);
        }

        return method switch {
          HttpMethods.Get => client.GetAsync(url),
          HttpMethods.Post => client.PostAsync(url, CreateJsonBody(body)),
          HttpMethods.Put => client.PutAsync(url, CreateJsonBody(body)),
          HttpMethods.Delete => client.DeleteAsync(url),
          _ => throw new ArgumentOutOfRangeException(nameof(method), method, null),
        };
      } finally {
        client.DefaultRequestHeaders.Clear();
      }
    }

    private static JsonContent CreateJsonBody(object? body) {
      if (body == null) {
        throw new ArgumentNullException(nameof(body));
      }

      return JsonContent.Create(body);
    }

    public static Task<T> AsJson<T>(this HttpClient client, string url,
                                    HttpMethods method, object? body = null,
                                    params (string, string)[] headers)
      where T : notnull {
      return RunRequest<T>(GetRequestTask(client, url, method, body, headers));
    }

    public static Task<string> AsString(this HttpClient client, string url,
                                        HttpMethods method, object? body = null,
                                        params (string, string)[] headers) {
      return RunRequestAsString(GetRequestTask(client, url, method, body, headers));
    }
  }
}
