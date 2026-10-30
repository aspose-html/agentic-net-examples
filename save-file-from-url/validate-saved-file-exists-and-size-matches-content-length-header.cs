// Validate that the saved file exists and its size matches the Content-Length header.

using System;
using System.IO;
using System.Net.Http;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://www.w3.org/TR/PNG/iso_8859-1.txt";
            string outputPath = "downloaded.txt";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).Result;
                response.EnsureSuccessStatusCode();

                long? contentLength = response.Content.Headers.ContentLength;

                using (Stream contentStream = response.Content.ReadAsStreamAsync().Result)
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    contentStream.CopyTo(fileStream);
                }

                if (!File.Exists(outputPath))
                {
                    throw new FileNotFoundException("The file was not saved.", outputPath);
                }

                long fileSize = new FileInfo(outputPath).Length;

                if (contentLength.HasValue && fileSize != contentLength.Value)
                {
                    throw new InvalidOperationException($"File size mismatch. Expected: {contentLength.Value} bytes, Actual: {fileSize} bytes.");
                }

                Console.WriteLine("File saved and size verification passed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}