// Implement asynchronous download of resources using async/await for each page.

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        try
        {
            string[] urls = new string[] { "https://example.com", "https://example.org" };
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                var downloadTasks = new System.Collections.Generic.List<System.Threading.Tasks.Task<string>>();
                foreach (string url in urls)
                {
                    downloadTasks.Add(DownloadPageAsync(httpClient, url));
                }

                string[] results = await System.Threading.Tasks.Task.WhenAll(downloadTasks);
                for (int i = 0; i < results.Length; i++)
                {
                    System.Console.WriteLine($"--- Content from {urls[i]} ---");
                    System.Console.WriteLine(results[i]);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async System.Threading.Tasks.Task<string> DownloadPageAsync(System.Net.Http.HttpClient client, string url)
    {
        System.Net.Http.HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string content = await response.Content.ReadAsStringAsync();

        // Optional: parse the HTML with Aspose.Html if needed
        using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
        {
            // No direct method to load raw HTML string into the document in this example.
            // The content is returned as-is.
        }

        return content;
    }
}