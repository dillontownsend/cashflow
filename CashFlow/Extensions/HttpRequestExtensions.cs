namespace CashFlow.Extensions;

public static class HttpRequestExtensions
{
    public static string GetBaseUrl(this HttpRequest httpRequest)
    {
        return $"{httpRequest.Scheme}://{httpRequest.Host}";
    }
}