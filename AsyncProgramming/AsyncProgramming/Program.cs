using System.Diagnostics;

namespace AsyncProgramming;

internal class Program
{
    static void Main(string[] args)
    {
        List<string> urls = [
            "https://bitcoin.org/bitcoin.pdf",
            "https://github.com/bitcoin/bitcoin",
            "https://info.cern.ch/hypertext/WWW/TheProject.html",
            "https://www.bloomberg.com/billionaires/",
            "https://dotnet.microsoft.com/en-us/"
        ];

        Stopwatch sw = new();

        #region Sync Method
        sw.Start();
        SendRequests(urls);
        sw.Stop();
        Console.WriteLine($"Synchronous method took the following milliseconds to run: {sw.ElapsedMilliseconds} ms");
        #endregion

        #region Async Method
        sw.Restart();
        SendRequestsAsync(urls).Wait();
        sw.Stop();
        Console.WriteLine($"Asynchronous method took the following milliseconds to run: {sw.ElapsedMilliseconds} ms");
        #endregion
    }

    static void SendRequests(List<string> urls)
    {
        HttpClient client = new();
        foreach (string url in urls)
        {
            client.GetStringAsync(url).Wait();
        }
    }

    static async Task SendRequestsAsync(List<string> urls)
    {
        HttpClient client = new();
        List<Task<string>> tasks = [];
        foreach (string url in urls)
        {
            tasks.Add(client.GetStringAsync(url));
        }
        await Task.WhenAll(tasks);
    }
}
