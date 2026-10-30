// Use asynchronous loading to improve performance when converting multiple websites concurrently.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] urls = new string[]
                {
                    "https://example.com",
                    "https://example.org"
                };

                List<Task> tasks = new List<Task>();

                foreach (string url in urls)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        string outputPath = Path.Combine(Path.GetTempPath(), "output_" + Guid.NewGuid().ToString("N") + ".pdf");
                        PdfSaveOptions options = new PdfSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertHTML(url, options, outputPath);
                        Console.WriteLine($"Converted {url} to {outputPath}");
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}