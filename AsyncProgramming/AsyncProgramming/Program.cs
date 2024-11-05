using AsyncProgramming.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AsyncProgramming;

internal class Program
{
    static void Main(string[] args)
    {
        #region Task-1
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

        #endregion

        #region Task-2
        DirectoryInfo pwd = new("../../../");
        string url = "https://jsonplaceholder.typicode.com/posts";

        Directory.CreateDirectory(pwd.FullName + "Models");
        Directory.CreateDirectory(pwd.FullName + "Data");

        string pathJSONData = pwd.FullName + @"Data\jsonData.json";

        if (!File.Exists(pathJSONData)) using (File.Create(pathJSONData)) { }

        string response = GetJSONData(url).Result;
        List<Post>? posts = JsonConvert.DeserializeObject<List<Post>>(response);

        if (posts == null)
        {
            Console.WriteLine("No data received!");
            return;
        }
        Console.WriteLine("Data were successfully received.");

        string rawPosts = JsonConvert.SerializeObject(posts);
        using (StreamWriter writer = new(pathJSONData))
        {
            writer.WriteLine(rawPosts);
        }
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

    static async Task<string> GetJSONData(string url)
    {
        HttpClient client = new();
        return await client.GetStringAsync(url);
    }
}
